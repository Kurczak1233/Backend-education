using Microsoft.AspNetCore.Identity;

namespace EntiryFramework.Database
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
