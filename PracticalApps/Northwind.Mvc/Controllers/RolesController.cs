using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Northwind.Mvc.Controllers;

public class RolesController : Controller
{
    private string AdminRole = "Administrators";
    private string UserEmail = "test@example.com";
    private readonly RoleManager<IdentityRole> roleManager;
    private readonly UserManager<IdentityUser> userManager;

    public RolesController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
    {
        this.roleManager = roleManager;
        this.userManager = userManager;
    }


    public async Task<IActionResult> Index()
    {
        if(!(await roleManager.RoleExistsAsync(AdminRole)))
        {
            await roleManager.CreateAsync(new IdentityRole(AdminRole));
        }
        IdentityUser user = await userManager.FindByEmailAsync(UserEmail);

        if (user == null)
        {
            user = new();
            user.UserName = UserEmail;
            user.Email = UserEmail;

            IdentityResult result = await userManager.CreateAsync(user, "Pa$$w0rd");

            if (result.Succeeded)
            {
                await Console.Out.WriteLineAsync($"User {user.UserName} created successully.");
            }
            else
            {
                foreach (IdentityError error in result.Errors)
                {
                    await Console.Out.WriteLineAsync($"Error: {error.Description}");
                }
            }
        }

        if (!user.EmailConfirmed)
        {
            string token = await userManager.GenerateEmailConfirmationTokenAsync(user);

            IdentityResult result = await userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
            {
                await Console.Out.WriteLineAsync($"User {user.UserName} email confirmed successfully");
            }
            else
            {
                foreach (IdentityError error in result.Errors)
                {
                    await Console.Out.WriteLineAsync(error.Description);
                }
            }
        }

        if(!(await userManager.IsInRoleAsync(user, AdminRole)))
        {
            IdentityResult result = await userManager.AddToRoleAsync(user, AdminRole);

            if (result.Succeeded)
            {
                await Console.Out.WriteLineAsync($"User {user.UserName} added to {AdminRole} successfully.");
            }
            else
            {
                foreach(IdentityError error in result.Errors)
                {
                    await Console.Out.WriteLineAsync(error.Description);
                }
            }
        }

        return Redirect("/");
    }
}
