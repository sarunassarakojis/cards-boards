using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GossipBoard.Models.Client
{
    public class ApplicationUser : IdentityUser
    {
        public User User { get; set; }
    }
}
