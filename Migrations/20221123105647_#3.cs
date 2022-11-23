using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoDMS.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryType",
                table: "Document");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Document",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Document");

            migrationBuilder.AddColumn<int>(
                name: "CategoryType",
                table: "Document",
                type: "INTEGER",
                nullable: true);
        }
    }
}
