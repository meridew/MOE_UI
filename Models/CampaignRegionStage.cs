using MOE_UI.Models.Definitions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Controls;

namespace MOE_UI.Models
{
    public class CampaignRegionStage
    {
        [Key] public int CampaignRegionStageId { get; set; }
        [ForeignKey("CampaignRegionId")] public CampaignRegion CampaignRegion { get; set; }
        [ForeignKey("ApiCommandId")] public ApiCommand ApiCommand { get; set; }
        public int CampaignRegionId { get; set; }
        public int ApiCommandId { get; set; }
        public int StageOrder { get; set; }
        public ICollection<CampaignRegionStageCriteria> CampaignRegionStageCriterias { get; set; } = new HashSet<CampaignRegionStageCriteria>();

        public ICollection<Action> Actions { get; set; } = new HashSet<Action>();
    }
}
