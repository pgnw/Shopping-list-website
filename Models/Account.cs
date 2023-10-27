using Microsoft.Build.Framework;

namespace Shopping_list_website.Models
{
    public class Account
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }

    }
}
