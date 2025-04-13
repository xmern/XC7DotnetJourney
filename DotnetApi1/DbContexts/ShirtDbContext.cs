using DotnetApi1.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetApi1.DbContexts
{
    public class ShirtDbContext(DbContextOptions<ShirtDbContext> options) : DbContext(options)
    {
        public DbSet<Shirt> Shirts => Set<Shirt>();
    }
}
