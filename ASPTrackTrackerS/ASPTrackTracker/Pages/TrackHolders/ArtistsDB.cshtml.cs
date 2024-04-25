using ASPTrackTracker.FillersAndFilters;
using DataLibrary.BL;
using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPTrackTracker.Pages.TrackHolders
{
    public class ArtistsDBModel : PageModel
    {
        private readonly SelectListsFiller selectListFiller;
        private readonly ITrackData trackData;
        private readonly IArtistData artistData;
        private readonly IGenreData genreData;
        private readonly IStyleData styleData;

        public List<SelectListItem> StyleItems { get; set; }
        public List<SelectListItem> GenreItems { get; set; }
        public List<SelectListItem> StatItems { get; set; }

        [BindProperty(SupportsGet = true)]
        public int GenreId { get; set; }

        [BindProperty(SupportsGet = true)]
        public int StyleId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SelectedStat { get; set; } = "Average";

        public ArtistsDBModel(SelectListsFiller selectListFiller, 
                              ITrackData trackData, IArtistData artistData, IGenreData genreData, IStyleData styleData)
        {
            this.selectListFiller = selectListFiller;
            this.trackData = trackData;
            this.artistData = artistData;
            this.genreData = genreData;
            this.styleData = styleData;
        }

        public async Task OnGet()
        {
            GenreItems = new List<SelectListItem>();
            StyleItems = new List<SelectListItem>();
            StatItems = new List<SelectListItem>();

            List<GenreModel> genres = await genreData.GetAll<GenreModel>();
            List<StyleModel> styles = await styleData.GetAll<StyleModel>();

            selectListFiller.FillSelectTrackHolder(GenreItems, genres);
            selectListFiller.FillSelectTrackHolder(StyleItems, styles);
            selectListFiller.FillSelectStats(StatItems);
        }

        public async Task<IActionResult> OnPost()
        {
            var select = new {  };

            return RedirectToPage(select);
        }

        public async Task<IActionResult> OnPostReset()
        {
            var selects = new { UserId = 0, StatSelected = "Average", StyleId = 0, GenreId = 0, ArtistId = 0 };

            return RedirectToPage(selects);
        }
    }
}
