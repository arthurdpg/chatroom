using ChatRoom.Data.Contexts;
using ChatRoom.Data.Queries;
using ChatRoom.Data.Repositories;
using ChatRoom.Data.UoW;
using ChatRoom.Domain.Interfaces;
using ChatRoom.Domain.Interfaces.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChatRoom.IoC
{
    internal static class DatabaseRegistry
    {
        public static void RegisterDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ChatRoomContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IRoomQueries, RoomQueries>();
            services.AddScoped<IPostQueries, PostQueries>();
        }

        public static void ApplyDatabaseMigrations(this IServiceProvider services)
        {
            var context = services.GetRequiredService<ChatRoomContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }
    }
}
