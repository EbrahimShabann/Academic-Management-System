using ITI_MVC_Project.Models;
using ITI_MVC_Project.Models.BL;
using ITI_MVC_Project.RepositoriesBL.IRepos;
using ITI_MVC_Project.ViewModels;

namespace ITI_MVC_Project.RepositoriesBL.Repos
{
    public class CourseRepository: ICourseRepository
    {
        private readonly AppDbContext db;

        public CourseRepository(AppDbContext _db)
        {
            db = _db;
        }
        public List<Course> GetAll()
        {
            var Courses = db.Courses.ToList();
            return Courses;
        }
        public Course GetById(int? id)
        {
            return db.Courses.SingleOrDefault(i => i.Id == id);
        }
        public void Add(Course cr)
        {
            db.Courses.Add(cr);
        }

        public void Update(Course cr)
        {
            Course crFromDb = db.Courses.SingleOrDefault(i => i.Id == cr.Id);
            crFromDb.Name = cr.Name;
            crFromDb.Degree = cr.Degree;
            crFromDb.MinDegree = cr.MinDegree;
            crFromDb.Hours = cr.Hours;
            crFromDb.DepartmentId = cr.DepartmentId;
            db.Courses.Update(crFromDb);
        }

        public void Delete(int? id)
        {
            Course crFromDb = db.Courses.SingleOrDefault(c => c.Id == id);
            db.Courses.Remove(crFromDb);
        }

        public void Save()
        {
            db.SaveChanges();
        }
        public PagedResult<CourseResultsViewModel> GetResult(int pageNumber, int pageSize, string cname)
        {


            var query = from trainee in db.Trainees
                        join crs in db.CrsResults on trainee.Id equals crs.TraineeId
                        join course in db.Courses on crs.CourseId equals course.Id
                        where course.Name == cname
                        select new CourseResultsViewModel
                        {
                            TraineeName = trainee.Name,
                            CourseName = course.Name,
                            TraineeDegree = crs.Degree,
                            TotalDegree = course.Degree,
                            MinDegree = course.MinDegree,
                            Status = crs.Degree >= course.MinDegree ? "Success" : "Failed",
                            Color = crs.Degree >= course.MinDegree ? "green" : "red"
                        };

            var paged =  query.ToPagedResult(pageNumber, pageSize);
            return paged;
        }

        public int GetTraineesCount(int? crId)
        {
            int count = (from crResult in db.CrsResults
                         join trainee in db.Trainees
                         on crResult.TraineeId equals trainee.Id
                         join course in db.Courses
                         on crResult.CourseId equals course.Id
                         where trainee.DepartmentId == course.DepartmentId 
                         && course.Id==crId
                         select crResult.Degree
                         ).Count();
            return count;
        }
    }
}
