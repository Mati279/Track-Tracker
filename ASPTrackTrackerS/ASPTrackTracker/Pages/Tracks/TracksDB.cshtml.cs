using DataLibrary.BL;
using DataLibrary.Data;
using DataLibrary.Db;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPTrackTracker.Pages.Tracks
{
    public class TracksDBModel : PageModel
    {
        private readonly ITrackData trackData;
        private readonly IArtistData artistData;
        private readonly IGenreData genreData;
        private readonly IStyleData styleData;
        public List<SelectListItem> ArtistItems { get; set; }
        public List<SelectListItem> TrackItems { get; set; }
        public List<SelectListItem> StyleItems { get; set; }
        public List<SelectListItem> GenreItems { get; set; }

        public TracksDBModel(ITrackData trackData, IArtistData artistData, IGenreData genreData, IStyleData styleData)
        {
            this.trackData = trackData;
            this.artistData = artistData;
            this.genreData = genreData;
            this.styleData = styleData;
        }
        public async Task OnGet()
        {

            TrackItems = new List<SelectListItem>();
            ArtistItems = new List<SelectListItem>();
            GenreItems = new List<SelectListItem>();
            StyleItems = new List<SelectListItem>();

            List<TrackModel> tracks = await trackData.GetAll<TrackModel>();
            List<ArtistModel> artists = await artistData.GetAll<ArtistModel>();
            List<GenreModel> genres = await genreData.GetAll<GenreModel>();
            List<StyleModel> styles = await styleData.GetAll<StyleModel>();


            foreach (var track in tracks)
            {
                var item = new SelectListItem { Value = track.Id.ToString(), Text = track.Name };
                TrackItems.Add(item);
            }

            await FillSelect(ArtistItems, artists);
            await FillSelect(GenreItems, genres);
            await FillSelect(StyleItems, styles);
        }


        private async Task FillSelect<T>(List<SelectListItem> selectList, List<T> lista) where T : ITrackHolderModel
        {
            foreach (var i in lista)
            {
                var item = new SelectListItem { Value = i.Id.ToString(), Text = i.Name };
                selectList.Add(item);
                await Console.Out.WriteLineAsync(item.Text + " agregada.");
            }
        }
    }
}
