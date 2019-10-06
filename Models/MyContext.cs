using Microsoft.EntityFrameworkCore;

namespace DogScover.Models {
    public class MyContext : DbContext {
        public MyContext (DbContextOptions options) : base (options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Funder> Funders { get; set; }

    }
}