using CommandsService.Models;

namespace CommandsService.Data;

public class CommandRepo:ICommandRepo
{
    private readonly AppDbContext _dbContext;
    public CommandRepo(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public bool SaveChanges()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Platform> GetAllPlatforms()
    {
        throw new NotImplementedException();
    }

    public bool PlatformExists(int platformId)
    {
        throw new NotImplementedException();
    }

    public Platform GetPlatformById(int id)
    {
        throw new NotImplementedException();
    }

    public void CreatePlatform(Platform plat)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Command> GetCommandsForPlatform(int platformId)
    {
        throw new NotImplementedException();
    }

    public Command GetCommand(int platformId, int commandId)
    {
        throw new NotImplementedException();
    }

    public void CrateCommand(int platformId, Command command)
    {
        throw new NotImplementedException();
    }
}