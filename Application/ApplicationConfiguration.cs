﻿using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplication(
          this IServiceCollection services,
          IConfiguration configuration)
          => services
              .Configure<AppSettings>(
                  configuration.GetSection(nameof(AppSettings)),
                  options => options.BindNonPublicProperties = true)
              .AddAutoMapper(Assembly.GetExecutingAssembly())
              .AddMediatR(Assembly.GetExecutingAssembly());
    }
}
