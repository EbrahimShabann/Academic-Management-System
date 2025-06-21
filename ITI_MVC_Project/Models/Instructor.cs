using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_MVC_Project.Models
{
    [Table("Instructor")]
    public class Instructor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public int? Salary { get; set; }
        [Column("dept_id")]
        public int? DepartmentId { get; set; }
        [Column("crs_id")]
        public int? CourseId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; }
    }
}
