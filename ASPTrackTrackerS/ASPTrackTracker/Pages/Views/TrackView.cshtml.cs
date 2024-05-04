using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata.Ecma335;

namespace ASPTrackTracker.Pages.Views
{
    public class TrackViewModel : PageModel
    {
        private readonly ITrackData trackData;
        private readonly IUserData userData;
        private readonly IArtistData artistData;
        private readonly IGenreData genreData;
        private readonly IStyleData styleData;
        private readonly IScoreData scoreData;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public string TrackUser { get; set; }
        public string TrackArtist { get; set; }
        public string TrackGenre { get; set; }
        public string TrackStyle { get; set; }

        public double AverageScore { get; set; }
        public double AffinityScore { get; set; }
        public double ComplexityScore { get; set; }
        public double CreativityScore { get; set; }
        public double VoicesScore { get; set; }
        public double LyricsScore { get; set; }
        public double InstrumentalScore { get; set; }

        public TrackModel Track {  get; set; }

        public TrackViewModel(ITrackData trackData, IUserData userData, IArtistData artistData, IGenreData genreData, IStyleData styleData, IScoreData scoreData)
        {
            this.trackData = trackData;
            this.userData = userData;
            this.artistData = artistData;
            this.genreData = genreData;
            this.styleData = styleData;
            this.scoreData = scoreData;
        }
        public async Task OnGet()
        {
            Track = await trackData.GetById<TrackModel>(Id);
            
        }

        public async Task OnPost()
        {

        }
    }
}
