using Microsoft.EntityFrameworkCore.Migrations;

namespace LiveTunes.MVC.Migrations
{
    public partial class all : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Music Preferences",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Music Preferences_UserId",
                table: "Music Preferences",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Music Preferences_User Profile_UserId",
                table: "Music Preferences",
                column: "UserId",
                principalTable: "User Profile",
                principalColumn: "UserProfileId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Music Preferences_User Profile_UserId",
                table: "Music Preferences");

            migrationBuilder.DropIndex(
                name: "IX_Music Preferences_UserId",
                table: "Music Preferences");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Music Preferences");
        }
    }
}
