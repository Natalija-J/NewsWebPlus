using Microsoft.AspNetCore.Mvc;
using News.Logic.Manager;
using NewsWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Controllers
{
    public class NewsController : Controller
    {
        private TopicManager topics = new TopicManager();
        private NewsManager articles = new NewsManager();

        public IActionResult Topics(int? id)
        {
            TopicsModel model = new TopicsModel();
            model.Topics = topics.GetAllTopics();
            if (id.HasValue)
            {
                //get active topic
                model.ActiveTopic = topics.GetTopic(id.Value);
                //retrieve information of articles under that topic
                model.Articles = articles.GetNewsByTopic(id.Value);
            }

            return View(model);
        }

        public IActionResult Article(int? id)
        {
            ArticleModel model = new ArticleModel();
            if (id.HasValue)
            {
                model.Article = articles.GetArticle(id.Value);
                model.Topics = topics.GetAllTopics();
                model.ActiveTopic = topics.GetTopic(model.Article.TopicId);

            }
            return View(model);
        }

        public IActionResult Index()
        {
            var info = articles.GetAllArticles();

            return View(info);
        }


        public IActionResult Delete(int id)
        {
            articles.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        //public IActionResult Create( model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            // manager call
        //            manager.CreateNewTopic(model.Title);

        //            return RedirectToAction(nameof(Create));
        //        }
        //        catch (LogicException ex)
        //        {
        //            ModelState.AddModelError("validation", ex.Message);
        //        }
        //        catch (Exception ex)
        //        {
        //            // some other unexpected error
        //            ModelState.AddModelError("validation", ex.Message);
        //        }
        //    }

        //}
    }
}
