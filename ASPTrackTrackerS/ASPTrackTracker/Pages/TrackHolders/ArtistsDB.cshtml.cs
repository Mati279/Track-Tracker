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

        public ArtistsDBModel(ITrackData trackData, IArtistData artistData, IGenreData genreData, IStyleData styleData)
        {
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

            await FillSelectTrackHolder(GenreItems, genres);
            await FillSelectTrackHolder(StyleItems, styles);
            FillSelectStats(StatItems);
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

        private async Task FillSelectTrackHolder<T>(List<SelectListItem> selectList, List<T> lista) where T : ITrackHolderModel
        {
            selectList.Insert(0, new SelectListItem { Value = "All", Text = "All" });
            foreach (var i in lista)
            {
                var item = new SelectListItem { Value = i.Id.ToString(), Text = i.Name };
                selectList.Add(item);
                await Console.Out.WriteLineAsync(item.Text + " agregada.");
            }
        }

        private void FillSelectStats(List<SelectListItem> selectList)
        {
            StatItems.Insert(0, new SelectListItem { Value = "Average", Text = "Average" });
            StatItems.Insert(1, new SelectListItem { Value = "Affinity", Text = "Affinity" });
            StatItems.Insert(2, new SelectListItem { Value = "Creativity", Text = "Creativity" });
            StatItems.Insert(3, new SelectListItem { Value = "Complexity", Text = "Complexity" });
            StatItems.Insert(4, new SelectListItem { Value = "Lyrics", Text = "Lyrics" });
            StatItems.Insert(5, new SelectListItem { Value = "Voices", Text = "Voices" });
            StatItems.Insert(6, new SelectListItem { Value = "Instrumental", Text = "Instrumental" });
        }
    }
}
