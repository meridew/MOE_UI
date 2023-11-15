using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOE_UI.Migrations
{
    /// <inheritdoc />
    public partial class AddedCampaignRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampaignRegions_Regions_RegionId",
                table: "CampaignRegions");

            migrationBuilder.DropForeignKey(
                name: "FK_CampaignRegionStages_CampaignRegions_CampaignRegionId",
                table: "CampaignRegionStages");

            migrationBuilder.DropForeignKey(
                name: "FK_Regions_Domains_DomainId",
                table: "Regions");

            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "DomainId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 12, 20, 50, 13, 244, DateTimeKind.Local).AddTicks(4037));

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_DomainId",
                table: "Campaigns",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignRegions_CampaignId",
                table: "CampaignRegions",
                column: "CampaignId");

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignRegions_Campaigns_CampaignId",
                table: "CampaignRegions",
                column: "CampaignId",
                principalTable: "Campaigns",
                principalColumn: "CampaignId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignRegions_Regions_RegionId",
                table: "CampaignRegions",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignRegionStages_CampaignRegions_CampaignRegionId",
                table: "CampaignRegionStages",
                column: "CampaignRegionId",
                principalTable: "CampaignRegions",
                principalColumn: "CampaignRegionId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_Domains_DomainId",
                table: "Campaigns",
                column: "DomainId",
                principalTable: "Domains",
                principalColumn: "DomainId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Regions_Domains_DomainId",
                table: "Regions",
                column: "DomainId",
                principalTable: "Domains",
                principalColumn: "DomainId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampaignRegions_Campaigns_CampaignId",
                table: "CampaignRegions");

            migrationBuilder.DropForeignKey(
                name: "FK_CampaignRegions_Regions_RegionId",
                table: "CampaignRegions");

            migrationBuilder.DropForeignKey(
                name: "FK_CampaignRegionStages_CampaignRegions_CampaignRegionId",
                table: "CampaignRegionStages");

            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_Domains_DomainId",
                table: "Campaigns");

            migrationBuilder.DropForeignKey(
                name: "FK_Regions_Domains_DomainId",
                table: "Regions");

            migrationBuilder.DropIndex(
                name: "IX_Campaigns_DomainId",
                table: "Campaigns");

            migrationBuilder.DropIndex(
                name: "IX_CampaignRegions_CampaignId",
                table: "CampaignRegions");

            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "DomainId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 12, 20, 32, 53, 912, DateTimeKind.Local).AddTicks(3907));

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignRegions_Regions_RegionId",
                table: "CampaignRegions",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "RegionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignRegionStages_CampaignRegions_CampaignRegionId",
                table: "CampaignRegionStages",
                column: "CampaignRegionId",
                principalTable: "CampaignRegions",
                principalColumn: "CampaignRegionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Regions_Domains_DomainId",
                table: "Regions",
                column: "DomainId",
                principalTable: "Domains",
                principalColumn: "DomainId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
