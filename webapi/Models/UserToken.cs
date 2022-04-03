using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace demo.Models
{
    /// <summary>
    /// 
    ///</summary>
    [Table("user_token")]
    public class UserToken
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
         [Column( "user_id"    )]
         public int? UserId { get; set; }
        /// <summary>
        /// 文章id 
        /// 默认值: NULL
        ///</summary>
         [Column( "token"    )]
         public string? Token { get; set; }
        /// <summary>
        /// 过期时间 
        /// 默认值: NULL
        ///</summary>
         [Column( "expire_time"    )]
         public DateTime? ExpireTime { get; set; }
    }
}
