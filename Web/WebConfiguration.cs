using Application.Interfaces;
using Web.Services;

namespace Web
{
    public static class WebConfiguration
    {
        public static IServiceCollection AddWeb(this IServiceCollection services)
            => (IServiceCollection)services
                .AddScoped<ICurrentUser, CurrentUser>()
                .AddControllers()
                .AddNewtonsoftJson();
    }
}
