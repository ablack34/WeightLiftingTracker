using TrackerAPI.Models;

namespace TrackerAPI.Repository
{
    public interface IExerciseRepository
    {
        Task<Exercise> GetExercise(int id);
        Task<IEnumerable<Exercise>> GetExerciseList();
        Task<Exercise> Add(Exercise exercise);
        Task<Exercise> Update(int id, Exercise exerciseChanges);
        Task<Exercise> Delete(int id);

    }
}
