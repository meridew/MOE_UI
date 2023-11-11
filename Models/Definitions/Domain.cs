﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MOE_UI.Models
{
    public class Domain
    {
        [Key]
        public int DomainId { get; set; }
        public string DomainName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
