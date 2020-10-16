using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZShop.Services.Interfaces;

namespace ZShop.Components
{
    public class Comments : ViewComponent
    {
        private IComentService _comentService;
        public Comments(IComentService comentService)
        {

            _comentService = comentService;
        }


        public IViewComponentResult Invoke(int id)
        {
            var comments = _comentService.CommentsByProductId(30);
            return View(comments);
        }
    }
}
