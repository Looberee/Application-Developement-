using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebApplication123.Utils;
using WebApplication123.Data;
using Microsoft.EntityFrameworkCore;


namespace WebApplication123.Controllers
{
	[Area(SD.AuthenticatedArea)]
	[Authorize(Roles = SD.StoreOwnerRole + "," + SD.CustomerRole)]
	public class OrderController : Controller
    {
		private readonly ApplicationDbContext context;
		private readonly IWebHostEnvironment webHostEnvironment;

		public OrderController(ApplicationDbContext context, IWebHostEnvironment webHost)
		{
			this.context = context;
			webHostEnvironment = webHost;
		}
		[HttpGet]
        public IActionResult OrderIndex()
        {
            return View();
        }
	}
}
