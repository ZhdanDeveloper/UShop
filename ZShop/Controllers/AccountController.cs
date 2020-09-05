using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZShop.Models.Account;
using ZShop.Persistence;
using ZShop.Services.Interfaces;

namespace ZShop.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;
        private ZShopContext _context;
        public AccountController(IUserService userService, ZShopContext context)
        {
            _userService = userService;
            _context = context;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                   
                    await Authenticate(model.Password, model.Email); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "incorrect data");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    await _userService.CreateAsync(new User { Email = model.Email, Password = model.Password, Name = model.Name, Role = "User", Phone = model.Phone });
                    //_context.Users.Add(new User { Email = model.Email, Password = model.Password, Name= model.Name });


                    await Authenticate(model.Password, model.Email); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "incorrect data");
            }
            return View(model);
        }

        private async Task Authenticate(string password, string email)
        {

            User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
            string name = user.Name;
            var claims = new List<Claim>
            {
               new Claim(ClaimTypes.Email, email),
               new Claim(ClaimTypes.Name, name),
               new Claim(ClaimTypes.Role, user.Role),
               new Claim("Id", user.Id.ToString())
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }


    }
}
