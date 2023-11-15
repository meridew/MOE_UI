using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOE_UI.Migrations
{
    /// <inheritdoc />
    public partial class Added_Action_CampaignRegionStage_Relationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "DomainId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 12, 21, 12, 6, 507, DateTimeKind.Local).AddTicks(3826));

            migrationBuilder.CreateIndex(
                name: "IX_Actions_CampaignRegionStageId",
                table: "Actions",
                column: "CampaignRegionStageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actions_CampaignRegionStages_CampaignRegionStageId",
                table: "Actions",
                column: "CampaignRegionStageId",
                principalTable: "CampaignRegionStages",
                principalColumn: "CampaignRegionStageId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actions_CampaignRegionStages_CampaignRegionStageId",
                table: "Actions");

            migrationBuilder.DropIndex(
                name: "IX_Actions_CampaignRegionStageId",
                table: "Actions");

            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "DomainId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 12, 21, 4, 40, 291, DateTimeKind.Local).AddTicks(708));
        }
    }
}
