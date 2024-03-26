using DataLibrary.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public class GenreData : DataManager, IGenreData
    {
        protected override string spAll_Name => "spGenres_All";
        protected override string spGetById_Name => "spGenres_GetById";
        protected override string spInsert_Name => "spGenres_Insert";
        protected override string spDelete_Name => "spGenres_Delete";

        private readonly IDataAccess _dataAccess;
        public ConnectionStringData _connectionString { get; }

        public GenreData(IDataAccess dataAccess, ConnectionStringData connectionString) : base(dataAccess, connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }


    }
}
