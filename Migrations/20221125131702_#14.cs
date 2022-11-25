using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoDMS.Migrations
{
    /// <inheritdoc />
    public partial class _14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "size",
                table: "Document",
                newName: "Size");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Document",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Document");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "Document",
                newName: "size");
        }
    }
}
