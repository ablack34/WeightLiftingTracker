using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Net;
using TrackerAPI.Controllers;
using TrackerAPI.Models;
using TrackerAPI.Repository;
using Xunit;

namespace TrackerAPI.Test
{
    public class ExerciseControllerTests
    {
        private ExercisesController controller;
        private Mock<IExerciseRepository> mockRepo;
        private List<Exercise> exercises;
        

        public ExerciseControllerTests()
        {
            mockRepo = new Mock<IExerciseRepository>();
            controller = new ExercisesController(mockRepo.Object);
            exercises = new List<Exercise>{
                new Exercise
                {
                    ExerciseId = 1,
                    Name = "Bench press"
                },
                new Exercise
                {
                    ExerciseId = 2,
                    Name = "Shoulder press"
                },
                new Exercise
                {
                    ExerciseId = 3,
                    Name = "Squat"
                },
                new Exercise
                {
                    ExerciseId = 4,
                    Name = "Lunge"
                }
            };
        }
        


        [Fact]
        public async void ExercisesController_GetAllExercises_ReturnsOkResultWhenExercisesAreFound()
        {
            //Arrange
            mockRepo.Setup(a => a.GetExerciseList()).ReturnsAsync(exercises);

            //Act
            var actionResult = await controller.GetExercises();
            var result = actionResult.Result as OkObjectResult;

            //Assert

            //Testing not null
            Assert.NotNull(result);
            //Testing Type is ActionResult<IEnumerable<Exercise>>>
            Assert.IsType<ActionResult<IEnumerable<Exercise>>>(actionResult);
            //Testing Status Code is 200
            Assert.Equal(200, result.StatusCode);
            //Testing count is 4 
            Assert.Equal(4, exercises.Count);

        }

        //GetExercisesTests

        [Fact]
        public async void ExercisesController_GetExercise_WithValidId_ReturnOkResultWhenExerciseIsFound()
        {
            //Arrange
            int exerciseId = exercises[0].ExerciseId;

            mockRepo.Setup(a => a.GetExercise(exerciseId)).ReturnsAsync(exercises.Find(x => x.ExerciseId == exerciseId));

            //Act
            var result = await controller.GetExercise(exerciseId);

            //Assert

            //Testing return type is correct
            var actionResult = Assert.IsType<ActionResult<Exercise>>(result);
            //Testing return value is correct
            var actionValue = Assert.IsType<OkObjectResult>(result.Result);
            //Testing Status Code
            Assert.Equal(200, actionValue.StatusCode);
            //Testing correct id returned
            Assert.Equal(exerciseId, ((Exercise)actionValue.Value).ExerciseId);

        }

        [Fact]
        public async void ExercisesController_GetExercise_WithInvalidId_ReturnNotFoundResult()
        {
            //Arrange
            int exerciseId = 5;

            mockRepo.Setup(a => a.GetExercise(exerciseId)).ReturnsAsync(exercises.Find(x => x.ExerciseId == exerciseId));

            //Act
            var result = await controller.GetExercise(exerciseId);

            //Assert
            //Testing return value is correct
            var actionValue = Assert.IsType<NotFoundObjectResult>(result.Result);
        }


        //AddExercisesTest

        [Fact]
        public async void ExercisesController_CreateExercise_ReturnsCreatedAtActionResult_201()
        {
            //Arrange
            Exercise NewExercise = new Exercise()
            {
                ExerciseId = 6,
                Name = "Split Jerk"
            };

            mockRepo.Setup(a => a.Add(NewExercise)).ReturnsAsync(NewExercise);

            //Act
            var result = await controller.CreateExercise(NewExercise);

            //Assert
            Assert.IsType<CreatedAtActionResult>(result.Result);
        }

        //[Fact]
        //public async void ExerciseRepository_CreateExercise_ReturnsBadRequest()
        //{
        //    //Arrange
        //    Exercise NewExercise = new Exercise()
        //    {
                
        //    };

        //    mockRepo.Setup(a => a.Add(NewExercise)).ReturnsAsync(NewExercise);

        //    //Act
        //    var result = await controller.CreateExercise(NewExercise);

        //    //Assert
        //    Assert.IsType<BadRequestObjectResult>(result.Result);

        //}


        //UpdateExercise

        [Fact]
        public async void ExercisesController_UpdateExercise_ReturnAcceptedResult_IfIdsEqual()
        {
            //Arrange
            Exercise exercise = new Exercise()
            {
                ExerciseId = exercises[1].ExerciseId,
                Name = "Push Press"
            };

            mockRepo.Setup(a => a.Update(exercises[1].ExerciseId, exercise)).ReturnsAsync(exercise);

            //Act
            var result = await controller.UpdateExercise(exercises[1].ExerciseId, exercise);

            //Assert
            Assert.IsType<AcceptedResult>(result);
        }

        [Fact]
        public async void ExercisesController_UpdateExercise_ReturnsBadRequest_IfIdsNotEqual()
        {
            //Arrange
            Exercise exercise = new Exercise()
            {
                ExerciseId = exercises[1].ExerciseId,
                Name = "Push Press"
            };

            mockRepo.Setup(a => a.Update(exercises[1].ExerciseId, exercise)).ReturnsAsync(exercise);

            //Act
            var result = await controller.UpdateExercise(exercises[2].ExerciseId, exercise);

            //Assert
            Assert.IsType<BadRequestResult>(result);
        }




        //DeleteExercise

        [Fact]
        public async void ExercisesController_DeleteExercise_ReturnOkResult()
        {
            //Arrange
            int exerciseId = exercises[0].ExerciseId;

            mockRepo.Setup(a => a.GetExercise(exerciseId)).ReturnsAsync(exercises.Find(x => x.ExerciseId == exerciseId));
            mockRepo.Setup(a => a.Delete(exerciseId)).Verifiable();

            //Act
            var result = await controller.DeleteExercise(exercises[0].ExerciseId);

            //Assert
            mockRepo.Verify();
        }

        [Fact]
        public async void ExercisesController_DeleteExercise_IfExerciseIsNull_ReturnNotFound()
        {
            //Arrange
            int exerciseId = 8;

            mockRepo.Setup(a => a.GetExercise(exerciseId)).ReturnsAsync(exercises.Find(x => x.ExerciseId == exerciseId));

            //Act
            var result = await controller.DeleteExercise(exerciseId);

            //Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }

    }
}