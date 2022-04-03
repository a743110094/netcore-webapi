using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace demo.Models
{
    /// <summary>
    /// 
    ///</summary>
    [Table("role")]
    public class Role
    {
        /// <summary>
        /// 主键 
        ///</summary>
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// 名称 
        /// 默认值: NULL
        ///</summary>
         [Column( "name"    )]
         public string Name { get; set; }
        /// <summary>
        /// 编码 
        /// 默认值: NULL
        ///</summary>
         [Column( "code"    )]
         public string Code { get; set; }
    }
}
