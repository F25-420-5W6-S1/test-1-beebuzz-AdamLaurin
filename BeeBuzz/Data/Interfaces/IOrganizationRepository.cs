using BeeBuzz.Data.Entities;

namespace BeeBuzz.Data.Interfaces
{
    public interface IOrganizationRepository : IBeeBuzzGenericRepository<Organization>
    {
        IEnumerable<ApplicationUser> GetUsersInOrganization(string organizationId);
        IEnumerable<Beehive> GetBeehivesInOrganization(string organizationId);
    }
}
