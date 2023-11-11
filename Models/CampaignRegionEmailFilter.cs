using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOE_UI.Models
{
    public class CampaignRegionEmailFilter
    {
        [Key]
        public int CampaignRegionEmailFilterId { get; set; }
        [ForeignKey("CampaignRegionId")]
        public int CampaignRegionId { get; set; }
        public string EmailAddress { get; set; }
    }
}
