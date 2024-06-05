using ASPTrackTracker.Auth;
using ASPTrackTracker.Comparers;
using ASPTrackTracker.FillersAndFilters;
using ASPTrackTracker.ScoreHelpers;
using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace ASPTrackTracker.Pages.Tracks
{
    [Authorize]
    public class TracksDBModel : AuthenticatedPageModel
    {
        private readonly ScoresManager scoresManager;
        private readonly TrackFilter tracksFilter;
        private readonly SelectListsFiller selectListConfig;
        private readonly ComparablesCreator comparableTrackCreator;
        private readonly ScoresSorter scoreSorter;
        private readonly IUserData userData;
        private readonly IArtistData artistData;
        private readonly IGenreData genreData;
        private readonly IStyleData styleData;
        private readonly ITrackData trackData;

        public List<SelectListItem> UserItems { get; set; }
        public List<SelectListItem> ArtistItems { get; set; }
        public List<SelectListItem> StyleItems { get; set; }
        public List<SelectListItem> GenreItems { get; set; }
        public List<SelectListItem> StatItems { get; set; }
        public List<TrackModel> allTracks { get; set; }

        public List<TrackModel> filteredTracks { get; set; }

        public List<ComparableTrack> comparableTracks { get; set; }

        [BindProperty(SupportsGet = true)]
        public int UserId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int ArtistId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int GenreId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int StyleId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SelectedStat { get; set; } = "Average";

        [BindProperty]
        public string FilterPrompt { get; set; }



        public TracksDBModel(ScoresManager scoresManager, TrackFilter tracksFilter, SelectListsFiller selectListConfig, ComparablesCreator comparableTrackCreator, ScoresSorter scoreSorter,
                            IArtistData artistData, IGenreData genreData, IStyleData styleData, IUserData userData, ITrackData trackData)
        {
            this.scoresManager = scoresManager;
            this.tracksFilter = tracksFilter;
            this.selectListConfig = selectListConfig;
            this.comparableTrackCreator = comparableTrackCreator;
            this.scoreSorter = scoreSorter;
            this.userData = userData;
            this.trackData = trackData;
            this.artistData = artistData;
            this.genreData = genreData;
            this.styleData = styleData;
        }
        public async Task OnGetAsync()
        {
            List<UserModel> users = await userData.GetAll<UserModel>();
            List<ArtistModel> artists = await artistData.GetAll<ArtistModel>();
            List<GenreModel> genres = await genreData.GetAll<GenreModel>();
            List<StyleModel> styles = await styleData.GetAll<StyleModel>();

            UserItems = new List<SelectListItem>();
            ArtistItems = new List<SelectListItem>();
            GenreItems = new List<SelectListItem>();
            StyleItems = new List<SelectListItem>();
            StatItems = new List<SelectListItem>();

            selectListConfig.FillSelectTrackHolder(UserItems, users);
            selectListConfig.FillSelectTrackHolder(ArtistItems, artists);
            selectListConfig.FillSelectTrackHolder(GenreItems, genres);
            selectListConfig.FillSelectTrackHolder(StyleItems, styles);

            selectListConfig.FillSelectStats(StatItems);

            filteredTracks = await tracksFilter.FilterTracks(UserId, ArtistId, GenreId, StyleId);
            comparableTracks = await comparableTrackCreator.CreateComparableTracks(filteredTracks);

            scoreSorter.SortComparable(comparableTracks, SelectedStat);

            FormatFilterPrompt();
        }

        private void FormatFilterPrompt()
        {
            FilterPrompt = "Rating based on " + SelectedStat + " scores.";
        }

        public async Task<int> GetModel(ComparableTrack comparableTrack)
        {
            var Track = await trackData.GetById<TrackModel>(comparableTrack.ModelId);

            return Track.Id;
        }

        public async Task<bool> CheckIfUserVotedTrack(int trackId)
        {
            TrackModel Track = await trackData.GetById<TrackModel>(trackId);

            return await scoresManager.CheckIfUserVotedTrack(Track, base.UserId); //Hardcoded - user.
        }

        public double GetQueryAverage()
        {
            double value = 0;
            int count = 0;

            foreach(ComparableTrack track in comparableTracks)
            {
                if(track.GetScoreByStat(SelectedStat) > 0)
                {
                    value += track.GetScoreByStat(SelectedStat);
                    count++;
                }
            }
            return Math.Round(value / count, 1);
        }







        //public async Task GetRandomScores(TrackModel track)
        //{
        //    var affinity = new ScoreModel();
        //    affinity.Stat = "Affinity";
        //    affinity.UserId = 1;
        //    affinity.Value = RndmScore();
        //    affinity.TrackId = track.Id;

        //    await ScoreData.Create(affinity);

        //    var Voices = new ScoreModel();
        //    Voices.Stat = "Voices";
        //    Voices.UserId = 1;
        //    Voices.Value = RndmScore();
        //    Voices.TrackId = track.Id;

        //    await ScoreData.Create(Voices);

        //    var Complexity = new ScoreModel();
        //    Complexity.Stat = "Complexity";
        //    Complexity.UserId = 1;
        //    Complexity.Value = RndmScore();
        //    Complexity.TrackId = track.Id;

        //    await ScoreData.Create(Complexity);

        //    var Creativity = new ScoreModel();
        //    Creativity.Stat = "Creativity";
        //    Creativity.UserId = 1;
        //    Creativity.Value = RndmScore();
        //    Creativity.TrackId = track.Id;

        //    await ScoreData.Create(Creativity);

        //    var Instrumental = new ScoreModel();
        //    Instrumental.Stat = "Instrumental";
        //    Instrumental.UserId = 1;
        //    Instrumental.Value = RndmScore();
        //    Instrumental.TrackId = track.Id;

        //    await ScoreData.Create(Instrumental);

        //    var Lyrics = new ScoreModel();
        //    Lyrics.Stat = "Lyrics";
        //    Lyrics.UserId = 1;
        //    Lyrics.Value = RndmScore();
        //    Lyrics.TrackId = track.Id;

        //    await ScoreData.Create(Lyrics);

        //    double RndmScore()
        //    {
        //        Random rnd = new Random();
        //        var rnd2 = rnd.Next(1, 5);

        //        return 5 + rnd2;
        //    }
        //}
        //public async Task OnPostRateAll()
        //{
        //    var allTracks = await trackData.GetAll<TrackModel>();
        //    foreach(var track in allTracks)
        //    {
        //        bool voted = await AlreadyVoted(1, track);
        //        if (!voted)
        //        {
        //            await GetRandomScores(track);
        //        }

        //    }

        //} 

    }
}
