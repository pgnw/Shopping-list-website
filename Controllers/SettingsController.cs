using Microsoft.AspNetCore.Mvc;


namespace Shopping_list_website.Controllers
{
    public class SettingsController : Controller
    {

        [HttpPost]
        public async Task<IActionResult> SetTheme([FromBody] ThemeSetting setting)
        {
            // Set the current theme based off what the request specified.
            HttpContext.Session.SetString("Theme", setting.Theme);
            return Ok();
        }

        [HttpGet]
        public string? GetTheme()
        {
            // Get the current theme from session and return it to the caller.
            string? theme = HttpContext.Session.GetString("Theme");

            return theme;
        }

        public IActionResult Index()
        {
            return View();
        }
    }

    // This class is used for mapping for the controller request.
    public class ThemeSetting
    {
        public string Theme { get; set; }
    }

}