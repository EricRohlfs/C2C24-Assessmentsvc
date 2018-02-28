using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Assessmentsvc.Database.Migrations
{
    public partial class capabilityassessmentnavigation4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_METAssessments_CapabilityAssessments_CapabilityAssessmentId",
                table: "METAssessments");

            migrationBuilder.AlterColumn<Guid>(
                name: "CapabilityAssessmentId",
                table: "METAssessments",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_METAssessments_CapabilityAssessments_CapabilityAssessmentId",
                table: "METAssessments",
                column: "CapabilityAssessmentId",
                principalTable: "CapabilityAssessments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_METAssessments_CapabilityAssessments_CapabilityAssessmentId",
                table: "METAssessments");

            migrationBuilder.AlterColumn<Guid>(
                name: "CapabilityAssessmentId",
                table: "METAssessments",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_METAssessments_CapabilityAssessments_CapabilityAssessmentId",
                table: "METAssessments",
                column: "CapabilityAssessmentId",
                principalTable: "CapabilityAssessments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
