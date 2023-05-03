namespace Labb_4___API.Services
{
    public interface IAppRepository <T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetSingle(int id);
        Task<T> Add(T obj);
        Task<T> Update(T obj);
        Task<T> Delete(int id);
    }
}
