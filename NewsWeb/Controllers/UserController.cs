using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using News.Logic;
using News.Logic.Manager;
using NewsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NewsWeb.Controllers
{
    public class UserController : Controller
    {
        private UserManager manager = new UserManager();
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    manager.Register(model.Username, model.Email, model.Password);
                    return RedirectToAction("Login");
                }
                catch (LogicException ex)
                {
                    ModelState.AddModelError("validation", ex.Message);                  
                }
            }
            return View(model);
        }

        public IActionResult Login(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = manager.GetUser(model.Username, model.Password);
                //check if the user doesn't exist in the database: error message
                if (user == null)
                {
                    ModelState.AddModelError("validation", "Incorrect username/password!");
                }
                else
                {
                    HttpContext.Session.SetString("username", user.Username);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
