using DataLibrary.BL;
using DataLibrary.Data;
using DataLibrary.Db;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata.Ecma335;

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

        [BindProperty(SupportsGet = true)]
        public int UserId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int ArtistId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int GenreId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int StyleId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string StatSelected { get; set; } = "Average";

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

        }

        public async Task<IActionResult> OnPost()
        {

            var selects = new { UserId, StatSelected, StyleId, GenreId, ArtistId  };

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

        public async Task<string> GetTrackScoreByStat(TrackModel track, string stat)
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
                    return Math.Round(average, 1).ToString();
                }
                else { return "Not Rated"; }
            }
            else
            {
                foreach(ScoreModel score in trackScores)
                {
                    if (score.Stat == stat)
                        return score.Value.ToString();
                }
            }
            return "0";
        }

        public async Task<bool> AlreadyVoted(int User, TrackModel track) //Hardcoded User Id. 
        {
            bool voted = false;
            var trackScores = await GetTrackScores(track);
            
            voted = !(trackScores.IsNullOrEmpty());

            return voted;
        }

        public async Task GetScores(TrackModel track)
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
                    await GetScores(track);
                }

            }

        } 

    }
}
