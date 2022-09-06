using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UsedBooks.Data;
using UsedBooks.Features.User;
using UsedBooks.Model;

public static class DbInitializer
{
    private static void CreateUsersAndRoles(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            // Create administrator roles
            var adminRole = new IdentityRole(Role.Admin);
            roleManager.CreateAsync(adminRole).Wait();

            // Create a user role
            var userRole = new IdentityRole(Role.User);
            roleManager.CreateAsync(userRole).Wait();

            // Create administrator users, username must be lowercase
            var admin = new ApplicationUser
            {
                FirstName = "Admin",
                LastName = "Jack",
                UserName = "admin",
                Email = "admin@mail.com",
                Role = Role.Admin
            };
            userManager.CreateAsync(admin, "Password1.").Wait();
            userManager.AddToRoleAsync(admin, Role.Admin).Wait();

            // Create user, username must be lowercase
            var user = new ApplicationUser
            {
                FirstName = "Mohamed",
                LastName = "Ali",
                UserName = "Moha",
                Email = "Moha@mail.com",
                Role = Role.User
            };
            userManager.CreateAsync(user, "Password1.").Wait();
            userManager.AddToRoleAsync(user, Role.User).Wait();
        }

    public static void Init(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager, bool development)
        {
            
            var engineering = new Faculty{Name = "Engineering"};
            var health = new Faculty{Name = "Health"};
            var economics= new Faculty{Name = "economy"};
            var other = new Faculty("other");
            var d1 = new Department("Data");
            var d2 = new Department("Elektro");
            var d3 = new Department("Bygg");
            var d4 = new Department("Mekatronikk");
            var nurse  = new Department("Sykepleie");
            var varnepleie = new Department("Varnepleie");
            context.Faculties.Add(engineering);
            context.Faculties.Add(health);
            context.Faculties.Add(economics);
            context.Faculties.Add(other);

            // initialise  Departments here.
            d1.Faculty = engineering;
            d2.Faculty = engineering;
            d3.Faculty = engineering;
            d4.Faculty = engineering;
           
            nurse.Faculty = health;
            varnepleie.Faculty = health;
            context.Departments.AddRange(d1,d2,d3,d4,nurse,varnepleie);

            //adding departments to Engeenering Fuculty
            engineering.Departments.Add(d1);
            engineering.Departments.Add(d2);
            engineering.Departments.Add(d3);
            engineering.Departments.Add(d4);
           
            // adding health departments 
            health.Departments.Add(nurse);
            health.Departments.Add(varnepleie);



            // Run migrations and add users if we're not in development mode
            if (!development)
            {
                context.Database.Migrate();

                // Only create users if no users exist
                if (!context.Users.Any())
                    CreateUsersAndRoles(userManager, roleManager);

                return;
            }

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            CreateUsersAndRoles(userManager, roleManager);
            context.SaveChangesAsync();
        }
}