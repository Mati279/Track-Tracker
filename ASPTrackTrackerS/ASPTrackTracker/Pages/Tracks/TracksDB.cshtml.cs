using DataLibrary.BL;
using DataLibrary.Data;
using DataLibrary.Db;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
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
        public string StatSelected{ get; set; }


        public TracksDBModel(ITrackData trackData, IArtistData artistData, IGenreData genreData, IStyleData styleData, IUserData userData)
        {
            this.trackData = trackData;
            this.userData = userData;
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

            var selects = new { UserId = 0, StatSelected = 0, StyleId = 0, GenreId = 0, ArtistId = 0 };

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
            StatItems.Insert(0, new SelectListItem { Value = "All", Text = "All" });
            StatItems.Insert(1, new SelectListItem { Value = "Affinity", Text = "Affinity" });
            StatItems.Insert(2, new SelectListItem { Value = "Creativity", Text = "Creativity" });
            StatItems.Insert(3, new SelectListItem { Value = "Complexity", Text = "Complexity" });
            StatItems.Insert(4, new SelectListItem { Value = "Lyrics", Text = "Lyrics" });
            StatItems.Insert(5, new SelectListItem { Value = "Voice", Text = "Voice" });
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
    }
}
