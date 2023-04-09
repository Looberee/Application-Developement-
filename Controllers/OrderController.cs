using Microsoft.AspNetCore.Mvc;

namespace WebApplication123.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet]
        public IActionResult OrderIndex()
        {
            return View();
        }
        [HttpPost]
		public IActionResult RenderCustomerOrder()
		{
			return View();
		}
	}
}
