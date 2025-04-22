using Microsoft.AspNetCore.Mvc;
using MongoTest.Models.Entities;
using MongoTest.Services;

namespace MongoTest.Controllers;

[ApiController]
[Route("[controller]")]
public class DataController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly DataService _dataService;

    public DataController(ILogger<WeatherForecastController> logger, DataService dataService)
    {
        _logger = logger;
        _dataService = dataService;
    }

    [HttpGet]
    public async Task<IEnumerable<SeasonModel>> Get()
    {
        return await _dataService.GetAllAsync();
    }
}
