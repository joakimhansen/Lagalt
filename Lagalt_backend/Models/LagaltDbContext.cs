using Lagalt_backend.Models.Entities;
using Microsoft.EntityFrameworkCore;
    
namespace Lagalt_backend.Models
{
    public class LagaltDbContext : DbContext
    {

        public LagaltDbContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}
