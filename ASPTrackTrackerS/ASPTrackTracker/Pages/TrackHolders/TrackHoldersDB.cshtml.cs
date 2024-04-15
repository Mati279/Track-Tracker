using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPTrackTracker.Pages.TrackHolders
{
    public class TrackHoldersDBModel : PageModel
    {
        private readonly ITrackData trackData;
        private readonly IUserData userData;
        private readonly IGenreData genreData;
        private readonly IArtistData artistData;
        private readonly IStyleData styleData;

        public List<SelectListItem> SelectList { get; set; }

        public TrackHoldersDBModel(ITrackData trackData, IUserData userData, IGenreData genreData, IArtistData artistData, IStyleData styleData)
        {
            this.trackData = trackData;
            this.userData = userData;
            this.genreData = genreData;
            this.artistData = artistData;
            this.styleData = styleData;
        }
        public async Task OnGet()
        {

        }

        private async Task BuildTrackHoldersSelectList()
        {
            

        }


    }
}
