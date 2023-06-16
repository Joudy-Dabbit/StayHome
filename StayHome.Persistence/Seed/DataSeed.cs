using System.Diagnostics.CodeAnalysis;
using Domain;
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
        await SeedCategories(context);
        await SeedCitiesWithArea(context);
        await SeedRole(roleManager, context);
        await SeedUser(userManager, context);
    }

    private static async Task SeedUser(UserManager<User> userManager, 
        StayHomeDbContext context)
    {
        if (context.Users.Any()) return;
        
        var cityId = context.Cities.First().Id;

        var admin = new Employee("joudy dabbit", "099999999",
            new DateTime(2001, 6, 2), "admin@gmail.com", AddImage());
        await userManager.CreateAsync(admin, "1234");
        await userManager.AddToRoleAsync(admin, nameof(StayHomeRoles.Admin));
        await context.SaveChangesAsync();

        var employee = new Employee("Hiba Baeij", "088888888",
            new DateTime(2002, 6, 2), "employee@gmail.com", AddImage());
        await userManager.CreateAsync(employee, "1234");
        await userManager.AddToRoleAsync(employee, nameof(StayHomeRoles.Employee));
        await context.SaveChangesAsync();

        var customer = new Customer("Aisha Biazed", "077777777",
            "customer@gmail.com", AddImage(), new DateTime(2003, 6, 2), cityId);
        await userManager.CreateAsync(customer, "1234");
        await userManager.AddToRoleAsync(customer, nameof(StayHomeRoles.Customer));       
        await context.SaveChangesAsync();

        var driver = new Driver("default driver", "077777777",
            new DateTime(2003, 6, 2), "driver@gmail.com", AddImage());
        await userManager.CreateAsync(driver, "1234");
        await userManager.AddToRoleAsync(driver, nameof(StayHomeRoles.Driver));
        await context.SaveChangesAsync();
    }

    private static async Task SeedRole( RoleManager<IdentityRole<Guid>> roleManager,
        StayHomeDbContext context)
    {
        if (roleManager.Roles.Any()) return;

        var roles = Enum.GetValues(typeof(StayHomeRoles)).Cast<StayHomeRoles>().Select(a => a.ToString());
        var identityRoles = roleManager.Roles.Select(a => a.Name).ToList();
        var newRoles = roles.Except(identityRoles).ToList();

        foreach (var @new in newRoles)
        {
            await roleManager.CreateAsync(new IdentityRole<Guid>() { Id = Guid.NewGuid(), Name = @new });
        }

        await context.SaveChangesAsync();
    }

    private static async Task SeedCategories(StayHomeDbContext context)
    {
        if (context.Categories.Any())
        {
            return;
        }

        var category1 = new Category("ألبسة", AddImage());
        var category2 = new Category("وجبات سريعة", AddImage());
        var category3 = new Category("مفروشات", AddImage());
        context.AddRange(new List<Category>() {category1, category2, category3});
        
        await context.SaveChangesAsync();
    }
    private static async Task SeedCitiesWithArea(StayHomeDbContext context)
    {
        if (context.Cities.Any())
        {
            return;
        }

        var city = new City("دمشق");
        var city1 = new City("حلب");
        context.AddRange(new List<City>() {city1, city});
        var area = new Area("المزة", city.Id);
        var area1 = new Area("الفرقان", city1.Id);
        var area2 = new Area("الشهباء", city1.Id);
        context.AddRange(new List<Area>() {area, area1, area2});
        
        await context.SaveChangesAsync();
    }
    private static string AddImage()
    {
        var s = Path.Combine(Directory.GetCurrentDirectory(), ConstValues.StayHomeJpg);
        var x = Path.Combine(ConstValues.Seed, Guid.NewGuid() + "_" + ConstValues.StayHomeJpg);
        var d = Path.Combine(Directory.GetCurrentDirectory(), ConstValues.WwwrootDir, x);
        File.Copy(s, d);
        return x;
    }
}