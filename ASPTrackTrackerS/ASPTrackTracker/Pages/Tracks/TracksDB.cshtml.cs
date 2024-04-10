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
        private readonly IUserData userData;
        private readonly ITrackData trackData;
        private readonly IArtistData artistData;
        private readonly IGenreData genreData;
        private readonly IStyleData styleData;
        private readonly IScoreData ScoreData;
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

        public TracksDBModel(ITrackData trackData, IArtistData artistData, IGenreData genreData, IStyleData styleData, IUserData userData, IScoreData scoreData)
        {
            this.trackData = trackData;
            this.userData = userData;
            ScoreData = scoreData;
            this.artistData = artistData;
            this.genreData = genreData;
            this.styleData = styleData;
        }
        public async Task OnGet()
        {
            allTracks = await trackData.GetAll<TrackModel>();

            List<UserModel> users = await userData.GetAll<UserModel>();
            List<ArtistModel> artists = await artistData.GetAll<ArtistModel>();
            List<GenreModel> genres = await genreData.GetAll<GenreModel>();
            List<StyleModel> styles = await styleData.GetAll<StyleModel>();

            UserItems = new List<SelectListItem>();
            ArtistItems = new List<SelectListItem>();
            GenreItems = new List<SelectListItem>();
            StyleItems = new List<SelectListItem>();
            StatItems = new List<SelectListItem>();

            await FillSelectTrackHolder(UserItems, users);
            await FillSelectTrackHolder(ArtistItems, artists);
            await FillSelectTrackHolder(GenreItems, genres);
            await FillSelectTrackHolder(StyleItems, styles);

            FillSelectStats(StatItems);

            await FilterTracks();
            await CreateComparables(filteredTracks);
            OrderTracks(SelectedStat);
            
        }

        public async Task<IActionResult> OnPost()
        {

            var selects = new { UserId, SelectedStat, StyleId, GenreId, ArtistId  };

            return RedirectToPage(selects);
        }
        public async Task<IActionResult> OnPostReset()
        {

            var selects = new { UserId = 0, StatSelected = "Average", StyleId = 0, GenreId = 0, ArtistId = 0 };

            return RedirectToPage(selects);
        }

        private async Task FillSelectTrackHolder<T>(List<SelectListItem> selectList, List<T> lista) where T : ITrackHolderModel
        {
            selectList.Insert(0, new SelectListItem { Value = "All", Text = "All" });
            foreach (var i in lista)
            {
                var item = new SelectListItem { Value = i.Id.ToString(), Text = i.Name };
                selectList.Add(item);
            }
        }

        private void FillSelectStats(List<SelectListItem> selectList)
        {
            StatItems.Insert(0, new SelectListItem { Value = "Average", Text = "Average" });
            StatItems.Insert(1, new SelectListItem { Value = "Affinity", Text = "Affinity" });
            StatItems.Insert(2, new SelectListItem { Value = "Creativity", Text = "Creativity" });
            StatItems.Insert(3, new SelectListItem { Value = "Complexity", Text = "Complexity" });
            StatItems.Insert(4, new SelectListItem { Value = "Lyrics", Text = "Lyrics" });
            StatItems.Insert(5, new SelectListItem { Value = "Voices", Text = "Voices" });
            StatItems.Insert(6, new SelectListItem { Value = "Instrumental", Text = "Instrumental" });
        }
        public async Task<string> GetTrackUser(TrackModel model)
        {
            var user = await userData.GetById<UserModel>(model.UserId);
            return user.Name;
        }
        public async Task<string> GetTrackArtist(TrackModel model)
        {
            var artist = await artistData.GetById<ArtistModel>(model.ArtistId);
            return artist.Name;
        }

        public async Task<string> GetTrackGenre(TrackModel model)
        {
            var genre = await genreData.GetById<GenreModel>(model.GenreId);
            return genre.Name;
        }

        public async Task<string> GetTrackStyle(TrackModel model)
        {
            var style = await styleData.GetById<StyleModel>(model.StyleId);
            return style.Name;
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
            List<TrackComparable> listTrackComparable = new List<TrackComparable>();
            trackComparables = new List<TrackComparable>();

            foreach(var track in filteredTracks)
            {
                string name = track.Name;
                string link = track.Link;
                string user = await GetTrackUser(track);
                string artist = await GetTrackArtist(track);
                string genre = await GetTrackGenre(track);
                string style = await GetTrackStyle(track);



                var trackComparable = new TrackComparable(name, link, user,artist, genre, style);

                await SetComparableScores(trackComparable, track);

                trackComparables.Add(trackComparable);
            }
        }

        private async Task SetComparableScores(TrackComparable trackComparable, TrackModel track)
        {

            double affinity = 0;
            double creativity = 0;
            double complexity = 0;
            double voices = 0;
            double lyrics = 0;
            double instrumental = 0;

            List<ScoreModel> scores = await GetTrackScores(track);
            
            foreach(ScoreModel score in scores)
            {
                switch (score.Stat)
                {
                    case "Affinity":
                        affinity = score.Value;
                        break;
                    case "Creativity":
                        creativity = score.Value;
                        break;
                    case "Complexity":
                        complexity = score.Value;
                        break;
                    case "Voices":
                        voices = score.Value;
                        break;
                    case "Lyrics":
                        lyrics = score.Value;
                        break;
                    case "Instrumental":
                        instrumental = score.Value;
                        break;
                    default:
                        throw new InvalidOperationException("Unhandled exception");
                }
            }

            trackComparable.GetScores(affinity, complexity, creativity, voices, lyrics, instrumental);
        }

        public string GetTrackComparableScoreByStat(TrackComparable trackComparable, string stat)
        {
            double score = 0;

            switch (stat)
            {
                case "Average":
                    score = trackComparable.AverageScore;
                    break;
                case "Affinity":
                    score = trackComparable.AffinityScore;
                    break;
                case "Creativity":
                    score = trackComparable.CreativityScore;
                    break;
                case "Complexity":
                    score = trackComparable.ComplexityScore;
                    break;
                case "Voices":
                    score = trackComparable.VoicesScore;
                    break;
                case "Lyrics":
                    score = trackComparable.LyricsScore;
                    break;
                case "Instrumental":
                    score = trackComparable.InstrumentalScore;
                    break;
                default:
                    throw new InvalidOperationException("Unhandled exception");
            }

            double roundedScore = Math.Round(score, 1);

            string resultString = roundedScore == 0 ? "- -" : roundedScore.ToString();
            return resultString;
        }
        public void OrderTracks(string stat)
        {
            switch (stat)
            {
                case "Average":
                    AverageComparer averageComparer = new AverageComparer();
                    trackComparables.Sort(averageComparer);
                    break;
                case "Affinity":
                    AffinityComparer affinityComparer = new AffinityComparer();
                    trackComparables.Sort(affinityComparer);
                    break;
                case "Creativity":
                    CreativityComparer creativityComparer = new CreativityComparer();
                    trackComparables.Sort(creativityComparer);
                    break;
                case "Complexity":
                    ComplexityComparer complexityComparer = new ComplexityComparer();
                    trackComparables.Sort(complexityComparer);
                    break;
                case "Voices":
                    VoicesComparer voicesComparer = new VoicesComparer();
                    trackComparables.Sort(voicesComparer);
                    break;
                case "Lyrics":
                    LyricsComparer lyricsComparer = new LyricsComparer();
                    trackComparables.Sort(lyricsComparer);
                    break;
                case "Instrumental":
                    InstrumentalComparer instrumentalComparer = new InstrumentalComparer();
                    trackComparables.Sort(instrumentalComparer);
                    break;
                default:
                    throw new InvalidOperationException("Unhandled exception");
            }
            

        }

        public async Task<List<ScoreModel>> GetTrackScores(TrackModel track)
        {
            List<ScoreModel> allScores = await ScoreData.GetAll<ScoreModel>();

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

        public async Task<double> GetTrackScoreByStat(TrackModel track, string stat)
        {
            var trackScores = await GetTrackScores(track);

            if(stat == "Average")
            {
                double value = 0;
                int count = 0;
                foreach(ScoreModel score in trackScores)
                {
                    value += score.Value;
                    count++;
                }

                double average = value / count;
                if(trackScores.Count > 0)
                {
                    return Math.Round(average, 1);
                }
                else { return 0; }
            }
            else
            {
                foreach(ScoreModel score in trackScores)
                {
                    if (score.Stat == stat)
                        return score.Value;
                }
            }
            return 0;
        }

        public async Task<bool> AlreadyVoted(int User, TrackModel track) //Hardcoded User Id. 
        {
            bool voted = false;
            var trackScores = await GetTrackScores(track);
            
            voted = !(trackScores.IsNullOrEmpty());

            return voted;
        }

        public async Task GetRandomScores(TrackModel track)
        {
            var affinity = new ScoreModel();
            affinity.Stat = "Affinity";
            affinity.UserId = 1;
            affinity.Value = RndmScore();
            affinity.TrackId = track.Id;

            await ScoreData.Create(affinity);

            var Voices = new ScoreModel();
            Voices.Stat = "Voices";
            Voices.UserId = 1;
            Voices.Value = RndmScore();
            Voices.TrackId = track.Id;

            await ScoreData.Create(Voices);

            var Complexity = new ScoreModel();
            Complexity.Stat = "Complexity";
            Complexity.UserId = 1;
            Complexity.Value = RndmScore();
            Complexity.TrackId = track.Id;

            await ScoreData.Create(Complexity);

            var Creativity = new ScoreModel();
            Creativity.Stat = "Creativity";
            Creativity.UserId = 1;
            Creativity.Value = RndmScore();
            Creativity.TrackId = track.Id;

            await ScoreData.Create(Creativity);

            var Instrumental = new ScoreModel();
            Instrumental.Stat = "Instrumental";
            Instrumental.UserId = 1;
            Instrumental.Value = RndmScore();
            Instrumental.TrackId = track.Id;

            await ScoreData.Create(Instrumental);

            var Lyrics = new ScoreModel();
            Lyrics.Stat = "Lyrics";
            Lyrics.UserId = 1;
            Lyrics.Value = RndmScore();
            Lyrics.TrackId = track.Id;

            await ScoreData.Create(Lyrics);

            double RndmScore()
            {
                Random rnd = new Random();
                var rnd2 = rnd.Next(1, 5);

                return 5 + rnd2;
            }
        }
        public async Task OnPostRateAll()
        {
            var allTracks = await trackData.GetAll<TrackModel>();
            foreach(var track in allTracks)
            {
                bool voted = await AlreadyVoted(1, track);
                if (!voted)
                {
                    await GetRandomScores(track);
                }

            }

        } 

    }
}
