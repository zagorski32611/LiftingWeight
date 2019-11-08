using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiftingWeight.Models
{
    public partial class ExerciseProgressViewModel
    {
        public Exercises Exercises { get; set; }
        public LiftingProgress LiftingProgress { get; set; }
    }
}