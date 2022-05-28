using ChatRoom.Domain.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChatRoom.IoC
{
    public static class NativeInjectorConfig
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            var apiConfig = configuration.GetSection("Api").Get<ApiConfig>();
            if (apiConfig != null)
                services.AddSingleton(apiConfig);

            services.RegisterCommand();
            services.RegisterDatabase(configuration);
        }

        public static void ApplyMigrations(this IServiceProvider services)
        {
            services.ApplyDatabaseMigrations();
        }
    }
}
