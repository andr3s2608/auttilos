using Backend.Shared.API.Injections;
using Backend.Shared.Entities.CustomValidation;
using Backend.Shared.Utilities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net.Mime;

namespace Backend.Shared.API
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
         private readonly string MyAllowSpecificOrigins = "AllowAll";
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures the services.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var result = new ValidationFailedResult(context.ModelState);
                    result.ContentTypes.Add(MediaTypeNames.Application.Json);
                    return result;
                };

            });

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });

            //services.AddWkhtmltopdf("Tools");
            services.AddInitialConfig();
            services.AddUtilities(Configuration.GetValue<string>(Utilities.Constants.KeyVault.InstrumentationKey));
            services.AddBusinessConfig(Configuration);
            services.AddSwaggerConfig();
            services.Configure<KestrelServerOptions>(options =>
            {
                options.Limits.MaxRequestBodySize = null;
            });
        }

        /// <summary>
        /// Configures the specified application.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The env.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseInitialConfig();
            app.UseSwaggerConfig();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

             app.UseCors(MyAllowSpecificOrigins);
        }
    }
}
