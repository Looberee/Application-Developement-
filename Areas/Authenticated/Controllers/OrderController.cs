﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebApplication123.Utils;
using WebApplication123.Data;
using Microsoft.EntityFrameworkCore;
using WebApplication123.Models;
using System.Security.Claims;

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
        public async Task<IActionResult> OrderIndex()
        {
			var order_customer_detail = await context.OrderDetails.Include(_ => _.Book).Include(_ => _.Order).ThenInclude(_ => _.User).ToListAsync();
			return View(order_customer_detail);	
        }

        public async Task<IActionResult> OrderBook()
		{

			var identity = (ClaimsIdentity)User.Identity;
			var claims = identity.FindFirst(ClaimTypes.NameIdentifier);

			var user = await context.ApplicationUsers.FindAsync(claims.Value);

			var customer = new Customer()
			{
				UserId = user.Id,
				Name  = user.FullName,
				Email = user.Email,
				Address = user.Address,
				User = user
			};

			await context.Customers.AddAsync(customer);
			await context.SaveChangesAsync();

			var order = new Order()
			{
				UserId = user.Id
			};

			await context.Orders.AddAsync(order);
			await context.SaveChangesAsync();


			var order_list = await context.Carts.Include(x => x.Book).ToListAsync();

			foreach (var book in order_list)
			{
				var book_object = await context.Carts.Include(x => x.Book).FirstOrDefaultAsync(x => x.BookId == book.BookId);
				var orderDetail = new OrderDetail()
				{
					Quantity = book.Quantity,
					BookId = book.BookId,
					OrderId = order.OrderId,
					Book = book_object.Book,
					Total = book.Total
				};

				await context.AddAsync(orderDetail);
				await context.SaveChangesAsync();
			}

			foreach (var book in order_list)
			{
				context.Carts.Remove(book);
				await context.SaveChangesAsync();
			}


			await context.SaveChangesAsync();
			return RedirectToAction("BookProduct", "Book");
		}

    }
}
