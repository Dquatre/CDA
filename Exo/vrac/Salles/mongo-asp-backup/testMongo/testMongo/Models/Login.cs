using MongoDB.Bson.Serialization.Attributes;

namespace testMongo.Models
{
    public class Login
    {
        [BsonElement("_id")]
        //[BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("password")]
        public Adresse Password { get; set; }
    }
}
