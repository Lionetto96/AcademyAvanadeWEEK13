using AziendaTicketAMM_CORE.BusinessLayer;
using AziendaTicketAMM_CORE.Interfaces;
using AziendaTicketAMM_EF;
using AziendaTicketAMM_EF.RepositoriesEF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace AziendaTicketAMM_WebApi
{
    public class Startup
    {
        public readonly string ApplicationName = Assembly.GetEntryAssembly().GetName().Name;
        public readonly string ApplicationVersion =
            $"v{Assembly.GetEntryAssembly().GetName().Version.Major}" +
            $".{Assembly.GetEntryAssembly().GetName().Version.Minor}" +
            $".{Assembly.GetEntryAssembly().GetName().Version.Build}";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllers();
            services.AddTransient<IBusinessLayer, BusinessLayer>();

            
            services.AddTransient<IRepositoryTicket, RepositoryTicketEF>();
            services.AddTransient<IRepositoryCategoria, RepositoryCategoriaEF>();
            services.AddTransient<IRepositoryStato, RepositoryStatoEF>();

            services.AddDbContext<Context>(options =>
            {
                options
                .UseSqlServer(Configuration
                .GetConnectionString("GestioneTicketAziendaAMM"));
            });

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = ApplicationName,
                    Version = ApplicationVersion,
                });
                string file = $"{ApplicationName}.xml";
                options.IncludeXmlComments(
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(
                    "v1/swagger.json",
                    $"{ApplicationName} {ApplicationVersion}");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
