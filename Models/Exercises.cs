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
        
        [Display(Name = "Exercise Name")]
        public string ExerciseName { get; set; }
        
        [Display(Name = "Machine or Free?")]
        public bool? MachineOrFree { get; set; }

        [Display(Name = "Targeted Muscle")]
        public string TargetedMuscle { get; set; }

        [Display(Name = "Gym or Home?")]
        public bool? GymOrHome { get; set; }

        [Display(Name = "Current?")]
        public bool? Current { get; set; }
 
        public virtual ICollection<LiftingProgress> LiftingProgress { get; set; }

    }
}
