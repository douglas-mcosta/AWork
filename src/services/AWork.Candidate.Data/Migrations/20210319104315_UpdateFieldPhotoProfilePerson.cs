using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace AWork.Infra.Migrations
{
    public partial class UpdateFieldPhotoProfilePerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.RenameColumn(
                name: "ProfileBase64",
                table: "Person",
                newName: "PhotoProfile");

            migrationBuilder.RenameColumn(
                name: "LanguageLevel",
                table: "LanguegePerson",
                newName: "fluencyLevel");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoProfile",
                table: "Person",
                newName: "ProfileBase64");

            migrationBuilder.RenameColumn(
                name: "fluencyLevel",
                table: "LanguegePerson",
                newName: "LanguageLevel");

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Initials = table.Column<string>(type: "varchar(2)", nullable: false),
                    Name = table.Column<string>(type: "varchar(20)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });
        }
    }
}
