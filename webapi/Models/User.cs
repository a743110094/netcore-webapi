using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace demo.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        [Column("login_name")]
        [MaxLength(64)]
        public string LoginName { get; set; }
        
          
        
        /// <summary>
        /// 密码
        /// </summary>
        [Column("password")]
        [MaxLength(64)]
        public string Password { get; set; }



        /// <summary>
        /// 昵称
        /// </summary>
        [Column("nick_name")]
        [MaxLength(64)]
        public string NickName { get; set; }


         /// <summary>
        /// 真实姓名
        /// </summary>
        [Column("real_name")]
        [MaxLength(64)]
        public string RealName { get; set; }



        /// <summary>
        /// 性别 
        /// </summary>
        [Column("gender")]
 
        public int Gender { get; set; }

        
         /// <summary>
        /// 头像
        /// </summary>
        [Column("avatar")]
        [MaxLength(255)]
        public string Avatar { get; set; }



         /// <summary>
        /// 生效标志
        /// </summary>
        [Column("enable_flag")]
        public int EnableFlag { get; set; }


        [Column("create_time")]
        public DateTime? CreateTime { get; set; }
    }
}
