using AutoMapper;
using IMS.Core.Entities;
using IMS.Core.Repository;
using IMS.Core.Service;
using IMS.Data.Repositories;
using IMS.Data.Repository;
using IMS.Service.Service;
using IMS.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using RFIDReaderAPI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace IMS.Client
{
    public class Startup
    {
        public static string SecretKey = "401b09eab3c013d4ca54922bb802bec8fd5318192b0aAMK167d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        readonly string MyAllowSpecificOrigins = "CorsPolicy";
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region Configure DataBase Connection String
            services.AddDbContext<AppDbContext>(options =>
             options.UseSqlServer(
                 Configuration.GetConnectionString("InventoryMSDb")));
            #endregion

            #region Add Injection Scops
            services.AddScoped<IScannedProductRepository, ScannedProductRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IMeasuringUnitRepository, MeasuringUnitRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IScannedStateRepository, ScannedStateRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<ITransferInRepository, TransferInRepository>();
            services.AddScoped<ICustmerRepository, CustmerRepository>();
            services.AddScoped<ITransferOutRepository, TransferOutRepository>();


            services.AddScoped<ITransferOutService, TransferOutService>();
            services.AddScoped<ICustmerService, CustmerService>();
            services.AddScoped<ITransferInService, TransferInService>();
            services.AddScoped<ISuppilerService, SuppilerService>();
            services.AddScoped<IMeasuringUnitService, MeasuringUnitService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IScannedProductService, ScannedProductService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddHttpContextAccessor();
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();
            #endregion

            #region Session Configuration
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(60);//You can set Time (1) Hour   
            });
            #endregion

            services.AddControllers();

            services.AddAutoMapper();
            services.AddMvc();

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStatusCodePages(async context =>
            {
                var request = context.HttpContext.Request;
                var response = context.HttpContext.Response;

                if (response.StatusCode == (int)HttpStatusCode.Unauthorized)
                {
                    response.Redirect("User/login");
                }
            });
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}