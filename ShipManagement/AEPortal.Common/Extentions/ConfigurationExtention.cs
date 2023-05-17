using AEPortal.Common.Configurations;
using AEPortal.Common.Extentions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;

namespace AEPortal.Common.Extentions
{
    public static class ConfigurationExtention
    {
        public static void AddConfigBase(this IServiceCollection services, IConfiguration Configuration, string rootApi, Assembly currentAssembly)
        {
            services.Configure<AppConfig>(Configuration.GetSection(nameof(AppConfig)));
            services.AddLogging();
            // Add services to the container.

            services.AddControllers(o =>
            {
                o.UseGeneralRoutePrefix(rootApi);
                o.ValueProviderFactories.Add(new SnakeCaseQueryValueProviderFactory());
            }).AddJsonOptions(opts =>
            {
                opts.JsonSerializerOptions.PropertyNamingPolicy = new SnakeCaseNamingPolicy();
                var enumConverter = new JsonStringEnumConverter();
                opts.JsonSerializerOptions.Converters.Add(enumConverter);

            })
                .AddNewtonsoftJson(opts =>
                {
                    opts.SerializerSettings.ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    };
                    opts.SerializerSettings.Converters.Add(new StringEnumConverter());
                });
            services.AddRouting(i => i.LowercaseUrls = true);
            services.AddMemoryCache();
            services.AddAuthentication(Configuration);
            services.AddSwagger(currentAssembly);
            services.AddCors(options =>
            {
                options.AddPolicy("AnyOrigin", builder =>
                {
                    builder
                        .WithOrigins(Configuration["AllowedHosts"])
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });
        }
        public static void AddSwagger(this IServiceCollection services, Assembly currentAssembly)
        {
            services.AddSwaggerGen(c =>
            {
                var jwtSecurityScheme = new OpenApiSecurityScheme
                {
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Description = "Please enter JWT token",

                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                c.OperationFilter<SnakecasingParameOperationFilter>();
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = currentAssembly.GetName().Version?.ToString(),
                    Title = "NovaSolution API Portal",
                    Description = "An ASP.NET Core Web API for managing NovaSolution Portal",
                });
                c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, Array.Empty<string>() }
                });
                c.EnableAnnotations();
            }).AddSwaggerGenNewtonsoftSupport();
        }
        public static void AddAuthentication(this IServiceCollection service, IConfiguration Configuration)
        {
            service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    var privateKey = LoadPrivateKey(Configuration);
                    if (privateKey?.Key != null)
                        options.TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidateLifetime = false,
                            ValidateIssuerSigningKey = true,
                            ValidAudience = Configuration["JwtConfig:Audience"],
                            ValidIssuer = Configuration["JwtConfig:Issuer"],
                            IssuerSigningKey = privateKey.Key
                        };
                });
        }

        private static SigningCredentials LoadPrivateKey(IConfiguration Configuration)
        {
            var privateKey = Configuration["JwtConfig:PrivateKey"];
            if (string.IsNullOrWhiteSpace(privateKey))
                return null;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(privateKey));
            return new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        }
    }
}
