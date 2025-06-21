using ITI_MVC_Project.Models;
using ITI_MVC_Project.Models.BL;
using ITI_MVC_Project.RepositoriesBL.IRepos;
using ITI_MVC_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static System.Net.Mime.MediaTypeNames;

namespace ITI_MVC_Project.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IInstructorRepository insRepo;
        private readonly IDepartmentRepository deptRepo;
        private readonly ICourseRepository crRepo;
        List<Department> DepartmentList;
        List<Course> CourseList;
        public InstructorController(IInstructorRepository insRepo,IDepartmentRepository deptRepo,ICourseRepository crRepo)
        {
            this.insRepo = insRepo;
            this.deptRepo = deptRepo;
            this.crRepo = crRepo;
        }
        public IActionResult Index(int page=1,int size=5)
        {
            var instructorList =  insRepo.GetAll().AsEnumerable();

           
            return View(instructorList.ToPagedResult(page,size));
        }
        public IActionResult Details(int id)
        {
            Instructor instructor = insRepo.GetById(id);
            int? numOfTrInCr = crRepo.GetTraineesCount(instructor.CourseId);
            ViewBag.traineesCount = numOfTrInCr;
            // Session State Managment
            //HttpContext.Session.SetString("InstructorName",instructor.Name);
            //HttpContext.Session.SetString("InstructorDepartment",instructor.Department.Name);

            ////Cookies
            //HttpContext.Response.Cookies.Append("InstructorName", instructor.Name);
            //HttpContext.Response.Cookies.Append("InstructorDepartment", instructor.Department.Name);
            return View(instructor);
        }

        [HttpGet]
        public IActionResult UpSert(int? id)
        {
             
            
            InstrWithCrsAndDept InsVM = new InstrWithCrsAndDept()
            {
                Departments = deptRepo.GetAll(),
                Courses = crRepo.GetAll(),
            };
            if (id == null || id==0)
            {
                //create new instructor
               return PartialView("_UpSertPartial",InsVM); 

            }
            else
            {
                //update existed instructor
                Instructor insFromDb = insRepo.GetById(id);
                if (insFromDb == null)
                {
                    return Content("Not Found");
                }
                InsVM.Id = insFromDb.Id;
                InsVM.DepartmentId = insFromDb.DepartmentId;
                InsVM.CourseId = insFromDb.CourseId;
                InsVM.Name = insFromDb.Name;
                InsVM.Address= insFromDb.Address;
                InsVM.Salary = insFromDb.Salary;
                InsVM.Image = insFromDb.Image;
                return PartialView("_UpSertPartial",InsVM);

            }


                
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpSert(InstrWithCrsAndDept insVM,IFormFile file)
        {
            DepartmentList = deptRepo.GetAll();
            CourseList = crRepo.GetAll();
            insVM.Departments=DepartmentList;
            insVM.Courses = CourseList;
            try
            {
                if (!ModelState.IsValid)
                {
                    return PartialView("_UpSertPartial", insVM);
                }
                else
                {

                    if (file != null)
                    {
                        string fileName = Path.GetFileName(file.FileName);
                        string FinalPath = Path.Combine("wwwroot", "images", fileName);
                        insVM.Image = fileName;
                        using (var stream = new FileStream(FinalPath, FileMode.Create))
                        {
                            file.CopyTo(stream);
                        }
                    }

                    if (insVM.Id == 0)
                    {
                        //New Instructor
                        Instructor newIns = new Instructor()
                        {
                            Name = insVM.Name,
                            Address = insVM.Address,
                            Salary = insVM.Salary,
                            Image = insVM.Image,
                            DepartmentId = insVM.DepartmentId,
                            CourseId = insVM.CourseId,
                        };
                        insRepo.Add(newIns);
                    }
                    else
                    {
                        //Update 
                        Instructor insFromDb = insRepo.GetById(insVM.Id);
                        insFromDb.Name = insVM.Name;
                        insFromDb.Address = insVM.Address;
                        insFromDb.Salary = insVM.Salary;
                        if (insVM.Image != null)
                        {
                            insFromDb.Image = insVM.Image;

                        }
                        insFromDb.DepartmentId = insVM.DepartmentId;
                        insFromDb.CourseId = insVM.CourseId;
                        insRepo.Update(insFromDb);
                    }
                    insRepo.Save();
                    return RedirectToAction("Index");


                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DepartmentId", "Select Department");
                return PartialView("_UpSertPartial", insVM);
            }


            }
        

        public IActionResult Delete(int? id)
        {


            if (insRepo.GetById(id) == null)
            {
                return NotFound();
            }
            insRepo.Delete(id);
            insRepo.Save();

            return RedirectToAction("Index");


        }
    }
}
