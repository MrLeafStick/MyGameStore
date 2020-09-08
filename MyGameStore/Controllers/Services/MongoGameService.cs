using MongoDB.Bson;
using MongoDB.Driver;
using MyGameStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGameStore.Controllers.Services
{
    public class MongoGameService
    {
        private readonly IMongoCollection<GameModelMongo> _game;

        public MongoGameService(IGameStoreDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _game = database.GetCollection<GameModelMongo>(settings.GameCollectionName);
        }

        public List<GameModelMongo> Get() =>
           _game.Find(game => true).ToList();

        public GameModelMongo Get(ObjectId id) =>
            _game.Find<GameModelMongo>(game => game.Id == id).FirstOrDefault();

        public GameModelMongo Create(GameModelMongo game)
        {
            _game.InsertOne(game);
            return game;
        }

        public void Update(ObjectId id, GameModelMongo gameIn) =>
            _game.ReplaceOne(game => game.Id == id, gameIn);

        public void Remove(GameModelMongo bookIn) =>
            _game.DeleteOne(book => book.Id == bookIn.Id);

        public void Remove(ObjectId id) =>
            _game.DeleteOne(book => book.Id == id);

    }
}
