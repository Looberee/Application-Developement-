using Microsoft.Build.Framework;

namespace BookStoreApp.ModelsCRUD.StoreOwner;

public class UpdateStoreOwnerView
{
    public int StoreOwnerId { get; set; }

    [Microsoft.Build.Framework.Required]
    public string Name { get; set; }
    
    [Microsoft.Build.Framework.Required]
    public string Email { get; set; }

    [Microsoft.Build.Framework.Required]
    public string Address { get; set; }
    
    
}