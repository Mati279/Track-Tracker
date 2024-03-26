using DataLibrary.Data;
using DataLibrary.Db;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPTrackTracker.Pages.TrackHolders
{
    public class CreateArtistModel : PageModel
    {
        private readonly IArtistData artistData;
        private readonly IGenreData genreData;

        [BindProperty]
        public string lastUrl { get; set; }
        public List<SelectListItem> GenreItems { get; set; }

        [BindProperty]
        public ArtistModel Artist { get; set; }
        public CreateArtistModel(IArtistData _artistData, IGenreData _genreData)
        {
            artistData = _artistData;
            genreData = _genreData;
        }

        //Viendo para que Create THolder vuelva a la página anterior y no a PublishTrack por defecto como está ahora. 

        public async Task OnGet()
        {
            GenreItems = new List<SelectListItem>();
            List<GenreModel> genres = await genreData.GetAll<GenreModel>();


            //Ver esto! Hay error volviendo a EditTrack.asd
            var fullUrl = Request.Headers["Referer"].ToString();

            Uri uri = new Uri(fullUrl);
            lastUrl = uri.PathAndQuery;


            await FillSelect(GenreItems, genres);
        }
        
        public async Task<IActionResult> OnPost() 
        {
            await artistData.Create(Artist);

            return RedirectToPage(lastUrl);
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
