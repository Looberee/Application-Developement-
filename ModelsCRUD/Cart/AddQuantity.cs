using System.ComponentModel.DataAnnotations;

namespace WebApplication123.ModelsCRUD.Cart
{
	public class AddQuantity
	{
		[Required]
		public int Quantity { get; set; }
	}
}
