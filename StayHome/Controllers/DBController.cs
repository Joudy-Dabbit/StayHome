using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Neptunee.BaseCleanArchitecture.Controllers;
using Neptunee.BaseCleanArchitecture.Dispatchers.RequestDispatcher;
using StayHome.Persistence.Context;
using StayHome.Persistence.Seed;
namespace StayHome.Controllers;

[Route("api/[controller]/[action]")]
public class DBController : ApiController
{
    private readonly StayHomeDbContext _context;
    private readonly IServiceProvider _serviceProvider;

    public DBController(IRequestDispatcher dispatcher,
        StayHomeDbContext context, IServiceProvider serviceProvider) : base(dispatcher)
    {
        _context = context;
        _serviceProvider = serviceProvider;
    }

    [HttpGet]
    public async Task<IActionResult> DeleteDb()
    {
        await _context.Database.EnsureDeletedAsync();
        await _context.Database.MigrateAsync();
        await DataSeed.Seed(_context, _serviceProvider);
        return Ok("Done");
    }
}