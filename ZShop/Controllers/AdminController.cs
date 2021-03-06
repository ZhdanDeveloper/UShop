﻿using System;
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
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IOrderService _orderService;
        private readonly IDetailsService _detailService;
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IComentService _comentService;

        private readonly ShopCart _shopCart;

        public AdminController(IProductService productService, IWebHostEnvironment hostEnvironment, ICategoryService categoryService, IDetailsService detailService, IOrderService orderService, IUserService userService, ShopCart shopCart, IComentService comentService)
        {
            _productService = productService;
            webHostEnvironment = hostEnvironment;
            _categoryService = categoryService;
            _detailService = detailService;
            _orderService = orderService;
            _userService = userService;
            _shopCart = shopCart;
            _comentService = comentService;
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
                if (modell.ImageUrl != null && modell.ImageUrl.Length > 0)
                {

                    product.ImageUrl = await UploadFile(@"images/prods", modell.ImageUrl);
                    product.ImageUrl_1 = product.ImageUrl_1 == null ? null : await UploadFile(@"images/prods_one", modell.ImageUrl_1);
                    product.ImageUrl_2 = product.ImageUrl_2 == null ? null : await UploadFile(@"images/prods_two", modell.ImageUrl_2);
                    product.ImageUrl_3 = product.ImageUrl_3 == null ? null : await UploadFile(@"images/prods_three", modell.ImageUrl_3);



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
            var modell = new EditProductViewModel
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
        public async Task<IActionResult> Edit(EditProductViewModel modell)
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
                if (modell.ImageUrl_1 != null && modell.ImageUrl_1.Length > 0)
                {
                    DeleteFile(product.ImageUrl_1);
                    product.ImageUrl_1 = await UploadFile(@"images/prods_one", modell.ImageUrl_1);
                }
                if (modell.ImageUrl_2 != null && modell.ImageUrl_2.Length > 0)
                {
                    DeleteFile(product.ImageUrl_2);
                    product.ImageUrl_2 = await UploadFile(@"images/prods_two", modell.ImageUrl_2);
                }
                if (modell.ImageUrl_3 != null && modell.ImageUrl_3.Length > 0)
                {
                    DeleteFile(product.ImageUrl_3);
                    product.ImageUrl_3 = await UploadFile(@"images/prods_three", modell.ImageUrl_3);
                }
                await _productService.UpdateAsync(product);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpGet("Detail")]
        public IActionResult AddDeatail(int id)
        {

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

            return RedirectToAction("ViewProduct", "Home", new { id = modell.ProductId });
        }
        [HttpGet("EditDetail")]
        public IActionResult EditDetail(int id)
        {
            var detail = _detailService.DetailById(id);

            return View(detail);

        }
        [HttpGet("AddCategory")]
        public IActionResult AddCategory()
        {

            return View();

        }
        [HttpPost("AddCategory")]
        public async Task<IActionResult> AddCategory(Category category)
        {
            await _categoryService.AddCategoryAsync(category);
            return RedirectToAction("AdminPanel", "Admin");

        }
        [HttpGet("RemoveCategory")]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            try
            {
                await _categoryService.RemoveCategoryByIdAsync(id);
            }
            catch (Exception)
            {

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("AllCategories", "Home");
        }
        [HttpGet("EditCategory")]
        public IActionResult EditCategory(int id)
        {
            var category = _categoryService.GetById(id);
            return View(category);
        }
        [HttpPost("EditCategory")]
        public async Task<IActionResult> EditCategory(Category category)
        {
            var _category = _categoryService.GetById(category.Id);
            _category.Name = category.Name;
            await _categoryService.SaveAsync();
            return RedirectToAction("AllCategories", "Home");
        }
        [HttpPost("EditDetail")]
        public async Task<IActionResult> EditDetail(Detail detail)
        {
            var _detail = _detailService.DetailById(detail.Id);

            _detail.Name = detail.Name;
            _detail.Description = detail.Description;
            await _detailService.UpdateAsync(_detail);

            return RedirectToAction("ViewProduct", "Home", new { id = _detail.ProductId });

        }
        [HttpGet("RemoveDetail/{id}")]
        public async Task<IActionResult> RemoveDetail(int id, int ProductId)
        {


            await _detailService.RemoveByIdAsync(id);


            return RedirectToAction("ViewProduct", "Home", new { id = ProductId });

        }

        [HttpGet("Orders")]
        public async Task<IActionResult> Orders(int? pageNumber = 1)
        {

            var orders = _orderService.GetAll();

            int pageSize = 7;
            return View(await PaginatedList<Order>.CreateAsync(orders.AsNoTracking(), pageNumber ?? 1, pageSize));


        }

        [HttpGet("DeleteOrder")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = _orderService.FindById(id);
            await _orderService.DeleteAsync(order);
            return RedirectToAction("Orders", "Admin");
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
            ViewData["CurrentFilter1"] = SearchString;



            int pageSize = 7;
            return View(await PaginatedList<Order>.CreateAsync(orders.AsNoTracking(), pageNumber ?? 1, pageSize));

        }


        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers(int? pageNumber = 1)
        {

            var users = _userService.GetAll();


            int pageSize = 9;
            return View(await PaginatedList<User>.CreateAsync(users.AsNoTracking(), pageNumber ?? 1, pageSize));

        }
        [Authorize(Roles = "SuperAdmin")]
        [HttpGet("ChangeRole")]
        public async Task<IActionResult> ChangeRole(string role, int id)
        {

            var user = _userService.GetById(id);

            if (user.Role == "Admin")
            {
                user.Role = "User";
                await _userService.SaveAsync();
            }
            else
            {
                user.Role = "Admin";
                await _userService.SaveAsync();
            }
            return RedirectToAction("GetUsers", "Admin");

        }


        [HttpGet("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int id)
        {

            if (User.IsInRole("SuperAdmin") && ((_userService.GetById(id).Role == "User") || (_userService.GetById(id).Role == "Admin")))
            {
                await _userService.Delete(id);
                if (_comentService.CommentsByUserId(id) != null)
                {
                    await _comentService.DeleteAllByUserId(id);
                }
            }
            else if (User.IsInRole("Admin") && _userService.GetById(id).Role == "User")
            {
                await _userService.Delete(id);
                if (_comentService.CommentsByUserId(id) != null)
                {
                    await _comentService.DeleteAllByUserId(id);
                }
            }

            return RedirectToAction("GetUsers", "Admin");


        }

        [HttpGet("UserSearch")]
        public async Task<IActionResult> UserSearch(string SearchString, int? pageNumber, string currentFilter)
        {

            var orders = _userService.GetUsersByName(SearchString);
            if (orders == null)
            {

            }

            if (SearchString != null)
            {
                pageNumber = 1;
            }
            else if (currentFilter == null)
            {
                return RedirectToAction("GetUsers", "Admin");
            }
            else
            {
                SearchString = currentFilter;
            }
            ViewData["CurrentFilter2"] = SearchString;



            int pageSize = 7;
            return View(await PaginatedList<User>.CreateAsync(orders.AsNoTracking(), pageNumber ?? 1, pageSize));

        }

        [HttpGet("DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var prod = _productService.GetById(id);
            if (_comentService.CommentsByProductId(id) != null)
            {
                await _comentService.DeleteAllByProductId(id);
            }
            _shopCart.DeletItemFromEveryCart(id);
            DeleteFile(prod.ImageUrl);
            DeleteFile(prod.ImageUrl_1);
            DeleteFile(prod.ImageUrl_2);
            DeleteFile(prod.ImageUrl_3);

            try
            {
                await _productService.DeleteAsync(prod);
            }
            catch (Exception)
            {

                return PartialView("Error");
            }

            return RedirectToAction("Index", "Home");
        }
        [HttpGet("DeleteComment")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var prodId = _comentService.GetProductIdByCommentId(id);
            await _comentService.DeleteOneByCommentIdAsync(id);
            return RedirectToAction("ViewProduct", "Home", new { id = prodId });
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




