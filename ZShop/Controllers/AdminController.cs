using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ZShop.Controllers
{
    [Route("Admin")]
    public class AdminController : Controller
    {
        [Authorize(Roles = "Admin")]
        [HttpGet("AdminPanel")]

        public IActionResult AdminPanel()
        {
            return View();
        }
    }
}
