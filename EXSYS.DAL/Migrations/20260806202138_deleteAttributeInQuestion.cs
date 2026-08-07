using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXSYS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class deleteAttributeInQuestion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Instructors_InstructorId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_InstructorId",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "InstructorId",
                table: "Questions",
                newName: "Type");

            migrationBuilder.AddColumn<decimal>(
                name: "Mark",
                table: "Questions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mark",
                table: "Questions");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Questions",
                newName: "InstructorId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_InstructorId",
                table: "Questions",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Instructors_InstructorId",
                table: "Questions",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
