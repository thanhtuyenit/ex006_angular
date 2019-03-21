using Microsoft.EntityFrameworkCore.Migrations;

namespace server.Migrations
{
    public partial class changeNameForClassTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Classrooms",
                newName: "IDClassroom");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IDClassroom",
                table: "Classrooms",
                newName: "ID");
        }
    }
}
