using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegisterLoginJWT.Migrations
{
    /// <inheritdoc />
    public partial class addBaseClassProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ModifierId",
                table: "users",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "users");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "users");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "users");

            migrationBuilder.DropColumn(
                name: "ModifierId",
                table: "users");
        }
    }
}
