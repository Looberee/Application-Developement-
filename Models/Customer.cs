using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }
        [Required]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string BirthDay { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
    }
}
