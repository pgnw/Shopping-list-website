using Microsoft.EntityFrameworkCore;

namespace Shopping_list_website.Models
{
    public class ShoppingCartDbContext : DbContext
    {

        public ShoppingCartDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Account> accounts { get; set; }
        public DbSet<ShoppingCart> shoppingCarts { get; set; }
        public DbSet<ShoppingCartLine> shoppingCartLines { get; set; }
        public DbSet<Item> items { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Account>().HasData(
            new Account { Id = 1, Email = "a", Password = "a" },
            new Account { Id = 2, Email = "websiteman@mail.com", Password = "a" }
            );

            string data = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Models/Data/ItemData.json"));
            Console.WriteLine(data ?? "no data");



        }

    }
}
