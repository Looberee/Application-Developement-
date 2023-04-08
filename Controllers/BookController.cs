using Microsoft.AspNetCore.Mvc;
using WebApplication123.Models;
using WebApplication123.Data;
using Microsoft.EntityFrameworkCore;
using WebApplication123.ModelsCRUD.Book;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication123.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public BookController(ApplicationDbContext context, IWebHostEnvironment webHost)
        {
            this.context = context;
            webHostEnvironment = webHost;
        }
        [HttpGet]
        public async Task<IActionResult> BookIndex()
        {
            var book = await context.Books.ToListAsync();
            return View(book);
        }
        [HttpGet]
        public IActionResult CreateBook()
        {
            ViewBag.Category_id = new SelectList(context.Categories, "CategoryId", "Name");
            ViewBag.Company_id = new SelectList(context.PublicCompanies, "PublishingCompanyId", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBook(AddBookViewModel BookModel, IFormFile uploadedImage)
        {
            ViewBag.Category_id = new SelectList(context.Categories, "CategoryId", "Name", BookModel.CategoryId);
            ViewBag.Company_id = new SelectList(context.PublicCompanies, "PublishingCompanyId", "Name", BookModel.PublishCompanyId);

            var book = new Book()
            {
                Name = BookModel.Name,
                Quantity = BookModel.Quantity,
                Price = BookModel.Price,
                Description = BookModel.Description,
                UpdateDate = BookModel.UpdateDate,
                Author = BookModel.Author,
                Image = BookModel.Image,
                CategoryId = BookModel.CategoryId,
                PublishCompanyId = BookModel.PublishCompanyId,
                Category = BookModel.Category,
                PublishCompany = BookModel.PublishCompany
            };
            

            foreach (var bookitem in context.Books.ToList())
            {
                if (book.Name == bookitem.Name)
                {
                        var NewQuantity = bookitem.Quantity.ToString();
                        var StoredQuantity = book.Quantity.ToString();
                        int ToStoredQuantity = int.Parse(StoredQuantity) + int.Parse(NewQuantity);
                        bookitem.Quantity = ToStoredQuantity.ToString();
                        await context.SaveChangesAsync();
                        return RedirectToAction("BookIndex");
                }
            }

            await context.Books.AddAsync(book);
            await context.SaveChangesAsync();
            return RedirectToAction("BookIndex");
            
            
            
     
        }
        [HttpGet]
        public async Task<IActionResult> ViewBook(int id)
        {
            var book = await context.Books.FirstOrDefaultAsync(x => x.BookId == id);

            if (book != null)
            {
                var viewmodel = new UpdateBookView()
                {
                    BookId = book.BookId,
                    Name = book.Name,
                    Quantity = book.Quantity,
                    Price = book.Price,
                    Description = book.Description,
                    UpdateDate = book.UpdateDate,
                    Author = book.Author,
                    Image = book.Image,
                    CategoryId = book.CategoryId,
                    PublishCompanyId = book.PublishCompanyId

                };

                return await Task.Run(() => View("ViewBook", viewmodel));
            }

            return RedirectToAction("BookIndex");
        }
        [HttpPost]
        public async Task<IActionResult> ViewBook(UpdateBookView model)
        {
            var book = await context.Books.FindAsync(model.BookId);
            if (book != null)
            {
                book.Name = model.Name;
                book.Quantity = model.Quantity;
                book.Price = model.Price;
                book.Description = model.Description;
                book.UpdateDate = model.UpdateDate;
                book.Author = model.Author;
                book.Image = model.Image;
                book.CategoryId = model.CategoryId;
                book.PublishCompanyId = model.PublishCompanyId;

                await context.SaveChangesAsync();

                return RedirectToAction("BookIndex");
            }

            return RedirectToAction("BookIndex");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteBook(UpdateBookView model)
        {
            var book = await context.Books.FindAsync(model.BookId);

            if (book != null)
            {
                context.Books.Remove(book);


                await context.SaveChangesAsync();

                return RedirectToAction("BookIndex");
            }

            return RedirectToAction("BookIndex");
        }
       

    }
}
