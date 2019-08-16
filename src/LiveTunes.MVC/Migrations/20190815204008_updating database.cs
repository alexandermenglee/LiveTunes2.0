using Microsoft.EntityFrameworkCore.Migrations;

namespace LiveTunes.MVC.Migrations
{
<<<<<<< HEAD:src/LiveTunes.MVC/Migrations/20190815185135_InitialMigrationh.cs
    public partial class InitialMigrationh : Migration
=======
    public partial class updatingdatabase : Migration
>>>>>>> 1ff39db991e148d5faa8ba80911bc3a9232663ff:src/LiveTunes.MVC/Migrations/20190815204008_updating database.cs
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Event",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Event");
        }
    }
}
