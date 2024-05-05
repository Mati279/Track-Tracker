using ASPTrackTracker.ScoreHelpers;
using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection.Metadata.Ecma335;

namespace ASPTrackTracker.Pages.Views
{
    public class TrackViewModel : PageModel
    {
        private readonly ScoresManager scoresManager;
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


        public TrackModel Track {  get; set; }

        public UserModel User {  get; set; }

        public ArtistModel Artist {  get; set; }

        public GenreModel Genre {  get; set; }

        public StyleModel Style {  get; set; }

        public double AverageScore { get; set; }
        public double AffinityScore { get; set; }
        public double ComplexityScore { get; set; }
        public double CreativityScore { get; set; }
        public double VoicesScore { get; set; }
        public double LyricsScore { get; set; }
        public double InstrumentalScore { get; set; }
        List<ScoreModel> TrackScores { get; set; }
        

        public TrackViewModel(ScoresManager scoresManager, ITrackData trackData, IUserData userData, IArtistData artistData, IGenreData genreData, IStyleData styleData, IScoreData scoreData)
        {
            this.scoresManager = scoresManager;
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
            User = await userData.GetById<UserModel>(Track.UserId);
            Artist = await artistData.GetById<ArtistModel>(Track.ArtistId);
            Genre = await genreData.GetById<GenreModel>(Track.GenreId);
            Style = await styleData.GetById<StyleModel>(Track.StyleId);

            TrackScores = await scoresManager.GetTrackScores(Track);

            AverageScore = GetAverage();
            AffinityScore = GetTrackScoreByStat("Affinity");
            ComplexityScore = GetTrackScoreByStat("Complexity");
            CreativityScore = GetTrackScoreByStat("Creativity");
            VoicesScore = GetTrackScoreByStat("Voices");
            LyricsScore = GetTrackScoreByStat("Lyrics");
            InstrumentalScore = GetTrackScoreByStat("Instrumental");

        }

        public async Task OnPost()
        {

        }

        private double GetTrackScoreByStat(string Stat)
        {
            foreach(ScoreModel score in  TrackScores)
            {
                if(score.Stat == Stat)
                {
                    return score.Value;
                }
            }
                    return 0;
        }

        private double GetAverage()
        {
            int count = 0;
            double values = 0;

            foreach (ScoreModel score in TrackScores)
            {
                if (score.Value != 0)
                {
                    values += score.Value;
                    count++;
                }
            }
            double average = values / count;

            return  Math.Round(average, 2);
        }

        public string ReturnScoreOrDashes(double score)
        {
            if(score == 0)
            {
                return "- -";
            }
            else
            {
                return score.ToString();
            }
        }
    }
}
