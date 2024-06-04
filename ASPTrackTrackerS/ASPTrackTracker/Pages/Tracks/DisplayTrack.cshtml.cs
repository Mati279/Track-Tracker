using ASPTrackTracker.Auth;
using DataLibrary.Data;
using DataLibrary.Db;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPTrackTracker.Pages.Tracks
{
    public class DisplayTrackModel : AuthenticatedPageModel
    {
        public ITrackData trackData { get; }
        public IGenreData genreData { get; }
        public IStyleData styleData { get; }

        public IArtistData artistData;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        public TrackModel Track { get; set; }

        public ArtistModel Artist { get; set; }
        public GenreModel Genre { get; set; }
        public StyleModel Style { get; set; }

        public DisplayTrackModel(ITrackData _trackData, IArtistData _artistData, IGenreData _genreData, IStyleData _styleData)
        {
            trackData = _trackData;
            artistData = _artistData;
            genreData = _genreData;
            styleData = _styleData;
        }
        public async Task OnGet()
        {
            Track = await trackData.GetById<TrackModel>(Id);

            if (Track != null)
            {
                Artist = await artistData.GetById<ArtistModel>(Track.ArtistId);
                Genre = await genreData.GetById<GenreModel>(Track.GenreId);
                Style = await styleData.GetById<StyleModel>(Track.StyleId);
            }
        }
    }
}
