using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Shopping_list_website.Models
{
    public class ShoppingCartDbContext : DbContext
    {

        public ShoppingCartDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartLine> ShoppingCartLines { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Account>().HasData(
            new Account { Id = 1, Email = "a", Password = BCrypt.Net.BCrypt.EnhancedHashPassword("a"), SelectedCart = 1 },
            new Account { Id = 2, Email = "websiteman@mail.com", Password = BCrypt.Net.BCrypt.EnhancedHashPassword("a"), SelectedCart = 2 }
            );

            builder.Entity<ShoppingCart>().HasData(
                new ShoppingCart { Id = 1, AccountId = 1, DateCreated = DateTime.Now, Name = "Default" },
                new ShoppingCart { Id = 2, AccountId = 2, DateCreated = DateTime.Now, Name = "Default" });


            string data = File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Models/Data/ItemData.json"));

            JsonTextReader jsonReader = new JsonTextReader(new StringReader(data));
            JsonSerializer serializer = new JsonSerializer();

            Item[] itemData = serializer.Deserialize<Item[]>(jsonReader);
            builder.Entity<Item>().HasData(itemData);

        }

    }
}
