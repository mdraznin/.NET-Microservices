using Microsoft.EntityFrameworkCore;
using Mido.PlatformService.Models;

namespace Mido.PlatformService.Data
{
    /// <summary>
    /// Utility class to populate AppDbContext object and to implement database migration to Sql Server
    /// </summary>
    public static class PrepDb
    {
        public static void PrepPoulation(IApplicationBuilder app, bool isProd)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
            }
        }

        private static void SeedData(AppDbContext? context, bool isProd)
        {
            if (context == null) {
                throw new ArgumentNullException(nameof(context));
            }
            
            if (isProd)
            {
                try
                {
                    context.Database.Migrate();
                    Console.WriteLine("--> Applied migrations");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"--> Failed write migration: {ex.Message}");
                }
            }

            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding data...");

                context.Platforms.AddRange(
                    new Platform() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
                );
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data");
            }
        }
    }
}