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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TzuChing.HotelManagement.ApplicationCore.RepositoryInterface;
using TzuChing.HotelManagement.ApplicationCore.ServiceInterface;
using TzuChing.HotelManagement.Infrastructure.Data;
using TzuChing.HotelManagement.Infrastructure.Helper;
using TzuChing.HotelManagement.Infrastructure.Repository;
using TzuChing.HotelManagement.Infrastructure.Service;

namespace TzuChing.HotelManagement.API
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

            services.AddControllers();

            services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
            services.AddScoped<IRoomRepository,RoomRepository>();
            services.AddScoped<ICustomerRepository,CustomerRepository>();
            services.AddScoped<IServiceRepository,ServiceRepository>();
            services.AddScoped<IRoomService,RoomService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IServiceService,ServiceService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TzuChing.HotelManagement.API", Version = "v1" });
            });
            
            services.AddDbContext<HotelManagementDBContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("Hotel")
            ));
            services.AddAutoMapper(typeof(Startup), typeof(MappingProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TzuChing.HotelManagement.API v1"));
            }

            app.UseCors(builder => {
                builder.WithOrigins(Configuration.GetValue<string>("ClientSPAUrl")).AllowAnyHeader().AllowAnyMethod();
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
