using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApi.Migrations
{
    /// <inheritdoc />
    public partial class RenameIdColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudentRelation_Courses_CourseId",
                table: "CourseStudentRelation");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudentRelation_Students_StudentId",
                table: "CourseStudentRelation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseStudentRelation",
                table: "CourseStudentRelation");

            migrationBuilder.RenameTable(
                name: "CourseStudentRelation",
                newName: "CourseStudentRelations");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Teachers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Courses",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_CourseStudentRelation_CourseId",
                table: "CourseStudentRelations",
                newName: "IX_CourseStudentRelations_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseStudentRelations",
                table: "CourseStudentRelations",
                columns: new[] { "StudentId", "CourseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudentRelations_Courses_CourseId",
                table: "CourseStudentRelations",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudentRelations_Students_StudentId",
                table: "CourseStudentRelations",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudentRelations_Courses_CourseId",
                table: "CourseStudentRelations");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseStudentRelations_Students_StudentId",
                table: "CourseStudentRelations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseStudentRelations",
                table: "CourseStudentRelations");

            migrationBuilder.RenameTable(
                name: "CourseStudentRelations",
                newName: "CourseStudentRelation");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Teachers",
                newName: "TeacherId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Courses",
                newName: "CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseStudentRelations_CourseId",
                table: "CourseStudentRelation",
                newName: "IX_CourseStudentRelation_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseStudentRelation",
                table: "CourseStudentRelation",
                columns: new[] { "StudentId", "CourseId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudentRelation_Courses_CourseId",
                table: "CourseStudentRelation",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseStudentRelation_Students_StudentId",
                table: "CourseStudentRelation",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "StudentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
