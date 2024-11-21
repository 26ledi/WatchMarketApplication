using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using WatchMarket.BusinessLogic.Interfaces;
using WatchMarket.BusinessLogic.Services;
using WatchMarketApp.BusinessLogic.Interfaces;
using WatchMarketApp.BusinessLogic.Services;
using WatchMarketApp.DataAccess.Data;
using WatchMarketApp.DataAccess.Repositories.Implementations;
using WatchMarketApp.DataAccess.Repositories.Interfaces;

namespace WatchMarketApp.Extensions
{
    public static class ApplicationDependanciesConfiguration
    {
        public static IServiceCollection ConfigureService(this WebApplicationBuilder builder)
        {
            AddJwtToken(builder);
            builder.Services.AddDbContext<WatchMarketContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IWatchService, WatchService>();
            builder.Services.AddScoped<IPriceService, PriceService>();
            builder.Services.AddScoped<IOrderService, OrderService>();
            builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();
            builder.Services.AddScoped<ICommentService, CommentService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddAzureClients(clientBuilder =>
            {
                clientBuilder.AddBlobServiceClient(builder.Configuration["localStorage:blob"]!, preferMsi: true);
                clientBuilder.AddQueueServiceClient(builder.Configuration["localStorage:queue"]!, preferMsi: true);
            });
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });

            return builder.Services;
        }
        public static IServiceCollection AddJwtToken(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:key"])),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    RequireExpirationTime = true,
                    ValidateLifetime = true
                };

            });

            return builder.Services; 
        }

        public static IServiceCollection AddSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My API",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                   {
                         new OpenApiSecurityScheme
                         {
                           Reference = new OpenApiReference
                           {
                             Type = ReferenceType.SecurityScheme,
                             Id = "Bearer"
                           }
                          },
                          new string[] { }
                        }
                  });
            });

            return builder.Services;
        }
    }
}
