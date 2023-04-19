using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using WebApplication123.Models;

namespace WebApplication123.Areas.UnAuthenticated.Controllers
{
    [Area(Utils.SD.UnAuthenticatedArea)]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            /*var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);*/

            // get the role of current signed in
            /*var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, "1234"),
                new Claim(ClaimTypes.Role, "Admin")
            };
            var identity = new ClaimsIdentity(claims, "MyAuthType");

            var roleClaim = claimsIdentity.FindFirst(ClaimTypes.Role);
            if (roleClaim == null)
            {
                return View();
            }

            string role = roleClaim.Value;
            ViewData["Message"] = "Hello " + role + "TO OUR STORE!";*/
            return View();
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