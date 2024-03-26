using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPTrackTracker.Pages.Tracks
{
    public class DeleteTrackModel : PageModel
    {
        private readonly ITrackData trackData;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public TrackModel Track { get; set; }
        public DeleteTrackModel(ITrackData _trackData)
        {
            trackData = _trackData;
        }
        public async Task OnGet()
        {
            Track = await trackData.GetById<TrackModel>(Id);
        }

        public async Task<IActionResult> OnPost()
        {
            await trackData.Delete(Id);

            return RedirectToPage("./PublishTrack");
        }
    }
}
