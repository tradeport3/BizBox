using Application;
using Domain;
using Infrastructure;
using Microsoft.OpenApi.Models;
using Web;

namespace Startup
{
    public class StartupConfig
    {
        public StartupConfig(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
            => services
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Sources-v2", Version = "2.0.1" });
                })
                .AddDomain()
                .AddApplication(this.Configuration)
                .AddInfrastructure(this.Configuration)
                .AddWeb();

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger()
                   .UseSwaggerUI();
            }

            app.UseHttpsRedirection()
               .UseRouting()
               .UseCors(options => options
                   .AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod())
               .UseAuthentication()
               .UseAuthorization()
               .UseEndpoints(endpoints => endpoints.MapControllers());
            //.Initialize();
        }
    }
}
