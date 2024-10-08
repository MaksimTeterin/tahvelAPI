using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class StudentHistoryChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentHistories",
                table: "StudentHistories");

            migrationBuilder.RenameTable(
                name: "StudentHistories",
                newName: "StudentHistory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentHistory",
                table: "StudentHistory",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentHistory",
                table: "StudentHistory");

            migrationBuilder.RenameTable(
                name: "StudentHistory",
                newName: "StudentHistories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentHistories",
                table: "StudentHistories",
                column: "Id");
        }
    }
}
