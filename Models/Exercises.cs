using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiftingWeight.Models
{
    public partial class Exercises
    {
        public Exercises()
        {
            LiftingProgress = new HashSet<LiftingProgress>();
        }

        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public bool? MachineOrFree { get; set; }
        public string TargetedMuscle { get; set; }
        public bool? GymOrHome { get; set; }
        public bool? Current { get; set; }

        public virtual ICollection<LiftingProgress> LiftingProgress { get; set; }
    }
}
