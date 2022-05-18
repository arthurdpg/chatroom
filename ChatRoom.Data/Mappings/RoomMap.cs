using ChatRoom.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatRoom.Data.Mappings
{
    public class RoomMap : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id);

            builder.Property(x => x.UserId)
                .HasColumnType("varchar(255)")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(x => x.Created)
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Description)
               .HasColumnType("varchar(280)")
               .HasMaxLength(280);
        }
    }
}
