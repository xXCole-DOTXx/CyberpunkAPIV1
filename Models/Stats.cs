using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CyberpunkAPI.Models
{
    public partial class Stats
    {
        public int PlayerId { get; set; }
        [Required]
        public int Int { get; set; }
        [Required]
        public int Ref { get; set; }
        [Required]
        public int Tech { get; set; }
        [Required]
        public int Cool { get; set; }
        [Required]
        public int Attr { get; set; }
        [Required]
        public int Luck { get; set; }
        [Required]
        public int Ma { get; set; }
        [Required]
        public int Body { get; set; }
        [Required]
        public int Emp { get; set; }
        [Required]
        public int Run { get; set; }
        [Required]
        public int Leap { get; set; }
        [Required]
        public int Lift { get; set; }

        //This was causing a circular reference 
        //public virtual Player Player { get; set; }
    }
}
