﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CO.DAL.Abstract;
using CO.DAL.Concrete;
using CO.Entity;
using CO.Manager.Abstract;
using CO.Manager.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CO.WebAPI
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


         services.Configure<DatabaseSettings>(options =>
         {
            options.ConnectionString
                = Configuration.GetSection("MongoConnection:ConnectionString").Get<string>();
            options.Database
                = Configuration.GetSection("MongoConnection:Database").Value;
         });


         services.AddScoped<IProductManager, ProductManager>();
         services.AddScoped<IProductDAL, ProductDAL>();

         services.AddMvc();

      }

      // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
      public void Configure(IApplicationBuilder app, IHostingEnvironment env)
      {
         if (env.IsDevelopment())
         {
            app.UseDeveloperExceptionPage();
         }

         app.UseMvc();
      }
   }
}
