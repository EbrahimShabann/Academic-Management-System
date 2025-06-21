using ITI_MVC_Project.Models;
using ITI_MVC_Project.RepositoriesBL.IRepos;
using ITI_MVC_Project.ViewModels;

namespace ITI_MVC_Project.RepositoriesBL.Repos
{
    public class InstructorRepository:IInstructorRepository
    {
        private readonly AppDbContext db;

        public InstructorRepository(AppDbContext _db)
        {
            db = _db;
        }
        public List<Instructor> GetAll()
        {
            var Instructors = db.Instructors.ToList();
            return Instructors;
        }

        public Instructor GetById(int? id)
        {
            return db.Instructors.SingleOrDefault(i => i.Id == id);
        }
        public void Add(Instructor ins)
        {
            db.Instructors.Add(ins);
        }

        public void Update(Instructor ins)
        {
           
            db.Instructors.Update(ins);
        }
        public void Delete(int? id)
        {
            var inst = GetById(id);
            db.Instructors.Remove(inst);
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
