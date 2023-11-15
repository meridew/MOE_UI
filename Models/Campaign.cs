using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOE_UI.Models
{
    public class Campaign
    {
        [Key] public int CampaignId { get; set; }
        public int DomainId { get; set; }
        public bool Active { get; set; }
        public string CampaignName { get; set; }
        public DateTime CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<CampaignRegion> CampaignRegions { get; set; } = new HashSet<CampaignRegion>();
    }
}
