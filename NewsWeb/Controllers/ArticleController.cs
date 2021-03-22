using Microsoft.AspNetCore.Mvc;
using News.Logic;
using News.Logic.Manager;
using NewsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Controllers
{
    public class ArticleController : Controller
    {
        private  TopicManager manager = new TopicManager();
        private NewsManager manager1 = new NewsManager();

        public IActionResult Index()
        {
            var articles = manager1.GetAllArticles();

            return View(articles);
        }


        [HttpGet]
        public IActionResult CreateArticle(int? id)
        {
            if (!HttpContext.Session.GetIsAdmin())
            {
                return NotFound();
            }
            var model = new NewArticle();
            model.Author = HttpContext.Session.GetUsername();
            model.Topics = manager.GetAllTopics();
            //in case of need to edit -> check for id
            if (id.HasValue)
            {
                var data = manager1.GetArticle(id.Value);
                model.Id = data.Id;
                model.Title = data.Title;
                model.Text = data.Text;
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateArticle(NewArticle model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // if id is not set then CREATE a NEW TOPIC
                    if (model.Id == 0)
                    {
                        // manager call
                        manager1.CreateNewArticle(model.ArticleTopicId, model.Title, model.Author, model.Text);
                    }
                    // If ID is defined THAN EDIT Article!!!
                    else
                    {
                        manager1.UpdateArticle(model.Id, model.ArticleTopicId, model.Author, model.Title, model.Text);
                    }

                    //redirecting back to the list of articles to see changes
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
            model.Topics = manager.GetAllTopics();
            return View(model);
        }

       

        [HttpGet]
        public IActionResult EditArticle(int id)
        {
            if (!HttpContext.Session.GetIsAdmin())
            {
                return NotFound();
            }
            //information from the database
            var data = manager1.GetArticle(id);

            NewArticle model = new NewArticle();
            model.Articles = manager1.GetAllArticles();

            //filling information from DB            
            model.Title = data.Title;
            model.Id = data.Id;
            model.Text = data.Text;
            model.ArticleTopicId = data.TopicId;

            return View(model);
        }

        [HttpPost]
        public IActionResult EditArticle(NewArticle model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // need to call a manager
                    manager1.UpdateArticle(model.Id, model.ArticleTopicId, model.Author, model.Title, model.Text);

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
