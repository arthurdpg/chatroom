using ChatRoom.Domain.Commands;
using ChatRoom.Domain.Interfaces.Bus;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ChatRoom.Web.Controllers
{
    public class CommandController : Controller
    {
        protected readonly IMediatorHandler Bus;

        protected CommandController(IMediatorHandler bus)
        {
            Bus = bus;
        }

        protected async Task<IActionResult> ExecuteCommand<TResult>(ICommand<TResult> command) where TResult : CommandResult
        {
            if (command == null) return BadRequest("Invalid command.");
            var result = await Bus.SendCommand(command);
            if (result.IsValid) return Ok(result);
            return BadRequest(result);
        }

        protected string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
