using ITI_MVC_Project.Models;
using ITI_MVC_Project.Models.CustomAttributes;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_MVC_Project.ViewModels
{
    public class AddTraineeResltVM
    {
        [Required]
        [Range(0, 100, ErrorMessage = "Degree Range from 0 to 100")]
        public int Degree { get; set; }


        [Remote("CheckMinDeptId", "Course",ErrorMessage ="Select Department")]
        public int DepartmentId { get; set; }
        public List<Department> Departments { get; set; }


        [Remote("CheckMinTrId", "Course", ErrorMessage = "Select Trainee")]
        public int TraineeId { get; set; }
        public virtual Trainee Trainee { get; set; }
        public dynamic Trainees { get; set; }

        [Remote("CheckMinCrId", "Course", ErrorMessage = "Select Course")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public dynamic Courses { get; set; }

    }
}
