using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Entities.Models
{
    public class MissionSkillModel
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string SkillName { get; set; }

        [Required]
        public string Status { get; set; } // e.g., "active" or "inactive"
    }
}
