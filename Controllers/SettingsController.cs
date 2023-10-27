using Microsoft.AspNetCore.Mvc;


namespace Shopping_list_website.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {

        [HttpPost("SetTheme")]
        public async Task<IActionResult> SetTheme([FromBody] ThemeSetting setting)
        {
            HttpContext.Session.SetString("Theme", setting.Theme);
            return Ok();
        }



        /// <summary>
        /// Used to extract the desired colour theme setting form our API calls
        /// </summary>
        public class ThemeSetting
        {
            public string Theme { get; set; }
        }
    }
}
