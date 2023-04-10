using BookStoreApp.Data;
using BookStoreApp.Models;
using BookStoreApp.ModelsCRUD;
using BookStoreApp.ModelsCRUD.Book;
using BookStoreApp.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Areas.Authenticated.Controllers;

[Area(SD.AuthenticatedArea)]



public class BooksController : Controller
{
    private readonly ApplicationDbContext _db;
    private readonly IWebHostEnvironment webHostEnvironment;

    // IWebHostEnvironment will help you take the image path
    public BooksController(ApplicationDbContext db, IWebHostEnvironment webHost)
    {
        _db = db;
        webHostEnvironment = webHost;
    }

    // GET
    // --------------------INDEX-------------------
    [HttpGet]
    public async Task<IActionResult> BooksIndex()
    {
        var book = await _db.Books.ToListAsync();
        return View(book);
    }

    [HttpGet]
    public IActionResult CreateBooks()
    {
        ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
        ViewBag.PublishCompanyId = new SelectList(_db.PublishCompanies, "PublishCompanyId", "Name");
        return View();
    }
// Store Owner request to Admin Create
[HttpPost]
    public async Task<IActionResult> CreateBooks(AddBookViewModel BookModel)
    {
        ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name", BookModel.CategoryId);
        ViewBag.PublishCompanyId = new SelectList(_db.PublishCompanies, "PublishingCompanyId", "Name", BookModel.PublishCompanyId);
        string uniqueFileName = UploadedFile(BookModel);
        var book = new Book()
        {
            Name = BookModel.Name,
            Quantity = BookModel.Quantity,
            Price = BookModel.Price,
            Description = BookModel.Description,
            Author = BookModel.Author,
            Image = uniqueFileName,
            UpdateDate = BookModel.UpdateDate,
            CategoryId = BookModel.CategoryId,
            PublishCompanyId = BookModel.PublishCompanyId
        };
        foreach (var bookitem in _db.Books.ToList())
        {
            if (book.Name == bookitem.Name)
            {
                var NewQuantity = bookitem.Quantity.ToString();
                var StoredQuantity = book.Quantity.ToString();
                int ToStoredQuantity = int.Parse(StoredQuantity) + int.Parse(NewQuantity);
                bookitem.Quantity = ToStoredQuantity.ToString();
                await _db.SaveChangesAsync();
                return RedirectToAction("BooksIndex");
            }
        }


        await _db.Books.AddAsync(book);
        await _db.SaveChangesAsync();
        return RedirectToAction("BooksIndex");
    }

    [HttpGet]
    public async Task<IActionResult> ViewBooks(int id)
    {
        
        var books = await _db.Books.FirstOrDefaultAsync(x => x.BookId == id);
        

        if (books != null)
        {
            var viewmodel = new UpdateBookView()
            {
                BookId = books.BookId,
                Name = books.Name,
                Quantity = books.Quantity,
                Price = books.Price,
                Description = books.Description,
                Author = books.Author,
                Image = books.Image,
                UpdateDate = books.UpdateDate,
                CategoryId = books.CategoryId,
                PublishCompanyId = books.PublishCompanyId

            };

            return await Task.Run(() => View("ViewBooks", viewmodel));
        }

        return RedirectToAction("BooksIndex");
    }

    [HttpPost]
    public async Task<IActionResult> ViewBooks(UpdateBookView model)
    {
        ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name", model.CategoryId);
        ViewBag.PublishCompanyId = new SelectList(_db.PublishCompanies, "PublishingCompanyId", "Name", model.PublishCompanyId);
        string uniqueFileName = UploadedFile(model);
        var book = await _db.Books.FindAsync(model.BookId);
        if (book != null)
        {
            book.Name = model.Name;
            book.Description = model.Description;

            await _db.SaveChangesAsync();

            return RedirectToAction("BooksIndex");
        }

        return RedirectToAction("BooksIndex");
    }

    [HttpPost]
    public async Task<IActionResult> DeleteBook(UpdateBookView model)
    {
        var book = await _db.Books.FindAsync(model.BookId);

        if (book != null)
        {
            _db.Books.Remove(book);


            await _db.SaveChangesAsync();

            return RedirectToAction("BooksIndex");
        }

        return RedirectToAction("BooksIndex");
    }

    private string UploadedFile(AddBookViewModel model)
    {
        string uniqueFileName = null;
            
        if (model.FronImage != null)
        {
            string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + model.FronImage.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                model.FronImage.CopyTo(fileStream);
            }

        }
        return uniqueFileName;
    }
    private string UploadedFile(UpdateBookView model)
    {
        string uniqueFileName = null;
            
        if (model.FronImage != null)
        {
            string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "Images");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + model.FronImage.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                model.FronImage.CopyTo(fileStream);
            }

        }
        return uniqueFileName;
    }
    
}

