using Microsoft.EntityFrameworkCore.Migrations;

namespace AWork.Identity.API.Migrations
{
    public partial class LastAccess : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "AspNetUsers",
                newName: "LastAccess");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastAccess",
                table: "AspNetUsers",
                newName: "BirthDate");
        }
    }
}
