using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyGameStore.Models
{
    public class GameModelMongo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        [BsonElement]
        public string Publisher { get; set; }
        [BsonElement]
        public string Title { get; set; }
        [BsonElement]
        public DateTime ReleaseDate { get; set; }
        [BsonElement]
        public string Genre { get; set; }
        [BsonElement]
        public string Description { get; set; }
        [BsonElement]
        public string Rating { get; set; }
        [BsonElement]
        public decimal Price { get; set; }
        [BsonElement]
        public int UnitsSold { get; set; }

    }
}
