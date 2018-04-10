using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ContosoUniversity.Data;
using ContosoUniversity.Data.Abstract;
using ContosoUniversity.Data.Repositories;
using ContosoUniversity.Model;
using ContosoUniversity.Model.ViewModels.Mapping;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ContosoUniversity.Api
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
            services.AddDbContext<ContosoContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ContosoUniversity"),
                    b => b.MigrationsAssembly("ContosoUniversity.Api"));
            });

            // services.AddTransient<DbInitializer>();

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.User.AllowedUserNameCharacters = null;
                options.SignIn.RequireConfirmedEmail = true;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 5;
            }).AddEntityFrameworkStores<ContosoContext>()
            .AddDefaultTokenProviders();

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            Mapper.AssertConfigurationIsValid();
            services.AddMvc();

            services.AddScoped<ICoursesRepository, CoursesRepository>();
            services.AddScoped<IInstructorsRepository, InstructorsRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env            )
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();

            //seeder.InitializeData().Wait();
        }
    }
}
