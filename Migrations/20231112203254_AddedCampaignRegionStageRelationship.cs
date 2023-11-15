using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOE_UI.Migrations
{
    /// <inheritdoc />
    public partial class AddedCampaignRegionStageRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "DomainId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 12, 20, 32, 53, 912, DateTimeKind.Local).AddTicks(3907));

            migrationBuilder.CreateIndex(
                name: "IX_CampaignRegionStages_CampaignRegionId",
                table: "CampaignRegionStages",
                column: "CampaignRegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignRegionStages_CampaignRegions_CampaignRegionId",
                table: "CampaignRegionStages",
                column: "CampaignRegionId",
                principalTable: "CampaignRegions",
                principalColumn: "CampaignRegionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampaignRegionStages_CampaignRegions_CampaignRegionId",
                table: "CampaignRegionStages");

            migrationBuilder.DropIndex(
                name: "IX_CampaignRegionStages_CampaignRegionId",
                table: "CampaignRegionStages");

            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "DomainId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 12, 20, 30, 7, 85, DateTimeKind.Local).AddTicks(3960));
        }
    }
}
