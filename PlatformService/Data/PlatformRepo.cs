using PlatformService.Models;

namespace PlatformService.Data;

public class PlatformRepo:IPlatformRepo
{
    private readonly AppDbContext _dbContext;
    public PlatformRepo(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public bool SaveChanges()
    {
        return _dbContext.SaveChanges() > 0;
    }

    public IEnumerable<Platform> GetAllPlatforms()
    {
        return _dbContext.Platforms.ToList();
    }

    public Platform GetPlatformById(int id)
    {
        return _dbContext.Platforms.SingleOrDefault(p => p.Id == id);
    }

    public void CreatePlatform(Platform plat)
    {
        if (plat == null)
            throw new ArgumentNullException(nameof(plat));
        _dbContext.Platforms.Add(plat);
    }
}