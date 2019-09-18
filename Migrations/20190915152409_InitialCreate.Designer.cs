﻿// <auto-generated />
using System;
using LiftingWeight.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LiftingWeight.Migrations
{
    [DbContext(typeof(WeightLiftingDbContext))]
    [Migration("20190915152409_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LiftingWeight.Models.Exercises", b =>
                {
                    b.Property<int>("ExerciseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("exercise_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("Current")
                        .HasColumnName("current");

                    b.Property<string>("ExerciseName")
                        .HasColumnName("exercise_name")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.Property<bool?>("GymOrHome")
                        .HasColumnName("gym_or_home");

                    b.Property<bool?>("MachineOrFree")
                        .HasColumnName("machine_or_free");

                    b.Property<string>("TargetedMuscle")
                        .HasColumnName("targeted_muscle")
                        .HasMaxLength(255)
                        .IsUnicode(false);

                    b.HasKey("ExerciseId")
                        .HasName("exercise_id")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.ToTable("exercises");
                });

            modelBuilder.Entity("LiftingWeight.Models.LiftingProgress", b =>
                {
                    b.Property<int>("ProgressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("progress_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ExerciseId")
                        .HasColumnName("exercise_id");

                    b.Property<int?>("Repititions")
                        .HasColumnName("repititions");

                    b.Property<decimal?>("WeightUsed")
                        .HasColumnName("weight_used")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<DateTime?>("WorkoutDate")
                        .HasColumnName("workout_date")
                        .HasColumnType("datetime");

                    b.HasKey("ProgressId")
                        .HasName("progress_id")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("ExerciseId");

                    b.ToTable("lifting_progress");
                });

            modelBuilder.Entity("LiftingWeight.Models.WorkoutRecord", b =>
                {
                    b.Property<int>("WorkoutId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("workout_id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("GymHome")
                        .HasColumnName("gym_home");

                    b.Property<int?>("ProgressId")
                        .HasColumnName("progress_id");

                    b.Property<DateTime?>("WorkoutDate")
                        .HasColumnName("workout_date")
                        .HasColumnType("datetime");

                    b.HasKey("WorkoutId")
                        .HasName("workout_id")
                        .HasAnnotation("SqlServer:Clustered", false);

                    b.HasIndex("ProgressId");

                    b.ToTable("workout_record");
                });

            modelBuilder.Entity("LiftingWeight.Models.LiftingProgress", b =>
                {
                    b.HasOne("LiftingWeight.Models.Exercises", "Exercise")
                        .WithMany("LiftingProgress")
                        .HasForeignKey("ExerciseId")
                        .HasConstraintName("FK_exercise_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LiftingWeight.Models.WorkoutRecord", b =>
                {
                    b.HasOne("LiftingWeight.Models.LiftingProgress", "Progress")
                        .WithMany("WorkoutRecord")
                        .HasForeignKey("ProgressId")
                        .HasConstraintName("FK_progress_id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
