using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOE_UI.Models
{
    public class CampaignRegion
    {
        [Key] public int CampaignRegionId { get; set; }
        [ForeignKey("RegionId")] public Region Region { get; set; }
        public int RegionId { get; set; }
        [ForeignKey("CampaignId")] public Campaign Campaign { get; set; }
        public int CampaignId { get; set; }
        public bool Active { get; set; }
        public DateTime ScheduleStart { get; set; }
        public DateTime ScheduleEnd { get; set; }
        public DateTime LastRun { get; set; }
        public DateTime NextRun { get; set; }
        public bool Running { get; set; }

        public ICollection<CampaignRegionStage> CampaignRegionStages { get; set; } = new HashSet<CampaignRegionStage>();
    }
}
