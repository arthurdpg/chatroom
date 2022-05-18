using ChatRoom.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatRoom.Data.Mappings
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id);

            builder.Property(x => x.UserId)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.Created)
               .IsRequired();

            builder.Property(x => x.Content)
                .HasColumnType("varchar(280)")
                .HasMaxLength(280)
                .IsRequired();

            builder.HasOne(x => x.Room)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.RoomId)
                .IsRequired();
        }
    }
}
