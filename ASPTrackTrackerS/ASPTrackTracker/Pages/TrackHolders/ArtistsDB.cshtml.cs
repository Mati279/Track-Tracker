using ASPTrackTracker.Comparers;
using ASPTrackTracker.FillersAndFilters;
using ASPTrackTracker.ScoreHelpers;
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
        private readonly ComparablesCreator comparablesCreator;
        private readonly ScoresSorter scoreSorter;
        private readonly ITrackData trackData;
        private readonly IArtistData artistData;
        private readonly IGenreData genreData;
        private readonly IStyleData styleData;
        public ArtistsFilter artistsFilter { get; set; }
        public List<ArtistModel> allArtists { get; set; }
        public List<ArtistModel> filteredArtists { get; set; }
        public List<ComparableArtist> comparableArtists { get; set; }
        public List<SelectListItem> StyleItems { get; set; }
        public List<SelectListItem> GenreItems { get; set; }
        public List<SelectListItem> StatItems { get; set; }

        [BindProperty(SupportsGet = true)]
        public int GenreId { get; set; }

        public string FilterStyleName { get; set; }

        [BindProperty(SupportsGet = true)]
        public int StyleId { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SelectedStat { get; set; } = "Average";

        public string FilterPrompt { get; set; }

        public ArtistsDBModel(SelectListsFiller selectListFiller, ArtistsFilter artistsFilter, ComparablesCreator comparablesCreator, ScoresSorter scoreSorter,
                              ITrackData trackData, IArtistData artistData, IGenreData genreData, IStyleData styleData)
        {
            this.selectListFiller = selectListFiller;
            this.artistsFilter = artistsFilter;
            this.comparablesCreator = comparablesCreator;
            this.scoreSorter = scoreSorter;
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

            

            filteredArtists = await artistsFilter.FilterArtists(GenreId, StyleId);

            comparableArtists = await comparablesCreator.CreateComparableArtists(filteredArtists);

            scoreSorter.SortComparable(comparableArtists, SelectedStat);

            await FormatFilterPrompt();
        }

        private async Task FormatFilterPrompt()
        {
            var genre = await genreData.GetById<GenreModel>(GenreId);
            var style = await styleData.GetById<StyleModel>(StyleId);

            string genrePrompt;
            string stylePrompt;
            string finalDot = ".";

            if (GenreId == 0 && StyleId == 0)
            {
                FilterStyleName = "All";
                genrePrompt = "";
                finalDot = "";
            }
            else if (GenreId == 0)
            {
                FilterStyleName = style.Name;
                genrePrompt = "Filtering artists ";
            }
            else
            {
                genrePrompt = "Filtering artists of " + genre.Name + " genre";
            }

            if (StyleId == 0)
            {
                FilterStyleName = "All";
                stylePrompt = "";
            }
            else
            {
                stylePrompt = " who have tracks of " + style.Name + " style";
            }
            FilterPrompt = genrePrompt + stylePrompt + finalDot + " Rating based on " + SelectedStat + " scores.";
        }
    }
}
