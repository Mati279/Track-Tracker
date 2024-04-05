using DataLibrary.BL;
using DataLibrary.Data;
using DataLibrary.Db;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public List<TrackModel> filteredTracks { get; set; }

        public int UserID { get; set; }
        public int ArtistID { get; set; }
        public int GenreID { get; set; }
        public int StyleID { get; set; }
        public int StatID { get; set; }

        public TracksDBModel(ITrackData trackData, IArtistData artistData, IGenreData genreData, IStyleData styleData, IUserData userData)
        {
            this.trackData = trackData;
            this.artistData = artistData;
            this.genreData = genreData;
            this.styleData = styleData;
            this.userData = userData;
        }
        public async Task OnGet()
        {
            allTracks = await trackData.GetAll<TrackModel>();
            

            UserItems = new List<SelectListItem>();
            ArtistItems = new List<SelectListItem>();
            GenreItems = new List<SelectListItem>();
            StyleItems = new List<SelectListItem>();
            StatItems = new List<SelectListItem>();


            List<UserModel> users = await userData.GetAll<UserModel>();
            List<ArtistModel> artists = await artistData.GetAll<ArtistModel>();
            List<GenreModel> genres = await genreData.GetAll<GenreModel>();
            List<StyleModel> styles = await styleData.GetAll<StyleModel>();

           

            await FillSelect(UserItems, users);
            await FillSelect(ArtistItems, artists);
            await FillSelect(GenreItems, genres);
            await FillSelect(StyleItems, styles);


            StatItems.Insert(0, new SelectListItem { Value = "All", Text = "All" });
            StatItems.Insert(1, new SelectListItem { Value = "Affinity", Text = "Affinity" });
            StatItems.Insert(2, new SelectListItem { Value = "Creativity", Text = "Creativity" });
            StatItems.Insert(3, new SelectListItem { Value = "Complexity", Text = "Complexity" });
            StatItems.Insert(4, new SelectListItem { Value = "Lyrics", Text = "Lyrics" });
            StatItems.Insert(5, new SelectListItem { Value = "Voice", Text = "Voice" });
            StatItems.Insert(6, new SelectListItem { Value = "Instrumental", Text = "Instrumental" });
        }


        private async Task FillSelect<T>(List<SelectListItem> selectList, List<T> lista) where T : ITrackHolderModel
        {
                selectList.Insert(0, new SelectListItem { Value = "All", Text = "All" });
            foreach (var i in lista)
            {
                var item = new SelectListItem { Value = i.Id.ToString(), Text = i.Name };
                selectList.Add(item);
                await Console.Out.WriteLineAsync(item.Text + " agregada.");
            }
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

    }
}
