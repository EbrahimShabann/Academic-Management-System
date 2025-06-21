using ITI_MVC_Project.Models;
using ITI_MVC_Project.ViewModels;

namespace ITI_MVC_Project.RepositoriesBL.IRepos
{
    public interface ICourseRepository:IRepository<Course>
    {
        public  PagedResult<CourseResultsViewModel> GetResult(int pageNumber, int pageSize, string cname);
        public int GetTraineesCount(int? crId);

    }
}
