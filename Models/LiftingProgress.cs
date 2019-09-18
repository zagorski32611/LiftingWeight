using System;
using System.Collections.Generic;

namespace LiftingWeight.Models
{
    public partial class LiftingProgress
    {
        public LiftingProgress()
        {
            WorkoutRecord = new HashSet<WorkoutRecord>();
        }

        public int ProgressId { get; set; }
        public DateTime? WorkoutDate { get; set; }
        public decimal? WeightUsed { get; set; }
        public int? Repititions { get; set; }
        public int? ExerciseId { get; set; }

        public virtual Exercises Exercise { get; set; }
        public virtual ICollection<WorkoutRecord> WorkoutRecord { get; set; }
    }
}
