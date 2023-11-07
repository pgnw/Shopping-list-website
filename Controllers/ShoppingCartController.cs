using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping_list_website.Models;

namespace Shopping_list_website.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ShoppingCartDbContext _context;
        public ShoppingCartController(ShoppingCartDbContext context) { _context = context; }
        public IActionResult Index()
        {
            string? user = HttpContext.Session.GetString("Username");

            // If the user has not logged in redirect back to home and store the error message in session, so the home controller can read it and then put it in viewbag and display it in html.
            if (user == null)
            {
                HttpContext.Session.SetString("ErrorMsg", "Please log in to access the shopping cart page");
                return Redirect("Home/Index");
            }

            // Get the user's account from the database and sent it to the view.
            Account userAccount = _context.Accounts.Where(a => a.Email.Equals(user)).Include(u => u.ShoppingCarts).FirstOrDefault();


            return View(userAccount);
        }

        [HttpPost]
        public IActionResult GetCartContents([FromQuery] int cartId)
        {
            // Extract the items out of the cart Id provided and send them to the partial view.

            var cart = _context.ShoppingCarts.Where(c => c.Id == cartId).FirstOrDefault();

            if (cart != null)
            {
                var lines = cart.Lines;
                if (lines != null)
                {
                    var items = lines.Select(l => l.Item).ToList();
                    return PartialView("_CartItemsPartial", items);
                }
            }

            return PartialView("_CartItemsPartial", null);
        }
        [HttpPost]
        public IActionResult MakeNewShoppingCart([FromQuery] string cartName)
        {
            if (cartName == null)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                //Create a new shopping based off of the name the user gave it.
                var cart = new ShoppingCart();
                cart.Name = cartName;

                // Get the account of the user who made the cart.
                string username = HttpContext.Session.GetString("Username");

                var userAccount = _context.Accounts.Where(a => a.Email.Equals(username)).FirstOrDefault();


                // Set the created date to now.
                cart.DateCreated = DateTime.Now;

                // Add the cart to the database
                _context.ShoppingCarts.Add(cart);

                // Link the cart up with it's owner
                cart.AccountId = userAccount.Id;
                cart.Account = userAccount;

                if (userAccount.ShoppingCarts == null)
                {
                    userAccount.ShoppingCarts = new List<ShoppingCart>();
                }

                userAccount.ShoppingCarts.Add(cart);

                _context.Update(userAccount);


                _context.SaveChanges();

                return Ok();
            }

            return BadRequest();
        }

        public IActionResult DeleteShoppingCart([FromQuery] int? cartId)
        {
            if (cartId == null)
                return BadRequest();
            // Find the cart based off of it's id.
            var cart = _context.ShoppingCarts.Where(c => c.Id == cartId).FirstOrDefault();

            // Delete it
            _context.ShoppingCarts.Remove(cart);
            _context.SaveChanges();

            return Ok("cart deleted");
        }
    }
}
