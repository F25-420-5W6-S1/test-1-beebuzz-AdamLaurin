namespace BeeBuzz.Data.Entities
{
    public class Organization
    {
        public string OrganizationId { get; set; }

        public string? Name { get; set; }

        public List<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
    }
}
