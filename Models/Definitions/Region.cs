using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOE_UI.Models
{
    public class Region
    {
        [Key] public int RegionId { get; set; }
        [ForeignKey("DomainId")] public Domain Domain { get; set; }
        public int DomainId { get; set; }
        public string RegionName { get; set; }
        public int BatchSize { get; set; }
        public int ActionRetryThreshold { get; set; }
        public string RegionUemUserDeviceTable { get; set; }
        public string RegionUemDeviceOsTable { get; set; }
        public string RegionUemDeviceActionInfoTable { get; set; }
        public string RegionUemDeviceActioNSoftwareTable { get; set; }
        public string RegionUemDeviceActionPolicyTable { get; set; }
        public string RegionUemDropCreateTablesSproc { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<CampaignRegion> CampaignRegions { get; set; } = new HashSet<CampaignRegion>();
    }
}
