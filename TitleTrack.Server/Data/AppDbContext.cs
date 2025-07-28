using Microsoft.EntityFrameworkCore;
using TitleTrack.Server.Models;

namespace TitleTrack.Server.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TitleAbstract> TitleAbstracts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {}
    }
}
