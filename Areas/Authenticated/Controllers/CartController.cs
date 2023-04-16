using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApplication123.Data;
using WebApplication123.Models;
using WebApplication123.Utils;

namespace WebApplication123.Areas.Authenticated.Controllers
{
	[Area(SD.AuthenticatedArea)]
	[Authorize(Roles = SD.StoreOwnerRole + "," + SD.CustomerRole)]
	public class CartController : Controller
	{
		private readonly ApplicationDbContext context;
		private readonly IWebHostEnvironment webHostEnvironment;

		public CartController(ApplicationDbContext context, IWebHostEnvironment webHost)
		{
			this.context = context;
			webHostEnvironment = webHost;
		}
		public async Task<IActionResult> CartIndex()
		{
			var cartitem = await context.Carts.Include(_ => _.Book).ToListAsync();
			return View(cartitem);
		}

		public async Task<IActionResult> AddToCart(int id)
		{
			var book = await context.Books.FirstOrDefaultAsync(x => x.BookId == id);
			if (book != null) 
			{
				var cart_item = new Cart()
				{
					BookId = book.BookId,
					Book = book,
					Quantity = 10
				};

				foreach (var item in context.Carts.Include(_ => _.Book).ToList()) 
				{
					if (item.BookId == cart_item.BookId)
					{
						Thread.Sleep(5000);
						return RedirectToAction("CartIndex");
					}
				}
				
				await context.Carts.AddAsync(cart_item);
				await context.SaveChangesAsync();

				Thread.Sleep(2500);
				return RedirectToAction("BookProduct", "Book");
				
				

				
			}

			return RedirectToAction("CartIndex");
		}
	}
}
