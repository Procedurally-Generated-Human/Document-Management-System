using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoDMS.Migrations
{
    /// <inheritdoc />
    public partial class _35 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Document");

            migrationBuilder.RenameColumn(
                name: "UploadDate",
                table: "Document",
                newName: "DateModified");

            migrationBuilder.RenameColumn(
                name: "ModifiedDate",
                table: "Document",
                newName: "DateCreated");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateCreated",
                table: "Folder",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateModified",
                table: "Folder",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Folder");

            migrationBuilder.DropColumn(
                name: "DateModified",
                table: "Folder");

            migrationBuilder.RenameColumn(
                name: "DateModified",
                table: "Document",
                newName: "UploadDate");

            migrationBuilder.RenameColumn(
                name: "DateCreated",
                table: "Document",
                newName: "ModifiedDate");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Document",
                type: "TEXT",
                nullable: true);
        }
    }
}
