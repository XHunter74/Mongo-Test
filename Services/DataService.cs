using MongoDB.Driver;
using MongoTest.Models.Entities;

namespace MongoTest.Services;

public class DataService
{
    private readonly IMongoCollection<SeasonModel> _seasons;

    public DataService(IMongoDatabase database)
    {
        _seasons = database.GetCollection<SeasonModel>("got_seasons_collection");
    }

    public async Task<List<SeasonModel>> GetAllAsync()
    {
        var data = await _seasons.Find(_ => true).ToListAsync();
        return data;
    }
}
