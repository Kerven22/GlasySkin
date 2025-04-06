using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Repositories;
using Repositories.DataBaseContext;
using Repository.Contract.Abstractions;
using Service.Contract;
using Services;
using Services.AuthenticationService;
using System.Text;

namespace GlasySkin.Extentions
{
    public static class ServiceExtentions
    {
        public static void CorsConfigure(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CustomPolicy", o =>

                    o.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()

                );
            });
        }

        public static void SqlServerConfigure(this IServiceCollection services, IConfiguration configuration) =>
            services.AddSqlServer<RepositoryContext>(configuration.GetConnectionString("sqlServer"), b => b.MigrationsAssembly("GlasySkin"));

        public static void RepositoryManagerConfigure(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ServiceManagerConfigure(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();


        public static void AddApiAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer =  AuthOption.Issure,
                    ValidateAudience = true,
                    ValidAudience = AuthOption.Audience,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthOption.SecretKey))
                };
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies["myCookies"];
                        return Task.CompletedTask; 
                    }
                }; 
            });

            services.AddAuthorization();

        }
    }
}
