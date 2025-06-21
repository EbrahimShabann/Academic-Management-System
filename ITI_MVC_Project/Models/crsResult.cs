using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_MVC_Project.Models
{
    [Table("crsResult")]
    public class crsResult
    {
        public int Id { get; set; }
        public int Degree { get; set; }
        [Column("crs_id")]
        public int CourseId { get; set; }
        public int TraineeId { get; set; }

        [ForeignKey("TraineeId")]
        public virtual Trainee Trainee { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
    }
}
