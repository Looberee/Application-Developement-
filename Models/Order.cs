using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BookStoreApp.Models;


namespace BookStoreApp.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public string OrderDate { get; set; }
        [Required]
        public string DeliveryDate { get; set; }
        [Required]
        public int CustomerId { get; set; }
        
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

    }
}