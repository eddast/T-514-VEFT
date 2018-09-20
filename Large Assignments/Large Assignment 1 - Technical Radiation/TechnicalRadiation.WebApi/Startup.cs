using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Repositories;
using TechnicalRadiation.Repositories.Data;
using TechnicalRadiation.Repositories.Data.Interfaces;
using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Services.Implementations;
using TechnicalRadiation.Services.Interfaces;
using TechnicalRadiation.WebApi.Extensions;

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
            // set up swagger
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

            // SETUP DEPENDENCY INJECTION
            // data providers
            services.AddSingleton<IAuthorDataProvider, AuthorDataProvider>();
            services.AddSingleton<IAuthorNewsItemRelationsProvider, AuthorNewsItemRelationProvider>();
            services.AddSingleton<ICategoryDataProvider, CategoryDataProvider>();
            services.AddSingleton<INewsItemCategoryRelationProvider, NewsItemCategoryRelationProvider>();
            services.AddSingleton<INewsItemDataProvider, NewsItemDataProvider>();
            // from repositories
            services.AddTransient<INewsItemRepository, NewsItemRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            // from services
            services.AddTransient<INewsItemService, NewsItemService>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<ICategoryService, CategoryService>();
            // log service
            services.AddTransient<ILogService, LogService>();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(opt => {
                opt.RoutePrefix = "api-documentation";
                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Technical Radiation API");
            });

            /* add global exception handling */
            app.ConfigureExceptionHandler();

            app.UseMvc();

            /* map API models via automapper */
            AutoMapper.Mapper.Initialize(cfg => {
                
                /* news item mappers */
                cfg.CreateMap<NewsItem, NewsItemDto>();
                cfg.CreateMap<NewsItem, NewsItemDetailDto>();
                cfg.CreateMap<NewsItemDetailDto, NewsItem>();
                cfg.CreateMap<NewsItemDto, NewsItem>();
                cfg.CreateMap<NewsItemInputModel, NewsItem>()
                    .ForMember(m => m.PublishDate, opt => opt.UseValue(DateTime.Now))
                    .ForMember(m => m.CreatedDate, opt => opt.UseValue(DateTime.Now))
                    .ForMember(m => m.ModifiedDate, opt => opt.UseValue(DateTime.Now))
                    .ForMember(m => m.ModifiedBy, opt => opt.UseValue("SystemAdmin"));

                /* author mappers */
                cfg.CreateMap<Author, AuthorDto>();
                cfg.CreateMap<Author, AuthorDetailDto>();
                cfg.CreateMap<AuthorDetailDto, Author>();
                cfg.CreateMap<AuthorDto, Author>();
                cfg.CreateMap<AuthorInputModel, Author>()
                    .ForMember(m => m.CreatedDate, opt => opt.UseValue(DateTime.Now))
                    .ForMember(m => m.ModifiedDate, opt => opt.UseValue(DateTime.Now))
                    .ForMember(m => m.ModifiedBy, opt => opt.UseValue("SystemAdmin"));
                
                /* category mappers */
                cfg.CreateMap<Category, CategoryDto>();
                cfg.CreateMap<Category, CategoryDetailDto>();
                cfg.CreateMap<CategoryDetailDto, Category>();
                cfg.CreateMap<CategoryDto, Category>();
                cfg.CreateMap<CategoryInputModel, Category>()
                    .ForMember(m => m.CreatedDate, opt => opt.UseValue(DateTime.Now))
                    .ForMember(m => m.ModifiedDate, opt => opt.UseValue(DateTime.Now))
                    .ForMember(m => m.ModifiedBy, opt => opt.UseValue("SystemAdmin"));
            });
            
        }
    }
}
