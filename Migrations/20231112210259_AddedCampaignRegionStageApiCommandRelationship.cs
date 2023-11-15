using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOE_UI.Migrations
{
    /// <inheritdoc />
    public partial class AddedCampaignRegionStageApiCommandRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "DomainId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 12, 21, 2, 59, 512, DateTimeKind.Local).AddTicks(9784));

            migrationBuilder.CreateIndex(
                name: "IX_CampaignRegionStages_ApiCommandId",
                table: "CampaignRegionStages",
                column: "ApiCommandId");

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignRegionStages_ApiCommands_ApiCommandId",
                table: "CampaignRegionStages",
                column: "ApiCommandId",
                principalTable: "ApiCommands",
                principalColumn: "ApiCommandId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampaignRegionStages_ApiCommands_ApiCommandId",
                table: "CampaignRegionStages");

            migrationBuilder.DropIndex(
                name: "IX_CampaignRegionStages_ApiCommandId",
                table: "CampaignRegionStages");

            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "DomainId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 12, 20, 50, 13, 244, DateTimeKind.Local).AddTicks(4037));
        }
    }
}
