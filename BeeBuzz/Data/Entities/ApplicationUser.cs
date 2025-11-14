using Microsoft.AspNetCore.Identity;

namespace BeeBuzz.Data.Entities
{
    public class ApplicationUser : IdentityUser<int>
    {
        public List<Beehive> Beehives { get; set; } = new List<Beehive>();

        public string? OrganizationId { get; set; }
    }
}
