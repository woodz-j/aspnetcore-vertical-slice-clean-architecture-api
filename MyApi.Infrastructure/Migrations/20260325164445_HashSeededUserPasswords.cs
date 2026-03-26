using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class HashSeededUserPasswords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAELqKiy3aTopPm6hxrTuuGjL/94HrJp2z10/RP85PdOh8AxEHIDiB4V1rAwh30T2Hnw==");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAIAAYagAAAAEMG2RQMUT2Y271SAT61FoEtW/c9klI8kUSq9NZrL9Y2IvQ+TIKsE6w+tHqb3K4t50g==");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "Password123!");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "Password123!");
        }
    }
}
