using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace demo.Models
{
    /// <summary>
    /// 
    ///</summary>
    [Table("user_role")]
    public class UserRole
    {
        /// <summary>
        /// 主键 
        ///</summary>
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// 角色id 
        /// 默认值: NULL
        ///</summary>
         [Column( "role_id"    )]
         public int? RoleId { get; set; }
        /// <summary>
        /// 用户id 
        /// 默认值: NULL
        ///</summary>
         [Column( "user_id"    )]
         public int? UserId { get; set; }
    }
}
