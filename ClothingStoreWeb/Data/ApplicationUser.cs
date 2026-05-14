using Microsoft.AspNetCore.Identity;

namespace ClothingStoreWeb.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string? UserFullName { get; set; }
    }

}
