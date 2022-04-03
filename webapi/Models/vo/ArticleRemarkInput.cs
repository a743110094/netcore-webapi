using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demo.Models.vo
{
    [Table("article_remark")]
   
    public class ArticleRemarkInput :BaseListInput
    {
       public string Content { get; set; }
    }
}
