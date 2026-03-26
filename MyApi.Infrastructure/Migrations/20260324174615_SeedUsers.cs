using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedUtc", "Email", "PasswordHash", "Role" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 24, 12, 0, 0, 0, DateTimeKind.Utc), "admin@test.com", "Password123!", "Admin" },
                    { 2, new DateTime(2025, 3, 24, 12, 0, 0, 0, DateTimeKind.Utc), "user@test.com", "Password123!", "User" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
