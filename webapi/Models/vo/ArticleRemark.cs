using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demo.Models.vo
{
    [Table("article_remark")]
   
    public class ArticleRemark
    {
        /// <summary>
        /// 主键 
        ///</summary>
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// 用户id 
        /// 默认值: NULL
        ///</summary>
        [Column("user_id")]
        public int? UserId { get; set; }
        /// <summary>
        /// 文章id 
        /// 默认值: NULL
        ///</summary>
        [Column("article_id")]
        public int? ArticleId { get; set; }

        [Column("title")]
        public string Title { get; set; }
        /// <summary>
        /// 正文 
        /// 默认值: NULL
        ///</summary>
        [Column("content")]
        public string Content { get; set; }
        /// <summary>
        /// 发布时间 
        /// 默认值: NULL
        ///</summary>
        [Column("created_time")]
        public DateTime? CreatedTime { get; set; }
        /// <summary>
        /// 状态 0 - 新建  1-审核通过  2 - 审核不通过  5-删除 
        /// 默认值: NULL
        ///</summary>
        [Column("status")]
        public byte? Status { get; set; }
        [Column("nick_name")]
        public string NickName { get; set; }

        [Column("avatar")]
        public string Avatar { get; set; }
    }
}
