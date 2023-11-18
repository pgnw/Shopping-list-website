using Microsoft.AspNetCore.Mvc;

namespace Shopping_list_website.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "About";
            return View();
        }
    }
}
