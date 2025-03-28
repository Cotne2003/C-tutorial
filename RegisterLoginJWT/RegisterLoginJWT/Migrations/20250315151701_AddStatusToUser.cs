﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegisterLoginJWT.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "users");
        }
    }
}
