using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Assessmentsvc.Database.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_METAssessments_AssessmentComments_CommentId",
                table: "METAssessments");

            migrationBuilder.DropForeignKey(
                name: "FK_METAssessments_Tasks_TaskId",
                table: "METAssessments");

            migrationBuilder.DropTable(
                name: "RespOrgs");

            migrationBuilder.DropTable(
                name: "UnitMissionAssessments");

            migrationBuilder.DropTable(
                name: "UnitMissionResourceStatusData");

            migrationBuilder.DropTable(
                name: "UnitResourceStatusData");

            migrationBuilder.DropIndex(
                name: "IX_METAssessments_CommentId",
                table: "METAssessments");

            migrationBuilder.DropIndex(
                name: "IX_METAssessments_TaskId",
                table: "METAssessments");

            migrationBuilder.DropColumn(
                name: "Approved",
                table: "METAssessments");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "METAssessments");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "METAssessments");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "METAssessments",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "DateAssessed",
                table: "METAssessments",
                newName: "Assessed");

            migrationBuilder.AddColumn<string>(
                name: "Abbreviation",
                table: "METAssessments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Achieved",
                table: "METAssessments",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CapabilityId",
                table: "METAssessments",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Current",
                table: "METAssessments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "METAssessments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Equipment",
                table: "METAssessments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "METAssessments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Next",
                table: "METAssessments",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ordnance",
                table: "METAssessments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Overall",
                table: "METAssessments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Personnel",
                table: "METAssessments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Supply",
                table: "METAssessments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Training",
                table: "METAssessments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CapabilityAssessments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Abbreviation = table.Column<string>(nullable: true),
                    Achieved = table.Column<string>(nullable: true),
                    Assessed = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Current = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Equipment = table.Column<int>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Next = table.Column<string>(nullable: true),
                    Ordnance = table.Column<int>(nullable: false),
                    Overall = table.Column<int>(nullable: false),
                    Personnel = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Supply = table.Column<int>(nullable: false),
                    Training = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CapabilityAssessments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonnelData",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Assigned = table.Column<int>(nullable: false),
                    Authorized = table.Column<int>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Possessed = table.Column<int>(nullable: false),
                    Structured = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonnelData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SortsAssessments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ADCON = table.Column<string>(nullable: true),
                    CBRCurrent = table.Column<string>(nullable: true),
                    CBRProjected = table.Column<string>(nullable: true),
                    CBRTraining = table.Column<string>(nullable: true),
                    Category = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Effectivity = table.Column<int>(nullable: false),
                    Embarked = table.Column<string>(nullable: true),
                    Equipment = table.Column<int>(nullable: false),
                    Latitude = table.Column<string>(nullable: true),
                    Level = table.Column<int>(nullable: false),
                    Limitation = table.Column<int>(nullable: false),
                    Longitude = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    OPCON = table.Column<string>(nullable: true),
                    Ordnance = table.Column<int>(nullable: false),
                    Organization = table.Column<string>(nullable: true),
                    Overall = table.Column<int>(nullable: false),
                    Personnel = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Supply = table.Column<int>(nullable: false),
                    Training = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SortsAssessments", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_METAssessments_CapabilityId",
                table: "METAssessments",
                column: "CapabilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_METAssessments_CapabilityAssessments_CapabilityId",
                table: "METAssessments",
                column: "CapabilityId",
                principalTable: "CapabilityAssessments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_METAssessments_CapabilityAssessments_CapabilityId",
                table: "METAssessments");

            migrationBuilder.DropTable(
                name: "CapabilityAssessments");

            migrationBuilder.DropTable(
                name: "PersonnelData");

            migrationBuilder.DropTable(
                name: "SortsAssessments");

            migrationBuilder.DropIndex(
                name: "IX_METAssessments_CapabilityId",
                table: "METAssessments");

            migrationBuilder.DropColumn(
                name: "Abbreviation",
                table: "METAssessments");

            migrationBuilder.DropColumn(
                name: "Achieved",
                table: "METAssessments");

            migrationBuilder.DropColumn(
                name: "CapabilityId",
                table: "METAssessments");

            migrationBuilder.DropColumn(
                name: "Current",
                table: "METAssessments");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "METAssessments");

            migrationBuilder.DropColumn(
                name: "Equipment",
                table: "METAssessments");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "METAssessments");

            migrationBuilder.DropColumn(
                name: "Next",
                table: "METAssessments");

            migrationBuilder.DropColumn(
                name: "Ordnance",
                table: "METAssessments");

            migrationBuilder.DropColumn(
                name: "Overall",
                table: "METAssessments");

            migrationBuilder.DropColumn(
                name: "Personnel",
                table: "METAssessments");

            migrationBuilder.DropColumn(
                name: "Supply",
                table: "METAssessments");

            migrationBuilder.DropColumn(
                name: "Training",
                table: "METAssessments");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "METAssessments",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "Assessed",
                table: "METAssessments",
                newName: "DateAssessed");

            migrationBuilder.AddColumn<bool>(
                name: "Approved",
                table: "METAssessments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "CommentId",
                table: "METAssessments",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TaskId",
                table: "METAssessments",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RespOrgs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Abbreviation = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespOrgs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnitMissionAssessments",
                columns: table => new
                {
                    UnitId = table.Column<Guid>(nullable: false),
                    MissionId = table.Column<Guid>(nullable: false),
                    Approved = table.Column<bool>(nullable: false),
                    CommentId = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    DateAssessed = table.Column<DateTime>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Rating = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitMissionAssessments", x => new { x.UnitId, x.MissionId });
                    table.UniqueConstraint("AK_UnitMissionAssessments_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitMissionAssessments_AssessmentComments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "AssessmentComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UnitMissionAssessments_Missions_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Missions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UnitMissionAssessments_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnitMissionResourceStatusData",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    Complete = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    MissionId = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    NormalizedScore = table.Column<int>(nullable: true),
                    Rating = table.Column<string>(nullable: true),
                    RawScore = table.Column<int>(nullable: true),
                    Source = table.Column<string>(nullable: true),
                    UnitId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitMissionResourceStatusData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitMissionResourceStatusData_Missions_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Missions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UnitMissionResourceStatusData_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UnitResourceStatusData",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Category = table.Column<string>(nullable: true),
                    Complete = table.Column<bool>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    NormalizedScore = table.Column<int>(nullable: true),
                    Rating = table.Column<string>(nullable: true),
                    RawScore = table.Column<int>(nullable: true),
                    ResourceStatusAmplificationID = table.Column<Guid>(nullable: false),
                    Source = table.Column<string>(nullable: true),
                    UnitId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitResourceStatusData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UnitResourceStatusData_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_METAssessments_CommentId",
                table: "METAssessments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_METAssessments_TaskId",
                table: "METAssessments",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitMissionAssessments_CommentId",
                table: "UnitMissionAssessments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitMissionAssessments_MissionId",
                table: "UnitMissionAssessments",
                column: "MissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitMissionResourceStatusData_MissionId",
                table: "UnitMissionResourceStatusData",
                column: "MissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitMissionResourceStatusData_UnitId",
                table: "UnitMissionResourceStatusData",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_UnitResourceStatusData_UnitId",
                table: "UnitResourceStatusData",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_METAssessments_AssessmentComments_CommentId",
                table: "METAssessments",
                column: "CommentId",
                principalTable: "AssessmentComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_METAssessments_Tasks_TaskId",
                table: "METAssessments",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
