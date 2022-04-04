using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrackerAPI.Data;
using TrackerAPI.Models;
using TrackerAPI.Repository;

namespace TrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExercisesController : ControllerBase
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExercisesController(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }

        // GET: api/Exercises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exercise>>> GetExercises()
        {
            var exercises = await _exerciseRepository.GetExerciseList();
            return Ok(exercises);
        }

        // GET: api/Exercises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Exercise>> GetExercise([FromRoute] int id)
        {
            var result = await _exerciseRepository.GetExercise(id);

            if(result == null)
            {
                return NotFound("Exercise not found.");
            }

            return Ok(result);
        }

        // PUT: api/Exercises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateExercise(int id, Exercise exercise)
        {
            if (id != exercise.ExerciseId)
            {
                return BadRequest();
            }

            await _exerciseRepository.UpdateExercise(id, exercise);

            return Accepted("Exercise updated.");
        }

        // POST: api/Exercises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Exercise>> CreateExercise([FromBody]Exercise exercise)
        {
            //Should there be a bad request option here??
            
            var createdExercise = await _exerciseRepository.AddExercise(exercise);

            return CreatedAtAction(nameof(GetExercise), new { id = createdExercise.ExerciseId }, createdExercise);

        }

        // DELETE: api/Exercises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercise(int id)
        {
            var exercise = await _exerciseRepository.GetExercise(id);

            if (exercise == null)
            {
                return NotFound("Exercise not found.");
            }

            var result = await _exerciseRepository.DeleteExercise(id);

            return Ok();
        }

    }
}
