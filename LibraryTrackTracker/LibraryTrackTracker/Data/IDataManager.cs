
namespace DataLibrary.Data
{
    public interface IDataManager
    {
        Task<int> Create(object model);
        Task Delete(int Id);
        Task<List<T>> GetAll<T>() where T : class;
        Task<T> GetById<T>(int id) where T : class;
        Task UpdateName(int Id, string name);
    }
}