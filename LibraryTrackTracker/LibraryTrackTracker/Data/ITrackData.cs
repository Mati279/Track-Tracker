using DataLibrary.Db;
using DataLibrary.Models;

namespace DataLibrary.Data
{
    public interface ITrackData
    {
        ConnectionStringData _connectionString { get; }

        Task<List<T>> GetAll<T>() where T : class;
        Task<T> GetById<T>(int id) where T : class;
        Task<int> Create(object model);
        Task Delete(int Id);
        Task UpdateName(int Id, string name);
        Task UpdateTrack(int id, string name, string link, int userId,  int ArtistId, int GenreId, int StyleId);
        Task UpdateLink(int id, string link);
    }
}