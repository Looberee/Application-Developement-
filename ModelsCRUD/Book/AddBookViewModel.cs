using Microsoft.Build.Framework;

namespace BookStoreApp.ModelsCRUD.Book;

public class AddBookViewModel
{
    
    [Required]
    public string Name { get; set; }
    [Required]
    public string Quantity { get; set; }
    [Required]
    public double Price { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public DateTime UpdateDate { get; set; }
    [Required]
    public string Author { get; set; }
    [Required]
    public string Image { get; set; }
    [Required]
    public int CategoryId { get; set; }
    [Required]
    public int PublishCompanyId { get; set; }
}