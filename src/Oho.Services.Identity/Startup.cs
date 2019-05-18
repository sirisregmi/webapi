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
using Microsoft.EntityFrameworkCore;
using Oho.Common.Auth;
using Oho.Services.Identity.Domain.Services;
using Oho.Services.Identity.Repo;
using Oho.Services.Identity.Services;

namespace Oho.Services.Identity
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


            services.AddDbContext<IdentityContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));


            Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //services.AddLogging();
            services.AddJwt(Configuration);
            //services.AddMongoDb(Configuration);
            //services.AddRabbitMq(Configuration);
            //services.AddTransient<ICommandHandler<CreateUser>,CreateUserHandler>();
            services.AddTransient<IEncrypter, Encrypter>();
            services.AddTransient<IUserRepository,UserRepository>();
            services.AddTransient<IUserService,UserService>();

          



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
    
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

           // app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
