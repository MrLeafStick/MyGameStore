using Microsoft.EntityFrameworkCore;
using MyGameStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGameStore.Data
{
    public class MyGameStoreContext : DbContext
    {
        public MyGameStoreContext(
            DbContextOptions<MyGameStoreContext> options) 
            : base(options)
        {
        }

        public DbSet<Game> Game { get;set;}

    }
}
