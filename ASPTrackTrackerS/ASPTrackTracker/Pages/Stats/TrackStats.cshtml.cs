using ASPTrackTracker.Auth;
using ASPTrackTracker.FillersAndFilters;
using ASPTrackTracker.ScoreHelpers;
using DataLibrary.BL;
using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata.Ecma335;

namespace ASPTrackTracker.Pages.Stats
{
    [Authorize]
    public class TrackStatsModel : AuthenticatedPageModel
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
        public int UsersWhoVoted { get; set; }
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
        public async Task OnGetAsync()
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

            selectListFilter.FillSelectTrackHolder(UsersSelectList, await GetUsersWhoVotedTrack(Track));


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
            if(ScoresUserId != 0)
            {
                foreach(ScoreModel score in TrackScores)
                {
                    if(score.UserId == ScoresUserId)
                    {
                        userScores.Add(score);
                    }
                }
                return userScores;
            }
            else
            {
                return TrackScores;
            }
        }

        private double GetTrackScoreByStat(string Stat)
        {
            double value = 0;
            int count = 0;
            List<ScoreModel> userScores = GetScoresFromSelectedUser();

            foreach (ScoreModel score in userScores)
            {
                if(score.Stat == Stat)
                {
                    count++;
                    value += score.Value;
                }
            }
            return Math.Round(value / count, 1);
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

            return  Math.Round(average, 1);
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
        public bool CheckIfUserPublishedTrack(TrackModel track, int userId)
        {
            if(track.UserId == userId)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<UserModel>> GetUsersWhoVotedTrack(TrackModel track)
        {
            List<UserModel> usersVoted = new List<UserModel>();

            foreach(UserModel user in AllUsers)
            {
                if(await CheckIfUserVotedTrack(track, user.Id))
                {
                    usersVoted.Add(user);

                }
            }
            UsersWhoVoted = usersVoted.Count;
            return usersVoted;
        }
    }
}
