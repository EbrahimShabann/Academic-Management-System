//using Azure;
//using ITI_MVC_Project.ViewModels;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Query.Internal;

//namespace ITI_MVC_Project.Models.BL
//{
//    public class DepartmentBL
//    {
//        AppDbContext db = new AppDbContext();


//        public PagedResult<Department> GetAll(int pageNumber, int pageSize)
//        {
//            var Departments =  db.Departments.ToPagedResult(pageNumber, pageSize);
//            return Departments;
//        }

//        public Department GetById(int? id)
//        {
//            return db.Departments.SingleOrDefault(d=>d.Id== id);
//        }

//        public void Add (Department dept)
//        {
//            db.Departments.Add(dept);
//            db.SaveChanges();
//        }

//        public void Update(Department dept)
//        {
//            Department deptFromDb = db.Departments.SingleOrDefault(i => i.Id == dept.Id);
//            deptFromDb.Name=dept.Name;
//            deptFromDb.Manager = dept.Manager;
//            db.Departments.Update(deptFromDb);
//            db.SaveChanges();
//        }
    
       
//    }
//}
