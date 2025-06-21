using ITI_MVC_Project.Models;
using ITI_MVC_Project.ViewModels;

namespace ITI_MVC_Project.RepositoriesBL.IRepos
{
    public interface ITraineeRepository:IRepository<Trainee>
    {
        public TraineeResultViewModel getResult(int tid, string cname);
    }
}
