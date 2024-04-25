using DataLibrary.Data;
using DataLibrary.Models;

namespace ASPTrackTracker.FillersAndFilters
{
    public class TrackHolderFilter
    {
        private readonly IArtistData artistData;

        public TrackHolderFilter(IArtistData artistData)
        {
            this.artistData = artistData;
        }



        public async Task<List<TrackModel>> FilterArtists(int UserId, int StyleId)
        {
            List<ArtistModel> allArtists = new List<ArtistModel>();
            allArtists = await artistData.GetAll<ArtistModel>();


            List<ArtistModel> filteredArtists = new List<ArtistModel>();

            bool filtered;
            filteredArtists = new List<ArtistModel>();

            foreach (ArtistModel artist in allArtists)
            {
                //Acá.


                if (UserId != 0 && UserId != artist.UserId)
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
