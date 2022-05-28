using ChatRoom.Application.Hubs;
using ChatRoom.Domain.Commands.Post;
using ChatRoom.Domain.Interfaces.Bus;
using ChatRoom.Domain.Interfaces.Queries;
using ChatRoom.Domain.Models;
using ChatRoom.Domain.Queries;
using ChatRoom.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ChatRoom.Web.Controllers
{
    [Authorize]
    public class PostController : CommandController
    {
        private readonly IPostQueries _postQueries;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHubContext<ChatHub, ITypedChatHub> _chatHub;
        private const string BootUserName = "ChatRoom Boot";

        public PostController(IPostQueries postQueries, UserManager<IdentityUser> userManager, IMediatorHandler bus, IHubContext<ChatHub, ITypedChatHub> chatHub) : base(bus)
        {
            _postQueries = postQueries;
            _userManager = userManager;
            _chatHub = chatHub;
        }

        public async Task<PagingQueryResult<PostViewModel>> Find(Guid id)
        {
            var parameters = new PostsParams { RoomId = id, UserId = GetUserId() };

            var result = await _postQueries.FindByRoom(parameters);
            return ConvertToPagingPostModel(result);
        }

        // POST: PostController/Create
        [HttpPost]
        public async Task<IActionResult> Create(PostViewModel model)
        {
            return await ExecuteCommand(new CreatePostCommand(GetUserId(), model.RoomId, model.Content, _chatHub));
        }

        private PagingQueryResult<PostViewModel> ConvertToPagingPostModel(PagingQueryResult<Post> result)
        {
            var posts = new List<PostViewModel>();

            if (result.TotalRecords == 0)
                return new PagingQueryResult<PostViewModel>(posts);

            var records = result.Records.OrderBy(r => r.Created).ToList();

            foreach (var post in records)
            {
                posts.Add(ConvertToPostModel(post));
            }

            return new PagingQueryResult<PostViewModel>(posts, result.TotalRecords, result.PageSize);
        }

        private PostViewModel ConvertToPostModel(Post post)
        {
            if (post == null)
                return new PostViewModel();

            return new PostViewModel {
                Id = post.Id,
                RoomId = post.RoomId,
                FromUser = post.From,
                FromUserName = string.IsNullOrEmpty(post.From) ? BootUserName : _userManager.FindByIdAsync(post.From).Result.UserName,
                Created = post.Created.ToString("HH:mm"),
                Content = post.Content,
                IsCommand = post.IsCommand
            };
        }

    }
}
