using System.ComponentModel;
using DigiturnoAPI.Constanst;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DigiturnoAPI.Models;

public class Param
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonElement("_id")]
    public string? Id { get; set; }
    [BsonElement("type")]
    public string Type { get; set; }
    [BsonElement("value")]
    public int Value { get; set; }

    [BsonRepresentation(BsonType.DateTime)]
    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; }

}
