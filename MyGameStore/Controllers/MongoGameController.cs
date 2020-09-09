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
        private readonly MongoGameService _game;

        public MongoGameController(MongoGameService game)
        {
            _game = game;
        }
        

        public IActionResult Index()
        {
            var games = _game.Get();
            
            return View(games);
        }

        //Post: Game/Create
        public IActionResult Create(GameModelMongo game)
        {

            if (ModelState.IsValid)
            {
                var exists = game.Title;

                if (game.Title != null)
                {
                    _game.Create(game);
                }


            }

            return View(game);
        }


        public IActionResult Edit(string id, GameModelMongo gameIn)
        {

            gameIn. = new ObjectId(id);
            var filter = Builders<GameModelMongo>.Filter.Eq<"Id", gameIn.Id>

            var game = _game.Get(id);

            if (game == null)
            {
                return NotFound();
            }

            gameIn.Title = game.Title;

            _game.Update(id, gameIn);

            return View();
        }
    }
}
