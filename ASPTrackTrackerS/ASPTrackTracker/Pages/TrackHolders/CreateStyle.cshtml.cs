using DataLibrary.Data;
using DataLibrary.Db;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPTrackTracker.Pages.TrackHolders
{
    public class CreateStyleModel : PageModel
    {
        public IStyleData StyleData { get; set; }

        [BindProperty]
        public StyleModel Style { get; set; }

        public CreateStyleModel(IStyleData _StyleData)
        {
            StyleData = _StyleData;
        }


        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            await StyleData.Create(Style);


            return RedirectToPage("../Tracks/PublishTrack");
        }
    }
}
