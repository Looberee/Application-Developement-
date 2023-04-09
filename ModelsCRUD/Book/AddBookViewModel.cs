﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApplication123.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication123.ModelsCRUD.Book
{
    public class AddBookViewModel
    {
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
        public Models.Category Category { get; set; }
        [ForeignKey("PublishCompanyId")]
        public Models.PublishCompany PublishCompany { get; set; }

        [Required(ErrorMessage = "Please choose Front image")]
        [Display(Name = "Front Image")]
        [NotMapped]
        public IFormFile FronImage { get; set; }
    }
}
