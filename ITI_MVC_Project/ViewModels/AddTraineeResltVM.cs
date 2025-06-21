using ITI_MVC_Project.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI_MVC_Project.ViewModels
{
    public class AddTraineeResltVM
    {
        [Required]
        [Range(0, 100, ErrorMessage = "Degree Range from 0 to 100")]
        public int Degree { get; set; }


        public int? DepartmentId { get; set; }
        public List<Department> Departments { get; set; }

       
        public int TraineeId { get; set; }
        public virtual Trainee Trainee { get; set; }
        public dynamic Trainees { get; set; }



    
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
        public dynamic Courses { get; set; }

    }
}
