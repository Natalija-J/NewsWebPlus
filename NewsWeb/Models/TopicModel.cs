using News.Logic.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Models
{
    public class TopicModel
    {
        [Required]
            [Display(Name = "Topic name")]
            public string Title { get; set; }

        [Display(Name = "Description of the topic")]
        public string Description { get; set; }
        [Display(Name = "Parent topic")]
        public int? ParentTopicId { get; set; }

        public List<Topics> Topics { get; set; }

        //id for editing purposes
        public int Id { get; set; }
    }
}
