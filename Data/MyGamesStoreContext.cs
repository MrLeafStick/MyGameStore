using Microsoft.EntityFrameworkCore;
using MyGamesStore.Models;

namespace MyGamesStore.Data
{
    public class MyGamesStoreContext : DbContext
    {
        public MyGamesStoreContext(DbContextOptions<MyGamesStoreContext> options) : base(options)
        {

        }

        public DbSet<Game> Game { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<OrderLineModel> OrderLines { get; set; }
        public DbSet<ShipmentModel> Shipments { get; set; }
        public DbSet<ProductModel> Products { get; set; }
    }

}