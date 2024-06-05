using ASPTrackTracker.Auth;
using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPTrackTracker.Pages.TrackHolders
{
    [Authorize]
    public class EditArtistModel : AuthenticatedPageModel
    {
        private readonly IArtistData artistData;
        private readonly IGenreData genreData;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public ArtistModel Artist { get; set; }

        public List<SelectListItem> GenreItems { get; set; }

        public EditArtistModel(IArtistData artistData, IGenreData genreData)
        {
            this.artistData = artistData;
            this.genreData = genreData;
        }
        public async Task OnGetAsync()
        {
            Artist = await artistData.GetById<ArtistModel>(Id);


            GenreItems = new List<SelectListItem>();


            List<ArtistModel> artists = await artistData.GetAll<ArtistModel>();
            List<GenreModel> genres = await genreData.GetAll<GenreModel>();

            await FillSelect(GenreItems, genres);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid == false) 
            {
                return Page(); 
            }

            await artistData.UpdateGenre(Id, Artist.GenreId);
            await artistData.UpdateName(Id, Artist.Name);

            return RedirectToPage("ArtistsDB");
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
