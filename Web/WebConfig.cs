using Application.Interfaces;
using Web.Services;

namespace Web
{
    public static class WebConfig
    {
        public static IServiceCollection AddWeb(this IServiceCollection services)
        {
            services.AddScoped<ICurrentUser, CurrentUser>();

            services.AddControllers()
                    .AddNewtonsoftJson();

            return services;
        }
    }
}
