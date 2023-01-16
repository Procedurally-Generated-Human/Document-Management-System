using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoDMS.Migrations
{
    /// <inheritdoc />
    public partial class _26 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Supervisor",
                table: "Document",
                newName: "SupervisorName");

            migrationBuilder.RenameColumn(
                name: "Author",
                table: "Document",
                newName: "AuthorName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SupervisorName",
                table: "Document",
                newName: "Supervisor");

            migrationBuilder.RenameColumn(
                name: "AuthorName",
                table: "Document",
                newName: "Author");
        }
    }
}
