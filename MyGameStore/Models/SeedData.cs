using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using MyGameStore.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGameStore.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyGameStoreContext(serviceProvider.GetRequiredService<DbContextOptions<MyGameStoreContext>>()))
            {
                
                context.Database.EnsureCreated();

                //look For Games
                if (context.Game.Any())
                {
                    return; // Db has been seeded
                }

                context.Game.AddRange(
                new Game
                {
                    Title = "World of warcraft",
                    ReleaseDate = DateTime.Parse("2003-1-11"),
                    Genre = "MMO",
                    Publisher = "Blizzard",
                    Price = 60m,
                    Rating = "18",
                    Description = "The adventures of azeroth bla bla bla...",
                    UnitsSold = 1003400,
                },

                new Game
                {
                    Title = "World of warcraft2",
                    ReleaseDate = DateTime.Parse("2003-1-11"),
                    Genre = "MMO",
                    Publisher = "Blizzard",
                    Price = 60m,
                    Rating = "18",
                    Description = "The adventures of azeroth bla bla bla...",
                    UnitsSold = 1003400,
                });

                context.SaveChanges();
            }
        }
    }
}
