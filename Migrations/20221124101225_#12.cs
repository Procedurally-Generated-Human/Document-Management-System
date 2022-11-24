using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoDMS.Migrations
{
    /// <inheritdoc />
    public partial class _12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "Document",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "size",
                table: "Document",
                type: "REAL",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Extension",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "size",
                table: "Document");
        }
    }
}
