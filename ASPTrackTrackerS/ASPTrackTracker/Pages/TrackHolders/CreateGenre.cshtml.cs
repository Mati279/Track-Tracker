using DataLibrary.Data;
using DataLibrary.Db;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPTrackTracker.Pages.TrackHolders
{
    public class CreateGenreModel : PageModel
    {
        public IGenreData GenreData { get; set; }

        [BindProperty]
        public GenreModel Genre { get; set; }
        public CreateGenreModel(IGenreData _GenreData)
        {
            GenreData = _GenreData;
        }


        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            await GenreData.Create(Genre);

            return RedirectToPage("../Tracks/PublishTrack");
        }
    }
}
