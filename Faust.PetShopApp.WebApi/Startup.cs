using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Faust.PetShopApp.Core.IServices;
using Faust.PetShopApp.Core.Models;
using Faust.PetShopApp.Domain.IRepositories;
using Faust.PetShopApp.Domain.Services;
using Faust.PetShopApp.Infrastructure;
using Faust.PetShopApp.Infrastructure.Entities;
using Faust.PetShopApp.Infrastructure.RepositoriesEF;
using Faust.PetShopApp.MySecurity.Authentication;
using Faust.PetShopApp.MySecurity.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

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
            Byte[] secretBytes = new byte[40];
        //    services.AddDbContext<PetAppContext>(builder => builder.UseInMemoryDatabase("ThaDB"));
        services.AddDbContext<PetAppContext>(opt =>
        {
            var loggerFactory = LoggerFactory.Create(configure: builder =>
            {
                builder.AddConsole();
            });
            opt.UseLoggerFactory(loggerFactory)
                .UseSqlite("Data Source=petapp.db");
        });
            
            services.AddControllers();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IPetRepository, EFPetRepository>();
            services.AddScoped<IPetTypeService, PetTypeService>();
            services.AddScoped<IPetTypeRepository, PetTypeRepositoryEF>();
            services.AddScoped<IOwnerRepository, OwnerRepositoryEF>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IColorRepository, ColorRepositoryEF>();
            services.AddScoped<IColorService, ColorService>();
            services.AddDbContext<SecurityContext>(opt => opt.UseInMemoryDatabase("Security"));
            services.AddTransient<ISecurityContextInitializer, SecurityMemoryInitializer>();
            services.AddScoped<UserRepository>();
            services.AddSingleton<IAuthenticationHelper>(new AuthenticationHelper(secretBytes));

            services.AddScoped<IUserAuthenticator, UserAuthenticator>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Faust.PetShopApp.WebApi", Version = "v1"});
            });
            services.AddCors(options =>
            {
                options.AddPolicy("petshop-policy",
                    builder =>
                    {
                        builder
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .WithOrigins("http://localhost:4200");
                    });
            });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, PetAppContext ctx)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    ctx.Database.EnsureDeleted();
                    ctx.Database.EnsureCreated();

                    ctx.SaveChanges();
                }
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Faust.PetShopApp.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("petshop-policy");
            
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}