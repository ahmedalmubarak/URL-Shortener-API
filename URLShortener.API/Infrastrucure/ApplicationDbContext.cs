using Microsoft.EntityFrameworkCore;
using TinyLink.API.Models.Entities;

namespace TinyLink.API.Infrastrucure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Link> Links { get; set; }
        public DbSet<Visit> Visits { get; set; }
    }
}
