using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Assessmentsvc.Database.Migrations
{
    public partial class MakeRawscoreNormalizedScoreOptional2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RawScore",
                table: "UnitResourceStatusData",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "NormalizedScore",
                table: "UnitResourceStatusData",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RawScore",
                table: "UnitResourceStatusData",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NormalizedScore",
                table: "UnitResourceStatusData",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
