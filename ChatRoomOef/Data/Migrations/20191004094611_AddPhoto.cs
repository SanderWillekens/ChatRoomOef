using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatRoomOef.Data.Migrations
{
    public partial class AddPhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserPictures",
                columns: table => new
                {
                    UserID = table.Column<string>(nullable: false),
                    Photo = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPictures", x => x.UserID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPictures");
        }
    }
}
