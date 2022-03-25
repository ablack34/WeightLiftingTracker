using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace TrackerAPI.Models
{
    public class LiftingStat
    {

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int LiftingStatId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string Date { get; set; }
        public double Weight { get; set; }
        public int Repetitions { get; set; }

        public int ExerciseId { get; set; }

        //public string ConvertToDateOnly()
        //{
        //    CultureInfo provider = CultureInfo.InvariantCulture;
        //    var format = "d";

        //    DateTime dateOnly = DateTime.Today;
        //    string formatDateOnly = dateOnly.ToString(format);
            
        //    return formatDateOnly;
        //}

    }

    
}
