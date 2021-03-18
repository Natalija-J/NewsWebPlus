using Microsoft.AspNetCore.Mvc;
using News.Logic.Manager;
using NewsWeb.Models;
using System;
using News.Logic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Controllers
{
    
    public class TopicController : Controller
    {
        private TopicManager manager = new TopicManager();
        
        [HttpGet]
        public IActionResult Create()
        {
            if (!HttpContext.Session.GetIsAdmin())
            {
                return NotFound();
            }

            TopicModel model = new TopicModel();
            model.Topics = manager.GetAllTopics();

            return View(model);
        }
        [HttpPost]
        public IActionResult Create(TopicModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // manager call
                    manager.CreateNewTopic(model.Title);

                    return RedirectToAction(nameof(Create));
                }
                catch (LogicException ex)
                {
                    ModelState.AddModelError("validation", ex.Message);
                }
                catch (Exception ex)
                {
                    // some other unexpected error
                    ModelState.AddModelError("validation", ex.Message);
                }
            }
            
            return View(model);
        }

        public IActionResult Index()
        {
            var topics = manager.GetAllTopics();

            return View(topics);
        }
        public IActionResult Delete(int id)
        {
            manager.Delete(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
