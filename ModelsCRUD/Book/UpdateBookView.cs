﻿using Microsoft.Build.Framework;

namespace BookStoreApp.ModelsCRUD.Book;

public class UpdateBookView
{
    public int BookId { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Quantity { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public DateTime UpdateDate { get; set; }
    [Required]
    public string Author { get; set; }
    [Required]
    public IFormFile Image { get; set; }
    [Required]
    public int CategoryId { get; set; }
    [Required]
    public int PublishCompanyId { get; set; }
}