namespace MyGameStore.Models
{
    public class GameStoreDatabaseSettings : IGameStoreDatabaseSettings
    {
        public string GameCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IGameStoreDatabaseSettings
    {
        string GameCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}