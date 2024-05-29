using System.ComponentModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DigiturnoAPI.Models;

public class Param
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public StatusTicket Type { get; set; }
    public int Value { get; set; }

}
public enum StatusTicket
{
    [Description("Available")]
    Available,
    [Description("Assigned")]
    Assigned,
    [Description("Attended")]
    Attended,
}