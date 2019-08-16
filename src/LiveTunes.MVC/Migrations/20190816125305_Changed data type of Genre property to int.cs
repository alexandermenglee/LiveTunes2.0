using Microsoft.EntityFrameworkCore.Migrations;

namespace LiveTunes.MVC.Migrations
{
    public partial class ChangeddatatypeofGenrepropertytoint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Genre",
                table: "Event",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Genre",
                table: "Event",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
