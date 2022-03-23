using System.ComponentModel.DataAnnotations;

namespace TrackerAPI.Models
{
    public class Exercise
    {
        [Key]
        public int ExerciseId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public IEnumerable<LiftingStat> Stats { get; set; }

    }
}
