using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
using PBIEmbedded.Application;
using PBIEmbedded.Application.Interfaces;
using PBIEmbedded.Persistence;
using PBIEmbedded.Persistence.Contexts;
using PBIEmbedded.Persistence.Interface;

namespace PBIEmbedded.api
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

            services.AddDbContext<PBIEmbeddedContext>(
                context => context.UseSqlServer(Configuration.GetConnectionString("Default"))
            );
            services.AddControllers()
                    .AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling
                                            = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //General
            services.AddScoped<IGeneralPersist, GeneralPersist>();
            //Dashboard
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IDashboardPersist, DashboardPersist>();
            //ServicePrincipal
            services.AddScoped<IServicePrincipalService, ServicePrincipalService>();
            services.AddScoped<IServicePrincipalPersist, ServicePrincipalPersist>();
            //User
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserPersist, UserPersist>();

            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PBIEmbedded.api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PBIEmbedded.api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(
                x => x.AllowAnyHeader()
                      .AllowAnyMethod()
                      .AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
