using ChatRoom.Application.Hubs;
using ChatRoom.Domain.Commands;
using ChatRoom.Domain.Commands.Post;
using ChatRoom.Domain.Configuration;
using ChatRoom.Domain.Interfaces;
using CsvHelper;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Net.Http.Headers;

namespace ChatRoom.Domain.CommandHandlers.Post
{
    public class CreateCommandPostHandler : IHandler<CreateCommandPostCommand, CommandResult>
    {
        private readonly IServiceProvider _services;
        private readonly ApiConfig _config;

        public CreateCommandPostHandler(IServiceProvider services, ApiConfig config)
        {
            _services = services;
            _config = config;
        }

        public async Task<CommandResult> Handle(CreateCommandPostCommand request, CancellationToken cancellationToken)
        {
            using (var scope = _services.CreateScope())
            {
                var uow = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var repository = scope.ServiceProvider.GetRequiredService<IRepository<Models.Post>>();

                if (!request.IsValid())
                {
                    await SaveResponse(request, uow, repository, "Invalid command");
                }
                else
                {
                    var values = request.Content.Split("=");
                    var command = values[0];
                    var parameter = values[1];

                    try
                    {
                        switch (command)
                        {
                            case "/stock":
                                await ProcessStockCommand(request, uow, repository, parameter);
                                break;
                            default:
                                await SaveResponse(request, uow, repository, $"The command {command} is not support.");
                                break;
                        }
                    }
                    catch
                    {
                        await SaveResponse(request, uow, repository, $"An error occurred while handling the command. Try again.");
                    }
                }

                request.ChatHub.Clients.User(request.UserId).ReceiveMessage();
                return CommandResultFactory.SuccessResult(Messages.Sucess);
            }
        }

        private async Task SaveResponse(CreateCommandPostCommand request, IUnitOfWork uow, IRepository<Models.Post> repository, string content)
        {
            var post = new Models.Post(Guid.NewGuid(), null, request.UserId, request.RoomId, DateTime.Now, content);

            await repository.InsertAsync(post);
            await uow.CommitAsync();
        }

        private async Task ProcessStockCommand(CreateCommandPostCommand request, IUnitOfWork uow, IRepository<Models.Post> repository, string parameter)
        {
            using (var httpClient = GetHttpClient())
            {
                var response = await httpClient.GetAsync(string.Format(_config.StocksUrl, parameter));
                if (response.IsSuccessStatusCode)
                {
                    using (var stream = await response.Content.ReadAsStreamAsync())
                    using (var streamReader = new StreamReader(stream))
                    using (var csv = new CsvReader(streamReader, CultureInfo.CurrentCulture))
                    {
                        var records = csv.GetRecords<Stock>();
                        foreach (var record in records)
                        {
                            await SaveResponse(request, uow, repository, $"{record.Symbol} quote is ${record.Close} per share");
                        }
                    }
                }
                else
                {
                    await SaveResponse(request, uow, repository, $"An error occurred while handling the command. Try again.");
                }
            }
        }

        private HttpClient GetHttpClient()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/csv"));
            return client;
        }
    }
}

internal class Stock
{
    public string Symbol { get; set; }
    public decimal Close { get; set; }
}