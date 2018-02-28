using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Assessmentsvc.Database.Migrations
{
    public partial class capabilityassessmentnavigation3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "METAssessmentId",
                table: "METAssessments",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CapabilityAssessmentId",
                table: "CapabilityAssessments",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "METAssessmentId",
                table: "METAssessments");

            migrationBuilder.DropColumn(
                name: "CapabilityAssessmentId",
                table: "CapabilityAssessments");
        }
    }
}
