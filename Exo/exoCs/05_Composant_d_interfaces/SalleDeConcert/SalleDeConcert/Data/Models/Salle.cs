using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace SalleDeConcert.Data.Models
{
    public class Salle
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string Nom { get; set; } = null!;

        public decimal adresse { get; set; }

        public string styles { get; set; } = null!;

        public int Capacite { get; set; } 
        public bool smac { get; set; } 
    }
}
