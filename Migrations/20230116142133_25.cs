using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoDMS.Migrations
{
    /// <inheritdoc />
    public partial class _25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Document");

            migrationBuilder.DropColumn(
                name: "YearOfPublication",
                table: "Document");

            migrationBuilder.RenameColumn(
                name: "StudentName",
                table: "Document",
                newName: "Author");

            migrationBuilder.RenameColumn(
                name: "Degree",
                table: "Document",
                newName: "Level");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "PublicationDate",
                table: "Document",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicationDate",
                table: "Document");

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "Document",
                newName: "Degree");

            migrationBuilder.RenameColumn(
                name: "Author",
                table: "Document",
                newName: "StudentName");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Document",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "YearOfPublication",
                table: "Document",
                type: "INTEGER",
                nullable: true);
        }
    }
}
