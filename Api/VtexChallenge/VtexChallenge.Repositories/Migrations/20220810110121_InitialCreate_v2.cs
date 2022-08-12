using Microsoft.EntityFrameworkCore.Migrations;

namespace VtexChallenge.Repositories.Migrations
{
    public partial class InitialCreate_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_PropertyTraces_TraceId",
                table: "Properties");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_PropertyTraces_TraceId",
                table: "Properties",
                column: "TraceId",
                principalTable: "PropertyTraces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_PropertyTraces_TraceId",
                table: "Properties");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_PropertyTraces_TraceId",
                table: "Properties",
                column: "TraceId",
                principalTable: "PropertyTraces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
