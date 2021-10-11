namespace Startup
{
    public class Program
    {
        public static async Task Main(string[] args) => await CreateHostBuilder(args).Build().RunAsync();

        public static IHostBuilder CreateHostBuilder(string[] args)
            => Host
                .CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<StartupConfig>());
    }
}

//using Domain;
//using Startup;
//using Web;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddControllers();
//builder.Services.AddSwaggerGen()
//                .AddDomain()
//                .AddApplication(this.Configuration)
//                .AddInfrastructure(this.Configuration)
//                .AddWeb();

//var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//    app.UseSwagger()
//       .UseSwaggerUI();
//}

//app.UseHttpsRedirection()
//   .UseRouting()
//   .UseCors(options => options
//       .AllowAnyOrigin()
//       .AllowAnyHeader()
//       .AllowAnyMethod())
//   .UseAuthentication()
//   .UseAuthorization()
//   .UseEndpoints(endpoints => endpoints
//       .MapControllers())
//   .Initialize();

//app.Run();
