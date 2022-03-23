using Microsoft.EntityFrameworkCore;
using TrackerAPI.Models;

namespace TrackerAPI.Data
{
    public class ExerciseContext : DbContext
    {
        

        public ExerciseContext(DbContextOptions<ExerciseContext> options)
            : base(options) 
        {
        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<LiftingStat> LiftingStats { get; set;}

        


    }
}
