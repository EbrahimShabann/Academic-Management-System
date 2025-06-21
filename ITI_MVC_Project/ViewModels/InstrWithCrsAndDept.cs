using ITI_MVC_Project.Models;
using ITI_MVC_Project.Models.CustomAttributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_MVC_Project.ViewModels
{
    public class InstrWithCrsAndDept
    {
        public int Id { get; set; }
        public int? DepartmentId { get; set; }
        public int? CourseId { get; set; }

        [Required]
        [Unique]
        [StringLength(100,MinimumLength =3,ErrorMessage ="Instructor Name length must be from 3 to 100 chars")]
        public string Name { get; set; }
        //[RegularExpression(@"\w+\.(png|jpg) ")]
        public string Image { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 10, ErrorMessage = " Address length must be from 20 to 100 chars")]
        public string Address { get; set; }
        [Range(7000,20000,ErrorMessage ="Salary range between 7K , 20K")]
        public int? Salary { get; set; }

        public List<Course> Courses { get; set; }
        public List<Department> Departments { get; set; }
    }
}
