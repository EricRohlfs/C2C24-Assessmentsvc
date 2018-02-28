using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Assessmentsvc.Database.Migrations
{
    public partial class create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AssessmentComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Equipment = table.Column<string>(nullable: true),
                    Facility = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    Ordnance = table.Column<string>(nullable: true),
                    Overall = table.Column<string>(nullable: true),
                    Personnel = table.Column<string>(nullable: true),
                    Supply = table.Column<string>(nullable: true),
                    Training = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentComments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConditionDescriptors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConditionDescriptors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Missions",
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
                    table.PrimaryKey("PK_Missions", x => x.Id);
                });

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
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Uic = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    MissionId = table.Column<Guid>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_Missions_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Missions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    NormalizedScore = table.Column<int>(nullable: false),
                    Rating = table.Column<string>(nullable: true),
                    RawScore = table.Column<int>(nullable: false),
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
                    NormalizedScore = table.Column<int>(nullable: false),
                    Rating = table.Column<string>(nullable: true),
                    RawScore = table.Column<int>(nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Conditions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ConditionDescriptorId = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    TaskId = table.Column<Guid>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conditions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Conditions_ConditionDescriptors_ConditionDescriptorId",
                        column: x => x.ConditionDescriptorId,
                        principalTable: "ConditionDescriptors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conditions_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Measures",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: false),
                    Number = table.Column<string>(nullable: true),
                    Scale = table.Column<string>(nullable: true),
                    TaskId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Measures_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "METAssessments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Approved = table.Column<bool>(nullable: false),
                    CommentId = table.Column<Guid>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    DateAssessed = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: false),
                    Rating = table.Column<string>(nullable: true),
                    TaskId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_METAssessments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_METAssessments_AssessmentComments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "AssessmentComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_METAssessments_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conditions_ConditionDescriptorId",
                table: "Conditions",
                column: "ConditionDescriptorId");

            migrationBuilder.CreateIndex(
                name: "IX_Conditions_TaskId",
                table: "Conditions",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Measures_TaskId",
                table: "Measures",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_METAssessments_CommentId",
                table: "METAssessments",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_METAssessments_TaskId",
                table: "METAssessments",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_MissionId",
                table: "Tasks",
                column: "MissionId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conditions");

            migrationBuilder.DropTable(
                name: "Measures");

            migrationBuilder.DropTable(
                name: "METAssessments");

            migrationBuilder.DropTable(
                name: "RespOrgs");

            migrationBuilder.DropTable(
                name: "UnitMissionAssessments");

            migrationBuilder.DropTable(
                name: "UnitMissionResourceStatusData");

            migrationBuilder.DropTable(
                name: "UnitResourceStatusData");

            migrationBuilder.DropTable(
                name: "ConditionDescriptors");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "AssessmentComments");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Missions");
        }
    }
}
