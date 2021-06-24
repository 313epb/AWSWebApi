using Microsoft.EntityFrameworkCore;

namespace AWSWebApi.Model
{
    public sealed class WebShopContext:DbContext
    {
        public DbSet<Product> Products { get; set; }

        public WebShopContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=AWSWebApi;Trusted_Connection=True;");
        }
    }
}