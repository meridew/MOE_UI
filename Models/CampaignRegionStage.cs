using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOE_UI.Models
{
    public class CampaignRegionStage
    {
        [Key]
        public int CampaignRegionStageId { get; set; }
        [ForeignKey("CampaignRegionId")]
        public int CampaignRegionId { get; set; }
        [ForeignKey("ApiCommandId")]
        public int ApiCommandId { get; set; }
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
