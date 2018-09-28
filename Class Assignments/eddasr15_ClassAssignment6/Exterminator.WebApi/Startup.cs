using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Exterminator.Models.Dtos;
using Exterminator.Models.Entities;
using Exterminator.Repositories.Data;
using Exterminator.Repositories.Implementations;
using Exterminator.Repositories.Interfaces;
using Exterminator.Services.Implementations;
using Exterminator.Services.Interfaces;
using Exterminator.WebApi.ExceptionHandlerExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Exterminator.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Registering all dependencies
            // Transient dependency injection context binding
            services.AddTransient<ILogService, LogService>();
            services.AddTransient<IGhostbusterService, GhostbusterService>();
            services.AddTransient<ILogRepository, LogRepository>();
            services.AddTransient<IGhostbusterRepository, GhostbusterRepository>();
            // Singleton dependency injection context binding
            services.AddSingleton<IGhostbusterDbContext, GhostbusterDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            // Sets up global exception handling and exception logging
            // On exceptions, an automatic HTTP response to client with error message
            // Handles the custom exceptions that yield HTTP responses of
            //      404s (ResourceNotFoundException),
            //      412s (InputFormatException),
            //      400s (Argument out of range exception) and
            //      500s (Default for any other exception)
            app.UseGlobalExceptionHandler();

            app.UseMvc();
            
            // Setup automapper to map between dtos and entities
            // (Ain't nobody got time for Linq, ok?!)
            AutoMapper.Mapper.Initialize(cfg => {
                cfg.CreateMap<Ghostbuster, GhostbusterDto>();
                cfg.CreateMap<GhostbusterDto, Ghostbuster>();
                cfg.CreateMap<Log, LogDto>();
                cfg.CreateMap<LogDto, Log>();
            });
        }
    }
}
