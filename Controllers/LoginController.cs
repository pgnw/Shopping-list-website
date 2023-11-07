using Microsoft.AspNetCore.Mvc;
using Shopping_list_website.Models;
namespace Shopping_list_website.Controllers
{
    public class LoginController : Controller
    {
        private readonly ShoppingCartDbContext _context;

        public LoginController(ShoppingCartDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return PartialView("_LoginPartial");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([FromBody] Account login)
        {
            if (login == null)
                return BadRequest("null data");

            ModelState.Remove("ShoppingCarts");

            if (ModelState.IsValid)
            {
                // Go through every user
                foreach (Account user in _context.Accounts)
                {
                    // If the username matches one found in the database:
                    if (login.Email.Equals(user.Email))
                    {
                        // Verify that the password matches too
                        if (login.Password.Equals(user.Password))
                        {
                            // Save the user's username and Id to the session.
                            HttpContext.Session.SetString("Username", login.Email);
                            HttpContext.Session.SetInt32("UserId", user.Id);

                            HttpContext.Session.SetString("ErrorMsg", "");


                            return Ok();
                        }
                    }

                }
            }

            ViewBag.LoginMessage = "Incorrect Password";

            return BadRequest("Incorrect username or password");

        }
    }
}
