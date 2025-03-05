using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegisterLoginJWT.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshTokeExpirationDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpirationDate",
                table: "users",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshTokenExpirationDate",
                table: "users");
        }
    }
}
