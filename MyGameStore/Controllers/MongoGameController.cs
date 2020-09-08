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
            var Mongogame = new GameModelMongo();
            var mongos = from g in games select g;

            return View(mongos);
        }

        //Post: Game/Create
        [HttpPost]
        public IActionResult Create()
        {
            return View();
        }
    }
}
