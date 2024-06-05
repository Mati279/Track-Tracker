using DataLibrary.Db;

namespace DataLibrary.Data
{
    public interface IArtistData
    {
        ConnectionStringData _connectionString { get; }

        Task<List<T>> GetAll<T>() where T : class;
        Task<T> GetById<T>(int id) where T : class;
        Task<int> Create(object model);
        Task Delete(int Id);
        Task UpdateName(int Id, string name);
        Task UpdateGenre(int Id, int genreId);
    }
}