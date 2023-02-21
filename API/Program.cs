using API.Data;
using API.Extensions;
using API.Middleware;
using Microsoft.EntityFrameworkCore;

// Creates a new instance of the WebApplicationBuilder class using the CreateBuilder method
var builder = WebApplication.CreateBuilder(args);

// Add services to the container

// Add services for MVC controllers
builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);

// Build the WebApplication object
var app = builder.Build();
// Configure the HTTP request pipeline
app.UseMiddleware<ExceptionMiddleware>();
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod()
    .WithOrigins("https://localhost:4200"));
// Enables authentication services and adds the authentication middleware to the application pipeline
// Authentication MUST ALWAYS be putted before Authorization
app.UseAuthentication(); 
// Adds authorization middleware to the pipeline to check if the user is authorized 
// to access the requested resource
app.UseAuthorization(); 

// Add the controllers to the middleware pipeline
app.MapControllers();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try{
    var context = services.GetRequiredService<DataContext>();
    await context.Database.MigrateAsync();
    await Seed.SeedUsers(context);
}
catch(Exception ex)
{
    var logger = services.GetService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred during migration");
}

app.Run();
