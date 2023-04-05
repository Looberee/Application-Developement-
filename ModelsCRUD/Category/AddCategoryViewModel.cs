using System.ComponentModel.DataAnnotations;

namespace WebApplication123.ModelsCRUD.Category
{
    public class AddCategoryViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
