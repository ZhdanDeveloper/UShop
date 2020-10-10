using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ShopCartSpace;
using ZShop.Models;
using ZShop.Models.Account;
using ZShop.Models.Pagination;
using ZShop.Persistence;
using ZShop.Services.Interfaces;

namespace ZShop.Controllers
{
    [Route("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IOrderService _orderService;
        private readonly IDetailsService _detailService;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ShopCart _shopCart;

        public AdminController(IProductService productService, IWebHostEnvironment hostEnvironment, ICategoryService categoryService, IDetailsService detailService, IOrderService orderService, ShopCart shopCart)
        {
            _productService = productService;
            webHostEnvironment = hostEnvironment;
            _categoryService = categoryService;
            _detailService = detailService;
            _orderService = orderService;
            _shopCart = shopCart;
        }

  
        [HttpGet("AdminPanel")]

        public IActionResult AdminPanel()
        {
            return View();
        }

   
        [HttpGet("Create")]
        public IActionResult Create()
        {
          
            return View();
        }
   
        [HttpPost("Create")]
        [ValidateAntiForgeryToken] //Prevents cross-site Request Forgery Attacks
        public async Task<IActionResult> Create(ProductViewModel modell)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Id = modell.Id,
                    CategoryId = modell.CategoryId,
                    Description = modell.Description,
                    Name = modell.Name,
                    Price = modell.Price,
                    Brand = modell.Brand,
                    Model = modell.Model
                   


                };
                if (modell.ImageUrl != null && modell.ImageUrl.Length > 0 && modell.ImageUrlShowCase != null && modell.ImageUrlShowCase.Length >0)
                {

                    product.ImageUrl = await UploadFile(@"images/prods", modell.ImageUrl);
                    product.ImageUrlShowCase = await UploadFile(@"images/showcase", modell.ImageUrlShowCase);
                   

                }
                await _productService.CreateAsync(product);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _productService.GetById(id);
            var modell = new ProductViewModel
            {
                Brand = product.Brand,
                Price = product.Price,
                Model = product.Model,
                Id = product.Id,
                CategoryId = product.CategoryId,
                Description = product.Description,
                Name = product.Name
                
               
            };
          

            return View(modell);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel modell)
        {
            if (ModelState.IsValid)
            {
                
                var product = _productService.GetById(modell.Id);
                product.Name = modell.Name;
                product.Price = modell.Price;
                product.Description = modell.Description;
                product.Brand = modell.Brand;
                product.CategoryId = modell.CategoryId;
                product.Model = modell.Model;
               


                if (modell.ImageUrl != null && modell.ImageUrl.Length > 0)
                {

                    DeleteFile(product.ImageUrl);
                    product.ImageUrl = await UploadFile(@"images/prods", modell.ImageUrl);
                  


                }
                if (modell.ImageUrlShowCase != null && modell.ImageUrlShowCase.Length > 0)
                {
                    DeleteFile(product.ImageUrlShowCase);
                    product.ImageUrlShowCase = await UploadFile(@"images/showcase", modell.ImageUrlShowCase);
                }
                await _productService.UpdateAsync(product);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpGet("Detail")]
        public IActionResult AddDeatail(int id) {

            var detail = new DetailViewModel
            {
                ProductId = id
            };
            return View(detail);

        }
        [HttpPost("Detail")]
        public async Task<IActionResult> AddDeatail(DetailViewModel modell)
        {
            var detail = new Detail
            {
                Description = modell.Description,
                Name = modell.Name,
                ProductId = modell.ProductId,

            };

            await _detailService.AddDetail(detail);

            return View();
        }
        [HttpGet("RemoveDetail/{id}")]
        public async Task<IActionResult> RemoveDetail(int id, int ProductId)
        {
            

            await _detailService.RemoveByIdAsync(id);


            return RedirectToAction("ViewProduct", "Home", new {id= ProductId });

        }

        [HttpGet("Orders")]
        public async Task<IActionResult> Orders(int? pageNumber = 1)
        {
           
            var orders = _orderService.GetAll();

            int pageSize = 3;
            return View(await PaginatedList<Order>.CreateAsync(orders.AsNoTracking(), pageNumber ?? 1, pageSize));
          
           
        }
        
        [HttpGet("DeleteOrder")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = _orderService.FindById(id);
             await _orderService.DeleteAsync(order);
            return RedirectToAction("Orders","Admin");
        }
        [HttpGet("Search")]
        public async Task<IActionResult> Search(string SearchString, int? pageNumber, string currentFilter)
        {
 
            var orders = _orderService.GetListByPhone(SearchString);
            if (orders == null)
            {

            }

            if (SearchString != null)
            {
                pageNumber = 1;
            }
            else if (currentFilter == null)
            {
                return RedirectToAction("Orders", "Admin");
            }
            else
            {
                SearchString = currentFilter;
            }
            ViewData["CurrentFilter"] = SearchString;



            int pageSize = 3;
            return View(await PaginatedList<Order>.CreateAsync(orders.AsNoTracking(), pageNumber ?? 1, pageSize));

        }

        [HttpGet("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var prod = _productService.GetById(id);
            _shopCart.DeletItemFromEveryCart(id);
            DeleteFile(prod.ImageUrl);
            DeleteFile(prod.ImageUrlShowCase);
            await _productService.DeleteAsync(prod);
            return RedirectToAction("Index", "Home");
        }

        private async Task<string> UploadFile(string uploadDir, IFormFile ModelFileVarName)
        {


            var fileName = Path.GetFileNameWithoutExtension(ModelFileVarName.FileName);
            var extension = Path.GetExtension(ModelFileVarName.FileName);
            var webRootPath = webHostEnvironment.WebRootPath;
            fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;
            var path = Path.Combine(webRootPath, uploadDir, fileName);

            using (FileStream destination = new FileStream(path, FileMode.Create))
            {
                await ModelFileVarName.CopyToAsync(destination);

            }

            return "/" + uploadDir + "/" + fileName;


        }

        private void DeleteFile(string fullPath)
        {
            if (System.IO.File.Exists("wwwroot" + fullPath))
            {
                System.IO.File.Delete("wwwroot" + fullPath);
                
            }
        }
    }
}  


    

