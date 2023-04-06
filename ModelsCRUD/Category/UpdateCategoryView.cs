using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.ModelsCRUD.Category
{
    public class UpdateCategoryView
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
