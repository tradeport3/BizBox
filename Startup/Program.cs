using Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<StartupConfiguration>();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
