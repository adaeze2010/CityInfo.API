﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using CityInfo.API.Enitites;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
               .AddMvcOptions(o => o.OutputFormatters.Add(
                  new XmlDataContractSerializerOutputFormatter()));
            //{
            //    if (o.SerializerSettings.ContractResolver != null)
            //    {
            //        var castedResolver = o.SerializerSettings.ContractResolver
            //        as DefaultContractResolver;
            //        castedResolver.NamingStrategy = null;
            //    }
            //}
            //    );


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            var connectionString = @"Server=(localdb)\mssqllocaldb;Database=CityInfoDB;Trusted_Connection=True;";
            services.AddDbContext<CityInfoContext>( o => o.UseSqlServer(connectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerfactory)
        {
            loggerfactory.AddConsole();
            loggerfactory.AddDebug( );

            loggerfactory.AddNLog();

            //app.UseWelcomePage();
           
           

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           else
            {

                app.UseExceptionHandler();
            }
            app.UseStatusCodePages();
            app.UseMvc();
           
        }
    }
}
