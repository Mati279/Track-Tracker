using ASPTrackTracker.Auth;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using DataLibrary.Data;
using DataLibrary.Models;
using ASPTrackTracker.ScoreHelpers;

namespace ASPTrackTracker.Pages
{
    [Authorize]
    public class IndexModel : AuthenticatedPageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ScoresManager scoresManager;
        private readonly ITrackData trackData;

        public int TracksNotRated { get; set; }
        public int TracksPublished { get; set; }
        public IndexModel(ILogger<IndexModel> logger, ScoresManager scoresManager, ITrackData trackData)
        {
            _logger = logger;
            this.scoresManager = scoresManager;
            this.trackData = trackData;
        }

        public async Task OnGetAsync()
        {

            TracksNotRated = await GetTracksNotRated();
            TracksPublished = await GetTracksPublished();

        }

        public async Task<int> GetTracksNotRated()
        {
            List<TrackModel> allTracks = await trackData.GetAll<TrackModel>();

            int count = 0;

            foreach (TrackModel track in allTracks)
            {
                if(!await scoresManager.CheckIfUserVotedTrack(track, UserId))
                {
                    count++;
                }
            }
            return count;
        }
        public async Task<int> GetTracksPublished()
        {
            List<TrackModel> allTracks = await trackData.GetAll<TrackModel>();

            int count = 0;

            foreach (TrackModel track in allTracks)
            {
                if(track.UserId == UserId) 
                {
                    count++;
                }
            }
            return count;
        }



    }
}
