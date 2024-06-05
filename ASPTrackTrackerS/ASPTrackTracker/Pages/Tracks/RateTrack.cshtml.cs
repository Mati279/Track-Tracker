using ASPTrackTracker.Auth;
using ASPTrackTracker.Comparers;
using ASPTrackTracker.ScoreHelpers;
using DataLibrary.BL;
using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using static System.Formats.Asn1.AsnWriter;

namespace ASPTrackTracker.Pages.Tracks
{
    [Authorize]
    public class RateTrackModel : AuthenticatedPageModel
    {
        private readonly IScoreData scoreData;
        private readonly IArtistData artistData;
        private readonly IUserData userData;
        private readonly ScoresManager scoresManager;

        public ITrackData trackData { get; }
        public IStyleData StyleData { get; }
        public string artistName { get; set; }
        public StyleModel Style { get; set; }
        public bool Instrumental { get; set; }
        public bool Choral { get; set; }

        [BindProperty]
        public List<ScoreModel> userVotesForTrack {get; set;}

        [BindProperty]
        public bool alreadyRated { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public TrackModel Track { get; set; }

        [BindProperty]
        public ScoreModel Score { get; set; }

        [BindProperty]
        [Range(0, 10)]
        public double valueAffinity { get; set; }
        [BindProperty]
        [Range(0, 10)]
        public double valueLyrics { get; set; }
        [BindProperty]
        [Range(0, 10)]
        public double valueCreativity { get; set; }
        [BindProperty]
        [Range(0, 10)]
        public double valueComplexity { get; set; }
        [BindProperty]
        [Range(0, 10)]
        public double valueVoices { get; set; }
        [BindProperty]
        [Range(0, 10)]
        public double valueInstrumental { get; set; }
        
        public RateTrackModel(IScoreData _scoreData, ITrackData _trackData, IArtistData _artistData, IStyleData _styleData, IUserData _userData, ScoresManager scoresManager)
        {
            scoreData = _scoreData;
            trackData = _trackData;
            artistData = _artistData;
            StyleData = _styleData;
            userData = _userData;
            this.scoresManager = scoresManager;
            
        }
        public async Task OnGetAsync()
        {
            Track = await trackData.GetById<TrackModel>(Id);

            var Artist = await artistData.GetById<ArtistModel>(Track.ArtistId);
            artistName = Artist.Name;

            Style = await StyleData.GetById<StyleModel>(Track.StyleId);

            CheckIstrumentalOrChoral(Style);

            await GetUserPreviousScores(Track, UserId); //Hardcoded user.
            AsignScoresToFields();

        }

        //@Value, @StatId, @UserId, @TrackId
        public async Task<IActionResult> OnPostAsync()
        {
            Score.UserId = UserId; //Hardcoded.
            Score.TrackId = Id;

            Track = await trackData.GetById<TrackModel>(Id);

            Style = await StyleData.GetById<StyleModel>(Track.StyleId);

            CheckIstrumentalOrChoral(Style);

            await GetUserPreviousScores(Track, UserId); //Hardcoded user.

            await SubmitScore(valueAffinity, "Affinity");

            await SubmitScore(valueCreativity, "Creativity");

            await SubmitScore(valueComplexity, "Complexity");

            if (Style.Name != "Instrumental" && Style.Name != "Guitar" && Style.Name != "Piano")
            {
                await SubmitScore(valueLyrics, "Lyrics");

                await SubmitScore(valueVoices, "Voices");
            }

            if (Style.Name != "Choral")
            {
                await SubmitScore(valueInstrumental, "Instrumental");
            }

            return RedirectToPage("./TracksDB");
        }

        private async Task SubmitScore(double _value, string _stat)
        {

            //Chequeando por qué sólo actualiza "Affinity". Puede tener que ver con el score Id.
            if (alreadyRated)
            {
                foreach(ScoreModel score in userVotesForTrack)
                {
                    if(score.Stat == _stat)
                    {
                        await scoreData.UpdateValue(score.Id, _value);
                        break;
                    }
                }
            }
            else
            {
                Score.Value = _value;
                Score.Stat = _stat;

                await scoreData.Create(Score);
            }
        }

        private void CheckIstrumentalOrChoral(StyleModel _style)
        {
            if (Style.Name == "Instrumental" || Style.Name == "Guitar" || Style.Name == "Piano")
                Instrumental = true;

            if (_style.Name == "Choral")
                Choral = true;
        }

        private async Task GetUserPreviousScores(TrackModel track, int userId) 
        {
            userVotesForTrack = new List<ScoreModel>();

            if (await scoresManager.CheckIfUserVotedTrack(track, userId))
            {
                alreadyRated = true;
                List<ScoreModel> trackScores = await scoresManager.GetTrackScores(track);

                foreach(ScoreModel score in trackScores)
                {
                    if(score.UserId == userId)
                    {
                        userVotesForTrack.Add(score);   
                    }
                }
            }
            else
            {
                alreadyRated = false;
            }
        }

        private void AsignScoresToFields()
        {
            if (alreadyRated)
            {
                foreach (ScoreModel score in userVotesForTrack)
                {
                    switch (score.Stat)
                    {
                        case "Affinity":
                            valueAffinity = score.Value;
                            break;
                        case "Lyrics":
                            valueLyrics = score.Value;
                            break;
                        case "Creativity":
                            valueCreativity = score.Value;
                            break;
                        case "Complexity":
                            valueComplexity = score.Value;
                            break;
                        case "Voices":
                            valueVoices = score.Value;
                            break;
                        case "Instrumental":
                            valueInstrumental = score.Value;
                            break;
                    }
                }
            }
            else
            {
                valueAffinity = 7;
                valueLyrics = 7;
                valueCreativity = 7;
                valueComplexity = 7;
                valueVoices = 7;
                valueInstrumental = 7;

            }
        }
    }
}   