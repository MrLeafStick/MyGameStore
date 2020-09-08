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

namespace MyGameStore.Controllers
{
    public class GameController : Controller
    {
        private readonly MyGameStoreContext _context;

        public GameController(MyGameStoreContext context)
        {
            _context = context;
        }

        //GET: Games
        public async Task<IActionResult> Index(string gameGenre, string searchString)
        {
                var genreQuery = from g in _context.Game
                                 orderby g.Genre
                                 select g.Genre;

                var games = from g in _context.Game
                            select g;

                if (!string.IsNullOrEmpty(searchString))
                {
                    games = games.Where(s => s.Title.Contains(searchString));
                }

                if (!string.IsNullOrEmpty(gameGenre))
                {
                    games = games.Where(x => x.Genre == gameGenre);
                }

                var gameGenreVm = new GamesGenreViewModel
                {
                    Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                    Games = await games.ToListAsync()
                };

                return View(gameGenreVm);
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        //Get Game/Create
        public IActionResult Create()
        {
            return View();
        }

        //Post: Game/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id, Title, Description, ReleaseDate, Genre, Publisher, Rating, Price, UnitsSold")]Game game)
        {
            _context.Database.EnsureCreated();

            if (ModelState.IsValid)
            {
                _context.Game.Add(game);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(game);

        }

        //GET: Game/Delete/{id}
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var games = _context.Game.Find(id);

            if (games == null)
            {
                return NotFound();
            }

            return View(games);
        }


        //POST: Game/Delete/{id}
        [HttpPost("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var game = _context.Game.Find(id);
            _context.Game.Remove(game);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        //GET: Game/Edit/{id}
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var games = _context.Game.Find(id);
            if (games == null)
            {
                return NotFound();
            }
            return View(games);

        }
        //POST: Game/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id, Title, Description, ReleaseDate, Genre, Publisher, Rating, Price, UnitsSold")] Game game)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(game).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(game);

        }



    }
}
