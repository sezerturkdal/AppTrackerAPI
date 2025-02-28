using System;
namespace AppTrackerAPI.Repositories
{
    public interface IRepositoryGet<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
    }

    public interface IRepositorySave<T> where T : class
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }

}

