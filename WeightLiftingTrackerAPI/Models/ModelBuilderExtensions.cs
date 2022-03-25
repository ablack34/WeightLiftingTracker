using Microsoft.EntityFrameworkCore;

namespace TrackerAPI.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercise>().HasData(
                new Exercise
                {
                    ExerciseId = 1,
                    Name = "Squat",
                },
                new Exercise
                {
                    ExerciseId = 2,
                    Name = "Bench",
                });

            modelBuilder.Entity<LiftingStat>().HasData(
                new LiftingStat
                {
                    LiftingStatId = 1,
                    Date = DateTime.Today.ToString("d"),
                    Weight = 100.0,
                    Repetitions = 5,
                    ExerciseId = 1,
                },
                new LiftingStat
                {
                    LiftingStatId = 2,
                    Date = DateTime.Today.ToString("d"),
                    Weight = 105.0,
                    Repetitions = 5,
                    ExerciseId = 1,
                },
                new LiftingStat
                {
                    LiftingStatId = 3,
                    Date = DateTime.Today.ToString("d"),
                    Weight = 85.50,
                    Repetitions = 5,
                    ExerciseId = 2,
                }); ;
        }
    }
}
