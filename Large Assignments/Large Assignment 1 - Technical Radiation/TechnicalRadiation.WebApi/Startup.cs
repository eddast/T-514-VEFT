using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Repositories;
using TechnicalRadiation.Repositories.Data;
using TechnicalRadiation.Repositories.Data.Interfaces;
using TechnicalRadiation.Repositories.Implementation;
using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Services.Implementations;
using TechnicalRadiation.Services.Interfaces;
using TechnicalRadiation.WebApi.Authorization;
using TechnicalRadiation.WebApi.Extensions;
using TechnicalRadiation.WebApi.Resolvers;

namespace TechnicalRadiation.WebApi
{
    /// <summary>
    /// Setup WebApi project
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Sets up configurations
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Returns configuration
        /// </summary>
        /// <value>configuration</value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Setup Swagger for API documentation of the system
            // Uses the in-code XML comments and MVC tags to generate understandable description for routes and models
            // Documentation available when server is running at localhost:5000/api-documentation
            services.AddSwaggerGen(opt => {
                opt.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Technical Radiation API",
                    Description = "Used to manipulate resources on news items, news categories and news authors in Technical Radiation system",
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                opt.IncludeXmlComments(xmlPath);
            });

            services.AddMvc();
            services.AddHttpContextAccessor();

            // Set up the authentication policy for system as a user requirement
            // I.e. tells system to force a requirement client must fulfill to access restricted routes in system
            // (In this case, client authorization header value must match a secret string/shared key) 
            services.AddAuthorization(options =>
                options.AddPolicy("HasSharedKey", policy => policy.Requirements.Add(new UserAuthorizationRequirement())));

            // Set up automatic dependency injection of concrete classes to interfaces
            // CLASSES RELATED TO AUTHORIZATION
            services.AddSingleton<IAuthorizationHandler, UserAuthorizationRequirementHandler>();

            // CLASSES RELATED TO DATA PROVIDERS (DATA CONTEXT)
            services.AddSingleton<IAuthorNewsItemRelationsProvider, AuthorNewsItemRelationProvider>();
            services.AddSingleton<INewsItemCategoryRelationProvider, NewsItemCategoryRelationProvider>();
            services.AddSingleton<IAuthorDataProvider, AuthorDataProvider>();
            services.AddSingleton<ICategoryDataProvider, CategoryDataProvider>();
            services.AddSingleton<INewsItemDataProvider, NewsItemDataProvider>();

            // CLASSES RELATED TO THE REPOSITORY LAYER
            services.AddTransient<INewsItemRepository, NewsItemRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IAuthorNewsItemRelationRepository, AuthorNewsItemRelationRepository>();
            services.AddTransient<INewsItemCategoryRelationRepository, NewsItemCategoryRelationRepository>();
           
            // CLASSES RELATED TO THE SERVICE LAYER
            services.AddTransient<INewsItemService, NewsItemService>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<ICategoryService, CategoryService>();
            
            // LOG SERVICE (USED IN GLOBAL EXCEPTION HANDLING)
            services.AddTransient<ILogService, LogService>();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            // Enable Swagger for API documentation of the system
            // Documentation available when server is running at localhost:5000/api-documentation
            app.UseSwagger();
            app.UseSwaggerUI(opt =>{
                opt.RoutePrefix = "api-documentation";
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Technical Radiation API");
            });

            // Sets up global exception handling and exception logging
            // On exceptions, an automatic HTTP response to client with error message
            // Handles the custom exceptions that yield HTTP responses of
            //      404s (ResourceNotFoundException),
            //      412s (InputFormatException),
            //      401 (AuthorizationException) and
            //      500 (Default for any other exception)
            app.ConfigureExceptionHandler();

            // Require authentication mechanism in system,
            // I.e. force a requirement client must fulfill to access specified restricted routes in system
            // (In this case, client authorization header value must match a secret string/shared key)
            app.UseAuthentication();

            app.UseMvc();

            // Create support for automatic mapping of model in system
            AutoMapper.Mapper.Initialize(cfg => {

                // MODELS REPRESENTING NEWS ITEM RESOURCES IN SYSTEM
                cfg.CreateMap<NewsItem, NewsItemDto>();
                cfg.CreateMap<NewsItem, NewsItemDetailDto>();
                cfg.CreateMap<NewsItemDetailDto, NewsItem>();
                cfg.CreateMap<NewsItemDto, NewsItem>();
                cfg.CreateMap<NewsItemInputModel, NewsItem>()
                    .ForMember(m => m.CreatedDate, opt => opt.UseValue(DateTime.Now))
                    .ForMember(m => m.ModifiedDate, opt => opt.UseValue(DateTime.Now))
                    .ForMember(m => m.ModifiedBy, opt => opt.UseValue("SystemAdmin"));

                // MODELS REPRESENTING AUTHOR RESOURCES IN SYSTEM
                cfg.CreateMap<Author, AuthorDto>();
                cfg.CreateMap<Author, AuthorDetailDto>();
                cfg.CreateMap<AuthorDetailDto, Author>();
                cfg.CreateMap<AuthorDto, Author>();
                cfg.CreateMap<AuthorInputModel, Author>()
                    .ForMember(m => m.CreatedDate, opt => opt.UseValue(DateTime.Now))
                    .ForMember(m => m.ModifiedDate, opt => opt.UseValue(DateTime.Now))
                    .ForMember(m => m.ModifiedBy, opt => opt.UseValue("SystemAdmin"));

                // MODELS REPRESENTING CATEGORY RESOURCES IN SYSTEM
                cfg.CreateMap<Category, CategoryDto>();
                cfg.CreateMap<Category, CategoryDetailDto>();
                cfg.CreateMap<CategoryDetailDto, Category>();
                cfg.CreateMap<CategoryDto, Category>();
                cfg.CreateMap<CategoryInputModel, Category>()
                    .ForMember(m => m.Slug, opt => opt.ResolveUsing<SlugResolver>())
                    .ForMember(m => m.CreatedDate, opt => opt.UseValue(DateTime.Now))
                    .ForMember(m => m.ModifiedDate, opt => opt.UseValue(DateTime.Now))
                    .ForMember(m => m.ModifiedBy, opt => opt.UseValue("SystemAdmin"));
            });
            
        }
    }
}
