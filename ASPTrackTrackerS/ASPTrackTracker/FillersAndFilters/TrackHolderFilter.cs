using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.IdentityModel.Tokens;

namespace ASPTrackTracker.FillersAndFilters
{
    public class TrackHolderFilter
    {
        private readonly IArtistData artistData;
        private readonly TrackFilter trackFilter;
        private List<TrackModel> filteredTracks;

        public TrackHolderFilter(IArtistData artistData, TrackFilter trackFilter)
        {
            this.artistData = artistData;
            this.trackFilter = trackFilter;
        }
        
        public async Task<List<ArtistModel>> FilterArtists(int GenreId, int StyleId)
        {
            List<ArtistModel> allArtists = new List<ArtistModel>();
            allArtists = await artistData.GetAll<ArtistModel>();

            List<ArtistModel> filteredArtists = new List<ArtistModel>();
            filteredArtists = new List<ArtistModel>();

            bool filtered;

            foreach (ArtistModel artist in allArtists)
            {
                if (GenreId != 0 && GenreId != artist.GenreId)
                {
                    filtered = false;
                    continue;
                }
                else if (StyleId != 0 && await CheckIfArtistHasStyle(artist.Id, StyleId))
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
                    filteredArtists.Add(artist);
                }
            }
            return filteredArtists;
        }

        private async Task<bool> CheckIfArtistHasStyle(int ArtistId, int StyleId)
        {
            var artist = await artistData.GetById<ArtistModel>(ArtistId);

            List<TrackModel> artistTracks = await trackFilter.FilterTracks(0, ArtistId, 0, 0); 

            if(artistTracks.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
