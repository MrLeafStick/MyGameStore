using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using MyGamesStore.Data;
using MyGamesStore.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace MyGamesStore.Controllers
{
    public class GameController : Controller
    {
        private readonly MyGamesStoreContext _context;

        public GameController(MyGamesStoreContext context) 
        {
            _context = context;
        }

        public async Task<IActionResult> IndexMongo()
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);

            var database = client.GetDatabase("MyGameStore");
            
            var collection = database.GetCollection<GameModelMongo>("Game");

            var games = await collection.Find(new BsonDocument()).ToListAsync();

            foreach (GameModelMongo game in games)
            {
                
            }

            return View(games);
        }

        public IActionResult Index()
        {
            return View(_context.Game.ToList());
        }

        //GET: Game/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Game/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,Description,Publisher,ReleaseDate,Genre,Rating,Price")] Game game)
        {
            if (ModelState.IsValid) {
                _context.Game.Add(game);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(game);
        }

        //DELETE: Games/Delete/{id}
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            var game = _context.Game.Find(id);
            _context.Game.Remove(game);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        //PUT: Game/Edit/${id}
        [Route("Game/Edit/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,Title,Description,Publisher,ReleaseDate,Genre,Rating,Price")] Game game)
        {
            if (ModelState.IsValid) {
                _context.Entry(game).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(game);
        }

        //GET: Game/Edit/{id}
        // [HttpGet("Edit")]
        // //GET: Game/Delete/{id}
        // [HttpGet("Delete")]
        //[Route("Game/Edit/{id}")]
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var games = _context.Game.Find(id);

            if (games == null) {
                return NotFound();
            }

            return View(games);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var games = _context.Game.Find(id);

            if (games == null) {
                return NotFound();
            }

            return View(games);
        }
    }
}