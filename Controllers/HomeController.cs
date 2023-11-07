using Microsoft.AspNetCore.Mvc;
using Shopping_list_website.Models;
using System.Diagnostics;

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

            // Displays an error message to the user.
            ViewBag.ErrorMessage = HttpContext.Session.GetString("ErrorMsg");
            // Used to welcome the user by name.
            ViewBag.Username = HttpContext.Session.GetString("Username");



            Account? account = _context.Accounts.Find(HttpContext.Session.GetInt32("UserId"));

            if (account != null)
            {
                // Get the users selected cart of the database and sent it to the view.
                var selectedCart = _context.ShoppingCarts.Find(account.SelectedCart);


                ViewData["SelectedCart"] = selectedCart;
            }


            return View(_context.Items);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}