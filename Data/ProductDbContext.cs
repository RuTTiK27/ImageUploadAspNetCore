using ImageUploadAspNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace ImageUploadAspNetCore.Data
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options) 
        {

        }
        
        public DbSet<Product> Product { get; set; } 
    }
}
