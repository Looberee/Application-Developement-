using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication123.Models;

namespace WebApplication123.Models
{
    public class PublishCompany
    {
        [Key]
        public int PublishingCompanyId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Adress { get; set; }
    }
}
