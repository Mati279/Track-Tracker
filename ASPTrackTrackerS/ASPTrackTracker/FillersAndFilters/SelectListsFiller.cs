using ASPTrackTracker.Comparers;
using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPTrackTracker.FillersAndFilters
{
    public class SelectListsFiller
    {
        private readonly ITrackData trackData;
        private readonly IArtistData artistData;
        private readonly IGenreData genreData;
        private readonly IStyleData styleData;
        private readonly IUserData userData;
        private readonly IScoreData scoreData;

        public SelectListsFiller(ITrackData trackData, IArtistData artistData, IGenreData genreData, IStyleData styleData, IUserData userData, IScoreData scoreData)
        {
            this.trackData = trackData;
            this.artistData = artistData;
            this.genreData = genreData;
            this.styleData = styleData;
            this.userData = userData;
            this.scoreData = scoreData;
        }

        public void FillSelectTrackHolder<T>(List<SelectListItem> selectList, List<T> lista) where T : ITrackHolderModel
        {
            selectList.Insert(0, new SelectListItem { Value = "All", Text = "All" });
            foreach (var i in lista)
            {
                var item = new SelectListItem { Value = i.Id.ToString(), Text = i.Name };
                selectList.Add(item);
            }
        }

        public void FillSelectStats(List<SelectListItem> selectList)
        {
            selectList.Insert(0, new SelectListItem { Value = "Average", Text = "Average" });
            selectList.Insert(1, new SelectListItem { Value = "Affinity", Text = "Affinity" });
            selectList.Insert(2, new SelectListItem { Value = "Creativity", Text = "Creativity" });
            selectList.Insert(3, new SelectListItem { Value = "Complexity", Text = "Complexity" });
            selectList.Insert(4, new SelectListItem { Value = "Lyrics", Text = "Lyrics" });
            selectList.Insert(5, new SelectListItem { Value = "Voices", Text = "Voices" });
            selectList.Insert(6, new SelectListItem { Value = "Instrumental", Text = "Instrumental" });
        }
    }
}
