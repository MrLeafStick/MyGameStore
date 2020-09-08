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
        public ObjectId Id { get; set; }
        public string Publisher { get; set; }
        public string Title { get;set;}

        public string ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string Rating { get; set; }

  
        public string Price { get; set; }
        public int UnitsSold { get; set;}
    }
}
