using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoTest.Models.Entities;

public class SeasonModel
{
    [BsonId]
    //[BsonElement("_id")]
    public ObjectId Id { get; set; }

    [BsonElement("season")]
    public string Season { get; set; }

    [BsonElement("year")]
    public int Year { get; set; }

    [BsonElement("episodes")]
    public EpisodeModel[] Episodes { get; set; } = [];
}

public class EpisodeModel
{
    public int number_overall { get; set; }
    public int number_in_season { get; set; }
    public string title { get; set; }
    public string[] directors { get; set; } = [];
    public string[] writers { get; set; } = [];
    public string original_air_date { get; set; }
    public string number_us_viewers { get; set; }
}
