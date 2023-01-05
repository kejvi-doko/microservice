using System.Text;
using System.Text.Json;
using PlatformService.Dtos;

namespace PlatformService.SyncDataService.Http;

public class HttpCommandDataClient:ICommandDataClient
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;
    public HttpCommandDataClient(HttpClient httpClient,IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }
    public async Task SendPlatformToCommand(PlatformReadDto plat)
    {
        var httpContent = new StringContent(JsonSerializer.Serialize(plat), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync($"{_configuration["CommandService"]}", httpContent);
        Console.WriteLine(response.IsSuccessStatusCode
            ? "--> Sync POST to CommandService was OK"
            : "--> Sync POST to CommandService was NOT OK");
    }
}