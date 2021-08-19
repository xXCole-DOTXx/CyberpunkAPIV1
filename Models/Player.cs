using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CyberpunkAPI.Models
{
    public partial class Player
    {
        public int Id { get; set; }
        [Required]
        public string Handle { get; set; }
        [Required]
        public string Role { get; set; }
        public string Avatar { get; set; }

        public virtual SpecialAbilities SpecialAbilities { get; set; }
        public virtual Stats Stats { get; set; }
    }
}
