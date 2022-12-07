using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Randvice.Core.Advices;

namespace Randvice.Infrastructure.Persistence;

public class ApplicationDbContextInitializer
{
    private readonly ApplicationDbContext _dbContext;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public ApplicationDbContextInitializer(
        ApplicationDbContext dbContext,
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _dbContext = dbContext;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitializeAsync()
    {
        await _dbContext.Database.EnsureDeletedAsync();
        await _dbContext.Database.EnsureCreatedAsync();
    }

    public async Task SeedAsync()
    {
        // Default roles
        var administratorRole = new IdentityRole("Administrator");

        if (_roleManager.Roles.All(r => r.Name != administratorRole.Name))
        {
            await _roleManager.CreateAsync(administratorRole);
        }

        // Default users
        var administrator = new IdentityUser { UserName = "admin", Email = "admin@mail.com" };

        if (_userManager.Users.All(u => u.Email != administrator.Email))
        {
            await _userManager.CreateAsync(administrator, "1!Admin");
            await _userManager.AddToRoleAsync(administrator, administratorRole.Name!);
        }

        // Default data
        // Seed, if necessary

        var advices = new List<Advice>()
        {
            new Advice
            {
                Id = Guid.NewGuid(),
                Text = "Identify sources of happiness."
            },
            new Advice
            {
                Id = Guid.NewGuid(),
                Text = "True happiness always resides in the quest."
            },
            new Advice
            {
                Id = Guid.NewGuid(),
                Text = "State the problem in words as clearly as possible."
            },
            new Advice
            {
                Id = Guid.NewGuid(),
                Text = "If you're squashed close to strangers on public transport, try not to be rude to them. No one likes those situations."
            },
            new Advice
            {
                Id = Guid.NewGuid(),
                Text = "No \"brand\" is your friend."
            },
            new Advice
            {
                Id = Guid.NewGuid(),
                Text = "Respect other people's opinions, even when they differ from your own."
            },
            new Advice
            {
                Id = Guid.NewGuid(),
                Text = "When hugging, hug with both arms and apply reasonable, affectionate pressure."
            },
            new Advice
            {
                Id = Guid.NewGuid(),
                Text = "Tell it like it is."
            },
            new Advice
            {
                Id = Guid.NewGuid(),
                Text = "Good advice is something a man gives when he is too old to set a bad example."
            },
            new Advice
            {
                Id = Guid.NewGuid(),
                Text = "If it still itches after a week, go to the doctors."
            },
            new Advice
            {
                Id = Guid.NewGuid(),
                Text = "Don't use Excel or Powerpoint documents for your basic word processing needs."
            }
        };

        if (!_dbContext.Advices.Any())
        {
            await _dbContext.Advices.AddRangeAsync(advices);
            await _dbContext.SaveChangesAsync();
        }
    }
}
