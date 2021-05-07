using Application;
using GlobalTicket.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Persistence;

namespace GlobalTicket.API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationServices();
            services.AddInfrastructureService(_configuration); //TODO add appsetting.json ( EmailSettings )
            services.AddPersistenceServices(_configuration); //TODO add appsetting.json  ( ConnectionString - GlobalTicketManagementStringConnection )

            services.AddControllers();
            services.AddCors(opt =>
            {
                opt.AddPolicy("open", builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            });

            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "GlobalTicket API",
                    Version = "v1"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(
                    c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "GlobalTicket API"); }
                );
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("open");
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}