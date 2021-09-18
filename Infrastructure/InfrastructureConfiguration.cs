using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(
           this IServiceCollection services,
           IConfiguration configuration)
                => services
                    .AddDatabase(configuration)
                    .AddIdentity(configuration);

        private static IServiceCollection AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
            => services
                .AddDbContext<CarRentalDbContext>(options => options
                .UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    sqlServer => sqlServer
                        .MigrationsAssembly(typeof(CarRentalDbContext).Assembly.FullName)))
            .AddScoped<IDealershipDbContext>(provider => provider.GetService<CarRentalDbContext>())
            .AddTransient<IInitializer, DatabaseInitializer>();
    }
}
