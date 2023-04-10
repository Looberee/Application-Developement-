using Microsoft.Build.Framework;

namespace BookStoreApp.ModelsCRUD.Customer;

public class UpdateCustomerView
{
    public int CustomerId { get; set; }

    [Microsoft.Build.Framework.Required]
    public string Name { get; set; }
    
    [Microsoft.Build.Framework.Required]
    public string Email { get; set; }

    [Microsoft.Build.Framework.Required]
    public string Address { get; set; }
    
    
}