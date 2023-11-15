using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOE_UI.Migrations
{
    /// <inheritdoc />
    public partial class Added_CampaignRegionStage_CriteriaRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "DomainId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 12, 21, 4, 40, 291, DateTimeKind.Local).AddTicks(708));

            migrationBuilder.CreateIndex(
                name: "IX_CampaignRegionStageCriterias_CampaignRegionStageId",
                table: "CampaignRegionStageCriterias",
                column: "CampaignRegionStageId");

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignRegionStageCriterias_CampaignRegionStages_CampaignRegionStageId",
                table: "CampaignRegionStageCriterias",
                column: "CampaignRegionStageId",
                principalTable: "CampaignRegionStages",
                principalColumn: "CampaignRegionStageId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampaignRegionStageCriterias_CampaignRegionStages_CampaignRegionStageId",
                table: "CampaignRegionStageCriterias");

            migrationBuilder.DropIndex(
                name: "IX_CampaignRegionStageCriterias_CampaignRegionStageId",
                table: "CampaignRegionStageCriterias");

            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "DomainId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 12, 21, 2, 59, 512, DateTimeKind.Local).AddTicks(9784));
        }
    }
}
