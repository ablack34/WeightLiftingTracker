using TrackerAPI.Models;

namespace TrackerAPI.Repository
{
    public interface IExerciseRepository
    {
        Task<Exercise> GetExercise(int id);
        Task<IEnumerable<Exercise>> GetExerciseList();
        Task<Exercise> AddExercise(Exercise exercise);
        Task<Exercise> UpdateExercise(int id, Exercise exerciseChanges);
        Task<Exercise> DeleteExercise(int id);

    }
}
