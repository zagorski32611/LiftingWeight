using System;
using System.Collections.Generic;

namespace LiftingWeight.Models
{
    public partial class WorkoutRecord
    {
        public int WorkoutId { get; set; }
        public DateTime? WorkoutDate { get; set; }
        public bool? GymHome { get; set; }
        public int? ProgressId { get; set; }

        public virtual LiftingProgress Progress { get; set; }
    }
}
