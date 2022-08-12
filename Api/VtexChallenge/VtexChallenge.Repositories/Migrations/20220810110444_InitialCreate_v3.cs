using Microsoft.EntityFrameworkCore.Migrations;

namespace VtexChallenge.Repositories.Migrations
{
	public partial class InitialCreate_v3 : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<int>(
				name: "TraceId",
				table: "Properties",
				type: "int",
				nullable: true,
				oldClrType: typeof(int),
				oldType: "int");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<int>(
				name: "TraceId",
				table: "Properties",
				type: "int",
				nullable: false,
				defaultValue: 0,
				oldClrType: typeof(int),
				oldType: "int",
				oldNullable: true);
		}
	}
}
