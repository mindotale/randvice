using Randvice.Api;
using Randvice.Core;
using Randvice.Infrastructure;
using Randvice.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .ConfigureInfrastructure(builder.Configuration)
    .ConfigureCore(builder.Configuration)
    .ConfigureApi(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var initializer = serviceProvider.GetRequiredService<ApplicationDbContextInitializer>();
        await initializer.InitializeAsync();
        await initializer.SeedAsync();
    }
    catch (Exception) { }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.InjectStylesheet("/swagger-ui/theme-flattop.css");
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
