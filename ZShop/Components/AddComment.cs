using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZShop.Services.Interfaces;

namespace ZShop.Components
{

    public class AddComment : ViewComponent
    {

        private IComentService _comentService;
        public AddComment(IComentService comentService)
        {
            _comentService = comentService;
        }


        public IViewComponentResult Invoke(int productId)
        {

            Comment comment = new Comment
            {
                ProductId = productId
            };
            
            return View(comment);
        }
    }
}
