using API.Data;
using API.Extensions;
using API.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
/* Adding the services to the container. => API\Extensions\ApplicationServiceExtensions.cs*/
builder.Services.AddApplicationServices(builder.Configuration);
/* Adding the services to the container. => API\Extensions\IdentityServiceExtensions.cs*/
builder.Services.AddIdentityServices(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

/* The Ohter builder services are implemented in an Extensions folder for more lisibility.  => API/Extenstion/ApplicationServiceExtensions */
var app = builder.Build();

/* 
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }
*/
/* Allowing the Angular app to make requests to the API. // Configure the HTTP request pipeline.*/

/* A custom middleware that is handling the exceptions. */
app.UseMiddleware<ExceptionMiddleware>();

app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200"));

app.UseAuthentication();
app.UseAuthorization();

//app.UseHttpsRedirection();
app.MapControllers();

using var scope = app.Services.CreateScope();

/* Migrating the database and seeding 'add fake data' to the database. */
var services = scope.ServiceProvider;
try
{
    var context = services.GetRequiredService<DataContext>();
    await context.Database.MigrateAsync();
    await SeedProducts.ProductsSeed(context);
    await context.Database.MigrateAsync();
    await Seed.SeedUsers(context);
 }
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error occurred during migration");
}

app.Run();
