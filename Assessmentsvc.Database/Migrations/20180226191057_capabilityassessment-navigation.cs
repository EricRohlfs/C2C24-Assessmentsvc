using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Assessmentsvc.Database.Migrations
{
    public partial class capabilityassessmentnavigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_METAssessments_CapabilityAssessments_CapabilityId",
                table: "METAssessments");

            migrationBuilder.RenameColumn(
                name: "CapabilityId",
                table: "METAssessments",
                newName: "CapabilityAssessmentId");

            migrationBuilder.RenameIndex(
                name: "IX_METAssessments_CapabilityId",
                table: "METAssessments",
                newName: "IX_METAssessments_CapabilityAssessmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_METAssessments_CapabilityAssessments_CapabilityAssessmentId",
                table: "METAssessments",
                column: "CapabilityAssessmentId",
                principalTable: "CapabilityAssessments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_METAssessments_CapabilityAssessments_CapabilityAssessmentId",
                table: "METAssessments");

            migrationBuilder.RenameColumn(
                name: "CapabilityAssessmentId",
                table: "METAssessments",
                newName: "CapabilityId");

            migrationBuilder.RenameIndex(
                name: "IX_METAssessments_CapabilityAssessmentId",
                table: "METAssessments",
                newName: "IX_METAssessments_CapabilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_METAssessments_CapabilityAssessments_CapabilityId",
                table: "METAssessments",
                column: "CapabilityId",
                principalTable: "CapabilityAssessments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
