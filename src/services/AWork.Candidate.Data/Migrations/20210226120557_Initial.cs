using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace AWork.Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Nationality = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseLevelName = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    ContactEmail = table.Column<string>(type: "varchar(200)", nullable: false),
                    EntityChildId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SiteAddress = table.Column<string>(type: "varchar(200)", nullable: false),
                    Alias = table.Column<string>(type: "varchar(20)", nullable: false),
                    SiteDomain = table.Column<string>(type: "varchar(200)", nullable: false),
                    UseWebServer_GrupoAPSe = table.Column<bool>(type: "bit", nullable: false),
                    WebServer_GrupoAPSe_user = table.Column<string>(type: "varchar(100)", nullable: true),
                    WebServer_GrupoAPSe_password = table.Column<string>(type: "varchar(36)", nullable: true),
                    WebServer_GrupoAPSe_Id_Empresa = table.Column<int>(type: "int", nullable: true),
                    EntitiesId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    Name = table.Column<string>(type: "varchar(150)", nullable: false),
                    Extension = table.Column<string>(type: "varchar(10)", nullable: false),
                    Type = table.Column<string>(type: "varchar(50)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastAccessTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastWriteTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Length = table.Column<long>(type: "bigint", nullable: false),
                    FileStream = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
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
                    Name = table.Column<string>(type: "varchar(200)", nullable: false),
                    Color = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterviewStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobTitleLevels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Level = table.Column<string>(type: "varchar(60)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitleLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobTitles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobTitleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false),
                    Hidden = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobTitles_JobTitles_JobTitleId",
                        column: x => x.JobTitleId,
                        principalTable: "JobTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaritalStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritalStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Religions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Religions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecialNeeds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialNeeds", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "SyncAPS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", nullable: false),
                    Entity = table.Column<string>(type: "varchar(20)", nullable: false),
                    HiringDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ResignationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<string>(type: "varchar(1)", nullable: false),
                    Abbreviation = table.Column<string>(type: "varchar(60)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SyncAPS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkingAreas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(60)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ZipCode = table.Column<string>(type: "varchar(8)", nullable: true),
                    District = table.Column<string>(type: "varchar(100)", nullable: false),
                    Street = table.Column<string>(type: "varchar(100)", nullable: false),
                    Number = table.Column<string>(type: "varchar(15)", nullable: false),
                    Complement = table.Column<string>(type: "varchar(200)", nullable: true),
                    State = table.Column<string>(type: "varchar(70)", nullable: false),
                    City = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseLevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseName = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_CourseLevels_CourseLevelId",
                        column: x => x.CourseLevelId,
                        principalTable: "CourseLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Enabled = table.Column<bool>(type: "bit", nullable: false)
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
                name: "Person",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NationalityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MaritalStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SpecialNeedsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReligionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FirstName = table.Column<string>(type: "varchar(100)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(200)", nullable: false),
                    FullName = table.Column<string>(type: "varchar(300)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", nullable: false),
                    ProfileBase64 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PPD = table.Column<bool>(type: "bit", nullable: false),
                    Goal = table.Column<string>(type: "varchar(450)", nullable: true),
                    Summary = table.Column<string>(type: "varchar(500)", nullable: true),
                    IdGroupApse = table.Column<int>(type: "int", nullable: true),
                    IdGroupApseGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GrupoAPSeIdEmpresa = table.Column<int>(type: "int", nullable: true),
                    DownloadPPD = table.Column<bool>(type: "bit", nullable: true),
                    LinkedIn = table.Column<string>(type: "varchar(500)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "AcademicEducations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CourseStatus = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    College = table.Column<string>(type: "varchar(100)", nullable: false),
                    CustomCourse = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicEducations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcademicEducations_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AcademicEducations_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "JobRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobTitleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobQuantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
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
                name: "JobTitleInteresteds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobTitleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTitleInteresteds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobTitleInteresteds_JobTitles_JobTitleId",
                        column: x => x.JobTitleId,
                        principalTable: "JobTitles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobTitleInteresteds_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LanguegePerson",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguegePerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguegePerson_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LanguegePerson_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "varchar(60)", nullable: false),
                    Message = table.Column<string>(type: "varchar(500)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Read = table.Column<bool>(type: "bit", nullable: false),
                    ReadDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Phone",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    phoneNumber = table.Column<string>(type: "varchar(11)", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false),
                    PhoneType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phone_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionalBackgrounds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobTitleLevelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkingAreaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobTitleName = table.Column<string>(type: "varchar(60)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CurrentJob = table.Column<bool>(type: "bit", nullable: false),
                    DescriptionJob = table.Column<string>(type: "varchar(500)", nullable: false),
                    Company = table.Column<string>(type: "varchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalBackgrounds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProfessionalBackgrounds_JobTitleLevels_JobTitleLevelId",
                        column: x => x.JobTitleLevelId,
                        principalTable: "JobTitleLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfessionalBackgrounds_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProfessionalBackgrounds_WorkingAreas_WorkingAreaId",
                        column: x => x.WorkingAreaId,
                        principalTable: "WorkingAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobRequestStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnalyzedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobQuantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", nullable: false),
                    Requirement = table.Column<string>(type: "varchar(500)", nullable: false),
                    Benefits = table.Column<string>(type: "varchar(500)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_JobRequests_JobRequestId",
                        column: x => x.JobRequestId,
                        principalTable: "JobRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jobs_Person_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "JobSubscribes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSubscribes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobSubscribes_Jobs_JobId",
                        column: x => x.JobId,
                        principalTable: "Jobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobSubscribes_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InterviewsSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobSubscribeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Link = table.Column<string>(type: "varchar(300)", nullable: true),
                    Via = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", nullable: false)
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
                name: "Interviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InterviewStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InterviewsScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IndicationName = table.Column<string>(type: "varchar(100)", nullable: true),
                    Description = table.Column<string>(type: "varchar(500)", nullable: false),
                    Attachment = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Interviews_InterviewsSchedules_InterviewsScheduleId",
                        column: x => x.InterviewsScheduleId,
                        principalTable: "InterviewsSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Interviews_InterviewStatus_InterviewStatusId",
                        column: x => x.InterviewStatusId,
                        principalTable: "InterviewStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Interviews_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InterviewId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Benefits = table.Column<string>(type: "varchar(500)", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    WorkingHours = table.Column<TimeSpan>(type: "time", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Interviews_InterviewId",
                        column: x => x.InterviewId,
                        principalTable: "Interviews",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContractRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnalyzedById = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_AcademicEducations_CourseId",
                table: "AcademicEducations",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicEducations_PersonId",
                table: "AcademicEducations",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_CountryId",
                table: "Address",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractRequests_AnalyzedById",
                table: "ContractRequests",
                column: "AnalyzedById");

            migrationBuilder.CreateIndex(
                name: "IX_ContractRequests_ContractId",
                table: "ContractRequests",
                column: "ContractId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_InterviewId",
                table: "Contracts",
                column: "InterviewId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseLevelId",
                table: "Courses",
                column: "CourseLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Entities_EntitiesId",
                table: "Entities",
                column: "EntitiesId");

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
                name: "IX_Interviews_PersonId",
                table: "Interviews",
                column: "PersonId");

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
                name: "IX_Jobs_CreatedById",
                table: "Jobs",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_JobRequestId",
                table: "Jobs",
                column: "JobRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobSubscribes_JobId",
                table: "JobSubscribes",
                column: "JobId");

            migrationBuilder.CreateIndex(
                name: "IX_JobSubscribes_PersonId",
                table: "JobSubscribes",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTitleInteresteds_JobTitleId",
                table: "JobTitleInteresteds",
                column: "JobTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTitleInteresteds_PersonId",
                table: "JobTitleInteresteds",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTitles_JobTitleId",
                table: "JobTitles",
                column: "JobTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguegePerson_LanguageId",
                table: "LanguegePerson",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguegePerson_PersonId",
                table: "LanguegePerson",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_AddressId",
                table: "Locations",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_EntityId",
                table: "Locations",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_PersonId",
                table: "Notifications",
                column: "PersonId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Phone_PersonId",
                table: "Phone",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalBackgrounds_JobTitleLevelId",
                table: "ProfessionalBackgrounds",
                column: "JobTitleLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalBackgrounds_PersonId",
                table: "ProfessionalBackgrounds",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfessionalBackgrounds_WorkingAreaId",
                table: "ProfessionalBackgrounds",
                column: "WorkingAreaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicEducations");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "ContractRequests");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "JobRequestStatus");

            migrationBuilder.DropTable(
                name: "JobTitleInteresteds");

            migrationBuilder.DropTable(
                name: "LanguegePerson");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Phone");

            migrationBuilder.DropTable(
                name: "ProfessionalBackgrounds");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "SyncAPS");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "JobTitleLevels");

            migrationBuilder.DropTable(
                name: "WorkingAreas");

            migrationBuilder.DropTable(
                name: "CourseLevels");

            migrationBuilder.DropTable(
                name: "Interviews");

            migrationBuilder.DropTable(
                name: "InterviewsSchedules");

            migrationBuilder.DropTable(
                name: "InterviewStatus");

            migrationBuilder.DropTable(
                name: "JobSubscribes");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "JobRequests");

            migrationBuilder.DropTable(
                name: "JobTitles");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Entities");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "MaritalStatus");

            migrationBuilder.DropTable(
                name: "Religions");

            migrationBuilder.DropTable(
                name: "SpecialNeeds");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
