using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPTrackTracker.Pages.Tracks
{
    public class RateTrackModel : PageModel
    {
        private readonly IScoreData scoreData;
        private readonly IArtistData artistData;

        public ITrackData trackData { get; }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public TrackModel Track { get; set; }

        [BindProperty]
        public ScoreModel Score { get; set; }
        public int scoreId { get; set; }
        public string artistName { get; set; }

        [BindProperty]
        public double valueAffinity { get; set; }
        [BindProperty]
        public double valueLyrics { get; set; }
        [BindProperty]
        public double valueCreativity { get; set; }
        [BindProperty]
        public double valueComplexity { get; set; }
        [BindProperty]
        public double valueVoices { get; set; }
        [BindProperty]
        public double valueInstrumental { get; set; }
        
        public RateTrackModel(IScoreData _scoreData, ITrackData _trackData, IArtistData _artistData)
        {
            scoreData = _scoreData;
            trackData = _trackData;
            artistData = _artistData;

            valueAffinity = 7;
            valueLyrics = 7;
            valueCreativity = 7;
            valueComplexity = 7;
            valueVoices = 7;
            valueInstrumental = 7;
        }
        public async Task OnGet()
        {
            Track = await trackData.GetById<TrackModel>(Id);
            var Artist = await artistData.GetById<ArtistModel>(Track.ArtistId);
            artistName = Artist.Name;
        }

        //@Value, @StatId, @UserId, @TrackId
        public async Task OnPost()
        {
            Score.UserId = 1; //Hardcoded.
            Score.TrackId = Track.Id;

            Score.Value = valueAffinity;
            Score.Stat = "Affinity";
            scoreId = await scoreData.Create(Score);

            Score.Value = valueLyrics;
            Score.Stat = "Lyrics";
            scoreId = await scoreData.Create(Score);

            Score.Value = valueCreativity;
            Score.Stat = "Creativity";
            scoreId = await scoreData.Create(Score);

            Score.Value = valueVoices;
            Score.Stat = "Voices";
            scoreId = await scoreData.Create(Score);

            Score.Value = valueComplexity;
            Score.Stat = "Complexity";
            scoreId = await scoreData.Create(Score);

            Score.Value = valueInstrumental;
            Score.Stat = "Instrumental";
            scoreId = await scoreData.Create(Score);

        }
    }
}   