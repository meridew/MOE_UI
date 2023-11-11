using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOE_UI.Models
{
    public class CampaignRegionStageCriteria
    {
        [Key]
        public int CampaignRegionStageCriteriaId { get; set; }
        [ForeignKey("CampaignRegionStageId")]
        public int CampaignRegionStageId { get; set; }
        public string Field { get; set; }
        public string StringValue { get; set; }
        public int IntValue { get; set; }
        public string Operator { get; set; }
    }
}
