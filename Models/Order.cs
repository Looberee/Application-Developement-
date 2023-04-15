using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication123.Models;


namespace WebApplication123.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int CustomerId { get; set; }
        
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

    }
}