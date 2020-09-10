using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyGameStore.Data;
using MyGameStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Bson;
using MongoDB.Driver;
using MyGameStore.Controllers.Services;

namespace MyGameStore.Controllers
{
    public class MongoGameController : Controller
    {
        //private readonly MongoGameService _game;

        //public MongoGameController(MongoGameService game)
        //{
        //    _game = game;
        //}


        private IMongoCollection<GameModelMongo> collection;

        public MongoGameController()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase db = client.GetDatabase("Gamestore");
            collection = db.GetCollection<GameModelMongo>("Game");
        }



        public IActionResult Index()
        {
            var model = collection.Find(FilterDefinition<GameModelMongo>.Empty).Limit(2500).ToList();

            return View(model);



        }

        //Post: Game/Create
        public IActionResult Create(GameModelMongo game)
        {


            if (game.Title == null)
            {
                collection.InsertOne(game);
                ViewBag.Message = "Emplayee added successfully!";
                return View();
            }

            return View();
        }

        public IActionResult Update(string id)
        {
            var oId = new ObjectId(id);
            var game = collection.Find(e => e.Id == oId).FirstOrDefault();

            return View(game);
        }

        [HttpPost]
        public IActionResult Update(string id, GameModelMongo gameIn)
        {

            gameIn.Id = new ObjectId(id);
            var filter = Builders<GameModelMongo>.Filter.Eq("Id", gameIn.Id);

            var updateField = Builders<GameModelMongo>.Update.Set("Title", gameIn.Title);
            updateField = updateField.Set("Publisher", gameIn.Publisher);
            updateField = updateField.Set("ReleaseDate", gameIn.ReleaseDate);
            updateField = updateField.Set("Genre", gameIn.Genre);
            updateField = updateField.Set("Description", gameIn.Description);
            updateField = updateField.Set("Rating", gameIn.Rating);
            updateField = updateField.Set("Price", gameIn.Price);
            updateField = updateField.Set("UnitsSold", gameIn.UnitsSold);

            var result = collection.UpdateOne(filter, updateField);

            if (result.IsAcknowledged)
            {
                ViewBag.Message = "Game updated successfully";
            }
            else
            {
                ViewBag.Message = "Error while updating Game";
            }

            return View(gameIn);
        }

        public async Task<IActionResult> Delete(string id)
        {


            var oId = new ObjectId(id);

            var filter = Builders<GameModelMongo>.Filter.Eq("Id", oId);

            collection.DeleteMany(filter);

            return Redirect( "/mongoGame");
        }
    }
}
