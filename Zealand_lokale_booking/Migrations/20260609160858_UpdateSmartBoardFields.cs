using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zealand_lokale_booking.Migrations
{
    public partial class UpdateSmartBoardFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SmartBoards",
                type: "longtext",
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "SizeInches",
                table: "SmartBoards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "SmartBoards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SmartBoards_RoomId",
                table: "SmartBoards",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_SmartBoards_Rooms_RoomId",
                table: "SmartBoards",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SmartBoards_Rooms_RoomId",
                table: "SmartBoards");

            migrationBuilder.DropIndex(
                name: "IX_SmartBoards_RoomId",
                table: "SmartBoards");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "SmartBoards");

            migrationBuilder.DropColumn(
                name: "SizeInches",
                table: "SmartBoards");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "SmartBoards");
        }
    }
}