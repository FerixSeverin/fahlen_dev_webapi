using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fahlen_dev_webapi.Data;
using fahlen_dev_webapi.Options;
using fahlen_dev_webapi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;

namespace fahlen_dev_webapi
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
            // Database connection
            services.AddDbContext<FoodContext>(opt => opt.UseNpgsql(""));

            // Cert
            services.AddDataProtection()
                .PersistKeysToDbContext<FoodContext>().UseCryptographicAlgorithms(new AuthenticatedEncryptorConfiguration() {
                    EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC,
                    ValidationAlgorithm = ValidationAlgorithm.HMACSHA256
                });;
            
            services.AddControllers().AddNewtonsoftJson(s => {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });

            // Add user to database
            services.AddDefaultIdentity<IdentityUser>()
                .AddEntityFrameworkStores<FoodContext>();
            

            // Load JWT settings with secret
            var jwtSettings = new JwtSettings();
            // jwtSettings.Secret = Environment.GetEnvironmentVariable("JWT_SECRET");
            
            Configuration.Bind(nameof(jwtSettings), jwtSettings);
            jwtSettings.Secret = "";
            services.AddSingleton(jwtSettings);

            services.AddScoped<IIdentityService, IdentityService>();

            // Token validation parameters
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = false,
                ValidateLifetime = true
            };

            services.AddSingleton(tokenValidationParameters);
            services.AddSingleton<IHttpContextAccessor,
                HttpContextAccessor>();

            // Bearer authentication
            services.AddAuthentication(x => {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x => {
                x.SaveToken = true;
                x.TokenValidationParameters = tokenValidationParameters;
            });

            // Automapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<IFoodDBRepo, PostgresFoodRepo>();
            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "fahlen_dev_webapi", Version = "v1" });

                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {
                        "Bearer", new string[0]
                    }
                };

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme {
                    Description = "JWT Authorization header using the bearer scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement() {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });

            // Cors policy
            services.AddCors(options => {
                options.AddPolicy("CorsPolicy",
                builder => {
                        builder.WithOrigins("https://*.fahlen.dev")
                                .SetIsOriginAllowedToAllowWildcardSubdomains()
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials();
                                
                    }
                );
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Activate Cors
            app.UseCors("CorsPolicy");

            // Developer mode
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "fahlen_dev_webapi v1"));
            }
            // HTTPS redirect
            //app.UseHttpsRedirection();

            // Activate Routing
            app.UseRouting();

            
            // Activate Authentication
            app.UseAuthorization();

            //Activate Endpoints
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }
    }
}
