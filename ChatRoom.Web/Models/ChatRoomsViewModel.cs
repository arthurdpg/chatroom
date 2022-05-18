namespace ChatRoom.Web.Models
{
    public class ChatRoomsViewModel
    {
        public List<ChatRoomViewModel> Rooms { get; set; }
        public bool RoomsNotFound => Rooms == null || Rooms.Count == 0;
    }
}
