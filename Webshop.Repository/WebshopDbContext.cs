using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop.Model;

namespace Webshop.Repository
{
    public class WebshopDbContext : DbContext
    {
        public static string LocalConnectionString { get; set; } =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WebshopDB;Integrated Security=True";

        public WebshopDbContext(DbContextOptions<WebshopDbContext> options) : base(options)
        {

        }

        public WebshopDbContext()
        {

        }

        public DbSet<Bluray> Blurays { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(LocalConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
