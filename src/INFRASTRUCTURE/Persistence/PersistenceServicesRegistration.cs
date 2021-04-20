using Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repository;

namespace Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<GlobalTicketDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("GlobalTicketManagementStringConnection"));
            });

            serviceCollection.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            
            serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();
            serviceCollection.AddScoped<IEventRepository, EventRepository>();
            serviceCollection.AddScoped<IOrderRepository, OrderRepository>();
            
            return serviceCollection;
        }
    }
}