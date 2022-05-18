using ChatRoom.Data.Mappings;
using ChatRoom.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatRoom.Data.Contexts
{
    public class ChatRoomContext : DbContext
    {
        public ChatRoomContext(DbContextOptions<ChatRoomContext> options) : base(options)
        {
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoomMap());
            modelBuilder.ApplyConfiguration(new PostMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
