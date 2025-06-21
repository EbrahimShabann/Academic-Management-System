using ITI_MVC_Project.Models;
using ITI_MVC_Project.RepositoriesBL.IRepos;
using ITI_MVC_Project.ViewModels;

namespace ITI_MVC_Project.RepositoriesBL.Repos
{
    public class CourseResultsRepo : ICourseResultsRepo
    {
        private readonly AppDbContext db;

        public CourseResultsRepo(AppDbContext db)
        {
            this.db = db;
        }
        public void Add(AddTraineeResltVM trResult)
        {
            crsResult crsResult = new crsResult();
            crsResult.CourseId = trResult.CourseId;
            crsResult.TraineeId = trResult.TraineeId;
            crsResult.Degree = trResult.Degree;
            db.CrsResults.Add(crsResult);
        }

        public void Delete(int? id)
        {
            throw new NotImplementedException();
        }

        public List<AddTraineeResltVM> GetAll()
        {
            throw new NotImplementedException();
        }

        public AddTraineeResltVM GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(AddTraineeResltVM Obj)
        {
            throw new NotImplementedException();
        }
    }
}
