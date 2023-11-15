using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MOE_UI.Models.Definitions
{
    public class ApiCommand
    {
        [Key] public int ApiCommandId { get; set; }
        public string ApiCommandName { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<CampaignRegionStage> CampaignRegionStages { get; set; } = new HashSet<CampaignRegionStage>();
    }
}
