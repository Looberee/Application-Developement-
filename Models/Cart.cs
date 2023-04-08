using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MessagePack;

namespace BookStoreApp.Models;

public class Cart
{
    [System.ComponentModel.DataAnnotations.Key]public int CartId { get; set; }
    [Microsoft.Build.Framework.Required] public string CustomerId { get; set; }
    [Microsoft.Build.Framework.Required] public int BookId { get; set; }
    [Microsoft.Build.Framework.Required] public int Count { get; set; }

    [ForeignKey("CustomerId")] 
    private ApplicationUser ApplicationUser { get; set; }
    [ForeignKey("BookId")] public Book Book { get; set; }
    [NotMapped] public double Price { get; set; }

    public Cart()
    {
        Count = 1;
    }
}