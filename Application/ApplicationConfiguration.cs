using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MediatR;

namespace Application
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplication(
          this IServiceCollection services,
          IConfiguration configuration)
          => services
              .Configure<ApplicationSettings>(
                  configuration.GetSection(nameof(ApplicationSettings)),
                  options => options.BindNonPublicProperties = true)
              .AddAutoMapper(Assembly.GetExecutingAssembly())
              .AddMediatR(Assembly.GetExecutingAssembly());
    }
}
