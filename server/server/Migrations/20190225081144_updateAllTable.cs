using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class updateAllTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classrooms_ClassID",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "ClassID",
                table: "Students",
                newName: "ClassroomID");

            migrationBuilder.RenameIndex(
                name: "IX_Students_ClassID",
                table: "Students",
                newName: "IX_Students_ClassroomID");

            migrationBuilder.RenameColumn(
                name: "IDClassroom",
                table: "Classrooms",
                newName: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classrooms_ClassroomID",
                table: "Students",
                column: "ClassroomID",
                principalTable: "Classrooms",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Classrooms_ClassroomID",
                table: "Students");

            migrationBuilder.RenameColumn(
                name: "ClassroomID",
                table: "Students",
                newName: "ClassID");

            migrationBuilder.RenameIndex(
                name: "IX_Students_ClassroomID",
                table: "Students",
                newName: "IX_Students_ClassID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Classrooms",
                newName: "IDClassroom");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Classrooms_ClassID",
                table: "Students",
                column: "ClassID",
                principalTable: "Classrooms",
                principalColumn: "IDClassroom",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
