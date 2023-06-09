﻿using Microsoft.AspNetCore.Mvc;
using WebApplication123.Models;
using WebApplication123.Data;
using Microsoft.EntityFrameworkCore;
using WebApplication123.ModelsCRUD.PublishCompany;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using WebApplication123.Utils;

namespace WebApplication123.Controllers
{
    [Area(SD.AuthenticatedArea)]
    [Authorize(Roles = SD.StoreOwnerRole)]
    public class PublishCompanyController : Controller
	{
		private readonly ApplicationDbContext context;

		public PublishCompanyController(ApplicationDbContext context)
		{
			this.context = context;
		}
		[HttpGet]
		public async Task<IActionResult> CompanyIndex()
		{
			var company = await context.PublicCompanies.ToListAsync();
			return View(company);
		}
		[HttpGet]
		public IActionResult CreatePublishCompany()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreatePublishCompany(AddCompanyViewModel CompanyModel)
		{
			var company = new PublishCompany()
			{
				Name = CompanyModel.Name,
				Adress = CompanyModel.Adress,


			};

			await context.PublicCompanies.AddAsync(company);
			await context.SaveChangesAsync();
			return RedirectToAction("CompanyIndex");
		}
		[HttpGet]
		public async Task<IActionResult> ViewCompany(int id)
		{
			var company = await context.PublicCompanies.FirstOrDefaultAsync(x => x.PublishingCompanyId == id);

			if (company != null)
			{
				var viewmodel = new UpdateCompanyView()
				{
					PublishingCompanyId = company.PublishingCompanyId,
					Name = company.Name,
					Adress = company.Adress,
				};

				return await Task.Run(() => View("ViewCompany", viewmodel));
			}

			return RedirectToAction("CompanyIndex");
		}
		[HttpPost]
		public async Task<IActionResult> ViewCompany(UpdateCompanyView model)
		{
			var company = await context.PublicCompanies.FindAsync(model.PublishingCompanyId);
			if (company != null)
			{
				company.Name = model.Name;
				company.Adress = model.Adress;

				await context.SaveChangesAsync();

				return RedirectToAction("CompanyIndex");
			}

			return RedirectToAction("CompanyIndex");
		}
		[HttpPost]
		public async Task<IActionResult> DeleteCompany(UpdateCompanyView model)
		{
			var company = await context.PublicCompanies.FindAsync(model.PublishingCompanyId);

			if (company != null)
			{
				context.PublicCompanies.Remove(company);


				await context.SaveChangesAsync();

				return RedirectToAction("CompanyIndex");
			}

			return RedirectToAction("CompanyIndex");
		}
	}
}