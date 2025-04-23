using Microsoft.AspNetCore.Mvc;
using MongoTest.Models.Entities;
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


    [HttpGet("{id}", Name = "GetSeasonById")]
    public async Task<IActionResult> GetById(string id)
    {
        var result = await _uow.Seasons.GetByIdAsync(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(SeasonModel model)
    {
        var result = await _uow.Seasons.AddAsync(model);
        return CreatedAtRoute("GetSeasonById", new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, SeasonModel model)
    {
        var updated = await _uow.Seasons.UpdateAsync(id, model);
        if (!updated)
            return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var deleted = await _uow.Seasons.RemoveAsync(id);
        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
