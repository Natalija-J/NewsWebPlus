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

    }
}
