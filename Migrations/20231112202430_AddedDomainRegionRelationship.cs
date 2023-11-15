using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOE_UI.Migrations
{
    /// <inheritdoc />
    public partial class AddedDomainRegionRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "DomainId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 12, 20, 24, 30, 283, DateTimeKind.Local).AddTicks(7854));

            migrationBuilder.CreateIndex(
                name: "IX_Regions_DomainId",
                table: "Regions",
                column: "DomainId");

            migrationBuilder.AddForeignKey(
                name: "FK_Regions_Domains_DomainId",
                table: "Regions",
                column: "DomainId",
                principalTable: "Domains",
                principalColumn: "DomainId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Regions_Domains_DomainId",
                table: "Regions");

            migrationBuilder.DropIndex(
                name: "IX_Regions_DomainId",
                table: "Regions");

            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "DomainId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 12, 20, 11, 31, 398, DateTimeKind.Local).AddTicks(4848));
        }
    }
}
