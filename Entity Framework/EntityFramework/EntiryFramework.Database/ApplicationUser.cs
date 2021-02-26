using Microsoft.AspNetCore.Identity;

namespace EntiryFramework.Database
{
    public class ApplicationUser : IdentityUser
    {
        public string City { get; set; }
    }
}
