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
        public IActionResult Create(int? id)
        {
            if (!HttpContext.Session.GetIsAdmin())
            {
                return NotFound();
            }

            TopicModel model = new TopicModel();
            model.Topics = manager.GetAllTopics();

            //in case of need to edit -> check for id
            if (id.HasValue)
            {
                var data = manager.GetTopic(id.Value);
                model.Id = data.Id;
                model.Title = data.Title;
            }
            
            return View(model);
        }


        [HttpPost]
        public IActionResult Create(TopicModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // if id is not set then CREATE a NEW TOPIC
                    if (model.Id == 0)
                    {
                        // manager call
                        manager.CreateNewTopic(model.Title);
                    }
                    // ID is defined THAN EDIT TOPIC!!!
                    else
                    {
                        manager.Update(model.Id, model.Title);
                    }

                    //redirecting back to the list of topics to see changes
                    return RedirectToAction(nameof(Index));
                    
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
            //if model is not valid than return to the same view. 
            return View(model);
        }

        public IActionResult Index()
        {
            if (!HttpContext.Session.GetIsAdmin())
            {
                return NotFound();
            }

            var topics = manager.GetAllTopics();

            return View(topics);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!HttpContext.Session.GetIsAdmin())
            {
                return NotFound();
            }
            //information from the database
            var data = manager.GetTopic(id); 

            TopicModel model = new TopicModel();            
            model.Topics = manager.GetAllTopics();

            //filling information from DB
            model.Title = data.Title;
            model.Id = data.Id;


            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(TopicModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // need new method to call manager
                    manager.Update(model.Id, model.Title);

                    return RedirectToAction(nameof(Index));
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

        public IActionResult Delete(int id)
        {
            if (!HttpContext.Session.GetIsAdmin())
            {
                return NotFound();
            }

            manager.Delete(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
