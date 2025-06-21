namespace ITI_MVC_Project.RepositoriesBL.IRepos
{
    public interface IRepository<T>
    {
        public List<T> GetAll();
        public T GetById(int? id);
        public void Add(T Obj);
        public void Update(T Obj);
        public void Delete(int? id);
        public void Save();
    }
}
