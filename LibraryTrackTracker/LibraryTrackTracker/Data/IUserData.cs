using DataLibrary.Db;

namespace DataLibrary.Data
{
    public interface IUserData
    {
        ConnectionStringData _connectionString { get; }
        Task<List<T>> GetAll<T>() where T : class;
        Task<T> GetById<T>(int id) where T : class;
        Task<int> Create(object model);
        Task Delete(int Id);
        Task UpdateName(int Id, string name);
        Task UpdateEmail(int Id, string email);
        Task UpdatePassword(int Id, string password);
    }
}