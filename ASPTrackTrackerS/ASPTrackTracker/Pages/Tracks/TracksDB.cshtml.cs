using ASPTrackTracker.Comparers;
using ASPTrackTracker.FillersAndFilters;
using DataLibrary.BL;
using DataLibrary.Data;
using DataLibrary.Db;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using static System.Formats.Asn1.AsnWriter;

namespace ASPTrackTracker.Pages.Tracks
{
    public class TracksDBModel : PageModel
    {
        private readonly TracksFilter tracksFilter;
        private readonly SelectListsFiller selectListConfig;
        private readonly ComparableTrackCreator comparableTrackCreator;
        private readonly IUserData userData;
        private readonly IArtistData artistData;
        private readonly IGenreData genreData;
        private readonly IStyleData styleData;
        private readonly IScoreData scoreData;
        public List<SelectListItem> UserItems { get; set; }
        public List<SelectListItem> ArtistItems { get; set; }
        public List<SelectListItem> StyleItems { get; set; }
        public List<SelectListItem> GenreItems { get; set; }
        public List<SelectListItem> StatItems { get; set; }

        public List<TrackModel> allTracks { get; set; }

        [BindProperty]
        public List<TrackModel> filteredTracks { get; set; }

        [BindProperty]
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

        public TracksDBModel(TracksFilter tracksFilter, SelectListsFiller selectListConfig, ComparableTrackCreator comparableTrackCreator,
                            IArtistData artistData, IGenreData genreData, IStyleData styleData, IUserData userData, IScoreData scoreData)
        {
            this.tracksFilter = tracksFilter;
            this.selectListConfig = selectListConfig;
            this.comparableTrackCreator = comparableTrackCreator;
            this.userData = userData;
            this.scoreData = scoreData;
            this.artistData = artistData;
            this.genreData = genreData;
            this.styleData = styleData;
        }
        public async Task OnGet()
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
        }

        public async Task<IActionResult> OnPost()
        {

            var selects = new {UserId, SelectedStat, StyleId, GenreId, ArtistId};

            return RedirectToPage(selects);
        }
        public async Task<IActionResult> OnPostReset()
        {

            var selects = new { UserId = 0, StatSelected = "Average", StyleId = 0, GenreId = 0, ArtistId = 0 };

            return RedirectToPage(selects);
        }

        public void OrderTracks(string stat)
        {
            switch (stat)
            {
                case "Average":
                    comparableTracks.Sort(new AverageComparer());
                    break;
                case "Affinity":
                    comparableTracks.Sort(new AffinityComparer());
                    break;
                case "Creativity":
                    comparableTracks.Sort(new CreativityComparer());
                    break;
                case "Complexity":
                    comparableTracks.Sort(new ComplexityComparer());
                    break;
                case "Voices":
                    comparableTracks.Sort(new VoicesComparer());
                    break;
                case "Lyrics":
                    comparableTracks.Sort(new LyricsComparer());
                    break;
                case "Instrumental":
                    comparableTracks.Sort(new InstrumentalComparer());
                    break;
                default:
                    throw new InvalidOperationException("Unhandled exception");
            }
        }

        public async Task<List<ScoreModel>> GetTrackScores(TrackModel track)
        {
            List<ScoreModel> allScores = await scoreData.GetAll<ScoreModel>();

            List<ScoreModel> trackScores = new List<ScoreModel>();

            foreach (ScoreModel score in allScores)
            {
                if (score.TrackId == track.Id)
                {
                    trackScores.Add(score);
                }
            }

            return trackScores;
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
