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
        protected override string spAll_Name => "spArtists_All";
        protected override string spGetById_Name => "spArtists_GetById";
        protected override string spInsert_Name => "spArtists_Insert";
        protected override string spDelete_Name => "spArtists_Delete";

        private readonly IDataAccess _dataAccess;
        public ConnectionStringData _connectionString { get; }

        public ArtistData(IDataAccess dataAccess, ConnectionStringData connectionString) : base(dataAccess, connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }
    }
}
