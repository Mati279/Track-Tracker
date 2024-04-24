using DataLibrary.Data;
using DataLibrary.Models;

namespace ASPTrackTracker.ScoreHelpers
{
    public class TrackScoresGetter
    {
        private readonly IScoreData scoreData;

        public TrackScoresGetter(IScoreData scoreData)
        {
            this.scoreData = scoreData;
        }
        public async Task<List<ScoreModel>> GetTrackScores(TrackModel track)
        {
            List<ScoreModel> allScores = await scoreData.GetAll<ScoreModel>();

            List<ScoreModel> trackScores = new List<ScoreModel>();

            foreach (ScoreModel score in allScores)
            {
                if (score.TrackId == track.Id)
                {
                    trackScores.Add(score);
                }
            }

            return trackScores;
        }
    }
}
