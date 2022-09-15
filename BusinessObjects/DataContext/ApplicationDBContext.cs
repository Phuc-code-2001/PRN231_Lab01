using BusinessObjects.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects.DataContext
{
    public class ApplicationDBContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            Console.WriteLine(Directory.GetDirectoryRoot(Directory.GetCurrentDirectory()));
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var configuration = builder.Build();
            optionBuilder.UseSqlServer(configuration.GetConnectionString("MyStoreDB"));

        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new Category() { Name="Beverages", Id=1 },
                new Category() { Name="Condiments", Id=2 },
                new Category() { Name="Confections", Id=3 },
                new Category() { Name="Dairy Products", Id=4 },
                new Category() { Name="Grains/Cereals", Id=5 },
                new Category() { Name="Meat/Poultry", Id=6 },
                new Category() { Name="Produce", Id=7 },
                new Category() { Name="Seafood", Id=8 },
            });


        }

    }
}
