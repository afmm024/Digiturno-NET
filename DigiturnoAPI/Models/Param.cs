using System.ComponentModel;
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
    public TypeTicketEnum Type { get; set; }
    [BsonElement("value")]
    public int Value { get; set; }

    [BsonRepresentation(BsonType.DateTime)]
    [BsonElement("createdAt")]
    public DateTime CreatedAt { get; set; }

}
public enum TypeTicketEnum
{
    [Description("ticket_queue")]
    Ticket_queue,
    [Description("handicapped_queue")]
    Handicapped_queue,
}