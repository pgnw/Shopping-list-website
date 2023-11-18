using System.ComponentModel.DataAnnotations;

namespace Shopping_list_website.Models
{
    public class ShoppingCartLine
    {
        public int Id { get; set; }
        [Required]
        public int ShoppingCartId { get; set; }
        [Required]
        public int ItemId { get; set; }
        public int Quantity { get; set; }

        public virtual ShoppingCart ShoppingCart { get; set; }
        public virtual Item Item { get; set; }

        public ShoppingCartLine()
        {

        }
        public ShoppingCartLine(int shoppingcartId)
        {
            this.ShoppingCartId = shoppingcartId;
        }
    }
}
