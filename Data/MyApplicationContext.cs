using Microsoft.EntityFrameworkCore;
using MOE_UI.Models;
using MOE_UI.Models.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOE_UI.Data
{
    public class MyApplicationContext : DbContext
    {
        public DbSet<Domain> Domains { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }

        public DbSet<CampaignRegion> CampaignRegions { get; set; }

        public DbSet<CampaignRegionStage> CampaignRegionStages { get; set; }

        public DbSet<CampaignRegionStageCriteria> CampaignRegionStageCriterias { get; set; }

        public DbSet<ApiCommand> ApiCommands { get; set; }

        public DbSet<Models.Action> Actions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure the connection string to your SQL Express instance
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=Mobility_Orchestration;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain>().HasData(new Domain { DomainId=1, DomainName="CORP" });
        }
    }

}
