using Microsoft.AspNetCore.Identity;

namespace B2B.IdentityServer.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string StoreName { get; set; }
    }
}
