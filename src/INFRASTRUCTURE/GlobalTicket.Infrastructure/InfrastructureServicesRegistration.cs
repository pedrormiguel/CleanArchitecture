using Application.Contracts.Infrastructure;
using Application.Models.Mail;
using GlobalTicket.Infrastructure.Export.Excel;
using GlobalTicket.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GlobalTicket.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            serviceCollection.AddTransient<IEmailServices, EmailServices>();
            serviceCollection.AddTransient<IExportToExcelServices, ExportToExcelServices>();

            return serviceCollection;
        }
    }
}