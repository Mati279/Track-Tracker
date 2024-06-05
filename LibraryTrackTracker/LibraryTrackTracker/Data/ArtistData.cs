using DataLibrary.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public class ArtistData : DataManager, IArtistData
    {
        protected override string spAll_Name { get; set; } = "spArtists_All";
        protected override string spGetById_Name { get; set; } = "spArtists_GetById";
        protected override string spInsert_Name { get; set; } = "spArtists_Insert";
        protected override string spDelete_Name { get; set; } = "spArtists_Delete";
        protected override string spUpdateName_Name { get; set; } = "spArtists_UpdateName";

        private readonly IDataAccess _dataAccess;
        public ConnectionStringData _connectionString { get; }

        public ArtistData(IDataAccess dataAccess, ConnectionStringData connectionString) : base(dataAccess, connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public async Task UpdateGenre(int Id, int genreId)
        {
            await _dataAccess.SaveData("spArtists_updateGenre", new { @Id = Id, @GenreId = genreId }, _connectionString.sqlConnectionName);
        }
    }
}
