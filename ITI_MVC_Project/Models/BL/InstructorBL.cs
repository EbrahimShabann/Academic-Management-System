//using ITI_MVC_Project.ViewModels;
//using Microsoft.EntityFrameworkCore;
//using System.Drawing;
//using System.Security.Cryptography.X509Certificates;

//namespace ITI_MVC_Project.Models.BL
//{
//    public class InstructorBL
//    {
       
//        AppDbContext db= new AppDbContext();
        

//        public PagedResult<Instructor> GetAll(int pageNumber,int pageSize)
//        {
//            var Instructors =  db.Instructors.ToPagedResult(pageNumber, pageSize);
//            return Instructors;
//        }

//        public Instructor GetById(int? id)
//        {
//            return db.Instructors.SingleOrDefault(i => i.Id == id);
//        }
//        public void Add(Instructor ins)
//        {
//            db.Instructors.Add(ins);
//            db.SaveChanges();
//        }

//        public void Update(InstrWithCrsAndDept insVM)
//        {
//            Instructor insFromDb = db.Instructors.SingleOrDefault(i => i.Id == insVM.Id);
//            insFromDb.Name = insVM.Name;
//            insFromDb.Address = insVM.Address;
//            insFromDb.Salary = insVM.Salary;
//            if (insVM.Image != null)
//            {
//                insFromDb.Image = insVM.Image;

//            }
//            insFromDb.DepartmentId = insVM.DepartmentId;
//            insFromDb.CourseId = insVM.CourseId;
//            db.Instructors.Update(insFromDb);
//            db.SaveChanges();
//        }
//    }
//}
