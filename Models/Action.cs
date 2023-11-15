using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MOE_UI.Models
{
    public class Action
    {
        [Key] public int ActionId { get; set; }
        public int CampaignRegionStageId { get; set; }
        [ForeignKey("CampaignRegionStageId")] public CampaignRegionStage CampaignRegionStage { get; set; }
        public string EmailAddress { get; set; }
        public Guid UserGuid { get; set; }
        public Guid PerimeterUuid { get; set; }
        public Guid GroupGuid { get; set; }
        public Guid CommandGuid { get; set; }
        public bool ActionRun { get; set; }
        public bool ActionCompleted { get; set; }
        public int ActionAttempts { get; set; }
        public DateTime ActionRunAt { get; set; }
    }
}
