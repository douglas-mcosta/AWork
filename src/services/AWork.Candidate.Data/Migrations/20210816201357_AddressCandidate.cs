using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AWork.Infra.Migrations
{
    public partial class AddressCandidate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_Address_AddressId",
                table: "Candidate");

            migrationBuilder.DropIndex(
                name: "IX_Candidate_AddressId",
                table: "Candidate");

            migrationBuilder.AddColumn<Guid>(
                name: "CandidateId",
                table: "Address",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Address_CandidateId",
                table: "Address",
                column: "CandidateId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Candidate_CandidateId",
                table: "Address",
                column: "CandidateId",
                principalTable: "Candidate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Candidate_CandidateId",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_CandidateId",
                table: "Address");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "Address");

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_AddressId",
                table: "Candidate",
                column: "AddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_Address_AddressId",
                table: "Candidate",
                column: "AddressId",
                principalTable: "Address",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
