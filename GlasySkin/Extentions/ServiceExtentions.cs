using Repositories;
using Repositories.DataBaseContext;
using Repository.Contract.Abstractions;
using Service.Contract;
using Services;

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
            services.AddSqlServer<RepositoryContext>(configuration.GetConnectionString("sqlServer"),b=>b.MigrationsAssembly("GlasySkin"));

        public static void RepositoryManagerConfigure(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ServiceManagerConfigure(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>(); 
    }
}
