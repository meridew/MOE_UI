using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MOE_UI.Models.Definitions
{
    public class ApiCommand
    {
        [Key]
        public int ApiCommandId { get; set; }
        public string ApiCommandName { get; set; }
        public DateTime CreatedAt { get; set; }

        // This represents a one-to-many relationship with CampaignRegionStage
        public virtual ICollection<CampaignRegionStage> CampaignRegionStages { get; set; }

        public ApiCommand()
        {
            CampaignRegionStages = new HashSet<CampaignRegionStage>();
        }
    }

}
