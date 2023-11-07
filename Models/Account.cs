
using System.ComponentModel.DataAnnotations;

namespace Shopping_list_website.Models
{
    public class Account
    {

        //TODO uncomment before submiting
        public int Id { get; set; }
        [Required]
        //[StringLength(maximumLength: 20, MinimumLength = 4)]
        public string Email { get; set; }
        [Required]
        // [StringLength(maximumLength: 20, MinimumLength = 8)]
        public string Password { get; set; }

        // This field is used to hold the key of the shopping cart the user has selected.
        public int? SelectedCart { get; set; }

        public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; }

    }
}
