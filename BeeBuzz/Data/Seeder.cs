using BeeBuzz.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;

namespace BeeBuzz.Data
{
    public class Seeder
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _hosting;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public Seeder(ApplicationDbContext context,
            IWebHostEnvironment hosting,
            RoleManager<IdentityRole<int>> roleManager,
            UserManager<ApplicationUser> userManager)
        {
            _db = context;
            _hosting = hosting; 
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task Seed()
        {
            _db.Database.EnsureCreated();

            if (!_roleManager.Roles.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole<int>("Admin"));
                await _roleManager.CreateAsync(new IdentityRole<int>("Default"));
            }

            if (!_db.Users.Any())
            {
                //Create an admin user 
                var user = new ApplicationUser()
                {
                    Email = "defaultEmail@beebuzz.org",
                    UserName = "BeeBuzzAdmin"
                };
                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Admin");
                }

                //Add the new organization to the database
                Organization organization = new Organization()
                {
                    OrganizationId = "0000-0000-0000-0000",
                    Users = new List<ApplicationUser>() { user }
                };
                _db.Organizations.Add(organization);

                _db.SaveChanges();  //commit changes to the database (make permanent) 
            }
        }
    }
}
