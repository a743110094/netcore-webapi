using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using demo.Models;
using demo.Models.vo;

namespace demo.Repository
{
    public class DemoContext : DbContext
    {
        public DemoContext (DbContextOptions<DemoContext> options)
            : base(options)
        {
           
        }

        public DbSet<Article> Article { get; set; }
        public DbSet<Remark> Remark { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<UserToken> UserToken { get; set; }
        //VO
        public virtual DbSet<ArticleRemark> ArticleRemark { get; set; }
    }
}
