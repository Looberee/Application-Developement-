using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.ModelsCRUD.Category
{
    public class AddCategoryViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
