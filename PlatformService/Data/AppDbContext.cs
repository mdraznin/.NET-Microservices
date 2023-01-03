using Microsoft.EntityFrameworkCore;
using Mido.PlatformService.Models;

namespace Mido.PlatformService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }

        public DbSet<Platform> Platforms { get; set; } = default!; //to avoid Non-nullable field 'platforms' must contain a non-null value when exiting constructor warning
    }

}