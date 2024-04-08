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
        protected override string spAll_Name { get; set; } = "spGenres_All";
        protected override string spGetById_Name { get; set; } = "spGenres_GetById";
        protected override string spInsert_Name { get; set; } = "spGenres_Insert";
        protected override string spDelete_Name { get; set; } = "spGenres_Delete";
        protected override string spUpdateName_Name { get; set; } = "spGenres_UpdateName";


        private readonly IDataAccess _dataAccess;
        public ConnectionStringData _connectionString { get; }

        public GenreData(IDataAccess dataAccess, ConnectionStringData connectionString) : base(dataAccess, connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }


    }
}
