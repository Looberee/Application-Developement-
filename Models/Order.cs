using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BookStoreApp.Models;


namespace BookStoreApp.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        
        [Required] public string CustomerId { get; set; }
        [Required] public string Address { get; set; }
        [Required] public double Total { get; set; }
        [Required] public DateTime OrderDate { get; set; }

        [Required]
        
        [ForeignKey("CustomerId")] public ApplicationUser ApplicationUser { get; set; }
        
        
    }
}