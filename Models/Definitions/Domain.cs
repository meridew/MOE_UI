using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MOE_UI.Models
{
    public class Domain
    {
        [Key] public int DomainId { get; set; }
        public string DomainName { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<Region> Regions { get; set; } = new HashSet<Region>();
        public ICollection<Campaign> Campaigns { get; set; } = new HashSet<Campaign>();
    }
}
