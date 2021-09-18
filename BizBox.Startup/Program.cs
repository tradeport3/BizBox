using Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services
        .AddDomain()
        .AddControllers();

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
