using CommandsService.Models;

namespace CommandsService.Data;

public interface ICommandRepo
{
    bool SaveChanges();

    IEnumerable<Platform> GetAllPlatforms();
    bool PlatformExists(int platformId);
    bool ExternalPlatformExists(int externalId);
    void CreatePlatform(Platform plat);

    IEnumerable<Command> GetCommandsForPlatform(int platformId);
    Command GetCommand(int platformId,int commandId);
    void CreateCommand(int platformId, Command command);

}