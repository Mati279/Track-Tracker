using ASPTrackTracker.Auth;
using DataLibrary.BL;
using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPTrackTracker.Pages.Tracks
{
    [Authorize]
    public class EditTrackModel : AuthenticatedPageModel
    {
        private readonly ITrackData trackData;
        private readonly IArtistData artistData;
        private readonly IStyleData styleData;

        public ArtistModel Artist { get; set; }
        public GenreModel Genre { get; set; }
        public StyleModel Style { get; set; }
        public List<SelectListItem> ArtistItems { get; set; }
        public List<SelectListItem> GenreItems { get; set; }
        public List<SelectListItem> StyleItems { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public TrackModel Track { get; set; }
        public EditTrackModel(ITrackData trackData, IArtistData artistData, IStyleData styleData)
        {
            this.artistData = artistData;
            this.styleData = styleData;
            this.trackData = trackData;
        }
        public async Task OnGet()
        {
            Track = await trackData.GetById<TrackModel>(Id);
            

            ArtistItems = new List<SelectListItem>();
            StyleItems = new List<SelectListItem>();


            List<ArtistModel> artists = await artistData.GetAll<ArtistModel>();
            List<StyleModel> styles = await styleData.GetAll<StyleModel>();

            await FillSelect(ArtistItems, artists);
            await FillSelect(StyleItems, styles);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid == false) //Si hay algún error en el modelo, cuando se hace el Submit (POST).
            {
                return Page(); //Devuelve la página actual.
            }

            var artist = await artistData.GetById<ArtistModel>(Track.ArtistId);

            Track.GenreId = artist.GenreId;

            await trackData.UpdateTrack(Id, Track.Name, Track.Link, 1, Track.ArtistId, 
                Track.GenreId, Track.StyleId); //Hardcoded.

            return RedirectToPage("./DisplayTrack", new { Id = Id });
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
