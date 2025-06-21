using ITI_MVC_Project.Models;
using ITI_MVC_Project.Models.BL;
using ITI_MVC_Project.RepositoriesBL.IRepos;
using ITI_MVC_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC_Project.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository crRepo;
        private readonly IDepartmentRepository deptRepo;
        List<Department> DepartmentList;
        public CourseController(ICourseRepository crRepo,IDepartmentRepository deptRepo)
        {
            this.crRepo = crRepo;
            this.deptRepo = deptRepo;
        }
        public  IActionResult Index(int page = 1, int size = 5)
        {
            var coursesList = crRepo.GetAll().AsEnumerable();
            var courses =  coursesList.ToPagedResult(page, size);

            return View(courses);
        }

        public IActionResult GetResults()
        {
            return View();
        }

       
        public IActionResult courseResults(string cname,int page=1,int size=2)
        {
          
            var ListCourseVM=  crRepo.GetResult(page,size,cname);
            
            return View(ListCourseVM);
        }


        [HttpGet]
        public IActionResult UpSert(int? id)
        {

            ViewBag.deptList = deptRepo.GetAll();
            if (id == null || id == 0)
            {
                //create new Course
                return PartialView(new Course());

            }
            else
            {
                //update existed course
                Course crFromDb = crRepo.GetById(id);
                if (crFromDb == null)
                {
                    return Content("Not Found 404");
                }
               
                return PartialView(crFromDb);

            }



        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpSert(Course cr)
        {
           
            ViewBag.deptList = deptRepo.GetAll();


            if (ModelState.IsValid)
            {
                try
                {
                    if (cr.Id == 0)
                    {
                        //New Course

                        crRepo.Add(cr);
                        
                    }
                    else
                    {
                        //Update 

                        crRepo.Update(cr);
                    }
                    crRepo.Save();
                    return RedirectToAction("Index");
                }
                catch (Exception ex) 
                {
                    ModelState.AddModelError("DepartmentId", "Select Department");
                    return PartialView(cr);
                }

            }
            else
            {
                return PartialView(cr);
            }
        }
        public IActionResult Delete(int? id)
        {
            
            
            if (crRepo.GetById(id) == null)
            {
                return NotFound();
            }
            crRepo.Delete(id);
            crRepo.Save();

            return RedirectToAction("Index");





        }
    
        public IActionResult CheckMinDeg(int MinDegree,int Degree)
        {
            if (MinDegree < Degree)
            {
                if(MinDegree>=0)
                  return Json(true);
                else
                    return Json("Min Degree can't be less than 0");
            }
            else
            {
                return Json("Min Degree must be less than Total Degree");

            }
        }
    
        public IActionResult CheckHours(int hours)
        {
            if (hours % 3 == 0)
            {
                return Json(true);
            }
            else
            {
                return Json("Hours must accept divsion by 3");

            }
        }
    }
}
