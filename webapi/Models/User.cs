using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace demo.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [MaxLength(64)]
        public string Id { get; set; }

        /// <summary>
        /// 登录名
        /// </summary>
        [Column("login_name")]
        [MaxLength(64)]
        public string LoginName { get; set; }

        [Column("password")]
        [MaxLength(64)]
        public string Password { get; set; }

        /// <summary>
        /// 性别 
        /// </summary>
        [Column("gender")]
        [MaxLength(16)]
        public string Gender { get; set; }

        [Column("create_time")]
        public DateTime? CreateTime { get; set; }
    }
}
