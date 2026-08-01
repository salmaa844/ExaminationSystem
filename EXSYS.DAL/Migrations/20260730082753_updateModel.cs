using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXSYS.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestions_Users_CreatedById",
                table: "ExamQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestions_Users_UpdatedById",
                table: "ExamQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamStudents_Users_CreatedById",
                table: "ExamStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamStudents_Users_UpdatedById",
                table: "ExamStudents");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Users_CreatedById",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Users_UpdatedById",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAnswers_Users_CreatedById",
                table: "StudentAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentAnswers_Users_UpdatedById",
                table: "StudentAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Users_CreatedById",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Users_UpdatedById",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_CreatedById",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_UpdatedById",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_CreatedById",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_UpdatedById",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourses_CreatedById",
                table: "StudentCourses");

            migrationBuilder.DropIndex(
                name: "IX_StudentCourses_UpdatedById",
                table: "StudentCourses");

            migrationBuilder.DropIndex(
                name: "IX_StudentAnswers_CreatedById",
                table: "StudentAnswers");

            migrationBuilder.DropIndex(
                name: "IX_StudentAnswers_UpdatedById",
                table: "StudentAnswers");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_CreatedById",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_Instructors_UpdatedById",
                table: "Instructors");

            migrationBuilder.DropIndex(
                name: "IX_ExamStudents_CreatedById",
                table: "ExamStudents");

            migrationBuilder.DropIndex(
                name: "IX_ExamStudents_UpdatedById",
                table: "ExamStudents");

            migrationBuilder.DropIndex(
                name: "IX_ExamQuestions_CreatedById",
                table: "ExamQuestions");

            migrationBuilder.DropIndex(
                name: "IX_ExamQuestions_UpdatedById",
                table: "ExamQuestions");

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
                name: "CreatedById",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "StudentCourses");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "StudentAnswers");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "StudentAnswers");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StudentAnswers");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "StudentAnswers");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "StudentAnswers");

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
                name: "CreatedById",
                table: "ExamStudents");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "ExamStudents");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ExamStudents");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "ExamStudents");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "ExamStudents");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ExamQuestions");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "ExamQuestions");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ExamQuestions");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "ExamQuestions");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "ExamQuestions");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Students",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "StudentCourses",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "StudentAnswers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Instructors",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ExamStudents",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ExamQuestions",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Students",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StudentCourses",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StudentAnswers",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Instructors",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ExamStudents",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ExamQuestions",
                newName: "ID");

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
                name: "CreatedById",
                table: "StudentCourses",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "StudentCourses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StudentCourses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "StudentCourses",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "StudentCourses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "StudentAnswers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "StudentAnswers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StudentAnswers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "StudentAnswers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "StudentAnswers",
                type: "datetime2",
                nullable: true);

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
                name: "CreatedById",
                table: "ExamStudents",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "ExamStudents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ExamStudents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "ExamStudents",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "ExamStudents",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "ExamQuestions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "ExamQuestions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ExamQuestions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "ExamQuestions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "ExamQuestions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_CreatedById",
                table: "Students",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UpdatedById",
                table: "Students",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CreatedById",
                table: "StudentCourses",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_UpdatedById",
                table: "StudentCourses",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswers_CreatedById",
                table: "StudentAnswers",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_StudentAnswers_UpdatedById",
                table: "StudentAnswers",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_CreatedById",
                table: "Instructors",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Instructors_UpdatedById",
                table: "Instructors",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ExamStudents_CreatedById",
                table: "ExamStudents",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ExamStudents_UpdatedById",
                table: "ExamStudents",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestions_CreatedById",
                table: "ExamQuestions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ExamQuestions_UpdatedById",
                table: "ExamQuestions",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestions_Users_CreatedById",
                table: "ExamQuestions",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestions_Users_UpdatedById",
                table: "ExamQuestions",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamStudents_Users_CreatedById",
                table: "ExamStudents",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamStudents_Users_UpdatedById",
                table: "ExamStudents",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Users_CreatedById",
                table: "Instructors",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Users_UpdatedById",
                table: "Instructors",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAnswers_Users_CreatedById",
                table: "StudentAnswers",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentAnswers_Users_UpdatedById",
                table: "StudentAnswers",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Users_CreatedById",
                table: "StudentCourses",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Users_UpdatedById",
                table: "StudentCourses",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_CreatedById",
                table: "Students",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_UpdatedById",
                table: "Students",
                column: "UpdatedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
