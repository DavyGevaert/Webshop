using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Webshop.Api.Authentication;
using Webshop.Api.Authentication.Abstractions;
using Webshop.Api.Authentication.Settings;
using Webshop.Api.Settings;
using Webshop.Repository;
using Webshop.Services;
using Webshop.Services.Abstractions;

namespace Webshop.Api
{
    public class Startup
    {
        string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static readonly ILoggerFactory ConsoleLoggerFactory
            = LoggerFactory.Create(builder => { builder.AddConsole(); });

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var settings = new AppSettings();
            Configuration.Bind(nameof(AppSettings), settings);
            services.AddSingleton(settings);

            var jwtSettings = new JwtSettings();
            Configuration.Bind(nameof(JwtSettings), jwtSettings);
            services.AddSingleton(jwtSettings);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            });

                //.AddJwtBearer(options =>
                //{
                //    options.SaveToken = true;
                //    options.TokenValidationParameters = new TokenValidationParameters
                //    {
                //        ValidateIssuerSigningKey = true,
                //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
                //        ValidateIssuer = false,
                //        ValidateAudience = false,
                //        RequireExpirationTime = false,
                //        ValidateLifetime = true
                //    };
                //});

            // Add services to the container.
            services.AddControllers();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Webshop.Api", Version = "v1" });

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "JWT Authorization using the Bearer Token scheme",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                };
                options.AddSecurityDefinition("Bearer", securityScheme);

                var securityRequirementScheme = new OpenApiSecurityScheme()
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                };
                var securityRequirement = new OpenApiSecurityRequirement
                {
                    {
                        securityRequirementScheme, new string[] { }
                    }
                };
                options.AddSecurityRequirement(securityRequirement);
            });

            services.AddDbContext<WebshopDbContext>(options =>
            {
                options.UseLoggerFactory(ConsoleLoggerFactory);
                options.UseSqlServer(settings.ConnectionString);
            });

            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
            }).AddEntityFrameworkStores<WebshopDbContext>();

            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<IIdentityService, IdentityService>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                                  });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, WebshopDbContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Webshop.Api v1"));
            }

            app.UseCors(MyAllowSpecificOrigins);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
