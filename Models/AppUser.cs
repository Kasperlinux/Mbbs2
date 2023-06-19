using Microsoft.AspNetCore.Identity;

namespace Mbbs2.Models
{
    public class AppUser :IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
