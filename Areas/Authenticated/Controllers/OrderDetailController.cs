using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApplication123.Data;
using WebApplication123.Models;
using WebApplication123.ModelsCRUD.OrderDetail;
using WebApplication123.Utils;

namespace WebApplication123.Areas.Authenticated.Controllers
{
	[Area(SD.AuthenticatedArea)]
	[Authorize(Roles = SD.StoreOwnerRole + "," + SD.CustomerRole)]
	public class OrderDetailController : Controller
	{
		private readonly ApplicationDbContext context;
		private readonly IWebHostEnvironment webHostEnvironment;

		public OrderDetailController(ApplicationDbContext context, IWebHostEnvironment webHost)
		{
			this.context = context;
			webHostEnvironment = webHost;
		}
		[HttpGet]
		public async Task<IActionResult> CartIndex()
		{
			var orderDetail = await context.OrderDetails.ToListAsync();
			return View(orderDetail);
		}
		public async Task<IActionResult> AddToCart(int id, UpdateCart uc)
		{
			var book = await context.Books.FirstOrDefaultAsync(x => x.BookId == id);
			if (book != null)
			{
				var CartOrder = new OrderDetail()
				{
					BookId = book.BookId,
					Quantity = 10,
					Book = book,
					OrderId = id
				};

				await context.OrderDetails.AddAsync(CartOrder);
				await context.SaveChangesAsync();
				Thread.Sleep(2000);
				return RedirectToAction("BookProduct", "Book");
			}
			Thread.Sleep(2000);
			return RedirectToAction("CartIndex", "OrderDetail");

		}
	}
}
