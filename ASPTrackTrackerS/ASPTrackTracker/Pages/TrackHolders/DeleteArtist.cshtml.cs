using ASPTrackTracker.Auth;
using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPTrackTracker.Pages.TrackHolders
{
    [Authorize]
    public class DeleteArtistModel : AuthenticatedPageModel
    {
        private readonly IArtistData artistData;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public ArtistModel Artist { get; set; }
        public DeleteArtistModel(IArtistData _artistData)
        {
            artistData = _artistData;
        }
        public async Task OnGetAsync()
        {
            Artist = await artistData.GetById<ArtistModel>(Id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await artistData.Delete(Id);

            return RedirectToPage("../Index");
        }
    }
}

