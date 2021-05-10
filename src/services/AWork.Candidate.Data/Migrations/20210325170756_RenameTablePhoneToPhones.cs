using Microsoft.EntityFrameworkCore.Migrations;

namespace AWork.Infra.Migrations
{
    public partial class RenameTablePhoneToPhones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phone_Candidate_CandidateId",
                table: "Phone");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Phone",
                table: "Phone");

            migrationBuilder.RenameTable(
                name: "Phone",
                newName: "Phones");

            migrationBuilder.RenameIndex(
                name: "IX_Phone_CandidateId",
                table: "Phones",
                newName: "IX_Phones_CandidateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Phones",
                table: "Phones",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Phones_Candidate_CandidateId",
                table: "Phones",
                column: "CandidateId",
                principalTable: "Candidate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Phones_Candidate_CandidateId",
                table: "Phones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Phones",
                table: "Phones");

            migrationBuilder.RenameTable(
                name: "Phones",
                newName: "Phone");

            migrationBuilder.RenameIndex(
                name: "IX_Phones_CandidateId",
                table: "Phone",
                newName: "IX_Phone_CandidateId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Phone",
                table: "Phone",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Phone_Candidate_CandidateId",
                table: "Phone",
                column: "CandidateId",
                principalTable: "Candidate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
