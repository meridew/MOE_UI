using System;
using System.ComponentModel.DataAnnotations;

namespace MOE_UI.Models.Definitions
{
    public class ApiCommand
    {
        [Key]
        public int Id { get; set; }
        public string ApiCommandName { get; set; }
        DateTime CreatedAt { get; set; }
    }
}
