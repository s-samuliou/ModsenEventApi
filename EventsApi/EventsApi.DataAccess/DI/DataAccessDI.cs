using EventsApi.DataAccess.Data;
using EventsApi.DataAccess.Interfaces;
using EventsApi.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EventsApi.DataAccess.DI
{
    public static class DataAccessDi
    {
        public static void AddDataLogic(this IServiceCollection service, IConfiguration config)
        {
            service.AddTransient<IEventRepository, EventRepository>();

            service.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
