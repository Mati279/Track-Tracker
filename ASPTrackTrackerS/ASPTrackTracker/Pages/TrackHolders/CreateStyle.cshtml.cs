using ASPTrackTracker.Auth;
using DataLibrary.Data;
using DataLibrary.Db;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPTrackTracker.Pages.TrackHolders
{
    public class CreateStyleModel : AuthenticatedPageModel
    {
        public IStyleData StyleData { get; set; }

        [BindProperty]
        public StyleModel Style { get; set; }
        [BindProperty]
        public string lastUrl { get; set; }

        public CreateStyleModel(IStyleData _StyleData)
        {
            StyleData = _StyleData;
        }


        public void OnGet()
        {
            var fullUrl = Request.Headers["Referer"].ToString();

            Uri uri = new Uri(fullUrl);
            lastUrl = uri.PathAndQuery;

        }

        public async Task<IActionResult> OnPost()
        {
            await StyleData.Create(Style);


            return Redirect(lastUrl);
        }
    }
}
