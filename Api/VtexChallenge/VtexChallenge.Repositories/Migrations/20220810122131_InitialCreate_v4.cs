using Microsoft.EntityFrameworkCore.Migrations;

namespace VtexChallenge.Repositories.Migrations
{
    public partial class InitialCreate_v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "Properties",
                type: "bit",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "Enabled",
                table: "Owners",
                type: "bit",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Enabled",
                table: "Owners");
        }
    }
}
