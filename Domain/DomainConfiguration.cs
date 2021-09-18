using Domain.Common;
using Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Domain
{
    public static class DomainConfiguration
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
            => services.AddFactories();

        private static IServiceCollection AddFactories(this IServiceCollection services)
          => services
                .Scan(scan => scan
                      .FromCallingAssembly()
                      .AddClasses(classes => classes
                          .AssignableTo(typeof(IFactory<>)))
                      .AsMatchingInterface()
                      .WithTransientLifetime());

        private static IServiceCollection AddRepositories(this IServiceCollection services)
         => services
               .Scan(scan => scan
                     .FromCallingAssembly()
                     .AddClasses(classes => classes
                         .AssignableTo(typeof(IRepository<>)))
                     .AsMatchingInterface()
                     .WithTransientLifetime());
    }
}
