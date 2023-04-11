using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebApplication123.Utils;

namespace WebApplication123.Controllers
{
    [Area(SD.AuthenticatedArea)]
    [Authorize(Roles = SD.StoreOwnerRole)]
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
