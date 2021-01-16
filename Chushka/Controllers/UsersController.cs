using Chushka.Helpers;
using Chushka.Models;
using Chushka.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chushka.Controllers
{
    public class UsersController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                model.RegisterUser();
                return RedirectToAction("Login");
            }
            
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = model.AuthenticateUser();
                if(user != null)
                {
                    //auth ok, save to session
                    IAuthenticationHelper authHelper = new SessionAuthenticationHelper(HttpContext.Session);
                    authHelper.SaveState(user);
                    return Redirect("/");
                }
                else
                {
                    //add error
                    ModelState.AddModelError(string.Empty, "The username or password provided is incorrect.");
                }

                
            }
            return View(model);
        }
    }
}
