using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DigiturnoAPI.Models
{
    public class Ticket
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string? Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("document")]
        public int Document { get; set; }
        [BsonElement("handicapped")]
        public bool Handicapped { get; set; }

        [BsonElement("createdAt")]
        public string CreatedAt { get; set; }

        [BsonElement("typeService")]
        public string TypeService { get; set; }

        [BsonElement("status")]
        public string Status { get; set; }

        [BsonElement("ticketId")]
        public string TicketId { get; set; }
        [BsonElement("moduleId")]
        public string ModuleId { get; set; }

        [BsonElement("ticketNumber")]
        public string TicketNumber { get; set; }


    }
}