using Microsoft.AspNetCore.Mvc;
using MongoTest.UnitOfWork;

namespace MongoTest.Controllers;

[ApiController]
[Route("[controller]")]
public class DataController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IMongoUnitOfWork _uow;

    public DataController(
        ILogger<WeatherForecastController> logger,
        IMongoUnitOfWork uow)
    {
        _logger = logger;
        _uow = uow;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _uow.Seasons.GetAllAsync();
        return Ok(result);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await _uow.Seasons.GetByIdAsync(id);
        return Ok(result);
    }
}
