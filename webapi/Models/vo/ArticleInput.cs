using System;
using System.Collections.Generic;

namespace demo.Models.vo
{
    public class ArticleInput : BaseListInput
    {
        public string Title { get; set; }

        public string Author { get; set; }        
        public string Series { get; set; }            
    }


}
