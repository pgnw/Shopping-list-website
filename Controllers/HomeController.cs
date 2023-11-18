using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shopping_list_website.Models;

namespace Shopping_list_website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ShoppingCartDbContext _context;

        public HomeController(ILogger<HomeController> logger, ShoppingCartDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // Set the title name in shared.
            ViewData["Title"] = "Home";

            // Displays an error message to the user.
            ViewBag.ErrorMessage = HttpContext.Session.GetString("ErrorMsg");
            // Used to welcome the user by name.
            ViewBag.Username = HttpContext.Session.GetString("Username");

            // Check if the user is signed in
            Account? account = _context.Accounts.Find(HttpContext.Session.GetInt32("UserId"));

            if (account != null)
            {
                // check if the user has selected an account, use eager loading to make it load the lines field in, and also load the items in from lines.
                var selectedCart = _context.ShoppingCarts
                   .Include(cart => cart.Lines)
                   .ThenInclude(line => line.Item)
                   .FirstOrDefault(cart => cart.Id == account.SelectedCart);

                if (selectedCart != null)
                {
                    // Give the view the selected carts name.
                    ViewData["SelectedCart"] = selectedCart.Name;

                    /*      // Old code used to display the users shopping cart items, which has been replaced with a modal.
                    if (selectedCart.Lines != null)
                    {
                        // Get the contents from selected cart.
                        var cartContents = selectedCart.Lines.Select(l => l.Item).ToList();

                        // Store the user's items and all the items into a tuple, to allow the view to display the users shopping cart contents aswell as the items that may be added.
                        Tuple<IEnumerable<Item>, IEnumerable<Item>> itemData = new Tuple<IEnumerable<Item>, IEnumerable<Item>>(_context.Items, cartContents);

                        return View(itemData);
                    }*/

                }
            }

            // Pass items into the view, the second value of the tuple used to be used for sending the items
            // inside the user's cart to the view aswell, but it was replaced by a modal.
            return View(new Tuple<IEnumerable<Item>, IEnumerable<Item>?>(_context.Items, null));

        }
        /*
        public IActionResult AddItemToCart([FromQuery] int? itemId)
        {
            if (itemId == null)
                return BadRequest("missing itemId");

            var userId = HttpContext.Session.GetInt32("UserId");

            // Find the currently logged in user.
            var account = _context.Accounts.Find(userId);

            // Check if the account has a shopping cart selected, if not return a bad request.
            if (account != null && account.SelectedCart != null)
            {
                // Get the selected item from the database using it's id
                var item = _context.Items.Find(itemId);

                try
                {
                    // Try to find a shopping cart line which connects the current shopping cart and the item being added.
                    var line = _context.ShoppingCartLines.Where(l => l.ItemId == itemId && l.ShoppingCartId == account.SelectedCart).FirstOrDefault();

                    // If a line already exists increase its quantity by one.
                    if (line != null)
                    {
                        line.Quantity += 1;
                    }
                    // Otherwise create a new shopping cart line to connect the shopping cart and the item.
                    else
                    {
                        // Make a new shopping cart line to connect the item with the shopping cart.
                        line = new ShoppingCartLine();
                        line.ShoppingCartId = (int)account.SelectedCart;
                        line.ItemId = item.Id;
                        line.Quantity = 1;
                        _context.Add(line);
                    }


                    _context.SaveChanges();

                    return Ok("Item added.");
                }

                catch
                {
                    return StatusCode(500, "Error adding item to shopping list.");

                }

            }
            else
                return BadRequest("No shopping cart selected.");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        */
    }
}