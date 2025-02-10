using Empower.Web.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Empower.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options) { }

        public DbSet<Product> Products { get; set; }

    }
}
