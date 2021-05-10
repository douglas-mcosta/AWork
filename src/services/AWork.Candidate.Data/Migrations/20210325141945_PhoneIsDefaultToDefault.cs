using Microsoft.EntityFrameworkCore.Migrations;

namespace AWork.Infra.Migrations
{
    public partial class PhoneIsDefaultToDefault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "phoneNumber",
                table: "Phone",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "IsDefault",
                table: "Phone",
                newName: "Default");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Phone",
                newName: "phoneNumber");

            migrationBuilder.RenameColumn(
                name: "Default",
                table: "Phone",
                newName: "IsDefault");
        }
    }
}
