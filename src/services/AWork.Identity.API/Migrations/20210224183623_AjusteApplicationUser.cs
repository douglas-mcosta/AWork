using Microsoft.EntityFrameworkCore.Migrations;

namespace AWork.Identity.API.Migrations
{
    public partial class AjusteApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPF",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "AspNetUsers",
                type: "varchar(11)",
                nullable: false,
                defaultValue: "");
        }
    }
}
