using ASPTrackTracker.Comparers;
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
        private readonly SelectListsConfig selectListConfig;
        private readonly IUserData userData;
        private readonly ITrackData trackData;
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
        public List<TrackComparable> trackComparables { get; set; }


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

        public TracksDBModel(SelectListsConfig selectListConfig, ITrackData trackData, IArtistData artistData, IGenreData genreData, IStyleData styleData, IUserData userData, IScoreData scoreData)
        {
            this.selectListConfig = selectListConfig;
            this.trackData = trackData;
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

            await FilterTracks();
            await CreateComparables(filteredTracks);
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

        private async Task FilterTracks()
        {
            allTracks = await trackData.GetAll<TrackModel>();

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

                if(filtered == true)
                {
                    filteredTracks.Add(track);
                }
            }
        }

        private async Task CreateComparables(List<TrackModel> filteredTracks)
        {
            trackComparables = new List<TrackComparable>();

            foreach(var track in filteredTracks)
            {

                var user = await userData.GetById<UserModel>(track.UserId);
                var artist = await artistData.GetById<ArtistModel>(track.ArtistId);
                var genre = await genreData.GetById<GenreModel>(track.GenreId);
                var style = await styleData.GetById<StyleModel>(track.StyleId);
                var scores = await scoreData.GetAll<ScoreModel>();
                var trackScores = await GetTrackScores(track);

                string name = track.Name;
                string link = track.Link;
                string userName = user.Name;
                string artistName = artist.Name;
                string genreName = genre.Name;
                string styleName = style.Name;

                var trackComparable = new TrackComparable(name, link, userName, artistName, genreName, styleName);

                trackComparable.GetScores(trackScores);

                trackComparables.Add(trackComparable);

            }
                OrderTracks(SelectedStat);
        }

        public void OrderTracks(string stat)
        {
            switch (stat)
            {
                case "Average":
                    trackComparables.Sort(new AverageComparer());
                    break;
                case "Affinity":
                    trackComparables.Sort(new AffinityComparer());
                    break;
                case "Creativity":
                    trackComparables.Sort(new CreativityComparer());
                    break;
                case "Complexity":
                    trackComparables.Sort(new ComplexityComparer());
                    break;
                case "Voices":
                    trackComparables.Sort(new VoicesComparer());
                    break;
                case "Lyrics":
                    trackComparables.Sort(new LyricsComparer());
                    break;
                case "Instrumental":
                    trackComparables.Sort(new InstrumentalComparer());
                    break;
                default:
                    throw new InvalidOperationException("Unhandled exception");
            }
        }

        public async Task<List<ScoreModel>> GetTrackScores(TrackModel track)
        {
            List<ScoreModel> allScores = await scoreData.GetAll<ScoreModel>();

            List<ScoreModel> trackScores = new List<ScoreModel>();

            foreach(ScoreModel score in allScores)
            {
                if(score.TrackId == track.Id )
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
