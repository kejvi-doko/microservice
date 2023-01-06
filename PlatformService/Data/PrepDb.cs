using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Data;

public static class PrepDb
{
    public static void PrepPopulation(IApplicationBuilder app,bool isProduction = false)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            SeedDate(serviceScope.ServiceProvider.GetService<AppDbContext>(),isProduction);
        }
    }

    private static void SeedDate(AppDbContext? context, bool isProduction = false)
    {
        if (isProduction)
        {
            Console.WriteLine("--> Running migrations");
            try
            {
                context.Database.Migrate();
            }
            catch (Exception e)
            {
                Console.WriteLine($"--> Could not run migrations {e.Message}");
                throw;
            }
            
        }

        if (!context.Platforms.Any())
        {
            Console.WriteLine("---> Seeding data");
            context.Platforms.AddRange(new[]
            {
                new Platform()
                {
                    Cost = "Free",
                    Name = "Dot Net",
                    Publisher = "Microsoft"
                },
                new Platform()
                {
                    Cost = "Free",
                    Name = "SQL Server Express",
                    Publisher = "Microsoft"
                },
                new Platform()
                {
                    Cost = "Free",
                    Name = "Kubernetes",
                    Publisher = "Cloud Native Computer Foundation"
                }
            });

            context.SaveChanges();
        }
        else
        {
            Console.WriteLine("---> We already have data");
        }

    }
}