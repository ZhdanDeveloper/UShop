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
using Microsoft.EntityFrameworkCore.Infrastructure;
using ZShop.Models.Account;
using ZShop.Persistence;
using ZShop.Services.Interfaces;

namespace ZShop.Controllers
{
    [Route("Admin")]
    public class AdminController : Controller
    {
        private readonly IProductService _productService;  
        private readonly IWebHostEnvironment webHostEnvironment;
        public AdminController(IProductService productService, IWebHostEnvironment hostEnvironment)
        {
            _productService = productService;
            webHostEnvironment = hostEnvironment;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("AdminPanel")]

        public IActionResult AdminPanel()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Create")]
        public IActionResult Create()
        {
          
            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost("Create")]
        [ValidateAntiForgeryToken] //Prevents cross-site Request Forgery Attacks
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    Id = model.Id,
                    CategoryId = model.CategoryId,
                    Description = model.Description,
                    Name = model.Name,
                    Price = model.Price

                };
                if (model.ImageUrl != null && model.ImageUrl.Length > 0 && model.ImageUrlShowCase != null && model.ImageUrlShowCase.Length >0)
                {

                    product.ImageUrl = await UploadFile(@"images/prods", model.ImageUrl);
                    product.ImageUrlShowCase = await UploadFile(@"images/showcase",  model.ImageUrlShowCase);
                   

                }
                await _productService.CreateAsync(product);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        private async Task<string> UploadFile(string uploadDir, IFormFile ModelFileVarName)
        {

            
            var fileName = Path.GetFileNameWithoutExtension(ModelFileVarName.FileName);
            var extension = Path.GetExtension(ModelFileVarName.FileName);
            var webRootPath = webHostEnvironment.WebRootPath;
            fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;
            var path = Path.Combine(webRootPath, uploadDir, fileName);
            await ModelFileVarName.CopyToAsync(new FileStream(path, FileMode.Create));
            return "/" + uploadDir + "/" + fileName;


        }


    }
}  


    

