using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using News.Logic.Manager;
using NewsWeb.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Controllers
{
    public class HomeController : Controller
    {
        private NewsManager manager = new NewsManager();
       public IActionResult Index()
        {
            var latestNews = manager.GetLatestNews();

            return View(latestNews);
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
