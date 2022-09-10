using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MongoDBProject.Repositories.Bsons
{
    public class AddressBson
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [BsonElement("PersonId")]
        public ObjectId PersonId { get; set; }

        [BsonElement("Street")]
        public String Street { get; set; }

        [BsonElement("Number")]
        public int Number { get; set; }
    }
}
