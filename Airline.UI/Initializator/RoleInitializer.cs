using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using static Global_Logic_ASP.Core.Initializator.Constants;
namespace Global_Logic_ASP.Core.Initializator
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
           const string adminEmail = "Admin@gmail.com";
           const string password = "Admin@gmail.com1";
            if (await roleManager.FindByNameAsync(ADMIN) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(ADMIN));
            }
            if (await roleManager.FindByNameAsync(STUDENT) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(STUDENT));
            }

            if (await userManager.FindByNameAsync(adminEmail) == null) // Create new userAdmin if not exist
            {
                var admin = new IdentityUser { Email = adminEmail, UserName = adminEmail };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, ADMIN);
                }
            }
        }
    }
}
