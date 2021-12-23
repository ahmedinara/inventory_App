using AutoMapper;
using IMS.Core.Entities;
using IMS.Core.Repository;
using IMS.Core.Service;
using IMS.Data.Repositories;
using IMS.Data.Repository;
using IMS.Service.Service;
using IMS.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public static string SecretKey = "401b09eab3c013d4ca54922bb802bec8fd5318192b0aAMK167d8b3727429090fb337591abd3e44453b954555b7a0812e1081c39b740293f765eae731f5a65ed1";

        readonly string MyAllowSpecificOrigins = "CorsPolicy";
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            #region Configure DataBase Connection String
            services.AddDbContext<AppDbContext>(options =>
             options.UseSqlServer(
                 Configuration.GetConnectionString("InventoryMSDb")));
            #endregion

            services.AddControllers();

            services.AddAutoMapper();

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
            #endregion

            #region Configure Bearer Token
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(
                option =>
                {
                    option.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                    option.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = async (context) =>
                        {
                            context.Response.StatusCode = 401;
                            await context.Response.WriteAsync("UnAuthrized");
                        }
                    };
                });
            #endregion

            #region Configure Cors
            services.AddCors(o =>
            {
                o.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                       .AllowAnyHeader().AllowAnyMethod();
                    });
            });
            #endregion

            #region Configure Swagger UI
            services.AddSwaggerGen(c =>
            {
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, Array.Empty<string>() }
                });
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "InventoryMS", Version = "v1" });
            });
            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
              
            }
            app.UseDeveloperExceptionPage();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "InventoryMS v1"));
            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);
            app.UseAuthentication();            // Added For Authentication
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
