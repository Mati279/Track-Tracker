using ASPTrackTracker.FillersAndFilters;
using ASPTrackTracker.ScoreHelpers;
using DataLibrary.BL;
using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata.Ecma335;

namespace ASPTrackTracker.Pages.Stats
{
    public class TrackStatsModel : PageModel
    {
        private readonly ScoresManager scoresManager;
        private readonly SelectListsFiller selectListFilter;
        private readonly ITrackData trackData;
        private readonly IUserData userData;
        private readonly IArtistData artistData;
        private readonly IGenreData genreData;
        private readonly IStyleData styleData;
        private readonly IScoreData scoreData;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty(SupportsGet = true)]
        public int ScoresUserId { get; set; } 
        public List<SelectListItem> UsersSelectList { get; set; }
        private List<UserModel> AllUsers {  get; set; }
        public TrackModel Track {  get; set; } 
        public UserModel User {  get; set; }
        public UserModel ScoresUser {  get; set; }
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
        public string ScoresPrompt { get; set; }

        public TrackStatsModel(ScoresManager scoresManager, SelectListsFiller selectListFilter, ITrackData trackData, IUserData userData, IArtistData artistData, IGenreData genreData, IStyleData styleData, IScoreData scoreData)
        {
            this.scoresManager = scoresManager;
            this.selectListFilter = selectListFilter;
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
            ScoresUser = await userData.GetById<UserModel>(ScoresUserId);
            User = await userData.GetById<UserModel>(Track.UserId);
            Artist = await artistData.GetById<ArtistModel>(Track.ArtistId);
            Genre = await genreData.GetById<GenreModel>(Track.GenreId);
            Style = await styleData.GetById<StyleModel>(Track.StyleId);

            TrackScores = await scoresManager.GetTrackScores(Track);

            AllUsers = await userData.GetAll<UserModel>();

            UsersSelectList = new List<SelectListItem>();

            selectListFilter.FillSelectTrackHolder(UsersSelectList, AllUsers);


            AverageScore = GetAverage();
            AffinityScore = GetTrackScoreByStat("Affinity");
            ComplexityScore = GetTrackScoreByStat("Complexity");
            CreativityScore = GetTrackScoreByStat("Creativity");
            VoicesScore = GetTrackScoreByStat("Voices");
            LyricsScore = GetTrackScoreByStat("Lyrics");
            InstrumentalScore = GetTrackScoreByStat("Instrumental");
        }

        private List<ScoreModel> GetScoresFromSelectedUser()
        {
            List<ScoreModel> userScores = new List<ScoreModel>();

            foreach(ScoreModel score in TrackScores)
            {
                if(score.UserId == ScoresUserId || ScoresUserId == 0)
                {
                    userScores.Add(score);
                }
            }

            return userScores;
        }

        private double GetTrackScoreByStat(string Stat)
        {

            foreach(ScoreModel score in GetScoresFromSelectedUser())
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

            foreach (ScoreModel score in GetScoresFromSelectedUser())
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

        public string ReturnScoreOrDash(double score)
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

        public async Task<bool> CheckIfUserVotedTrack(TrackModel track, int userId)
        {
           return await scoresManager.CheckIfUserVotedTrack(track, userId);
        }
    }
}
