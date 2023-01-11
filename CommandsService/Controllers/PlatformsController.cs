using AutoMapper;
using CommandsService.Data;
using CommandsService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers;

[Route("/api/c/[controller]")]
[ApiController]
public class PlatformsController:ControllerBase
{
    private readonly ICommandRepo _repo;
    private readonly IMapper _mapper;
    public PlatformsController(ICommandRepo repo,IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
    {
        Console.WriteLine("--> Getting platform from CommandService");
        var platformItems = _repo.GetAllPlatforms();
        return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platformItems));
    }
    
    [HttpPost]
    public ActionResult TestInboundConnection()
    {
        Console.WriteLine("---> Inbound POST # Command Service");
        return Ok("Inbound Test of from Platform Controller");
    }
}