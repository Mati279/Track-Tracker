using Dapper;
using DataLibrary.BL;
using DataLibrary.Db;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public class DataManager : IDataManager
    {
        protected virtual string spAll_Name => "";
        protected virtual string spGetById_Name => "";
        protected virtual string spInsert_Name => "";
        protected virtual string spDelete_Name => "";
        protected virtual string spUpdateName_Name => "";

        private readonly IDataAccess _dataAccess;
        private readonly ConnectionStringData _connectionString;

        public DataManager(IDataAccess dataAccess, ConnectionStringData connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        public async Task<List<T>> GetAll<T>() where T : class
        {
            return await _dataAccess.LoadData<T, dynamic>(this.spAll_Name, new { },
                                                                       _connectionString.sqlConnectionName);
        }

        public async Task<T> GetById<T>(int id) where T : class
        {
            var recs = await _dataAccess.LoadData<T, dynamic>(this.spGetById_Name, new { @Id = id },
                                                                       _connectionString.sqlConnectionName);

            return recs.FirstOrDefault();
        }

        public async Task<int> Create(object model)
        {
            var p = new DynamicParameters();
            p.AddDynamicParams(model);
            p.Add("@Id", DbType.Int32, direction: ParameterDirection.Output);

            await _dataAccess.SaveData(this.spInsert_Name, p, _connectionString.sqlConnectionName);

            return p.Get<int>("@Id");
        }

        public async Task Delete(int Id)
        {
            await _dataAccess.SaveData(this.spDelete_Name, new { @Id = Id}, _connectionString.sqlConnectionName);
        }

        public async Task UpdateName(int Id, string name)
        {
            await _dataAccess.SaveData(this.spUpdateName_Name, new { @Id = Id, @Name = name }, _connectionString.sqlConnectionName);
        }
    }

}
