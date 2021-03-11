using Day3_Classes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopWeb.Controllers
{
    public class ShopController : Controller
    {
        private static ShopManager manager = new ShopManager();

        // for catalogue
        public IActionResult Index()
        {
            List<Item> items = manager.GetAvailableItems();

            return View(items);
        }

        // for basket
        public IActionResult Basket()
        {
            List<Item> items = manager.Pay();

            return View(items);
        }

        //to buy an item
        public IActionResult Buy(string name)
        {
            manager.AddToBasket(name);
            //sends the user back to the catalogue (Index)
            return RedirectToAction(nameof(Index));
        }
    }
}
