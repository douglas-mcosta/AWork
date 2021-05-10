using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace AWork.Infra.Migrations
{
    public partial class AjusteDeContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_InterviewsSchedules_InterviewsScheduleId",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_InterviewStatus_InterviewStatusId",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_JobRequests_JobRequestId",
                table: "Jobs");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "ContractRequests");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "InterviewsSchedules");

            migrationBuilder.DropTable(
                name: "InterviewStatus");

            migrationBuilder.DropTable(
                name: "JobRequestStatus");

            migrationBuilder.DropTable(
                name: "SyncAPS");

            migrationBuilder.DropTable(
                name: "JobRequests");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Entities");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_JobRequestId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Interviews_InterviewsScheduleId",
                table: "Interviews");

            migrationBuilder.DropIndex(
                name: "IX_Interviews_InterviewStatusId",
                table: "Interviews");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidates_Person_Id",
                        column: x => x.Id,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContractRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnalyzedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractRequests_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContractRequests_Person_AnalyzedById",
                        column: x => x.AnalyzedById,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Entities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Alias = table.Column<string>(type: "varchar(20)", nullable: false),
                    ContactEmail = table.Column<string>(type: "varchar(200)", nullable: false),
                    EntitiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EntityChildId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    SiteAddress = table.Column<string>(type: "varchar(200)", nullable: false),
                    SiteDomain = table.Column<string>(type: "varchar(200)", nullable: false),
                    UseWebServer_GrupoAPSe = table.Column<bool>(type: "bit", nullable: false),
                    WebServer_GrupoAPSe_Id_Empresa = table.Column<int>(type: "int", nullable: true),
                    WebServer_GrupoAPSe_password = table.Column<string>(type: "varchar(36)", nullable: true),
                    WebServer_GrupoAPSe_user = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entities_Entities_EntitiesId",
                        column: x => x.EntitiesId,
                        principalTable: "Entities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Extension = table.Column<string>(type: "varchar(10)", nullable: false),
                    FileStream = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    LastAccessTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastWriteTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Length = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false),
                    Type = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InterviewStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Color = table.Column<string>(type: "varchar(50)", nullable: true),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SyncAPS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Abbreviation = table.Column<string>(type: "varchar(60)", nullable: true),
                    CPF = table.Column<string>(type: "varchar(11)", nullable: false),
                    Entity = table.Column<string>(type: "varchar(20)", nullable: false),
                    HiringDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResignationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "varchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SyncAPS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locations_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InterviewsSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", nullable: false),
                    JobSubscribeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Link = table.Column<string>(type: "varchar(300)", nullable: true),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Via = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewsSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InterviewsSchedules_JobSubscribes_JobSubscribeId",
                        column: x => x.JobSubscribeId,
                        principalTable: "JobSubscribes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InterviewsSchedules_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<int>(type: "int", nullable: false),
                    JobQuantity = table.Column<int>(type: "int", nullable: false),
                    JobTitleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobRequests_JobTitles_JobTitleId",
                        column: x => x.JobTitleId,
                        principalTable: "JobTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobRequests_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobRequests_Person_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobRequestStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnalyzedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", nullable: false),
                    JobRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobRequestStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobRequestStatus_JobRequests_JobRequestId",
                        column: x => x.JobRequestId,
                        principalTable: "JobRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobRequestStatus_Person_AnalyzedById",
                        column: x => x.AnalyzedById,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobRequestId",
                table: "Jobs",
                column: "JobRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_InterviewsScheduleId",
                table: "Interviews",
                column: "InterviewsScheduleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Interviews_InterviewStatusId",
                table: "Interviews",
                column: "InterviewStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractRequests_AnalyzedById",
                table: "ContractRequests",
                column: "AnalyzedById");

            migrationBuilder.CreateIndex(
                name: "IX_ContractRequests_ContractId",
                table: "ContractRequests",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Entities_EntitiesId",
                table: "Entities",
                column: "EntitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewsSchedules_JobSubscribeId",
                table: "InterviewsSchedules",
                column: "JobSubscribeId");

            migrationBuilder.CreateIndex(
                name: "IX_InterviewsSchedules_LocationId",
                table: "InterviewsSchedules",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobRequests_CreatedById",
                table: "JobRequests",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_JobRequests_JobTitleId",
                table: "JobRequests",
                column: "JobTitleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobRequests_LocationId",
                table: "JobRequests",
                column: "LocationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobRequestStatus_AnalyzedById",
                table: "JobRequestStatus",
                column: "AnalyzedById");

            migrationBuilder.CreateIndex(
                name: "IX_JobRequestStatus_JobRequestId",
                table: "JobRequestStatus",
                column: "JobRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_AddressId",
                table: "Locations",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_EntityId",
                table: "Locations",
                column: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_InterviewsSchedules_InterviewsScheduleId",
                table: "Interviews",
                column: "InterviewsScheduleId",
                principalTable: "InterviewsSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_InterviewStatus_InterviewStatusId",
                table: "Interviews",
                column: "InterviewStatusId",
                principalTable: "InterviewStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_JobRequests_JobRequestId",
                table: "Jobs",
                column: "JobRequestId",
                principalTable: "JobRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
