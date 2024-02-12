using Microsoft.EntityFrameworkCore;
using Shop.Models;

namespace Shop.Data
{
    public class ApplicationDbContext : DbContext
    {
       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //to create Table
        public DbSet<Company> companies { get; set; }
        public DbSet<Product> products { get; set; }    

        public DbSet<Category> categories { get; set; }
        public DbSet<Post> posts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasData(
                new Company { Id=1, Name="Nike"},
                new Company { Id=2, Name="Adidias"}
            );

            modelBuilder.Entity<Category>().HasData(
               new Category { Id = 1, Name = "Fashion" },
               new Category { Id = 2, Name = "Sports" },
               new Category { Id = 3, Name = "Nature" }
           );
        }
    }
}
