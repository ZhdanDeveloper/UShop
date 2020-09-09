using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using ZShop.Models.Account;
using ZShop.Persistence;

namespace Managers
{
    public class FileManager
    {
        
        private readonly ZShopContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public FileManager(ZShopContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            webHostEnvironment = hostEnvironment;
        }
        
        public async Task<string> Upload(string uploadDir, ProductViewModel model)
        {
            
            var fileName = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
            var extension = Path.GetExtension(model.ImageUrl.FileName);
            var webRootPath = webHostEnvironment.WebRootPath;
            fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;
            var path = Path.Combine(webRootPath, uploadDir, fileName);
            await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
            return "/" + uploadDir + "/" + fileName;

        }


    }
}
