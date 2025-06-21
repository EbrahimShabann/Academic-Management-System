//using ITI_MVC_Project.ViewModels;
//using Microsoft.EntityFrameworkCore;

//namespace ITI_MVC_Project.Models.BL
//{
//    public class CourseBL
//    {
//        AppDbContext db = new AppDbContext();
//        //public async Task<PagedResult<Course>> GetAll(int pageNumber, int pageSize)
//        //{
//        //    var Courses = await db.Courses.ToPagedResultAsync(pageNumber, pageSize);
//        //    return Courses;
//        //}
//        //public Course GetById(int? id)
//        //{
//        //    return db.Courses.SingleOrDefault(i => i.Id == id);
//        //}
//        //public void Add(Course cr)
//        //{
//        //    db.Courses.Add(cr);
//        //    db.SaveChanges();
//        //}

//        //public void Update(Course cr)
//        //{
//        //    Course crFromDb = db.Courses.SingleOrDefault(i => i.Id == cr.Id);
//        //    crFromDb.Name = cr.Name;
//        //    crFromDb.Degree = cr.Degree;
//        //    crFromDb.MinDegree = cr.MinDegree;
//        //    crFromDb.Hours = cr.Hours;
//        //    crFromDb.DepartmentId = cr.DepartmentId;
//        //    db.Courses.Update(crFromDb);
//        //    db.SaveChanges();
//        //}
//        public PagedResult<CourseResultsViewModel> GetResultAsync(int pageNumber, int pageSize, string cname)
//        {
           

//            var query = from trainee in db.Trainees
//                        join crs in db.CrsResults on trainee.Id equals crs.TraineeId
//                        join course in db.Courses on crs.CourseId equals course.Id
//                        where course.Name == cname
//                        select new CourseResultsViewModel
//                        {
//                            TraineeName = trainee.Name,
//                            CourseName = course.Name,
//                            TraineeDegree = crs.Degree,
//                            TotalDegree = course.Degree,
//                            MinDegree = course.MinDegree,
//                            Status = crs.Degree >= course.MinDegree ? "Success" : "Failed",
//                            Color = crs.Degree >= course.MinDegree ? "green" : "red"
//                        };

//            var paged =  query.ToPagedResult(pageNumber, pageSize);
//            return paged;
//        }

//    }
//}
