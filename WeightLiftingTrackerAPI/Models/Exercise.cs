using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrackerAPI.Models
{
    public class Exercise
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ExerciseId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        public virtual IEnumerable<LiftingStat> Stats { get; set; }

    }
}
