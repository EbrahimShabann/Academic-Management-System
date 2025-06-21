using ITI_MVC_Project.Models;
using ITI_MVC_Project.Models.BL;
using ITI_MVC_Project.RepositoriesBL.IRepos;
using ITI_MVC_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ITI_MVC_Project.Controllers
{
    public class TraineeController : Controller
    {
        private readonly ITraineeRepository trRepo;
        private readonly IDepartmentRepository deptRepo;
        List<Department> depts;
        public TraineeController(ITraineeRepository trRepo,IDepartmentRepository deptRepo)
        {
            this.trRepo = trRepo;
            this.deptRepo = deptRepo;
        }
        public IActionResult Index(int page = 1, int size = 5)
        {
            var traineesList =  trRepo.GetAll().AsEnumerable();
            
            return View(traineesList.ToPagedResult(page, size));
        }

        public IActionResult GetResult()
        {
            return View();
        }
        public IActionResult Result(int tid,string cname)
        {

           TraineeResultViewModel traineeVM =new TraineeResultViewModel();
            traineeVM= trRepo.getResult(tid, cname);

            return View(traineeVM);
        }


        [HttpGet]
        public IActionResult UpSert(int? id)
        {

             depts = deptRepo.GetAll();
            ViewBag.deptList = depts;
            if (id == null || id == 0)
            {
                //create new trinee
                return PartialView(new Trainee());

            }
            else
            {
                //update existed trainee
                Trainee trFromDb = trRepo.GetById(id);
                if (trFromDb == null)
                {
                    return NotFound();
                }

                return PartialView(trFromDb);

            }



        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpSert(Trainee tr,IFormFile file)
        {
            depts = deptRepo.GetAll();
            ViewBag.deptList = depts;


            if (tr.Name == null)
            {
                ModelState.AddModelError("name", "Trainee name is required");
                return PartialView(tr);
            }
           
            else
            {
                if (file != null)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    string FinalPath = Path.Combine("wwwroot", "images", fileName);
                    tr.Image = fileName;
                    using (var stream = new FileStream(FinalPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }


                if (tr.Id == 0)
                {
                    //New Trainee

                    trRepo.Add(tr);
                }
                else
                {
                    //Update 

                    trRepo.Update(tr);
                }
                trRepo.Save();
                return RedirectToAction("Index");

            }
        }

        public IActionResult Details(int id)
        {
            Trainee tr = trRepo.GetById(id);
         
            return View(tr);
        }
   
        public IActionResult Delete(int? id)
        {
            trRepo.Delete(id);
            trRepo.Save();
            return RedirectToAction("Index");
        }
    }
}
