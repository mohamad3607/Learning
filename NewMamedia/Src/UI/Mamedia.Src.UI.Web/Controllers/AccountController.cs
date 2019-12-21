using Mamedia.Src.Domain.Application.Services;
using Mamedia.Src.Domain.Core.Entities;
using Mamedia.Src.UI.Web.Models.AccountModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Mamedia.Src.UI.Web.Controllers
{
    public class AccountController : Controller
    {
        IAccountService _Service;
        public AccountController(IAccountService service)
        {
            _Service = service;
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            SignInModel model = new SignInModel();
            return View(model);
        }
        [HttpPost]
        public IActionResult SignIn([Bind] SignInModel model)
        {
            if (!string.IsNullOrEmpty(model.Username) && string.IsNullOrEmpty(model.Password))
            {
                return RedirectToAction("SignIn");
            }
            Admin admin = new Admin()
            {
                Username = model.Username,
                Password = model.Password
            };
            var user = _Service.AdminLogIn(admin);
            if (user != null)
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name,model.Username)
                }, CookieAuthenticationDefaults.AuthenticationScheme
                );
                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return RedirectToAction("PostManagement", "Admin");
            }
            TempData["Result"] = "Invalid Login Credentials";
            return View();

        }
    }
}