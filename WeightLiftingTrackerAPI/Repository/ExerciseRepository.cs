using Microsoft.EntityFrameworkCore;
using TrackerAPI.Data;
using TrackerAPI.Models;

namespace TrackerAPI.Repository
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly ExerciseContext _context;

        public ExerciseRepository(ExerciseContext context)
        {
            this._context = context;
        }

        public async Task<Exercise> AddExercise(Exercise exercise)
        {
            await _context.Exercises.AddAsync(exercise);
            await _context.SaveChangesAsync();
            return exercise;
        }

        public async Task<Exercise> DeleteExercise(int id)
        {
            Exercise exercise = await _context.Exercises.FindAsync(id);
            if (exercise != null)
            {
                _context.Exercises.Remove(exercise);
                await _context.SaveChangesAsync();
            }
            return exercise;
        }

        public async Task<Exercise> GetExercise(int id)
        {
            return await _context.Exercises.FindAsync(id);
        }

        public async Task<IEnumerable<Exercise>> GetExerciseList()
        {
            return await _context.Exercises.ToListAsync();

            //When not using lazy loading
            //return await _context.Exercises.Include(x => x.Stats).ToListAsync();
        }


        public async Task<Exercise> UpdateExercise(int id, Exercise exerciseChanges)
        {
            Exercise exerciseToUpdate = await _context.Exercises.FindAsync(id);

            if (exerciseToUpdate != null)
            {
                exerciseToUpdate.Name = exerciseChanges.Name;
                await _context.SaveChangesAsync();
            }

            return exerciseChanges;
        }
    }
}
