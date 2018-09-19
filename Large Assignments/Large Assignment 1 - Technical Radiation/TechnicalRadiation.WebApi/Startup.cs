﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TechnicalRadiation.Models.DTO;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.WebApi.Extensions;

namespace TechnicalRadiation.WebApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
