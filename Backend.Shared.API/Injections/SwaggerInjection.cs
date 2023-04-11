using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Backend.Shared.API.Injections
{
    /// <summary>
    /// Swagger Injection
    /// </summary>
    public static class SwaggerInjection
    {
        /// <summary>
        /// Adds the swagger configuration.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = Utilities.Constants.KeyVault.AppShared, Version = "v1" });
                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                var dir = new System.IO.DirectoryInfo(baseDirectory);
                foreach (var fi in dir.EnumerateFiles("*.xml"))
                {
                    c.IncludeXmlComments(fi.FullName);
                }
            });
        }

        /// <summary>
        /// Uses the swagger configuration.
        /// </summary>
        /// <param name="app">The application.</param>
        public static void UseSwaggerConfig(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SDS-Shared");
            });
        }
    }
}
