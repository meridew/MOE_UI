using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MOE_UI.Models
{
    public class Domain
    {
        [Key]
        public int DomainId { get; set; }
        public string DomainName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual ICollection<Campaign> Campaigns { get; set; }

        public Domain()
        {
            Campaigns = new HashSet<Campaign>();
        }
    }
}
