using System;
using System.Collections.Generic;

#nullable disable

namespace CyberpunkAPI.Models
{
    public partial class SpecialAbilities
    {
        public int PlayerId { get; set; }
        public int? Authority { get; set; }
        public int? CharismaticLeadership { get; set; }
        public int? CombatSense { get; set; }
        public int? Credibility { get; set; }
        public int? Family { get; set; }
        public int? Interface { get; set; }
        public int? JuryRig { get; set; }
        public int? MedicalTech { get; set; }
        public int? Resources { get; set; }
        public int? Streedeal { get; set; }

        //public virtual Player Player { get; set; }
    }
}
