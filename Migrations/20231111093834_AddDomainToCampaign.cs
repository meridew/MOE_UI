using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOE_UI.Migrations
{
    /// <inheritdoc />
    public partial class AddDomainToCampaign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ApiCommands",
                newName: "ApiCommandId");

            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "DomainId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 11, 9, 38, 34, 400, DateTimeKind.Local).AddTicks(607));

            migrationBuilder.CreateIndex(
                name: "IX_Campaigns_DomainId",
                table: "Campaigns",
                column: "DomainId");

            migrationBuilder.AddForeignKey(
                name: "FK_Campaigns_Domains_DomainId",
                table: "Campaigns",
                column: "DomainId",
                principalTable: "Domains",
                principalColumn: "DomainId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campaigns_Domains_DomainId",
                table: "Campaigns");

            migrationBuilder.DropIndex(
                name: "IX_Campaigns_DomainId",
                table: "Campaigns");

            migrationBuilder.RenameColumn(
                name: "ApiCommandId",
                table: "ApiCommands",
                newName: "Id");

            migrationBuilder.UpdateData(
                table: "Domains",
                keyColumn: "DomainId",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2023, 11, 11, 9, 31, 1, 943, DateTimeKind.Local).AddTicks(8402));
        }
    }
}
