using ITI_MVC_Project.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace ITI_MVC_Project.Models.CustomAttributes
{
    public class UniqueAttribute:ValidationAttribute
    {
         
       
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            AppDbContext db = validationContext.GetService<AppDbContext>();

            if (validationContext.ObjectInstance .GetType() == typeof(Course))
            {
                Course crFromReq = validationContext.ObjectInstance as Course;
                Course crFromDb = db.Courses.FirstOrDefault(c => c.Name == value.ToString() && c.DepartmentId == crFromReq.DepartmentId);
                if (crFromReq.Id == 0)
                {
                    if (crFromDb == null)
                    {
                        return ValidationResult.Success;
                    }
                    return new ValidationResult("Course Name is Existed in this Department");
                }
                else
                {
                    //in case u try to update course name with an existing course name (fails)
                    crFromDb = db.Courses.FirstOrDefault(c => c.Name == value.ToString() && c.Id != crFromReq.Id
                                                            && c.DepartmentId == crFromReq.DepartmentId);
                    if(crFromDb == null)
                    {
                        return ValidationResult.Success;
                    }
                    return new ValidationResult("Course Name is Existed in this Department");


                }


            }
            else if(validationContext.ObjectInstance.GetType() == typeof(Department))
            {
                Department deptFromReq = validationContext.ObjectInstance as Department;
                Department deptFromDb = db.Departments.FirstOrDefault(d => d.Name == value.ToString());
                if (deptFromReq.Id == 0)
                {
                    if (deptFromDb == null)
                    {
                        return ValidationResult.Success;
                    }
                    return new ValidationResult("Department is already Existed  ");
                }

                return ValidationResult.Success;

            }

            else if(validationContext.ObjectInstance.GetType() == typeof(InstrWithCrsAndDept))
            {
                InstrWithCrsAndDept instFromReq = validationContext.ObjectInstance as InstrWithCrsAndDept;
                if (instFromReq.Id == 0)
                {

                    Instructor instFromDb = db.Instructors.FirstOrDefault(d => d.Name == value.ToString());
                    if (instFromDb == null)
                    {
                        return ValidationResult.Success;
                    }
                    return new ValidationResult("Instructor is already Existed  ");
                }

                return ValidationResult.Success;

            }

            else if(validationContext.ObjectInstance.GetType() == typeof(Trainee))
            {
                Trainee trFromDb = db.Trainees.FirstOrDefault(d => d.Name == value.ToString());
                if (trFromDb == null)
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult("Trainee is already Existed  ");
            }
            else
                return new ValidationResult("Check Model Type in UniqueAttribute Class ");


        }
    }
}
