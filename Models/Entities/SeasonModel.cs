using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoTest.Models.Entities;

public class SeasonModel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("season")]
    public int Season { get; set; }

    [BsonElement("year")]
    public int Year { get; set; }

    [BsonElement("episodes")]
    public EpisodeModel[] Episodes { get; set; } = [];
}

public class EpisodeModel
{
    [BsonElement("number_overall")]
    public int NumberOverall { get; set; }

    [BsonElement("number_in_season")]
    public int NumberInSeason { get; set; }

    [BsonElement("title")]
    public string Title { get; set; }

    [BsonElement("directors")]
    public string[] Directors { get; set; } = [];

    [BsonElement("writers")]
    public string[] Writers { get; set; } = [];

    [BsonElement("original_air_date")]
    public string OriginalAirDate { get; set; }

    [BsonElement("number_us_viewers")]
    public decimal NumberUsViewers { get; set; }
}
