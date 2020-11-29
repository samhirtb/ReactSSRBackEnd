using LivingSimple.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivingSimple.DataAccess
{
    public class LivingSimpleDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=<SERVER_NAME_HERE>;Initial Catalog=LivingSimple;Persist Security Info=True;User ID=<USER_HERE>;Password=<PASSWORD_HERE>");
        }
    }
}
