using ASPTrackTracker.Auth;
using DataLibrary.Data;
using DataLibrary.Db;
using DataLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPTrackTracker.Pages.TrackHolders
{
    [Authorize]
    public class CreateGenreModel : AuthenticatedPageModel
    {
        public IGenreData GenreData { get; set; }

        [BindProperty]
        public GenreModel Genre { get; set; }
        [BindProperty]
        public string lastUrl { get; set; }
        public CreateGenreModel(IGenreData _GenreData)
        {
            GenreData = _GenreData;
        }


        public void OnGet()
        {
            var fullUrl = Request.Headers["Referer"].ToString();

            Uri uri = new Uri(fullUrl);
            lastUrl = uri.PathAndQuery;

        }

        public async Task<IActionResult> OnPost()
        {
            await GenreData.Create(Genre);

            return Redirect(lastUrl);
        }
    }
}
