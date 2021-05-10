using Microsoft.EntityFrameworkCore.Migrations;

namespace AWork.Infra.Migrations
{
    public partial class AjusteNoCpf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "Candidate",
                newName: "Cpf");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Candidate",
                type: "varchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(11)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Candidate",
                newName: "CPF");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Candidate",
                type: "varchar(11)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldMaxLength: 11,
                oldNullable: true);
        }
    }
}
