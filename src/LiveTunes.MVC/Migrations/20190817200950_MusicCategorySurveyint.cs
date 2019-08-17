using Microsoft.EntityFrameworkCore.Migrations;

namespace LiveTunes.MVC.Migrations
{
    public partial class MusicCategorySurveyint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Survey_MusicCategories_FavoriteGenre1Id",
                table: "Survey");

            migrationBuilder.DropForeignKey(
                name: "FK_Survey_MusicCategories_FavoriteGenre2Id",
                table: "Survey");

            migrationBuilder.DropForeignKey(
                name: "FK_Survey_MusicCategories_FavoriteGenre3Id",
                table: "Survey");

            migrationBuilder.DropIndex(
                name: "IX_Survey_FavoriteGenre1Id",
                table: "Survey");

            migrationBuilder.DropIndex(
                name: "IX_Survey_FavoriteGenre2Id",
                table: "Survey");

            migrationBuilder.DropIndex(
                name: "IX_Survey_FavoriteGenre3Id",
                table: "Survey");

            migrationBuilder.DropColumn(
                name: "FavoriteGenre1Id",
                table: "Survey");

            migrationBuilder.DropColumn(
                name: "FavoriteGenre2Id",
                table: "Survey");

            migrationBuilder.DropColumn(
                name: "FavoriteGenre3Id",
                table: "Survey");

            migrationBuilder.AddColumn<int>(
                name: "FavoriteGenre1",
                table: "Survey",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FavoriteGenre2",
                table: "Survey",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FavoriteGenre3",
                table: "Survey",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FavoriteGenre1",
                table: "Survey");

            migrationBuilder.DropColumn(
                name: "FavoriteGenre2",
                table: "Survey");

            migrationBuilder.DropColumn(
                name: "FavoriteGenre3",
                table: "Survey");

            migrationBuilder.AddColumn<int>(
                name: "FavoriteGenre1Id",
                table: "Survey",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FavoriteGenre2Id",
                table: "Survey",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FavoriteGenre3Id",
                table: "Survey",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Survey_FavoriteGenre1Id",
                table: "Survey",
                column: "FavoriteGenre1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_FavoriteGenre2Id",
                table: "Survey",
                column: "FavoriteGenre2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Survey_FavoriteGenre3Id",
                table: "Survey",
                column: "FavoriteGenre3Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Survey_MusicCategories_FavoriteGenre1Id",
                table: "Survey",
                column: "FavoriteGenre1Id",
                principalTable: "MusicCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Survey_MusicCategories_FavoriteGenre2Id",
                table: "Survey",
                column: "FavoriteGenre2Id",
                principalTable: "MusicCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Survey_MusicCategories_FavoriteGenre3Id",
                table: "Survey",
                column: "FavoriteGenre3Id",
                principalTable: "MusicCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
