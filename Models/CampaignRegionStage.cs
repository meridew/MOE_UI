using MOE_UI.Models.Definitions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Controls;

namespace MOE_UI.Models
{
    public class CampaignRegionStage
    {
        [Key]
        public int CampaignRegionStageId { get; set; }
        public int CampaignRegionId { get; set; }
        [ForeignKey("CampaignRegionId")]
        public virtual CampaignRegion CampaignRegion { get; set; }
        public int ApiCommandId { get; set; }
        [ForeignKey("ApiCommandId")]
        public virtual ApiCommand ApiCommand { get; set; }
        public int StageOrder { get; set; }
        public virtual ICollection<Action> Actions { get; set; }
        public virtual ICollection<CampaignRegionStageCriteria> CampaignRegionStageCriterias { get; set; }

        public CampaignRegionStage()
        {
            Actions = new HashSet<Action>();
            CampaignRegionStageCriterias = new HashSet<CampaignRegionStageCriteria>();
        }
    }

}
