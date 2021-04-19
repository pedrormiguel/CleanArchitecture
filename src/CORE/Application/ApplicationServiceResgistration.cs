using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationServiceResgistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection service)
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
            service.AddMediatR(Assembly.GetExecutingAssembly());


            return service;
        }
    }
}