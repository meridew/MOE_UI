using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MOE_UI.Migrations
{
    /// <inheritdoc />
    public partial class Updated_Domain_Entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Domains",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "DomainId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Domains",
                columns: new[] { "DomainId", "DomainName" },
                values: new object[,]
                {
                    { 2, "CORP2" },
                    { 3, "CORP3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Domains",
                keyColumn: "DomainId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Domains",
                keyColumn: "DomainId",
                keyValue: 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Domains",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "DomainId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 12, 21, 12, 6, 507, DateTimeKind.Local).AddTicks(3826));
        }
    }
}
