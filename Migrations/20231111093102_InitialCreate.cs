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
                name: "ApiCommands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiCommandName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApiCommands", x => x.Id);
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
                name: "CampaignRegions",
                columns: table => new
                {
                    CampaignRegionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CampaignId = table.Column<int>(type: "int", nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_CampaignRegions_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "CampaignId",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_CampaignRegionStages_CampaignRegions_CampaignRegionId",
                        column: x => x.CampaignRegionId,
                        principalTable: "CampaignRegions",
                        principalColumn: "CampaignRegionId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    table.ForeignKey(
                        name: "FK_Actions_CampaignRegionStages_CampaignRegionStageId",
                        column: x => x.CampaignRegionStageId,
                        principalTable: "CampaignRegionStages",
                        principalColumn: "CampaignRegionStageId",
                        onDelete: ReferentialAction.Cascade);
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
                    table.ForeignKey(
                        name: "FK_CampaignRegionStageCriterias_CampaignRegionStages_CampaignRegionStageId",
                        column: x => x.CampaignRegionStageId,
                        principalTable: "CampaignRegionStages",
                        principalColumn: "CampaignRegionStageId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Domains",
                columns: new[] { "DomainId", "CreatedAt", "DomainName" },
                values: new object[] { 1, new DateTime(2023, 11, 11, 9, 31, 1, 943, DateTimeKind.Local).AddTicks(8402), "CORP" });

            migrationBuilder.CreateIndex(
                name: "IX_Actions_CampaignRegionStageId",
                table: "Actions",
                column: "CampaignRegionStageId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignRegions_CampaignId",
                table: "CampaignRegions",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignRegionStageCriterias_CampaignRegionStageId",
                table: "CampaignRegionStageCriterias",
                column: "CampaignRegionStageId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignRegionStages_CampaignRegionId",
                table: "CampaignRegionStages",
                column: "CampaignRegionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "ApiCommands");

            migrationBuilder.DropTable(
                name: "CampaignRegionStageCriterias");

            migrationBuilder.DropTable(
                name: "Domains");

            migrationBuilder.DropTable(
                name: "CampaignRegionStages");

            migrationBuilder.DropTable(
                name: "CampaignRegions");

            migrationBuilder.DropTable(
                name: "Campaigns");
        }
    }
}
