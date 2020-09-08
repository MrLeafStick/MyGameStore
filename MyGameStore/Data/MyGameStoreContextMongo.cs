using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using MyGameStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGameStore.Data
{
    public class MyGameStoreContextMongo : DbContext
    {
        public MyGameStoreContextMongo(
            DbContextOptions<MyGameStoreContext> options) 
            : base(options)
        {
        }

        public DbSet<GameModelMongo> Game { get;set;}

        public IMongoDatabase contextMongo()
        {
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase("Gamestore");

            return database;

        }

    }
}
