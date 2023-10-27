namespace Shopping_list_website.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<ShoppingCartLine> ShoppingCarts { get; set; }
    }
}
