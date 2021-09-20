using Microsoft.Extensions.DependencyInjection.Extensions;
using Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.TryAddSingleton<StartupConfiguration>();

builder.Build().Run();
