using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    /*Added a class ApplicationServiceExtensions in an extension folder 
    to make the builder cleaner => API\Program.cs*/
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            /* Adding the DataContext to the services. Using Sqlite in development */
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            services.AddCors();
            /* Adding the `TokenService` to the services. */
            services.AddScoped<ITokenService, TokenService>();
            /* Adding the `UserRepository` to the services. */
            services.AddScoped<IUserRepository, UserRepository>();
            
            services.AddScoped<IProductRepository, ProductRepository>();
/*             services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
 */ 
            /* Adding the AutoMapperService */
           /*  services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());       */      
            return services;
        }
    }
}