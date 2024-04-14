using Data.AppContext;
using Logic.CookBook;
using Logic.CookBook.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Web.Shared.ViewModels;

namespace Web.Shared
{
    public static class ServiceConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration config)
        {

            // add db context
            services.AddDbContext<AppDbContext>(opt =>
            {
                var connection = config.GetConnectionString("AppDbContext") ?? null;

                if (connection == null)
                {
                    throw new Exception("Could not find database connection!");
                }

                opt.UseMySQL(connection);
            });

            // add unit of works
            services.AddScoped<ICookBookUnitOfWork, CookbookUnitOfWork>();

            services.AddTransient<CookBookViewModel>();
           
        }

    }
}
