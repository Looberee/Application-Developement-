using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApp.ModelsCRUD.Book;

public class UpdateBookView
{
    public int BookId { get; set; }
    [Microsoft.Build.Framework.Required]
    public string Name { get; set; }
    [Microsoft.Build.Framework.Required]
    public string Quantity { get; set; }
    [Microsoft.Build.Framework.Required]
    public double Price { get; set; }
    [Microsoft.Build.Framework.Required]
    public string Description { get; set; }
    [Microsoft.Build.Framework.Required]
    public DateTime UpdateDate { get; set; }
    [Microsoft.Build.Framework.Required]
    public string Author { get; set; }
    [Microsoft.Build.Framework.Required]
    public string Image { get; set; }
    [Required(ErrorMessage = "Please choose Front image")]      
    [Display(Name = "Front Image")]
    [NotMapped]
    public IFormFile FronImage { get; set; }
    [Microsoft.Build.Framework.Required]
    public int CategoryId { get; set; }
    [Microsoft.Build.Framework.Required]
    public int PublishCompanyId { get; set; }
}