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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Do I need to use FluentAPI to configure relationships when I have already done so in class structure???
            //modelBuilder.Entity<LiftingStat>()
            //    .HasOne<Exercise>(s => s.Exercise)
            //    .WithMany(e => e.Stats)
            //    .HasForeignKey(s => s.ExerciseId);

            modelBuilder.Seed();
            
        }     

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
         


    }
}
