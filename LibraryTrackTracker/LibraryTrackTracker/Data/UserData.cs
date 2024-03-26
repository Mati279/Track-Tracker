using Dapper;
using DataLibrary.BL;
using DataLibrary.Db;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Data
{
    public class UserData : DataManager, IUserData
    {
        protected override string spAll_Name => "spUsers_All";
        protected override string spGetById_Name => "spUsers_GetById";
        protected override string spInsert_Name => "spUsers_Insert";
        protected override string spDelete_Name => "spUsers_Delete";
        protected override string spUpdateName_Name => "spUsers_UpdateName";

        private readonly IDataAccess _dataAccess;

        private readonly ITrackData _trackData;
        public ConnectionStringData _connectionString { get; }
        private List<User> allUsers = new List<User>();
        public IReadOnlyList<User> AllUsers { get => allUsers.AsReadOnly(); }

        public UserData(IDataAccess dataAccess, ConnectionStringData connectionString, ITrackData trackData) : base(dataAccess, connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
            _trackData = trackData;
        }

        //Métodos de acceso a datos propios.
        public async Task UpdateEmail(int Id, string email)
        {
            await _dataAccess.SaveData("spUsers_UpdateEmail", new { @Id = Id, @eMail = email }, _connectionString.sqlConnectionName);
        }
        public async Task UpdatePassword(int Id, string password)
        {
            await _dataAccess.SaveData("spUsers_UpdatePassword", new { @Id = Id, @Password = password }, _connectionString.sqlConnectionName);
        }

        public async Task<IReadOnlyList<User>> MappUsers()
        {
            var models = await GetAll<UserModel>();

            foreach (var model in models)
            {
                var user = new User(_trackData, model.Id, model.Name, model.eMail, model.Password);
                allUsers.Add(user);
            }
            return allUsers;
        }
    }
}
