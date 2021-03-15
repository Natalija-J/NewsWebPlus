using News.Logic.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace News.Logic.Manager
{
   public class TopicManager
    {
        //Create TopicManager with method GetAllTopics - returns Topics, ordered by Title ASC
        public List<Topics> GetAllTopics()
        {
            //returns Topics, ordered by Title ASC
            using (var db = new NewsDatabase())
            {
                // SELECT * FROM Topics ORDER BY Title
                return db.Topics.OrderBy(t => t.Title).ToList();
            }
        }
       
        public Topics GetTopic (int id)
        {
            using(var db = new NewsDatabase())
            {
                return db.Topics.FirstOrDefault(topic => topic.Id == id);
            }
        }

        public void CreateNewTopic(string title)
        {
            using(var db = new NewsDatabase())
            {
                if (String.IsNullOrEmpty(title))
                {
                    throw new LogicException("Title can't be empty!");
                }
                var sameTitle = db.Topics.FirstOrDefault(t => t.Title.ToLower() == title.ToLower());
                if (sameTitle != null)
                {
                    throw new LogicException("Topic already exists!");
                }

                db.Topics.Add(new Topics()
                {
                    Title = title,
                });

                db.SaveChanges();
            }

        }
    }
}
