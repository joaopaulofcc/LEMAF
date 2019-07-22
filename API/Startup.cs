using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using API.Domain.Repositories;
using API.Domain.Services;
using API.Persistence.Contexts;
using API.Persistence.Repositories;
using API.Services;
using AutoMapper;

namespace API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddCors();

            services.AddDbContext<AppDbContext>(options => {
                options.UseInMemoryDatabase("api-in-memory");
            });

            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ITripRepository, TripRepository>();
            
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<ITripService, TripService>();

            services.AddAutoMapper(typeof(Startup));
        }

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

            app.UseCors(
                options => options.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}