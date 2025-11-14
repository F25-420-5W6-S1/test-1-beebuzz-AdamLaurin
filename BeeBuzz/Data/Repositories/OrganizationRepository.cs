using BeeBuzz.Data.Entities;
using BeeBuzz.Data.Interfaces;

namespace BeeBuzz.Data.Repositories
{
    public class OrganizationRepository: BeeBuzzGenericGenericRepository<Organization>, IOrganizationRepository
    {
        public OrganizationRepository(ApplicationDbContext db, ILogger<BeeBuzzGenericGenericRepository<Organization>> logger) : base(db, logger)
        {
        }

        public IEnumerable<ApplicationUser> GetUsersInOrganization(string organizationId)
        {
            return _dbSet.Where(o => o.OrganizationId == organizationId).First().Users;
        }
    }
}
