using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXSYS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Choices_Users_CreatedById",
                table: "Choices");

            migrationBuilder.DropForeignKey(
                name: "FK_Choices_Users_UpdatedById",
                table: "Choices");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Users_CreatedById",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Users_UpdatedById",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Instructors_InstructorID",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Users_CreatedById",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Users_UpdatedById",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Users_CreatedById",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Users_UpdatedById",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAnswers_Choices_ChoiceID",
                table: "StudentAnswers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Instructors");

            migrationBuilder.RenameColumn(
                name: "ChoiceID",
                table: "StudentAnswers",
                newName: "ChoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAnswers_ChoiceID",
                table: "StudentAnswers",
                newName: "IX_StudentAnswers_ChoiceId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Questions",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "InstructorID",
                table: "Exams",
                newName: "InstructorId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Exams",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Exams_InstructorID",
                table: "Exams",
                newName: "IX_Exams_InstructorId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Courses",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Choices",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Students",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Students",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Students",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Students",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Instructors",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Instructors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Instructors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "Instructors",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Instructors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Instructors",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CreatedById",
                table: "Students",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UpdatedById",
                table: "Students",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UserId",
                table: "Students",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_CreatedById",
                table: "Instructors",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_UpdatedById",
                table: "Instructors",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_UserId",
                table: "Instructors",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Choices_Users_CreatedById",
                table: "Choices",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Choices_Users_UpdatedById",
                table: "Choices",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Users_CreatedById",
                table: "Courses",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Users_UpdatedById",
                table: "Courses",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Instructors_InstructorId",
                table: "Exams",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Users_CreatedById",
                table: "Exams",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Users_UpdatedById",
                table: "Exams",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Users_CreatedById",
                table: "Instructors",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Users_UpdatedById",
                table: "Instructors",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Users_UserId",
                table: "Instructors",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Users_CreatedById",
                table: "Questions",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Users_UpdatedById",
                table: "Questions",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAnswers_Choices_ChoiceId",
                table: "StudentAnswers",
                column: "ChoiceId",
                principalTable: "Choices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_CreatedById",
                table: "Students",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_UpdatedById",
                table: "Students",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_UserId",
                table: "Students",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Choices_Users_CreatedById",
                table: "Choices");

            migrationBuilder.DropForeignKey(
                name: "FK_Choices_Users_UpdatedById",
                table: "Choices");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Users_CreatedById",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Users_UpdatedById",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Instructors_InstructorId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Users_CreatedById",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Users_UpdatedById",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Users_CreatedById",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Users_UpdatedById",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Users_UserId",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Users_CreatedById",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Users_UpdatedById",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAnswers_Choices_ChoiceId",
                table: "StudentAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_CreatedById",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_UpdatedById",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_UserId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_CreatedById",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_UpdatedById",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_UserId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_CreatedById",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_UpdatedById",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_UserId",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Instructors");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Instructors");

            migrationBuilder.RenameColumn(
                name: "ChoiceId",
                table: "StudentAnswers",
                newName: "ChoiceID");

            migrationBuilder.RenameIndex(
                name: "IX_StudentAnswers_ChoiceId",
                table: "StudentAnswers",
                newName: "IX_StudentAnswers_ChoiceID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Questions",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "InstructorId",
                table: "Exams",
                newName: "InstructorID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Exams",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Exams_InstructorId",
                table: "Exams",
                newName: "IX_Exams_InstructorID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Courses",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Choices",
                newName: "ID");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Instructors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Choices_Users_CreatedById",
                table: "Choices",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Choices_Users_UpdatedById",
                table: "Choices",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Users_CreatedById",
                table: "Courses",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Users_UpdatedById",
                table: "Courses",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Instructors_InstructorID",
                table: "Exams",
                column: "InstructorID",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Users_CreatedById",
                table: "Exams",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Users_UpdatedById",
                table: "Exams",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Users_CreatedById",
                table: "Questions",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Users_UpdatedById",
                table: "Questions",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAnswers_Choices_ChoiceID",
                table: "StudentAnswers",
                column: "ChoiceID",
                principalTable: "Choices",
                principalColumn: "ID");
        }
    }
}
