using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication123.Models;

namespace WebApplication123.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public string Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
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


        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        [ForeignKey("PublishCompanyId")] 
        public PublishCompany PublishCompany { get; set; }


    }
}
