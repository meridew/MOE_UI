using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOE_UI.Migrations
{
    /// <inheritdoc />
    public partial class AddedRegionCampaignRegionRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "DomainId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 12, 20, 30, 7, 85, DateTimeKind.Local).AddTicks(3960));

            migrationBuilder.CreateIndex(
                name: "IX_CampaignRegions_RegionId",
                table: "CampaignRegions",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignRegions_Regions_RegionId",
                table: "CampaignRegions",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampaignRegions_Regions_RegionId",
                table: "CampaignRegions");

            migrationBuilder.DropIndex(
                name: "IX_CampaignRegions_RegionId",
                table: "CampaignRegions");

            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "DomainId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 12, 20, 24, 30, 283, DateTimeKind.Local).AddTicks(7854));
        }
    }
}
