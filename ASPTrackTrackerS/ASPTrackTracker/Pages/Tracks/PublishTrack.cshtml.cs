using ASPTrackTracker.Auth;
using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;


namespace ASPTrackTracker.Pages.Tracks
{
    [Authorize]
    public class PublishTrackModel : AuthenticatedPageModel
    {
        private readonly ITrackData trackData;
        private readonly IArtistData artistData;
        private readonly IStyleData styleData;

        public List<SelectListItem> ArtistItems { get; set; } 
        public List<SelectListItem> StyleItems { get; set; }

        [BindProperty]
        public TrackModel Track { get; set; }
        public PublishTrackModel(ITrackData trackData, IArtistData artistData, IGenreData genreData, IStyleData styleData)
        {
            this.artistData = artistData;
            this.styleData = styleData;
            this.trackData = trackData;
        }
        public async Task OnGet()
        {
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

            int Id = await trackData.Create(Track); 

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
