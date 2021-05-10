using Microsoft.EntityFrameworkCore.Migrations;

namespace AWork.Infra.Migrations
{
    public partial class PersonUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "Person",
                newName: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Person",
                newName: "ApplicationUserId");
        }
    }
}
