using System.Reflection;
using System.ComponentModel.Design;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace Application
{
    public static class ApplicationServiceResgistrarion
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection service)
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());
            service.AddMediatR(Assembly.GetExecutingAssembly());


            return service;
        }
    }
}