using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Entities.Entities
{
    public class MissionSkill
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string SkillName { get; set; }

        [Required]
        public string Status { get; set; } // e.g., "active" or "inactive"

        public bool IsDeleted { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? ModifiedDate { get; set; }
    }
}
