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
            ViewData["Title"] = "Shopping cart";

            try
            {
                string? user = HttpContext.Session.GetString("Username");

                // If the user has not logged in redirect back to home and store the error message in session, so the home controller can read it and then put it in viewbag and display it in html.
                if (user == null)
                {
                    HttpContext.Session.SetString("ErrorMsg", "Please log in to access the shopping cart page");
                    return Redirect("Home/Index");
                }

                // Get the user's account from the database.
                Account userAccount = _context.Accounts.Where(a => a.Email.Equals(user)).Include(u => u.ShoppingCarts).FirstOrDefault();

                return View(userAccount);
            }

            catch
            {

                return View(null);
            }


        }
        [HttpGet]
        public IActionResult GetPartialCartItems()
        {
            string? user = HttpContext.Session.GetString("Username");

            // Get the user's account from the database.
            Account? userAccount = _context.Accounts.Where(a => a.Email.Equals(user)).Include(a => a.ShoppingCarts).FirstOrDefault();


            if (userAccount != null)
            {
                // If the user account was found, find the users selected cart, include the lines and include the items from the lines.
                ShoppingCart? cart = _context.ShoppingCarts.Where(c => c.Id == userAccount.SelectedCart)
                    .Include(c => c.Lines)
                    .ThenInclude(l => l.Item)
                    .FirstOrDefault();

                // If a cart was found return a partial page to be displayed inside the main page.
                // The partial page being sent will display all the items inside the cart.
                if (cart != null)
                {
                    return PartialView("_CartItemsPartial", cart);
                }
                else
                {
                    // If the user does not have a selected cart try to set the user's selected cart to the first cart in the user's shopping carts.
                    var carts = _context.ShoppingCarts.Where(c => c.AccountId == userAccount.Id).Include(c => c.Lines).ThenInclude(l => l.Item);
                    if (carts != null)
                    {
                        cart = carts.FirstOrDefault();
                        userAccount.SelectedCart = cart.Id;
                        _context.SaveChanges();
                        return PartialView("_CartItemsPartial", cart);
                    }
                }

                return BadRequest("User does not have any carts");
            }

            return BadRequest("user not signed in");
        }

        [HttpGet]
        public IActionResult GetCartContents([FromQuery] int cartId)
        {
            // Extract the items out of the cart Id provided and send them to the partial view.

            // Get the cart, include the shopping cart lines, and the items from those lines.
            var cart = _context.ShoppingCarts.Where(c => c.Id == cartId).Include(c => c.Lines).ThenInclude(l => l.Item).FirstOrDefault();

            // Get the currently signed in user from session
            var userId = HttpContext.Session.GetInt32("UserId");
            var account = _context.Accounts.Find(userId);


            if (cart != null)
            {
                // Get all the items out of the cart and send them to the view.
                if (cart.Lines != null)
                {
                    return PartialView("_CartItemsPartialMultiColumn", cart);
                }
            }

            return PartialView("_CartItemsPartialMultiColumn", null);
        }

        [HttpPut]
        public IActionResult UpdateSelectedCart([FromQuery] int? cartId)
        {
            // Get the user from session
            var userId = HttpContext.Session.GetInt32("UserId");

            var account = _context.Accounts.Find(userId);

            // If the user is signed in update their selected cart with the one passed in to the method.
            if (account != null)
            {
                account.SelectedCart = cartId;
                _context.SaveChanges();
                return Ok("Selected cart updated");
            }

            return StatusCode(500, "Error user not signed in");
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
                    userAccount.ShoppingCarts = new List<ShoppingCart>();

                // Add the newly created cart to the user and save to database.
                userAccount.ShoppingCarts.Add(cart);
                _context.Update(userAccount);
                _context.SaveChanges();

                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete]
        public IActionResult DeleteShoppingCart([FromQuery] int? cartId)
        {
            if (cartId == null)
                return BadRequest();
            // Find the cart based off of it's id.
            var cart = _context.ShoppingCarts.Where(c => c.Id == cartId).FirstOrDefault();

            // Delete it
            _context.ShoppingCarts.Remove(cart);

            // Find the user who has the cart was their selected cart and remove it.
            var accountWithCart = _context.Accounts.Where(a => a.SelectedCart == cartId).FirstOrDefault();
            if (accountWithCart != null)
                accountWithCart.SelectedCart = null;

            _context.SaveChanges();

            return Ok("cart deleted");
        }

        [HttpPost]
        public IActionResult AddItem([FromQuery] int? itemId)
        {
            if (itemId == null)
                return BadRequest("No item id given");

            int? userId = HttpContext.Session.GetInt32("UserId");

            // Get the user's account from the database.
            Account userAccount = _context.Accounts.Find(userId);

            if (userAccount != null)
            {
                ShoppingCart? selectedCart = _context.ShoppingCarts.Find(userAccount.SelectedCart);

                if (selectedCart != null)
                {
                    // Get the Shopping cart line which connects the item being added and the selected cart if it exists.
                    var itemLine = _context.ShoppingCartLines.Where(l => l.ShoppingCartId == selectedCart.Id && l.ItemId == itemId).FirstOrDefault();

                    // If there is an existing item line increase it's quantity and return.
                    if (itemLine != null)
                    {
                        itemLine.Quantity++;
                        _context.SaveChanges();
                        return Ok();
                    }
                    // If there is not an already exisiting item line make a new one.
                    else
                    {
                        var newItemLine = new ShoppingCartLine();

                        newItemLine.ShoppingCartId = selectedCart.Id;
                        newItemLine.ItemId = (int)itemId;
                        newItemLine.Quantity = 1;

                        _context.ShoppingCartLines.Add(newItemLine);
                        _context.SaveChanges();
                        return Ok();
                    }
                }
                return BadRequest("No selected cart");
            }
            return BadRequest("User not logged in");
        }

        [HttpDelete]
        public IActionResult RemoveItem([FromQuery] int? itemId)
        {
            if (itemId == null)
                return BadRequest("No item id given");

            int? userId = HttpContext.Session.GetInt32("UserId");

            // Get the user's account from the database.
            Account userAccount = _context.Accounts.Find(userId);

            if (userAccount != null)
            {
                ShoppingCart? selectedCart = _context.ShoppingCarts.Find(userAccount.SelectedCart);

                if (selectedCart != null)
                {
                    // Get the Shopping cart line which connects the item being removed and the selected cart if it exists.
                    var itemLine = _context.ShoppingCartLines.Where(l => l.ShoppingCartId == selectedCart.Id && l.ItemId == itemId).FirstOrDefault();

                    // If there is an existing item line reduce it's quantity and return.
                    if (itemLine != null)
                    {
                        // If the shopping cart has two or more of the item reduce it by one.
                        if (itemLine.Quantity >= 2)
                            itemLine.Quantity--;
                        else
                        {
                            // Otherwise just remove it.
                            _context.Remove(itemLine);
                        }
                        _context.SaveChanges();
                        return Ok();
                    }
                    // If there is no shopping cart line just do nothing.
                    else
                    {
                        return Ok();
                    }
                }
                return BadRequest("No selected cart");
            }
            return BadRequest("User not logged in");
        }
    }
}
