using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MongoDBProject.Repositories.Bsons
{
    public class PersonBson
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; } // = ObjectId.GenerateNewId();

        [BsonElement("Name")]
        public String Name { get; set; }
        
        [BsonElement("YearsOld")]
        public int YearsOld { get; set; }
    }
}
