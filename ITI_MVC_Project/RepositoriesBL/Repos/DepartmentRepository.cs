using ITI_MVC_Project.Models;
using ITI_MVC_Project.RepositoriesBL.IRepos;

namespace ITI_MVC_Project.RepositoriesBL.Repos
{
    public class DepartmentRepository:IDepartmentRepository
    {
        private readonly AppDbContext db;

        public DepartmentRepository(AppDbContext _db)
        {
            db = _db;
        }
        public List<Department> GetAll()
        {
            var Departments = db.Departments.ToList();
            return Departments;
        }

        public Department GetById(int? id)
        {
            return db.Departments.SingleOrDefault(d => d.Id == id);
        }

        public void Add(Department dept)
        {
            db.Departments.Add(dept);
        }
        public void Delete(int? id)
        {
            var dept = db.Departments.SingleOrDefault(d => d.Id == id);
            db.Departments.Remove(dept);
        }

        public void Update(Department dept)
        {
            Department deptFromDb = db.Departments.SingleOrDefault(i => i.Id == dept.Id);
            deptFromDb.Name = dept.Name;
            deptFromDb.Manager = dept.Manager;
            db.Departments.Update(deptFromDb);
        }
        public void Save()
        {
            db.SaveChanges();

        }

    }
}
