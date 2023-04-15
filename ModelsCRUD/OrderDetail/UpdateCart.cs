using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication123.Models;

namespace WebApplication123.ModelsCRUD.OrderDetail
{
	public class UpdateCart
	{
		[Required]
		public int Quantity { get; set; }
		[Required]
		public int BookId { get; set; }
		[ForeignKey("BookId")]
		public Models.Book Book { get; set; }
		[Required]
		public int OrderId { get; set; }
		[ForeignKey("OrderId")]
		public Order Order { get; set; }
	}
}
