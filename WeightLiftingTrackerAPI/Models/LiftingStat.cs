using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackerAPI.Models
{
    public class LiftingStat
    {
        [Key]
        public int LiftingStatId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public double Weight { get; set; }
        public int Repetitions { get; set; }

        public int ExerciseId { get; set; }
    }
}
