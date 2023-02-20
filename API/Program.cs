using API.Extensions;
using API.Middleware;

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

app.Run();
