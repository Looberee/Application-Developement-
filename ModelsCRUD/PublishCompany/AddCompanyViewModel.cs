using System.ComponentModel.DataAnnotations;

namespace WebApplication123.ModelsCRUD.PublishCompany
{
	public class AddCompanyViewModel
	{
		[Required]
		public string Name { get; set; }
		[Required]
		public string Adress { get; set; }
	}
}
