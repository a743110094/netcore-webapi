using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demo.Models
{
    /// <summary>
    /// 
    ///</summary>
    ///
    [Table("article")]
    public class Article
    {
        /// <summary>
        /// 主键 
        ///</summary>
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// 标题 
        /// 默认值: NULL
        ///</summary>
         [Column( "title"    )]
         public string Title { get; set; }
        /// <summary>
        /// 作者 
        /// 默认值: NULL
        ///</summary>
         [Column( "author"    )]
         public string Author { get; set; }
        /// <summary>
        /// 分类 
        /// 默认值: NULL
        ///</summary>
         [Column( "series"    )]
         public string Series { get; set; }
        /// <summary>
        /// 正文 
        /// 默认值: NULL
        ///</summary>
         [Column( "content"    )]
         public string Content { get; set; }
        /// <summary>
        /// 发表时间 
        /// 默认值: NULL
        ///</summary>
         [Column( "create_time"    )]
         public DateTime? CreateTime { get; set; }
        /// <summary>
        /// 星座日期范围 
        /// 默认值: NULL
        ///</summary>
         [Column( "dateRange"    )]
         public string DateRange { get; set; }
        /// <summary>
        /// 特点 
        /// 默认值: NULL
        ///</summary>
         [Column( "attr1"    )]
         public string Attr1 { get; set; }
        /// <summary>
        /// 掌管宫位 
        /// 默认值: NULL
        ///</summary>
         [Column( "attr2"    )]
         public string Attr2 { get; set; }
        /// <summary>
        /// 阴阳性 
        /// 默认值: NULL
        ///</summary>
         [Column( "attr3"    )]
         public string Attr3 { get; set; }
        /// <summary>
        /// 最大特征 
        /// 默认值: NULL
        ///</summary>
         [Column( "attr4"    )]
         public string Attr4 { get; set; }
        /// <summary>
        /// 主管星 
        /// 默认值: NULL
        ///</summary>
         [Column( "attr5"    )]
         public string Attr5 { get; set; }
        /// <summary>
        /// 颜色 
        /// 默认值: NULL
        ///</summary>
         [Column( "attr6"    )]
         public string Attr6 { get; set; }
        /// <summary>
        /// 珠宝 
        /// 默认值: NULL
        ///</summary>
         [Column( "attr7"    )]
         public string Attr7 { get; set; }
        /// <summary>
        /// 幸运号码 
        /// 默认值: NULL
        ///</summary>
         [Column( "attr8"    )]
         public string Attr8 { get; set; }
        /// <summary>
        /// 简介 
        /// 默认值: NULL
        ///</summary>
         [Column( "intro"    )]
         public string Intro { get; set; }
    }
}
