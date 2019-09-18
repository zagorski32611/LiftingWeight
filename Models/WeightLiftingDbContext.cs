using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LiftingWeight.Models
{
    public partial class WeightLiftingDbContext : DbContext
    {
        public WeightLiftingDbContext()
        {
        }

        public WeightLiftingDbContext(DbContextOptions<WeightLiftingDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Exercises> Exercises { get; set; }
        public virtual DbSet<LiftingProgress> LiftingProgress { get; set; }
        public virtual DbSet<WorkoutRecord> WorkoutRecord { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=tcp:wlsql01.database.windows.net,1433;Initial Catalog=WeightLiftingDb;Persist Security Info=True;User ID=jzagorski;Password=password1#;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Exercises>(entity =>
            {
                entity.HasKey(e => e.ExerciseId)
                    .HasName("exercise_id")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("exercises");

                entity.Property(e => e.ExerciseId).HasColumnName("exercise_id");

                entity.Property(e => e.Current).HasColumnName("current");

                entity.Property(e => e.ExerciseName)
                    .HasColumnName("exercise_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GymOrHome).HasColumnName("gym_or_home");

                entity.Property(e => e.MachineOrFree).HasColumnName("machine_or_free");

                entity.Property(e => e.TargetedMuscle)
                    .HasColumnName("targeted_muscle")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LiftingProgress>(entity =>
            {
                entity.HasKey(e => e.ProgressId)
                    .HasName("progress_id")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("lifting_progress");

                entity.Property(e => e.ProgressId).HasColumnName("progress_id");

                entity.Property(e => e.ExerciseId).HasColumnName("exercise_id");

                entity.Property(e => e.Repititions).HasColumnName("repititions");

                entity.Property(e => e.WeightUsed)
                    .HasColumnName("weight_used")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.WorkoutDate)
                    .HasColumnName("workout_date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Exercise)
                    .WithMany(p => p.LiftingProgress)
                    .HasForeignKey(d => d.ExerciseId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_exercise_id");
            });

            modelBuilder.Entity<WorkoutRecord>(entity =>
            {
                entity.HasKey(e => e.WorkoutId)
                    .HasName("workout_id")
                    .ForSqlServerIsClustered(false);

                entity.ToTable("workout_record");

                entity.Property(e => e.WorkoutId).HasColumnName("workout_id");

                entity.Property(e => e.GymHome).HasColumnName("gym_home");

                entity.Property(e => e.ProgressId).HasColumnName("progress_id");

                entity.Property(e => e.WorkoutDate)
                    .HasColumnName("workout_date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Progress)
                    .WithMany(p => p.WorkoutRecord)
                    .HasForeignKey(d => d.ProgressId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_progress_id");
            });
        }
    }
}
