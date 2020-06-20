using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json;
using AutoMapper;
using DigitalOwl.Api.Helpers;
using DigitalOwl.Api.Infrastructure;
using DigitalOwl.Api.Infrastructure.Auth;
using DigitalOwl.Repository;
using DigitalOwl.Repository.Entity;
using DigitalOwl.Repository.Interface.Base;
using DigitalOwl.Repository.Repositories;
using DigitalOwl.Repository.Repositories.Base;
using DigitalOwl.Service.Infrastructure;
using DigitalOwl.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DigitalOwl.Api.Startup
{
    /// <summary>
    ///  Main config file
    /// </summary>
    public class Startup
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Ctor nothing intresting
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        private static void ConfigureMapper(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new ModelToDtoMapperProfile());
                mc.AddProfile(new DtoToEntityMapperProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(opt =>
                opt.UseLazyLoadingProxies().UseSqlServer(_configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("DigitalOwl.Migrations")));

            services.AddSingleton<IJwtFactory, JwtFactory>();

            services.TryAddTransient<IHttpContextAccessor, HttpContextAccessor>();


            services.AddTransient<IDbContext, ApplicationDbContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // RepositoriesRegister.Register(services);
            ServicesRegister.Register(services);

            AuthConfiguration.Configure(services, _configuration);

            ConfigureMapper(services);

            services.AddControllers();

            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My API", Version = "v1"
                });
                // xml comments
                // var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                // var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                // c.IncludeXmlComments(xmlPath);
            });
        }

        /// <summary>
        /// Configure App Middleware 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors(
                    options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
                );

                // Enable middleware to serve generated Swagger as a JSON endpoint.
                app.UseSwagger();

                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
                // specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                    c.RoutePrefix = string.Empty;
                });
            }

// app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}