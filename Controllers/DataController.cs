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
    public async Task<IActionResult> Get()
    {
        var result = await _dataService.GetAllAsync();
        return Ok(result);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await _dataService.GetByIdAsync(id);
        return Ok(result);
    }
}
