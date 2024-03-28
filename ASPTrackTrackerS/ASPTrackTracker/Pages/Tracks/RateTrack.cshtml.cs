using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Formats.Asn1.AsnWriter;

namespace ASPTrackTracker.Pages.Tracks
{
    public class RateTrackModel : PageModel
    {
        private readonly IScoreData scoreData;
        private readonly IArtistData artistData;

        public ITrackData trackData { get; }
        public IStyleData StyleData { get; }
        public string artistName { get; set; }
        public StyleModel Style { get; set; }
        public bool Instrumental  { get; set; }
        public bool Choral  { get; set; }


        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public TrackModel Track { get; set; }

        [BindProperty]
        public ScoreModel Score { get; set; }

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
        
        public RateTrackModel(IScoreData _scoreData, ITrackData _trackData, IArtistData _artistData, IStyleData _styleData)
        {
            scoreData = _scoreData;
            trackData = _trackData;
            artistData = _artistData;
            StyleData = _styleData;

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

            Style = await StyleData.GetById<StyleModel>(Track.StyleId);

            CheckIstrumentalOrChoral(Style);

        }

        //@Value, @StatId, @UserId, @TrackId
        public async Task<IActionResult> OnPost()
        {
            Score.UserId = 1; //Hardcoded.
            Score.TrackId = Track.Id;

            Track = await trackData.GetById<TrackModel>(Id);

            Style = await StyleData.GetById<StyleModel>(Track.StyleId);

            CheckIstrumentalOrChoral(Style);

            await CreateScore(valueAffinity, "Affinity");

            await CreateScore(valueCreativity, "Creativity");

            await CreateScore(valueComplexity, "Complexity");

            if (Style.Name == "Choral")
            {
                await CreateScore(valueLyrics, "Lyrics");

                await CreateScore(valueVoices, "Voices");
            }

            if (Style.Name == "Instrumental")
            {
                await CreateScore(valueInstrumental, "Instrumental");
            }

            return RedirectToPage("../Index");
        }

        private async Task CreateScore(double _value, string _stat)
        {
            await Console.Out.WriteLineAsync("Método llamado con " + _stat + ".");
            Score.Value = _value;
            Score.Stat = _stat;

            await scoreData.Create(Score);
        }

        private void CheckIstrumentalOrChoral(StyleModel _style)
        {
            if (_style.Name == "Instrumental")
                Instrumental = true;

            if (_style.Name == "Choral")
                Choral = true;
        }
    }
}   