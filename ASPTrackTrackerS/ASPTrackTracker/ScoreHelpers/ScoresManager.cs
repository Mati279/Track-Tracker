using ASPTrackTracker.Comparers;
using ASPTrackTracker.FillersAndFilters;
using DataLibrary.Data;
using DataLibrary.Models;

namespace ASPTrackTracker.ScoreHelpers
{
    public class ScoresManager
    {
        private readonly IScoreData scoreData;
        private readonly ITrackData trackData;
        private readonly ArtistsFilter artistsFilter;

        public ScoresManager(ArtistsFilter artistsFilter, IScoreData scoreData, ITrackData trackData)
        {
            this.scoreData = scoreData;
            this.trackData = trackData;
            this.artistsFilter = artistsFilter;
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

        public async Task<List<ScoreModel>> GetArtistScores(ArtistModel artist)
        {
            List<ScoreModel> allScores = await scoreData.GetAll<ScoreModel>();

            List<ScoreModel> artistScores = new List<ScoreModel>();

            foreach (ScoreModel score in allScores)
            {
                var scoreTrack = await trackData.GetById<TrackModel>(score.TrackId);

                if (scoreTrack.ArtistId == artist.Id)
                {
                    artistScores.Add(score);
                }
            }

            return artistScores;
        }

        public void SetComparableTrackScores(ComparableTrack comparableTrack, List<ScoreModel> scores)
        {
            comparableTrack.Voted = CheckTimesVoted(scores);

            foreach (ScoreModel score in scores)
            {
                switch (score.Stat)
                {
                    case "Affinity":
                        comparableTrack.AffinityScore = score.Value;
                        break;
                    case "Creativity":
                        comparableTrack.CreativityScore = score.Value;
                        break;
                    case "Complexity":
                        comparableTrack.ComplexityScore = score.Value;
                        break;
                    case "Voices":
                        comparableTrack.VoicesScore = score.Value;
                        break;
                    case "Lyrics":
                        comparableTrack.LyricsScore = score.Value;
                        break;
                    case "Instrumental":
                        comparableTrack.InstrumentalScore = score.Value;
                        break;
                    default:
                        throw new InvalidOperationException("Unhandled exception");
                }
            }


            comparableTrack.AverageScore = (comparableTrack.AffinityScore + comparableTrack.ComplexityScore + comparableTrack.CreativityScore + comparableTrack.VoicesScore + comparableTrack.LyricsScore + comparableTrack.InstrumentalScore) / (6 - GetCount());

            int GetCount()
            {
                int zeroCount = 0;

                if (comparableTrack.VoicesScore == 0)
                    zeroCount++;

                if (comparableTrack.LyricsScore == 0)
                    zeroCount++;

                if (comparableTrack.InstrumentalScore == 0)
                    zeroCount++;

                return zeroCount;
            }
        }

        public int CheckTimesVoted(List<ScoreModel> scores)
        {
            int voted = 0;
            List<int> voters = new List<int>();
            foreach (ScoreModel score in scores)
            {
                if (voters.Contains(score.UserId) == false)
                {
                    voters.Add(score.UserId);
                    voted++;
                }

            }

            return voted;
        }

        public void SetComparableArtistScores(ComparableArtist comparableArtist, List<ScoreModel> artistScores)
        {
            foreach (ScoreModel score in artistScores)
            {
                switch (score.Stat)
                {
                    case "Affinity":
                        comparableArtist.AffinityScore += score.Value;
                        break;
                    case "Creativity":
                        comparableArtist.CreativityScore += score.Value;
                        break;
                    case "Complexity":
                        comparableArtist.ComplexityScore += score.Value;
                        break;
                    case "Voices":
                        comparableArtist.VoicesScore += score.Value;
                        break;
                    case "Lyrics":
                        comparableArtist.LyricsScore += score.Value;
                        break;
                    case "Instrumental":
                        comparableArtist.InstrumentalScore += score.Value;
                        break;
                    default:
                        throw new InvalidOperationException("Unhandled exception");
                }
            }

            comparableArtist.AverageScore = (comparableArtist.AffinityScore + comparableArtist.ComplexityScore + comparableArtist.CreativityScore + comparableArtist.VoicesScore + comparableArtist.LyricsScore + comparableArtist.InstrumentalScore) / (6 - GetCount());

            int GetCount()
            {
                int zeroCount = 0;

                if (comparableArtist.VoicesScore == 0)
                    zeroCount++;

                if (comparableArtist.LyricsScore == 0)
                    zeroCount++;

                if (comparableArtist.InstrumentalScore == 0)
                    zeroCount++;

                return zeroCount;
            }
        }
    }
}
