using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfrastructureLayer.Context.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Utility;
using POSApi.GlobalErrorHandling;
using POSApi.Filters;
using AutoMapper;
using Utility.AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using InfrastructureLayer.Interfaces;
using InfrastructureLayer.Implementations;
using BusinessLayer.Interface;
using BusinessLayer.Implementations;

namespace POSApi
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
            services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            }));


            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<POSContext>(options => options.UseLazyLoadingProxies().UseSqlServer(connectionString));

            // Adding validation filter
            services.AddMvc(options => options.Filters.Add(typeof(ValidationFilterAttribute)));

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new AutoMapperProfile()); });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: Constants.SwaggerDoc,
                    new OpenApiInfo { Title = Constants.SwaggerTitle, Version = Constants.ApiVersion });
                c.AddSecurityDefinition(Constants.SecurityScheme, new OpenApiSecurityScheme
                {
                    Description = Constants.Description,
                    Name = Constants.Authorization,
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = Constants.SecurityScheme,
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = Constants.SecurityScheme,
                            },
                            Scheme = Constants.SecuritySchemeType,
                            Name = Constants.SecurityScheme,
                            In = ParameterLocation.Header,
                        },
                        new List<string>()
                    }
                });
            });

            #region Register Dependency

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthenticationService,AuthenticationService >();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ValidationFilterAttribute>();

            #endregion

            #region Authentication configuration

            var key = Configuration[Constants.SecretKey];

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                    x.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Query[Constants.AccessTokenKey];
                            return Task.CompletedTask;
                        }
                    };
                });

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.ConfigureCustomExceptionMiddleware();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<POSContext>();
                context.Database.Migrate();
            }

            app.UseAuthorization();
            
            app.UseAuthentication();

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(Constants.SwaggerEndPoint, Constants.SwaggerTitle);
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
