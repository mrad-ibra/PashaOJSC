using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ProductApi.Data;
using ProductApi.Filters;
using ProductApi.Interfaces;
using ProductApi.Models;
using ProductApi.Repositories;
using ProductApi.Resources;
using ProductApi.Validators;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi
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
            services.AddScoped<AbstractValidator<ProductResource>, ProductValidator>();
            services.AddScoped<AbstractValidator<ProductCategory>, ProductCategoryValidator>();
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<ProductDbContext>(options => options
            .UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddControllers(options => options.Filters.Add<ValidationFilter>())
     .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<ProductValidator>())
     .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<ProductCategoryValidator>())
     .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProductApi", Version = "v1" });
            });
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProductApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseSerilogRequestLogging();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
