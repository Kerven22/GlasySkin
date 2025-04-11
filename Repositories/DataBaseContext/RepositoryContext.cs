using Entity.Models;
using Microsoft.EntityFrameworkCore;

namespace Repositories.DataBaseContext
{
    public class RepositoryContext:DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options):base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Basket> Baskets { get; set; }

        public DbSet<Comment> Comments { get; set; }

    }
}
