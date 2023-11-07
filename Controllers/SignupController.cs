using Microsoft.AspNetCore.Mvc;
using Shopping_list_website.Models;

namespace Shopping_list_website.Controllers
{
    public class SignupController : Controller
    {
        readonly private ShoppingCartDbContext _context;
        public SignupController(ShoppingCartDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return PartialView("_SignupPartial");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Signup([FromBody] Account signup)
        {
            if (signup == null)
                return BadRequest("null data");

            // Check if the email has already been used.
            bool emailExists = _context.Accounts.Select(a => a.Email == signup.Email).FirstOrDefault();
            if (emailExists)
            {
                return BadRequest("Email already in use.");
            }

            ModelState.Remove("ShoppingCarts");

            // If nothing is wrong with the new account save it to the database.
            if (ModelState.IsValid)
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        _context.Add(signup);
                        _context.SaveChanges();

                        var signupWithId = _context.Accounts.Where(a => a.Email.Equals(signup.Email)).FirstOrDefault();

                        // Create a default shopping cart for the new user.
                        var defaultCart = new ShoppingCart();

                        defaultCart.Name = "Default";
                        defaultCart.AccountId = signupWithId.Id;
                        defaultCart.DateCreated = DateTime.Now;
                        defaultCart.Lines = new List<ShoppingCartLine>();
                        defaultCart.Account = signupWithId;
                        _context.Add(defaultCart);
                        _context.SaveChanges();

                        var defaultCartWithId = _context.ShoppingCarts.Where(c => c.Name.Equals(defaultCart.Name));

                        signupWithId.ShoppingCarts.Add(defaultCart);

                        _context.SaveChanges();
                        signupWithId.SelectedCart = signupWithId.ShoppingCarts.FirstOrDefault().Id;
                        _context.SaveChanges();


                        transaction.Commit();

                        return Ok("New account created");
                    }

                    catch
                    {
                        transaction.Rollback();
                        return StatusCode(500, "An error has occured while creating a new account.");
                    }
                }


            }


            return BadRequest("Something went wrong with creating a new account");
        }
    }
}