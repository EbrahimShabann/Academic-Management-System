using ITI_MVC_Project.Models.CustomAttributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_MVC_Project.Models
{
    [Table("Department")]
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [Unique]
        [StringLength(100,MinimumLength =3, ErrorMessage = "Department Name length from 3 to 100 chars")]
        public string Name { get; set; }
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Manager Name length from 3 to 100 chars")]
        public string Manager { get; set; }

        public virtual List<Instructor> Instructors { get; set; }
        public virtual List<Course> Courses { get; set; }
        public virtual List<Trainee> Trainees { get; set; }
    }
}
