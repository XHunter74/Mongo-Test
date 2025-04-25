using Microsoft.AspNetCore.Mvc;
using MongoTest.Models.Entities;
using MongoTest.UnitOfWork;

namespace MongoTest.Controllers;

[ApiController]
[Route("[controller]")]
public class DataController : ControllerBase
{
    private readonly ILogger<DataController> _logger;
    private readonly IMongoUnitOfWork _uow;

    public DataController(
        ILogger<DataController> logger,
        IMongoUnitOfWork uow)
    {
        _logger = logger;
        _uow = uow;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        _logger.LogInformation("Executing Get method to retrieve all seasons.");
        var result = await _uow.Seasons.GetAllAsync().ConfigureAwait(false);
        _logger.LogInformation("Retrieved {Count} seasons.", result.Count());
        return Ok(result);
    }

    [HttpGet("{id}", Name = "GetSeasonById")]
    public async Task<IActionResult> GetById(string id)
    {
        _logger.LogInformation("Executing GetById method with id: {Id}.", id);
        var result = await _uow.Seasons.GetByIdAsync(id).ConfigureAwait(false);
        if (result == null)
        {
            _logger.LogWarning("Season with id: {Id} not found.", id);
            return NotFound();
        }
        _logger.LogInformation("Retrieved season with id: {Id}.", id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create(SeasonModel model)
    {
        _logger.LogInformation("Executing Create method with model: {@Model}.", model);
        var result = await _uow.Seasons.AddAsync(model).ConfigureAwait(false);
        _logger.LogInformation("Created season with id: {Id}.", result.Id);
        return CreatedAtRoute("GetSeasonById", new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, SeasonModel model)
    {
        _logger.LogInformation("Executing Update method with id: {Id} and model: {@Model}.", id, model);
        var updated = await _uow.Seasons.UpdateAsync(id, model).ConfigureAwait(false);
        if (!updated)
        {
            _logger.LogWarning("Failed to update season with id: {Id}. Not found.", id);
            return NotFound();
        }
        _logger.LogInformation("Updated season with id: {Id}.", id);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        _logger.LogInformation("Executing Delete method with id: {Id}.", id);
        var deleted = await _uow.Seasons.RemoveAsync(id).ConfigureAwait(false);
        if (!deleted)
        {
            _logger.LogWarning("Failed to delete season with id: {Id}. Not found.", id);
            return NotFound();
        }
        _logger.LogInformation("Deleted season with id: {Id}.", id);
        return NoContent();
    }
}
