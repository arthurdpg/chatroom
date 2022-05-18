using ChatRoom.Bus;
using ChatRoom.Domain.CommandHandlers.Post;
using ChatRoom.Domain.CommandHandlers.Room;
using ChatRoom.Domain.Commands;
using ChatRoom.Domain.Commands.Post;
using ChatRoom.Domain.Commands.Room;
using ChatRoom.Domain.Interfaces.Bus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ChatRoom.IoC
{
    public static class CommandRegistry
    {
        public static void RegisterCommand(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            services.AddScoped<IRequestHandler<CreateRoomCommand, CommandResult>, CreateRoomHandler>();
            services.AddScoped<IRequestHandler<CreatePostCommand, CommandResult>, CreatePostHandler>();
        }
    }
}
