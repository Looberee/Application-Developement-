using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace WebApplication123.ModelsCRUD.User;

public class ResetPasswordViewModel : IEnumerable
{
    [Required] [EmailAddress] public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Password and confirm password must match")]
    public string ConfirmPassword { get; set; }

    public string Token { get; set; }
    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }
}