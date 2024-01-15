using Microsoft.EntityFrameworkCore;

namespace OrganicStore.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Products> Products { get; set; }

        public DbSet<CartItem> CartItems { get; set; }

    }
}