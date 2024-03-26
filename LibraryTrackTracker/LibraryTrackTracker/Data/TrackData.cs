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
    public class TrackData : DataManager, ITrackData
    {
        protected override string spAll_Name => "spTracks_All";
        protected override string spGetById_Name => "spTracks_GetById";
        protected override string spInsert_Name => "spTracks_Insert";
        protected override string spDelete_Name => "spTracks_Delete";
        protected override string spUpdateName_Name => "spTracks_UpdateName";

        private readonly IDataAccess _dataAccess;
        public ConnectionStringData _connectionString { get; }

        public TrackData(IDataAccess dataAccess, ConnectionStringData connectionString) : base(dataAccess, connectionString)
        {
            _dataAccess = dataAccess;
            _connectionString = connectionString;
        }

        //Métodos de acceso a datos propios.
        public async Task UpdateLink(int id, string link)
        {
            await _dataAccess.SaveData("spTracks_UpdateLink", new { @Id = id, @Link = link }, _connectionString.sqlConnectionName);
        }

        public async Task UpdateTrack(int id, string name, string link, int userId, int ArtistId, int GenreId, int StyleId) 
        {
   
            await _dataAccess.SaveData("spTracks_Update", new { @Id = id, @Name = name, @Link = link, 
                                                                @UserId = userId, @ArtistId = ArtistId,
                                                                 @GenreId = GenreId, @StyleId = StyleId}, _connectionString.sqlConnectionName);
        }

        public async Task<List<TrackModel>> GetTracksBy<T>(ITrackHolderModel trackHolder) where T : class
        {
            string storedProcedure = "";
            switch (trackHolder)
            {
                case UserModel userModel:
                    storedProcedure = "spTracks_GetByUser";
                    break;
                case ArtistModel artistModel:
                    storedProcedure = "spTracks_GetByArtist";
                    break;
                case GenreModel genreModel:
                    storedProcedure = "spTracks_GetByGenre";
                    break;
                case StyleModel styleModel:
                    storedProcedure = "spTracks_GetByStyle";
                    break;
                default: throw new NotImplementedException();
            }

            return await _dataAccess.LoadData<TrackModel, dynamic>(storedProcedure, new { trackHolder.Id },
                                                                       _connectionString.sqlConnectionName);
        }
    }
}
