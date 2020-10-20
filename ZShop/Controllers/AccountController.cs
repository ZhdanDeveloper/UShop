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
using Extensions;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;


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

                User user = await _context.Users.FirstOrDefaultAsync(u => u.Name == model.Name);

                if (user == null)
                {

                    ModelState.AddModelError("", "Неправильно введенный логин");
                    return View(model);
                }
                else if (!PasswordManager.VerifyPasswordHash(model.Password, user.Password))
                {

                    ModelState.AddModelError("", "Неправильно введенный пароль");
                    return View(model);
                }
                else if (user != null && PasswordManager.VerifyPasswordHash(model.Password, user.Password))
                {

                    await Authenticate(model.Name); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
               
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

                User user = await _context.Users.FirstOrDefaultAsync(u => u.Name == model.Name);
                
                if (user == null)
                {

                   

                    var passwordHSH = PasswordManager.GeneratePasswordHash(model.Password);
                    // добавляем пользователя в бд
                    await _userService.CreateAsync(new User { Email = model.Email, Password = passwordHSH, Name = model.Name, Role = "User", Phone = model.Phone.StartsWith("+380") ? model.Phone : "+38" + model.Phone });
                    //_context.Users.Add(new User { Email = model.Email, Password = model.Password, Name= model.Name });


                    await Authenticate(model.Name); // аутентификация

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Такой пользователь уже существует");
                    return View(model);
            }
            ModelState.AddModelError("", "Введенные пароли должны быть одинаковыми");
            return View(model);
        }

        private async Task Authenticate(string Name)
        {

            User user = await _context.Users.FirstOrDefaultAsync(u => u.Name == Name);

            var claims = new List<Claim>
            {
               new Claim(ClaimTypes.Email, user.Email),
               new Claim(ClaimTypes.Name, user.Name),
               new Claim(ClaimTypes.Role, user.Role),
               new Claim("Id", user.Id.ToString())
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id),
                  new AuthenticationProperties
                  {
                      ExpiresUtc = DateTime.UtcNow.AddYears(100),
                      IsPersistent = true
                  });
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }


    }
}
