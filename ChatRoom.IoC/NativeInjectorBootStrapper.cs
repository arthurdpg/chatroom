using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChatRoom.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterCommand();
            services.RegisterDatabase(configuration);
        }

        public static void ApplyMigrations(this IServiceProvider services)
        {
            services.ApplyDatabaseMigrations();
        }
    }
}
