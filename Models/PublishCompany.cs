using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.Models
{
    public class PublishCompany
    {
        [Key]
        public int PublishCompanyId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Adress { get; set; }
    }
}
