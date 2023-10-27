namespace Shopping_list_website.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int AccountId { get; set; }

        public virtual Account account { get; set; }

        public virtual ICollection<ShoppingCartLine> Lines { get; set; }
    }
}
