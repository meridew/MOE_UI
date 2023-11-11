﻿// <auto-generated />
using System;
using MOE_UI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MOE_UI.Migrations
{
    [DbContext(typeof(MyApplicationContext))]
    [Migration("20231111094715_ChangedApiCommandCampaignRegionStageRelationship")]
    partial class ChangedApiCommandCampaignRegionStageRelationship
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MOE_UI.Models.Action", b =>
                {
                    b.Property<int>("ActionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ActionId"));

                    b.Property<int>("ActionAttempts")
                        .HasColumnType("int");

                    b.Property<bool>("ActionCompleted")
                        .HasColumnType("bit");

                    b.Property<bool>("ActionRun")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ActionRunAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CampaignRegionStageId")
                        .HasColumnType("int");

                    b.Property<Guid>("CommandGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("GroupGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PerimeterUuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserGuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ActionId");

                    b.HasIndex("CampaignRegionStageId");

                    b.ToTable("Actions");
                });

            modelBuilder.Entity("MOE_UI.Models.Campaign", b =>
                {
                    b.Property<int>("CampaignId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CampaignId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CampaignName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedBy")
                        .HasColumnType("datetime2");

                    b.Property<int>("DomainId")
                        .HasColumnType("int");

                    b.HasKey("CampaignId");

                    b.HasIndex("DomainId");

                    b.ToTable("Campaigns");
                });

            modelBuilder.Entity("MOE_UI.Models.CampaignRegion", b =>
                {
                    b.Property<int>("CampaignRegionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CampaignRegionId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("CampaignId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastRun")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NextRun")
                        .HasColumnType("datetime2");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.Property<bool>("Running")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ScheduleEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ScheduleStart")
                        .HasColumnType("datetime2");

                    b.HasKey("CampaignRegionId");

                    b.HasIndex("CampaignId");

                    b.ToTable("CampaignRegions");
                });

            modelBuilder.Entity("MOE_UI.Models.CampaignRegionStage", b =>
                {
                    b.Property<int>("CampaignRegionStageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CampaignRegionStageId"));

                    b.Property<int>("ApiCommandId")
                        .HasColumnType("int");

                    b.Property<int>("CampaignRegionId")
                        .HasColumnType("int");

                    b.Property<int>("StageOrder")
                        .HasColumnType("int");

                    b.HasKey("CampaignRegionStageId");

                    b.HasIndex("ApiCommandId");

                    b.HasIndex("CampaignRegionId");

                    b.ToTable("CampaignRegionStages");
                });

            modelBuilder.Entity("MOE_UI.Models.CampaignRegionStageCriteria", b =>
                {
                    b.Property<int>("CampaignRegionStageCriteriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CampaignRegionStageCriteriaId"));

                    b.Property<int>("CampaignRegionStageId")
                        .HasColumnType("int");

                    b.Property<string>("Field")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IntValue")
                        .HasColumnType("int");

                    b.Property<string>("Operator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StringValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CampaignRegionStageCriteriaId");

                    b.HasIndex("CampaignRegionStageId");

                    b.ToTable("CampaignRegionStageCriterias");
                });

            modelBuilder.Entity("MOE_UI.Models.Definitions.ApiCommand", b =>
                {
                    b.Property<int>("ApiCommandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ApiCommandId"));

                    b.Property<string>("ApiCommandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("ApiCommandId");

                    b.ToTable("ApiCommands");
                });

            modelBuilder.Entity("MOE_UI.Models.Domain", b =>
                {
                    b.Property<int>("DomainId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DomainId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DomainName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DomainId");

                    b.ToTable("Domains");

                    b.HasData(
                        new
                        {
                            DomainId = 1,
                            CreatedAt = new DateTime(2023, 11, 11, 9, 47, 15, 621, DateTimeKind.Local).AddTicks(4819),
                            DomainName = "CORP"
                        });
                });

            modelBuilder.Entity("MOE_UI.Models.Action", b =>
                {
                    b.HasOne("MOE_UI.Models.CampaignRegionStage", null)
                        .WithMany("Actions")
                        .HasForeignKey("CampaignRegionStageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MOE_UI.Models.Campaign", b =>
                {
                    b.HasOne("MOE_UI.Models.Domain", "Domain")
                        .WithMany("Campaigns")
                        .HasForeignKey("DomainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Domain");
                });

            modelBuilder.Entity("MOE_UI.Models.CampaignRegion", b =>
                {
                    b.HasOne("MOE_UI.Models.Campaign", null)
                        .WithMany("CampaignRegions")
                        .HasForeignKey("CampaignId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MOE_UI.Models.CampaignRegionStage", b =>
                {
                    b.HasOne("MOE_UI.Models.Definitions.ApiCommand", "ApiCommand")
                        .WithMany("CampaignRegionStages")
                        .HasForeignKey("ApiCommandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MOE_UI.Models.CampaignRegion", "CampaignRegion")
                        .WithMany("CampaignRegionStages")
                        .HasForeignKey("CampaignRegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApiCommand");

                    b.Navigation("CampaignRegion");
                });

            modelBuilder.Entity("MOE_UI.Models.CampaignRegionStageCriteria", b =>
                {
                    b.HasOne("MOE_UI.Models.CampaignRegionStage", null)
                        .WithMany("CampaignRegionStageCriterias")
                        .HasForeignKey("CampaignRegionStageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MOE_UI.Models.Campaign", b =>
                {
                    b.Navigation("CampaignRegions");
                });

            modelBuilder.Entity("MOE_UI.Models.CampaignRegion", b =>
                {
                    b.Navigation("CampaignRegionStages");
                });

            modelBuilder.Entity("MOE_UI.Models.CampaignRegionStage", b =>
                {
                    b.Navigation("Actions");

                    b.Navigation("CampaignRegionStageCriterias");
                });

            modelBuilder.Entity("MOE_UI.Models.Definitions.ApiCommand", b =>
                {
                    b.Navigation("CampaignRegionStages");
                });

            modelBuilder.Entity("MOE_UI.Models.Domain", b =>
                {
                    b.Navigation("Campaigns");
                });
#pragma warning restore 612, 618
        }
    }
}
