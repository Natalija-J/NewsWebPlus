using News.Logic.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace News.Logic.Manager
{  

    /// <summary>
    /// All the logic for managing the News 
    /// </summary>
    public class NewsManager
    {
        public List<Articles> GetLatestNews(int count = 6)
        {
            using (var db = new NewsDatabase())
            {
                // SELECT TOP 6 * FROM Articles ORDER BY PublishedOn DESC
                return db.Articles.OrderByDescending(a => a.PublishedOn).Take(count).ToList();
            }
        }
        
        
        public List<Articles> GetNewsByTopic(int topicId)
        {
            using(var db = new NewsDatabase())
            {
                return db.Articles.Where(a => a.TopicId == topicId)
                                  .OrderByDescending(a => a.PublishedOn)
                                  .ToList();
            }
        }


        public Articles GetArticle(int id)
        {
            using (var db = new NewsDatabase())
            {
                return db.Articles.FirstOrDefault(a => a.Id == id);
            }
        }

        public List<Articles> GetAllArticles()
        {
            //returns Articles, ordered by Title ASC
            using (var db = new NewsDatabase())
            {
                // SELECT * FROM Topics ORDER BY Title
                return db.Articles.OrderByDescending(a => a.PublishedOn).ToList();
            }

        }

        public void CreateNewArticle(int topicId, string title, string author,  string text)
        {
            using (var db = new NewsDatabase())
            {
                if (String.IsNullOrEmpty(title))
                {
                    throw new LogicException("Title can't be empty!");
                }

                var sameTitle = db.Articles.FirstOrDefault(a => a.Title.ToLower() == title.ToLower());
                if (sameTitle != null)
                {
                    throw new LogicException("Article already exists!");
                }

                db.Articles.Add(new Articles()
                {
                    TopicId = topicId,
                    Title = title,
                    Author = author,
                    PublishedOn = DateTime.Now,
                    Text = text,
                    Image = ""
                });

                db.SaveChanges();

            }

        }
        // method to delete an article
        public void Delete(int id)
        {
            using (var db = new NewsDatabase())
            {
                var article = db.Articles.FirstOrDefault(a => a.Id == id);

                db.Articles.Remove(article);

                db.SaveChanges();
            }
        }
    }
}
