using DataLibrary.Data;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BL
{
    public abstract class TrackHolderBase : ITrackHolder
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private ITrackData trackData;
        public TrackHolderBase(ITrackData _trackData, int _id, string _name)
        {
            trackData = _trackData;
            Id = _id;
            Name = _name;
        }

        public async Task<List<TrackModel>> FilterTracks(ITrackHolder _trackHolder) //MEJORABLE - DRY.
        {
            var allTracks = await GetTracks();

            var filteredList = new List<TrackModel>();

            switch (_trackHolder)
            {
                case User:
                    foreach (var track in allTracks)
                    {
                        if (track.UserId == Id)
                        {
                            filteredList.Add(track);
                        }
                    }
                    return filteredList;
                case Artist:
                    foreach (var track in allTracks)
                    {
                        if (track.ArtistId == Id)
                        {
                            filteredList.Add(track);
                        }
                    }
                    return filteredList;
                case Genre:
                    foreach (var track in allTracks)
                    {
                        if (track.GenreId == Id)
                        {
                            filteredList.Add(track);
                        }
                    }
                    return filteredList;
                case Style:
                    foreach (var track in allTracks)
                    {
                        if (track.StyleId == Id)
                        {
                            filteredList.Add(track);
                        }
                    }
                    return filteredList;
                default:
                    throw new NotImplementedException();
            }
        }

        public async Task<List<TrackModel>> GetTracks() //MEJORABLE - DRY.
        {
            var allTracks = await trackData.GetAll<TrackModel>();

            var filteredList = new List<TrackModel>();

            switch (this)
            {
                case User:
                    foreach (var track in allTracks)
                    {
                        if (track.UserId == Id)
                        {
                            filteredList.Add(track);
                        }
                    }
                    return filteredList;
                case Artist:
                    foreach (var track in allTracks)
                    {
                        if (track.ArtistId == Id)
                        {
                            filteredList.Add(track);
                        }
                    }
                    return filteredList;
                case Genre:
                    foreach (var track in allTracks)
                    {
                        if (track.GenreId == Id)
                        {
                            filteredList.Add(track);
                        }
                    }
                    return filteredList;
                case Style:
                    foreach (var track in allTracks)
                    {
                        if (track.StyleId == Id)
                        {
                            filteredList.Add(track);
                        }
                    }
                    return filteredList;
                default:
                    throw new NotImplementedException();
            } 
        }
    }
}
