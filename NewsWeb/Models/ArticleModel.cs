﻿using News.Logic.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWeb.Models
{
    public class ArticleModel
    {
        public List<Topics> Topics { get; set; }
        public Articles Article { get; set; }
        public Topics ActiveTopic { get; set; }


        
    }
}
