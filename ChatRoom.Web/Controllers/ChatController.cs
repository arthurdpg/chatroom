using ChatRoom.Domain.Commands.Post;
using ChatRoom.Domain.Commands.Room;
using ChatRoom.Domain.Interfaces.Bus;
using ChatRoom.Domain.Interfaces.Queries;
using ChatRoom.Domain.Models;
using ChatRoom.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ChatRoom.Web.Controllers
{
    [Authorize]
    public class ChatController : CommandController
    {
        private readonly IRoomQueries _roomQueries;
        private readonly UserManager<IdentityUser> _userManager;

        public ChatController(IRoomQueries roomQueries, UserManager<IdentityUser> userManager,  IMediatorHandler bus) : base(bus)
        {
            _roomQueries = roomQueries;
            _userManager = userManager;
        }

        // GET: ChatController
        public ActionResult Index()
        {
            var result = _roomQueries.FindAll().Result;
            return View(ConvertToRoomsModel(result));
        }

        // GET: ChatController/Details/5
        public ActionResult Details(Guid id)
        {
            var result = _roomQueries.FindById(id).Result;
            return View(ConvertToRoomDetailsModel(result));
        }

        // GET: ChatController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChatController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ChatRoomViewModel model)
        {
            try
            {
                await ExecuteCommand(new CreateRoomCommand(GetUserId(), model.Name, model.Description));
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: ChatController/CreatePost
        [HttpPost]
        public async Task<IActionResult> CreatePost(PostViewModel model)
        {
            return await ExecuteCommand(new CreatePostCommand(GetUserId(), model.RoomId, model.Content));
        }

        private ChatRoomsViewModel ConvertToRoomsModel(List<Room> rooms)
        {
            var model = new ChatRoomsViewModel();
            
            if (rooms != null && rooms.Any())
            {
                model.Rooms = new List<ChatRoomViewModel>();
                rooms.ForEach(r => model.Rooms.Add(ConvertToRoomModel(r)));
            }

            return model;
        }

        private ChatRoomViewModel ConvertToRoomModel(Room room)
        {
            if (room == null)
                return new ChatRoomViewModel();

            return new ChatRoomViewModel { Id = room.Id, Name = room.Name, Description = room.Description };
        }

        private ChatRoomDetailsViewModel ConvertToRoomDetailsModel(Room room)
        {
            if (room == null)
                return new ChatRoomDetailsViewModel();

            var model = new ChatRoomDetailsViewModel { Id = room.Id, Name = room.Name, Description = room.Description, Posts = new List<PostViewModel>() };

            if (room.Posts != null && room.Posts.Any())
            {
                foreach (var post in room.Posts)
                {
                    model.Posts.Add(new PostViewModel
                    {
                        Id = post.Id,
                        RoomId = post.RoomId,
                        UserId = post.UserId,
                        UserName = _userManager.FindByIdAsync(post.UserId).Result.UserName,
                        Created = post.Created,
                        Content = post.Content
                    });
                }
            }

            return model;
        }
    }
}
