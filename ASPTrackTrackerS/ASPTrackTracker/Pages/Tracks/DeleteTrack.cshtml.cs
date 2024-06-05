using ASPTrackTracker.Auth;
using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPTrackTracker.Pages.Tracks
{
    [Authorize]
    public class DeleteTrackModel : AuthenticatedPageModel
    {
        private readonly ITrackData trackData;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public TrackModel Track { get; set; }
        public DeleteTrackModel(ITrackData _trackData)
        {
            trackData = _trackData;
        }
        public async Task OnGetAsync()
        {
            Track = await trackData.GetById<TrackModel>(Id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await trackData.Delete(Id);

            return RedirectToPage("../Index");
        }
    }
}
