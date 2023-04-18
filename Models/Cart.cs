using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication123.Models;


namespace WebApplication123.Models
{
	public class Cart
	{
		[Key]
		public int CartId { get; set; }
		[Required]
		public int Quantity { get; set; }
		[Required]
		public int BookId { get; set; }


		[ForeignKey("BookId")]
		public Book Book { get; set; }
        [Required]
        public decimal Total { get; set; }
    }
}
