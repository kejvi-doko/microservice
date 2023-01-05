using PlatformService.Models;

namespace PlatformService.Data;

public static class PrepDb
{
    public static void PrepPopulation(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            SeedDate(serviceScope.ServiceProvider.GetService<AppDbContext>());
        }
    }

    private static void SeedDate(AppDbContext? context)
    {
        if (!context.Platforms.Any())
        {
            Console.WriteLine("---> Seeding data");
            context.Platforms.AddRange(new []
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