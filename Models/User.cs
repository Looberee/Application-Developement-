﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace WebApplication123.Models
{
    public class User : IdentityUser

    {
    public User()
    {
        CreatedAt = DateTime.Now;
    }

    [Required] public string FullName { get; set; }
    [Required] public string Address { get; set; }
    [NotMapped] public string Role { get; set; }


    public DateTime CreatedAt { get; set; }
    public string CreatedBy { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string UpdatedBy { get; set; }
    public bool IsDelete { get; set; }
    }

}
