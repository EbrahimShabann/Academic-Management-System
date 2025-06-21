using ITI_MVC_Project.Models.CustomAttributes;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_MVC_Project.Models
{
    [Table("Course")]
    public class Course
    {
        
        public int Id { get; set; }

        [Required]
        [Unique]
        [MinLength(2,ErrorMessage ="Course Name can't be less than 2 chars")]
        [MaxLength(20,ErrorMessage = "Course Name can't be greater than 20 chars")]
        public string Name { get; set; }

        [Range(50,100,ErrorMessage ="Must be >= 50 and <= 100")]
        public int Degree { get; set; }

        [Remote("CheckMinDeg","Course",AdditionalFields ="Degree")]
        
        public int MinDegree { get; set; }
        [Remote("CheckHours","Course")]
        public int Hours { get; set; }
        [Column("dept_id")]
        public int? DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }

        public virtual List<Instructor> Instructors { get; set; }
        public virtual List<crsResult> CrsResults { get; set; }
    }
}
