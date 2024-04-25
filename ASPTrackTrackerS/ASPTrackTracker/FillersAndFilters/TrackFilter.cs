using DataLibrary.Data;
using DataLibrary.Models;

namespace ASPTrackTracker.FillersAndFilters
{
    public class TrackFilter
    {
        private readonly ITrackData trackData;

        public TrackFilter(ITrackData trackData)
        {
            this.trackData = trackData;
        }

        public async Task<List<TrackModel>> FilterTrack(int UserId, int ArtistId, int GenreId, int StyleId)
        {
            List<TrackModel> allTracks = new List<TrackModel>();
            allTracks = await trackData.GetAll<TrackModel>();


            List<TrackModel> filteredTracks = new List<TrackModel>();

            bool filtered;
            filteredTracks = new List<TrackModel>();

            foreach (TrackModel track in allTracks)
            {
                if (UserId != 0 && UserId != track.UserId)
                {
                    filtered = false;
                    continue;
                }
                else if (ArtistId != 0 && ArtistId != track.ArtistId)
                {
                    filtered = false;
                    continue;
                }
                else if (GenreId != 0 && GenreId != track.GenreId)
                {
                    filtered = false;
                    continue;
                }
                else if (StyleId != 0 && StyleId != track.StyleId)
                {
                    filtered = false;
                    continue;
                }
                else
                {
                    filtered = true;
                }

                if (filtered == true)
                {
                    filteredTracks.Add(track);
                }
            }
            return filteredTracks;
        }
    }
}
