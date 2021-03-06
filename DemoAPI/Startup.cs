using System.Reflection;
using DemoDataService.Contracts;
using DemoDataService.Repos;
using DemoDataService.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DemoDataService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddGrpc();

            // Add DB Context
            services.AddDbContext<DemoContext>(options => 
                {
                    options.UseNpgsql(Configuration.GetConnectionString("Database"));
                    options.UseSnakeCaseNamingConvention();
                }
            );

            // Local base Repo
            services.AddSingleton<IPersonRepo, PersonRepo>();

            // DB Access Repo
            services.AddScoped<IEmployeeRepo, EmployeeRepo>();

            services.AddScoped<IDepartementRepository, DepartementRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            // Mediatr
            services.AddMediatR(Assembly.GetExecutingAssembly());

            // Swagger
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<DepartementService>();

                endpoints.MapControllers();
            });

            // Swagger Middleware
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo Web API");
            });
        }
    }
}
