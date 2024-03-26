using DataLibrary.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public class ScoreData : DataManager, IScoreData
    {
        protected override string spAll_Name => "spScores_All";
        protected override string spGetById_Name => "spScores_GetById";
        protected override string spInsert_Name => "spScores_Insert";
        protected override string spDelete_Name => "spScores_Delete";

        private readonly IDataAccess _dataAccess;
        public ConnectionStringData _connectionString { get; }

        public ScoreData(IDataAccess dataAccess, ConnectionStringData connectionString) : base(dataAccess, connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        //Métodos de acceso a datos propios.

        public async Task UpdateValue(int Id, double value)
        {
            await _dataAccess.SaveData("spScores_UpdateValue", new { @Id = Id, @Value = value }, _connectionString.sqlConnectionName);
        }

    }
}
