using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LiftingWeight.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "exercises",
                columns: table => new
                {
                    exercise_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    exercise_name = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    machine_or_free = table.Column<bool>(nullable: true),
                    targeted_muscle = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    gym_or_home = table.Column<bool>(nullable: true),
                    current = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("exercise_id", x => x.exercise_id)
                        .Annotation("SqlServer:Clustered", false);
                });

            migrationBuilder.CreateTable(
                name: "lifting_progress",
                columns: table => new
                {
                    progress_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    workout_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    weight_used = table.Column<decimal>(type: "decimal(18, 0)", nullable: true),
                    repititions = table.Column<int>(nullable: true),
                    exercise_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("progress_id", x => x.progress_id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_exercise_id",
                        column: x => x.exercise_id,
                        principalTable: "exercises",
                        principalColumn: "exercise_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workout_record",
                columns: table => new
                {
                    workout_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    workout_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    gym_home = table.Column<bool>(nullable: true),
                    progress_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("workout_id", x => x.workout_id)
                        .Annotation("SqlServer:Clustered", false);
                    table.ForeignKey(
                        name: "FK_progress_id",
                        column: x => x.progress_id,
                        principalTable: "lifting_progress",
                        principalColumn: "progress_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_lifting_progress_exercise_id",
                table: "lifting_progress",
                column: "exercise_id");

            migrationBuilder.CreateIndex(
                name: "IX_workout_record_progress_id",
                table: "workout_record",
                column: "progress_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "workout_record");

            migrationBuilder.DropTable(
                name: "lifting_progress");

            migrationBuilder.DropTable(
                name: "exercises");
        }
    }
}
