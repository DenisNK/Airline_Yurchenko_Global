using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using static Airline.DAL.Initializator.Constants;
namespace Airline.DAL.Initializator
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            const string adminEmail = "Admin@gmail.com";
            const string adminPassword = "Admin@gmail.com1"; 
            
            const string dispatcherEmail = "Dispatcher@gmail.com";
            const string dispatcherPassword = "Dispatcher@gmail.com1"; 

            const string dispatcher2Email = "Dispatcher2@gmail.com";
            const string dispatcher2Password = "Dispatcher2@gmail.com1";

            if (await roleManager.FindByNameAsync(ADMIN) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(ADMIN));
            }
            if (await roleManager.FindByNameAsync(USER) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(USER));
            }
            if (await roleManager.FindByNameAsync(DISPATCHER) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(DISPATCHER));
            }

            if (await userManager.FindByNameAsync(adminEmail) == null) // Create new userAdmin if not exist
            {
                var admin = new IdentityUser { Email = adminEmail, UserName = adminEmail };
                IdentityResult result = await userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, ADMIN);
                }
            }

            if (await userManager.FindByNameAsync(dispatcherEmail) == null) // Create new dispatcher if not exist
            {
                var dispatcher = new IdentityUser { Email = dispatcherEmail, UserName = dispatcherEmail};
                IdentityResult result = await userManager.CreateAsync(dispatcher, dispatcherPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(dispatcher, DISPATCHER);
                }
            }

            if (await userManager.FindByNameAsync(dispatcher2Email) == null) // Create new dispatcher if not exist
            {
                var dispatcher2 = new IdentityUser { Email = dispatcher2Email, UserName = dispatcher2Email };
                IdentityResult result = await userManager.CreateAsync(dispatcher2, dispatcher2Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(dispatcher2, DISPATCHER);
                }
            }
        }
    }
}
