using News.Logic.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Models
{
    public class NewArticle
    {
      
        [Required]
        [Display(Name = "Author")]
        public string Author { get; set; }

        [Required]
        [Display(Name = "Title of the article")]
        public string Title { get; set; }

        [Display(Name = "Article text")]
        public string Text { get; set; }
        [Display(Name = "Article category (topic)")]
        public int ArticleTopicId { get; set; }

        public List<Articles> Articles { get; set; }
        public List<Topics> Topics { get; set; }

        //id for the case when editing an article
        public int Id { get; set; }
    }
}
