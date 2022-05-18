using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatRoom.Data.Migrations
{
    public partial class SetRoomDescriptionMaxlength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Rooms",
                type: "varchar(280)",
                maxLength: 280,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Rooms",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(280)",
                oldMaxLength: 280);
        }
    }
}
