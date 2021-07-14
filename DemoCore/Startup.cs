using DemoCore.BLL.Interfaces;
using DemoCore.BLL.Mapper;
using DemoCore.BLL.Repository;
using DemoCore.DAL.DataBase;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;

namespace DemoCore
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


            services.AddControllersWithViews().AddNewtonsoftJson(opts => {
                opts.SerializerSettings.ContractResolver = new DefaultContractResolver();
                
                
            });
                
                
            // Enahancment In Connection String

            services.AddDbContextPool<DataContext>(opts =>
            opts.UseSqlServer(Configuration.GetConnectionString("SharpDbContext")));

            // AutoMapper
            services.AddAutoMapper(m => m.AddProfile(new DomainProfile()));


             // Depependcy Injection
              
            //[Take Instance Every Request]
            //services.AddTransient<DepartmentRep>();



            //[Take One Instance For Each User]
            services.AddScoped<IDepartmentRep , DepartmentRep>();
            services.AddScoped<IEmployeeRep, EmployeeRep>();
            services.AddScoped<ICountryRep, CountryRep>();
            services.AddScoped<ICityRep, CityRep>();
            services.AddScoped<IDistricRep, DistrictRep>();



            //[Take Shared Instance For All Users]
            //services.AddSingleton<DepartmentRep>();


            /// Identity User To Create Table Belong To [User , Role]
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<DataContext>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
