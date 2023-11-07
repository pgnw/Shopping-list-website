namespace Shopping_list_website.Models
{
    public class ShoppingCartLine
    {
        public int Id { get; set; }
        public int ShoppingCartId { get; set; }
        public int ItemId { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }
        public virtual Item Item { get; set; }
    }
}
