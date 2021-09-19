using Microsoft.Extensions.DependencyInjection.Extensions;
using Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.TryAddSingleton<StartupConfiguration>();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
