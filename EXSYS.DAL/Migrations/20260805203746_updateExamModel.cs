using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXSYS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateExamModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Exams",
                newName: "StartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Exams",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Exams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalMark",
                table: "Exams",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "TotalMark",
                table: "Exams");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Exams",
                newName: "Date");
        }
    }
}
