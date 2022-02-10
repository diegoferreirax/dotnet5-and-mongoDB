using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MongoDBProject
{
    public class PurchaseDTO
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; } = ObjectId.GenerateNewId();

        [BsonElement("Placename")]
        public String Placename { get; set; }
        
        [BsonElement("Create")]
        public String Create { get; set; }

        [BsonElement("PurchaseCategoryNumber")]
        public int PurchaseCategoryNumber { get; set; }
    }
}
