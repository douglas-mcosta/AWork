using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AWork.Infra.Migrations
{
    public partial class ChangePersonToCandidate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicEducations_Person_PersonId",
                table: "AcademicEducations");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Person_PersonId",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Person_CreatedById",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSubscribes_Person_PersonId",
                table: "JobSubscribes");

            migrationBuilder.DropForeignKey(
                name: "FK_JobTitleInteresteds_Person_PersonId",
                table: "JobTitleInteresteds");

            migrationBuilder.DropForeignKey(
                name: "FK_LanguegePerson_Person_PersonId",
                table: "LanguegePerson");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Person_PersonId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Phone_Person_PersonId",
                table: "Phone");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalBackgrounds_Person_PersonId",
                table: "ProfessionalBackgrounds");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "ProfessionalBackgrounds",
                newName: "CandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfessionalBackgrounds_PersonId",
                table: "ProfessionalBackgrounds",
                newName: "IX_ProfessionalBackgrounds_CandidateId");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Phone",
                newName: "CandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_Phone_PersonId",
                table: "Phone",
                newName: "IX_Phone_CandidateId");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Notifications",
                newName: "CandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_PersonId",
                table: "Notifications",
                newName: "IX_Notifications_CandidateId");

            migrationBuilder.RenameColumn(
                name: "fluencyLevel",
                table: "LanguegePerson",
                newName: "FluencyLevel");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "LanguegePerson",
                newName: "CandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_LanguegePerson_PersonId",
                table: "LanguegePerson",
                newName: "IX_LanguegePerson_CandidateId");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "JobTitleInteresteds",
                newName: "CandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_JobTitleInteresteds_PersonId",
                table: "JobTitleInteresteds",
                newName: "IX_JobTitleInteresteds_CandidateId");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "JobSubscribes",
                newName: "CandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_JobSubscribes_PersonId",
                table: "JobSubscribes",
                newName: "IX_JobSubscribes_CandidateId");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Interviews",
                newName: "CandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_Interviews_PersonId",
                table: "Interviews",
                newName: "IX_Interviews_CandidateId");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "AcademicEducations",
                newName: "CandidateId");

            migrationBuilder.RenameIndex(
                name: "IX_AcademicEducations_PersonId",
                table: "AcademicEducations",
                newName: "IX_AcademicEducations_CandidateId");

            migrationBuilder.AlterColumn<string>(
                name: "Benefits",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(500)");

            migrationBuilder.CreateTable(
                name: "Candidate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NationalityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MaritalStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SpecialNeedsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReligionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FirstName = table.Column<string>(type: "varchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(200)", nullable: false),
                    FullName = table.Column<string>(type: "varchar(300)", nullable: true),
                    CPF = table.Column<string>(type: "varchar(11)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    PhotoProfile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PPD = table.Column<bool>(type: "bit", nullable: false),
                    Goal = table.Column<string>(type: "varchar(450)", nullable: true),
                    Summary = table.Column<string>(type: "varchar(500)", nullable: true),
                    LinkedIn = table.Column<string>(type: "varchar(500)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidate_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Candidate_Country_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Candidate_MaritalStatus_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalTable: "MaritalStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Candidate_Religions_ReligionId",
                        column: x => x.ReligionId,
                        principalTable: "Religions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Candidate_SpecialNeeds_SpecialNeedsId",
                        column: x => x.SpecialNeedsId,
                        principalTable: "SpecialNeeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_AddressId",
                table: "Candidate",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_MaritalStatusId",
                table: "Candidate",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_NationalityId",
                table: "Candidate",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_ReligionId",
                table: "Candidate",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_SpecialNeedsId",
                table: "Candidate",
                column: "SpecialNeedsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicEducations_Candidate_CandidateId",
                table: "AcademicEducations",
                column: "CandidateId",
                principalTable: "Candidate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Candidate_CandidateId",
                table: "Interviews",
                column: "CandidateId",
                principalTable: "Candidate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Candidate_CreatedById",
                table: "Jobs",
                column: "CreatedById",
                principalTable: "Candidate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSubscribes_Candidate_CandidateId",
                table: "JobSubscribes",
                column: "CandidateId",
                principalTable: "Candidate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobTitleInteresteds_Candidate_CandidateId",
                table: "JobTitleInteresteds",
                column: "CandidateId",
                principalTable: "Candidate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LanguegePerson_Candidate_CandidateId",
                table: "LanguegePerson",
                column: "CandidateId",
                principalTable: "Candidate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Candidate_CandidateId",
                table: "Notifications",
                column: "CandidateId",
                principalTable: "Candidate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Phone_Candidate_CandidateId",
                table: "Phone",
                column: "CandidateId",
                principalTable: "Candidate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalBackgrounds_Candidate_CandidateId",
                table: "ProfessionalBackgrounds",
                column: "CandidateId",
                principalTable: "Candidate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicEducations_Candidate_CandidateId",
                table: "AcademicEducations");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Candidate_CandidateId",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Candidate_CreatedById",
                table: "Jobs");

            migrationBuilder.DropForeignKey(
                name: "FK_JobSubscribes_Candidate_CandidateId",
                table: "JobSubscribes");

            migrationBuilder.DropForeignKey(
                name: "FK_JobTitleInteresteds_Candidate_CandidateId",
                table: "JobTitleInteresteds");

            migrationBuilder.DropForeignKey(
                name: "FK_LanguegePerson_Candidate_CandidateId",
                table: "LanguegePerson");

            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Candidate_CandidateId",
                table: "Notifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Phone_Candidate_CandidateId",
                table: "Phone");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessionalBackgrounds_Candidate_CandidateId",
                table: "ProfessionalBackgrounds");

            migrationBuilder.DropTable(
                name: "Candidate");

            migrationBuilder.RenameColumn(
                name: "CandidateId",
                table: "ProfessionalBackgrounds",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfessionalBackgrounds_CandidateId",
                table: "ProfessionalBackgrounds",
                newName: "IX_ProfessionalBackgrounds_PersonId");

            migrationBuilder.RenameColumn(
                name: "CandidateId",
                table: "Phone",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Phone_CandidateId",
                table: "Phone",
                newName: "IX_Phone_PersonId");

            migrationBuilder.RenameColumn(
                name: "CandidateId",
                table: "Notifications",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_CandidateId",
                table: "Notifications",
                newName: "IX_Notifications_PersonId");

            migrationBuilder.RenameColumn(
                name: "FluencyLevel",
                table: "LanguegePerson",
                newName: "fluencyLevel");

            migrationBuilder.RenameColumn(
                name: "CandidateId",
                table: "LanguegePerson",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_LanguegePerson_CandidateId",
                table: "LanguegePerson",
                newName: "IX_LanguegePerson_PersonId");

            migrationBuilder.RenameColumn(
                name: "CandidateId",
                table: "JobTitleInteresteds",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_JobTitleInteresteds_CandidateId",
                table: "JobTitleInteresteds",
                newName: "IX_JobTitleInteresteds_PersonId");

            migrationBuilder.RenameColumn(
                name: "CandidateId",
                table: "JobSubscribes",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_JobSubscribes_CandidateId",
                table: "JobSubscribes",
                newName: "IX_JobSubscribes_PersonId");

            migrationBuilder.RenameColumn(
                name: "CandidateId",
                table: "Interviews",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Interviews_CandidateId",
                table: "Interviews",
                newName: "IX_Interviews_PersonId");

            migrationBuilder.RenameColumn(
                name: "CandidateId",
                table: "AcademicEducations",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_AcademicEducations_CandidateId",
                table: "AcademicEducations",
                newName: "IX_AcademicEducations_PersonId");

            migrationBuilder.AlterColumn<string>(
                name: "Benefits",
                table: "Contracts",
                type: "varchar(500)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DownloadPPD = table.Column<bool>(type: "bit", nullable: true),
                    FirstName = table.Column<string>(type: "varchar(100)", nullable: false),
                    FullName = table.Column<string>(type: "varchar(300)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    Goal = table.Column<string>(type: "varchar(450)", nullable: true),
                    GrupoAPSeIdEmpresa = table.Column<int>(type: "int", nullable: true),
                    IdGroupApse = table.Column<int>(type: "int", nullable: true),
                    IdGroupApseGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastName = table.Column<string>(type: "varchar(200)", nullable: false),
                    LinkedIn = table.Column<string>(type: "varchar(500)", nullable: true),
                    MaritalStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NationalityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PPD = table.Column<bool>(type: "bit", nullable: false),
                    PhotoProfile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReligionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SpecialNeedsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Summary = table.Column<string>(type: "varchar(500)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_Country_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_MaritalStatus_MaritalStatusId",
                        column: x => x.MaritalStatusId,
                        principalTable: "MaritalStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_Religions_ReligionId",
                        column: x => x.ReligionId,
                        principalTable: "Religions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_SpecialNeeds_SpecialNeedsId",
                        column: x => x.SpecialNeedsId,
                        principalTable: "SpecialNeeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Person_AddressId",
                table: "Person",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_MaritalStatusId",
                table: "Person",
                column: "MaritalStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_NationalityId",
                table: "Person",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_ReligionId",
                table: "Person",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_SpecialNeedsId",
                table: "Person",
                column: "SpecialNeedsId");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicEducations_Person_PersonId",
                table: "AcademicEducations",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Person_PersonId",
                table: "Interviews",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Person_CreatedById",
                table: "Jobs",
                column: "CreatedById",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobSubscribes_Person_PersonId",
                table: "JobSubscribes",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JobTitleInteresteds_Person_PersonId",
                table: "JobTitleInteresteds",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LanguegePerson_Person_PersonId",
                table: "LanguegePerson",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Person_PersonId",
                table: "Notifications",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Phone_Person_PersonId",
                table: "Phone",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessionalBackgrounds_Person_PersonId",
                table: "ProfessionalBackgrounds",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
