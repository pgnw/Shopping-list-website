
using System.ComponentModel.DataAnnotations;

namespace Shopping_list_website.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        [Required]
        public int AccountId { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 1)]
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }


        public virtual Account Account { get; set; }
        public virtual ICollection<ShoppingCartLine> Lines { get; set; }
    }
}
