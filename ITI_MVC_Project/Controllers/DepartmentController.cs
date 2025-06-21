using ITI_MVC_Project.Models;
using ITI_MVC_Project.Models.BL;
using ITI_MVC_Project.RepositoriesBL.IRepos;
using ITI_MVC_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC_Project.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository deptRepo;
        Department deptFromDb;
        public DepartmentController(IDepartmentRepository deptRepo)
        {
            this.deptRepo = deptRepo;
        }
        public IActionResult Index(int page = 1, int size = 5)
        {
            var DepartmentsList =  deptRepo.GetAll().AsEnumerable();
            var depts = DepartmentsList.ToPagedResult(page, size);

            return View(depts);
        }

        
        [HttpGet]
        public IActionResult UpSert(int? id)
        {

            
            if (id == null || id == 0)
            {
                //create new department
                Department newDept= new Department();
                return PartialView(newDept);

            }
            else
            {
                //update existed department
                 deptFromDb = deptRepo.GetById(id);
                if (deptFromDb == null)
                {
                    return Content("Not Found");
                }
               
                return PartialView(deptFromDb);

            }



        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpSert(Department dept)
        {
            
            
            if (!ModelState.IsValid)
            {
                return PartialView(dept);
            }
            else
            {

                if (dept.Id == 0)
                {
                    //New Department
                    Department newDept = new Department()
                    {
                        Name = dept.Name,
                        Manager=dept.Manager
                    };
                    deptRepo.Add(newDept);
                }
                else
                {
                    //Update 

                    deptRepo.Update(dept);
                }
                deptRepo.Save();
                return RedirectToAction("Index");

            }
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {

             
            if (deptRepo.GetById(id) == null)
            {
                return NotFound();
            }
            deptRepo.Delete(id);
            deptRepo.Save();

            return RedirectToAction("Index");

            
        }

    }
}
