using Domain.Entities;
using Domain.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using StayHome.Persistence.Context;

namespace StayHome.Persistence.Seed;

public static class DataSeed
{
    public static async Task Seed(StayHomeDbContext context, IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
        await SeedUser(userManager, roleManager, context);
    }

    private static async Task SeedUser(UserManager<User> userManager, 
        RoleManager<IdentityRole<Guid>> roleManager,
        StayHomeDbContext context )
    {
        if (roleManager.Roles.Any()) return;

        #region - Roles -

        var roles = Enum.GetValues(typeof(StayHomeRoles)).Cast<StayHomeRoles>().Select(a => a.ToString());
        var identityRoles = roleManager.Roles.Select(a => a.Name).ToList();
        var newRoles = roles.Except(identityRoles).ToList();

        foreach (var @new in newRoles)
        {
            await roleManager.CreateAsync(new IdentityRole<Guid>() { Id = Guid.NewGuid(), Name = @new });
        }

        await context.SaveChangesAsync();

        #endregion

    } 
}