using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOE_UI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    ActionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignRegionStageId = table.Column<int>(type: "int", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PerimeterUuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommandGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActionRun = table.Column<bool>(type: "bit", nullable: false),
                    ActionCompleted = table.Column<bool>(type: "bit", nullable: false),
                    ActionAttempts = table.Column<int>(type: "int", nullable: false),
                    ActionRunAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.ActionId);
                });

            migrationBuilder.CreateTable(
                name: "ApiCommands",
                columns: table => new
                {
                    ApiCommandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiCommandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiCommands", x => x.ApiCommandId);
                });

            migrationBuilder.CreateTable(
                name: "CampaignRegions",
                columns: table => new
                {
                    CampaignRegionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionId = table.Column<int>(type: "int", nullable: false),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ScheduleStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduleEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastRun = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NextRun = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Running = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignRegions", x => x.CampaignRegionId);
                });

            migrationBuilder.CreateTable(
                name: "CampaignRegionStageCriterias",
                columns: table => new
                {
                    CampaignRegionStageCriteriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignRegionStageId = table.Column<int>(type: "int", nullable: false),
                    Field = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StringValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntValue = table.Column<int>(type: "int", nullable: false),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignRegionStageCriterias", x => x.CampaignRegionStageCriteriaId);
                });

            migrationBuilder.CreateTable(
                name: "CampaignRegionStages",
                columns: table => new
                {
                    CampaignRegionStageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignRegionId = table.Column<int>(type: "int", nullable: false),
                    ApiCommandId = table.Column<int>(type: "int", nullable: false),
                    StageOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignRegionStages", x => x.CampaignRegionStageId);
                });

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    CampaignId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DomainId = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CampaignName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.CampaignId);
                });

            migrationBuilder.CreateTable(
                name: "Domains",
                columns: table => new
                {
                    DomainId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DomainName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domains", x => x.DomainId);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DomainId = table.Column<int>(type: "int", nullable: false),
                    RegionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BatchSize = table.Column<int>(type: "int", nullable: false),
                    ActionRetryThreshold = table.Column<int>(type: "int", nullable: false),
                    RegionUemUserDeviceTable = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionUemDeviceOsTable = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionUemDeviceActionInfoTable = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionUemDeviceActioNSoftwareTable = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionUemDeviceActionPolicyTable = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionUemDropCreateTablesSproc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionId);
                });

            migrationBuilder.InsertData(
                table: "Domains",
                columns: new[] { "DomainId", "CreatedAt", "DomainName" },
                values: new object[] { 1, new DateTime(2023, 11, 12, 20, 11, 31, 398, DateTimeKind.Local).AddTicks(4848), "CORP" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "ApiCommands");

            migrationBuilder.DropTable(
                name: "CampaignRegions");

            migrationBuilder.DropTable(
                name: "CampaignRegionStageCriterias");

            migrationBuilder.DropTable(
                name: "CampaignRegionStages");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "Domains");

            migrationBuilder.DropTable(
                name: "Regions");
        }
    }
}
