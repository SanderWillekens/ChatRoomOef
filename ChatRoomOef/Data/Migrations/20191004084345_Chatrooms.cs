using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChatRoomOef.Data.Migrations
{
    public partial class Chatrooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chatrooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CreatorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chatrooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ActualMessage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatroomMessages",
                columns: table => new
                {
                    ChatroomId = table.Column<int>(nullable: false),
                    MessageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatroomMessages", x => new { x.ChatroomId, x.MessageId });
                    table.ForeignKey(
                        name: "FK_ChatroomMessages_Chatrooms_ChatroomId",
                        column: x => x.ChatroomId,
                        principalTable: "Chatrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChatroomUsers",
                columns: table => new
                {
                    ChatroomId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatroomUsers", x => new { x.ChatroomId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ChatroomUsers_Chatrooms_ChatroomId",
                        column: x => x.ChatroomId,
                        principalTable: "Chatrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatroomMessages");

            migrationBuilder.DropTable(
                name: "ChatroomUsers");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Chatrooms");
        }
    }
}
