using Microsoft.AspNetCore.Identity;
using UsersService.Model;

namespace UsersService.Data
{
    public class SeedData
    {

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var usermanager = serviceScope.ServiceProvider.GetService<UserManager<AppUser>>();

                var RoleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();


                if (!await RoleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await RoleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                }
                string admin1Email = "admin115@gmail.com";
                var admin1 = await usermanager.FindByEmailAsync(admin1Email);
                if (admin1 == null)
                {
                    var newadmin1 = new AppUser()
                    {
                        UserName = "admin1",
                        Email = admin1Email,
                        EmailConfirmed = true,
                    };
                    await usermanager.CreateAsync(newadmin1, "Coding@1234?");
                    await usermanager.AddToRoleAsync(newadmin1, UserRoles.Admin);
                }

            }
        }

    }
}
