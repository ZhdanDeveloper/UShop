using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZShop.Services.Interfaces;

namespace ZShop.Components
{
    public class DetailsList : ViewComponent
    {
        private IDetailsService _detailsService;
        public DetailsList(IDetailsService detailsService)
        {

            _detailsService = detailsService;
        }
        public IViewComponentResult Invoke(int id)
        {
            var categories = _detailsService.DetailsByProductId(id);
            return View(categories);
        }
    }
}

