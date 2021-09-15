using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Faust.PetShopApp.Core.IServices;
using Faust.PetShopApp.Domain.IRepositories;
using Faust.PetShopApp.Domain.Services;
using Faust.PetShopApp.Infrastructure;
using Faust.PetShopApp.Infrastructure.EFRepositories;
using Faust.PetShopApp.Infrastructure.Repositories;
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

namespace Faust.PetShopApp.WebApi
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
            services.AddDbContext<PetAppContext>(
                builder => builder.UseInMemoryDatabase("ThaDB"));
            
            services.AddControllers();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IPetRepository, EFPetRepository>();
            services.AddScoped<IPetTypeService, PetTypeService>();
            services.AddScoped<IPetTypeRepository, EFPetTypeRepository>();
            services.AddScoped<IOwnerRepository, OwnerRepositoryEF>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Faust.PetShopApp.WebApi", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Faust.PetShopApp.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}