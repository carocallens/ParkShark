using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using ParkShark.API.Controllers.Divisions.Mappers;
using ParkShark.API.Controllers.Divisions.Mappers.Interfaces;
using ParkShark.API.Controllers.Members.Mappers;
using ParkShark.API.Controllers.Members.Mappers.Interfaces;
using ParkShark.API.Controllers.ParkingLots.Mappers;
using ParkShark.API.Controllers.ParkingLots.Mappers.Interfaces;
using ParkShark.Data;
using ParkShark.Services.Divisions;
using ParkShark.Services.Divisions.Interfaces;
using ParkShark.Services.Members;
using ParkShark.Services.Members.Interfaces;
using ParkShark.Services.ParkingLots;
using ParkShark.Services.ParkingLots.Interfaces;
using Swashbuckle.AspNetCore.Swagger;

namespace ParkShark.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public readonly ILoggerFactory efLoggerFactory
          = new LoggerFactory(new[] { new ConsoleLoggerProvider((category, level) => category.Contains("Command") && level == LogLevel.Information, true) });

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "ParkShark.Api", Version = "v1" });
            });

            services.AddScoped<IDivisionServices, DivisionService>();
            services.AddScoped<IMemberServices, MemberService>();
            services.AddScoped<IParkingLotService, ParkingLotService>();

            services.AddScoped<IMemberMapper, MemberMapper>();
            services.AddScoped<IAddressMapper, AddressMapper>();
            services.AddScoped<IDivisionMapper, DivisionMapper>();
            services.AddScoped<IContactPersonMapper, ContactPersonMapper>();
            services.AddScoped<IParkingLotMapper, ParkingLotMapper>();
            services.AddScoped<IMembershipLevelMapper, MembershipLevelMapper>();
            services.AddScoped<ICityMapper, CityMapper>();

            services.AddDbContext<ParkSharkDbContext>(options =>
                options
                .UseSqlServer(Configuration.GetConnectionString("ParkSharkDb"))
                .UseLoggerFactory(efLoggerFactory));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseMvc();
            app.Run(async context =>
            {
                context.Response.Redirect("/swagger");
            });
        }
    }
}
