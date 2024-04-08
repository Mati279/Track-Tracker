using DataLibrary.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public class StyleData : DataManager, IStyleData
    {
        protected override string spAll_Name { get; set; } = "spStyles_All";
        protected override string spGetById_Name { get; set; } = "spStyles_GetById";
        protected override string spInsert_Name { get; set; } = "spStyles_Insert";
        protected override string spDelete_Name { get; set; } = "spStyles_Delete";
        protected override string spUpdateName_Name { get; set; } = "spStyles_UpdateName";

        private readonly IDataAccess _dataAccess;
        public ConnectionStringData _connectionString { get; }

        public StyleData(IDataAccess dataAccess, ConnectionStringData connectionString) : base(dataAccess, connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }
    }
}
