using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatRoom.Data.Migrations
{
    public partial class UpdatePostTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)        {
            migrationBuilder.AddColumn<bool>(
                name: "IsCommand",
                table: "Posts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCommand",
                table: "Posts");
        }
    }
}
