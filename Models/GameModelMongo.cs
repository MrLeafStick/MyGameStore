using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MyGamesStore.Models 
{
    public class GameModelMongo
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Publisher { get; set; }
        public string Title { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public string Rating { get; set; }
        public decimal Price { get; set; }
    }
}