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

    // IWebHostEnvironment will help you take the image path
    public BooksController(ApplicationDbContext db)
    {
        _db = db;
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
        return View();
    }
// Store Owner request to Admin Create
    public async Task<IActionResult> CreateBooks(AddBookViewModel BookModel)
    {
        var book = new Book()
        {
            Name = BookModel.Name,
            Quantity = BookModel.Quantity,
            Price = BookModel.Price,
            Description = BookModel.Description,
            Author = BookModel.Author,
            Image = BookModel.Image,
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

    [HttpPost("upload-image")]
    public async Task<IActionResult> UploadImage(IFormFile image)
    {
        // Code to handle uploaded image goes here
        if (image != null && image.Length > 0)
        {
            var fileName = image.FileName;
            var contentType = image.ContentType;
            var content = new byte[image.Length];
            await image.OpenReadStream().ReadAsync(content, 0, (int)image.Length);
        
            // Code to handle uploaded image goes here
        }
    
        // Handle case where no image was uploaded
        return RedirectToAction("BooksIndex");
    }
}

