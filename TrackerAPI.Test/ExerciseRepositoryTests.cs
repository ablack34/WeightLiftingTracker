using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerAPI.Data;
using TrackerAPI.Models;
using TrackerAPI.Repository;
using Xunit;

namespace TrackerAPI.Test
{
    public class ExerciseRepositoryTests
    {

        private readonly ExerciseContext context;
        public ExerciseRepositoryTests()
        {
            DbContextOptionsBuilder<ExerciseContext> dbOptions = new DbContextOptionsBuilder<ExerciseContext>()
                .UseInMemoryDatabase(
                    databaseName: Guid.NewGuid().ToString());

            context = new ExerciseContext(dbOptions.Options);
        }

        [Fact]
        public async Task ExerciseRepository_GetExerciseList_ReturnsCorrectCount()
        {
            //Arrange
            var exercises = new List<Exercise>()
            {
                new() {ExerciseId = 1, Name = "Squat", Stats = null},
                new() {ExerciseId = 2, Name = "Lunge", Stats = null},
                new() {ExerciseId = 3, Name = "Bench", Stats = null}
            };

            context.Exercises.AddRange(exercises);
            await context.SaveChangesAsync();

            var sut = new ExerciseRepository(context);

            //Act
            IEnumerable<Exercise> result = await sut.GetExerciseList();

            //Assert
            Assert.Equal(exercises.Count, result.Count());
        }

        [Fact]
        public async Task ExerciseRepository_GetExercise_ReturnsAnEntity()
        {
            //Arrange
            context.Exercises.Add(new() { ExerciseId = 1, Name = "Squat", Stats = null });
            await context.SaveChangesAsync();
            var sut = new ExerciseRepository(context);

            //Act
            Exercise result = await sut.GetExercise(1);

            //Assert
            Assert.Equal(1, 1);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task ExerciseRepository_AddExercise_ReturnsTrueIfAdded()
        {
            //Arrange
            var sut = new ExerciseRepository(context);
            var newExercise = new Exercise() { ExerciseId=1, Name = "Squat", Stats= null };
            
            //Act
            Exercise result = await sut.AddExercise(newExercise);

            //Assert
            Assert.Single(context.Exercises);
        }

        //[Fact]
        //public async Task ExerciseRepository_UpdateExercise_()
        //{
        //    //Arrange
        //    var sut = new ExerciseRepository(context);
        //    Exercise exerciseToUpdate = new Exercise() { ExerciseId = 1, Name = "Squat", Stats = null };
        //    Exercise exerciseChanges = new Exercise() { ExerciseId = 1, Name = "Lunge", Stats = null }; 

        //    //Act
        //    exerciseToUpdate.Name = exerciseChanges.Name;

        //    //Assert
        //    Assert.Equal(exerciseChanges, exerciseToUpdate);


        //}

    }
}
