using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOE_UI.Migrations
{
    /// <inheritdoc />
    public partial class ChangedApiCommandCampaignRegionStageRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApiCommands_CampaignRegionStages_CampaignRegionStageId",
                table: "ApiCommands");

            migrationBuilder.DropIndex(
                name: "IX_ApiCommands_CampaignRegionStageId",
                table: "ApiCommands");

            migrationBuilder.DropColumn(
                name: "CampaignRegionStageId",
                table: "ApiCommands");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ApiCommands",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "DomainId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 11, 9, 47, 15, 621, DateTimeKind.Local).AddTicks(4819));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ApiCommands");

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
                value: new DateTime(2023, 11, 11, 9, 45, 25, 786, DateTimeKind.Local).AddTicks(7770));

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
        }
    }
}
