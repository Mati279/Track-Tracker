using ASPTrackTracker.Auth;
using ASPTrackTracker.ScoreHelpers;
using DataLibrary.BL;
using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPTrackTracker.Pages.Stats
{
    [Authorize]
    public class UserStatsModel : AuthenticatedPageModel
    {
        private readonly ScoresManager scoresManager;
        private readonly IUserData userData;
        private readonly IArtistData artistData;
        private readonly IGenreData genreData;
        private readonly ITrackData trackData;

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        public UserModel User { get; set; }

        public UserStatsModel(ScoresManager scoresManager, IUserData userData, IGenreData genreData, ITrackData trackData)
        {
            this.scoresManager = scoresManager;
            this.userData = userData;
            this.genreData = genreData;
            this.trackData = trackData;
        }
        public async Task OnGet()
        {
            User = await userData.GetById<UserModel>(Id);


            //artistScores = await scoresManager.GetArtistScores(Artist);

            //AverageScore = GetAverage();
            //AffinityScore = GetArtistScoreByStat("Affinity");
            //ComplexityScore = GetArtistScoreByStat("Complexity");
            //CreativityScore = GetArtistScoreByStat("Creativity");
            //VoicesScore = GetArtistScoreByStat("Voices");
            //LyricsScore = GetArtistScoreByStat("Lyrics");
            //InstrumentalScore = GetArtistScoreByStat("Instrumental");

            //trackAmmount = await GetTrackAmmount();
        }

        //    private double GetArtistScoreByStat(string Stat)
        //    {
        //        double value = 0;
        //        int count = 0;

        //        foreach (ScoreModel score in artistScores)
        //        {
        //            if (score.Stat == Stat)
        //            {
        //                value += score.Value;
        //                count++;
        //            }
        //        }

        //        return Math.Round(value / count, 1);
        //    }
        //    private double GetAverage()
        //    {
        //        int count = 0;
        //        double values = 0;

        //        foreach (ScoreModel score in artistScores)
        //        {
        //            if (score.Value != 0)
        //            {
        //                values += score.Value;
        //                count++;
        //            }
        //        }
        //        double average = values / count;

        //        return Math.Round(average, 1);
        //    }

        //    private async Task<int> GetTrackAmmount()
        //    {
        //        int ammount = 0;

        //        List<TrackModel> allTracks = await trackData.GetAll<TrackModel>();
        //        foreach (TrackModel track in allTracks)
        //        {
        //            if (track.ArtistId == Artist.Id)
        //            {
        //                ammount++;
        //            }
        //        }
        //        return ammount;
        //    }
        //    public string ReturnScoreOrDash(double score)
        //    {
        //        if (score == 0)
        //        {
        //            return "- -";
        //        }
        //        else
        //        {
        //            return score.ToString();
        //        }
        //    }
        //}
    }
}

