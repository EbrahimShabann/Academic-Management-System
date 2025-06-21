using ITI_MVC_Project.Models;
using ITI_MVC_Project.RepositoriesBL.IRepos;
using ITI_MVC_Project.ViewModels;

namespace ITI_MVC_Project.RepositoriesBL.Repos
{
    public class TraineeRepository:ITraineeRepository
    {
        private readonly AppDbContext db;

        public TraineeRepository(AppDbContext _db)
        {
            db = _db;
        }
        public List<Trainee> GetAll()
        {
            var Trainees =  db.Trainees.ToList();
            return Trainees;
        }

        public Trainee GetById(int? id)
        {
            return db.Trainees.SingleOrDefault(i => i.Id == id);
        }
        public void Add(Trainee tr)
        {
            db.Trainees.Add(tr);
        }

        public void Update(Trainee tr)
        {
            Trainee trFromDb = db.Trainees.SingleOrDefault(i => i.Id == tr.Id);
            trFromDb.Name = tr.Name;
            trFromDb.Address = tr.Address;
            if (tr.Image != null)
            {
                trFromDb.Image = tr.Image;

            }

            trFromDb.DepartmentId = tr.DepartmentId;
            db.Trainees.Update(trFromDb);
        }
        public TraineeResultViewModel getResult(int tid, string cname)
        {

            var result = (from trainee in db.Trainees
                          join crs in db.CrsResults
                              on trainee.Id equals crs.TraineeId
                          join course in db.Courses
                              on crs.CourseId equals course.Id
                          where course.Name == cname && trainee.Id == tid
                          select new TraineeResultViewModel
                          {

                              TraineeName = trainee.Name,
                              CourseName = course.Name,
                              TraineeDegree = crs.Degree,
                              TotalDegree = course.Degree,
                              Status = crs.Degree >= course.MinDegree ? "Success" : "Failed",
                              Color = crs.Degree >= course.MinDegree ? "green" : "red"
                          }).FirstOrDefault();

            return result;

        }

        public void Delete(int? id)
        {
            Trainee trFromDb = db.Trainees.SingleOrDefault(t => t.Id == id);
            db.Trainees.Remove(trFromDb);
        }

       public void Save()
        {
            db.SaveChanges();
        }
    }
}
