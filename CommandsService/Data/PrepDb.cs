using CommandsService.Models;
using CommandsService.SyncDataService.Grpc;

namespace CommandsService.Data;

public static class PrepDb
{
    public static void PrepPopulation(IApplicationBuilder applicationBuilder)
    {
        using (var scope = applicationBuilder.ApplicationServices.CreateScope())
        {
            var grpcClient = scope.ServiceProvider.GetService<IPlatformDataClient>();
            var platforms = grpcClient.ReturnAllPlatforms();
            SeedData(scope.ServiceProvider.GetService<ICommandRepo>(), platforms);
        }
    }

    private static void SeedData(ICommandRepo commandRepo, IEnumerable<Platform> platforms)
    {
        Console.WriteLine("Seed platforms");

        foreach (var platform in platforms)
        {
            if (!commandRepo.ExternalPlatformExists(platform.ExternalId))
            {
                commandRepo.CreatePlatform(platform);
            }
        }
        commandRepo.SaveChanges();
    }
}