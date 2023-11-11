using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOE_UI.Migrations
{
    /// <inheritdoc />
    public partial class AddApiCommandToCampaignRegionStage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CampaignRegionStageId",
                table: "ApiCommands",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "DomainId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 11, 9, 43, 2, 454, DateTimeKind.Local).AddTicks(3130));

            migrationBuilder.CreateIndex(
                name: "IX_CampaignRegionStages_ApiCommandId",
                table: "CampaignRegionStages",
                column: "ApiCommandId");

            migrationBuilder.CreateIndex(
                name: "IX_ApiCommands_CampaignRegionStageId",
                table: "ApiCommands",
                column: "CampaignRegionStageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApiCommands_CampaignRegionStages_CampaignRegionStageId",
                table: "ApiCommands",
                column: "CampaignRegionStageId",
                principalTable: "CampaignRegionStages",
                principalColumn: "CampaignRegionStageId");

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignRegionStages_ApiCommands_ApiCommandId",
                table: "CampaignRegionStages",
                column: "ApiCommandId",
                principalTable: "ApiCommands",
                principalColumn: "ApiCommandId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApiCommands_CampaignRegionStages_CampaignRegionStageId",
                table: "ApiCommands");

            migrationBuilder.DropForeignKey(
                name: "FK_CampaignRegionStages_ApiCommands_ApiCommandId",
                table: "CampaignRegionStages");

            migrationBuilder.DropIndex(
                name: "IX_CampaignRegionStages_ApiCommandId",
                table: "CampaignRegionStages");

            migrationBuilder.DropIndex(
                name: "IX_ApiCommands_CampaignRegionStageId",
                table: "ApiCommands");

            migrationBuilder.DropColumn(
                name: "CampaignRegionStageId",
                table: "ApiCommands");

            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "DomainId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 11, 9, 38, 34, 400, DateTimeKind.Local).AddTicks(607));
        }
    }
}
