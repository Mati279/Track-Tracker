using ASPTrackTracker.Comparers;
using ASPTrackTracker.FillersAndFilters;
using DataLibrary.Data;
using DataLibrary.Models;
using System.Reflection.Metadata.Ecma335;

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

        public async Task<bool> CheckIfUserVoted(TrackModel track, int userId)
        {
            List<ScoreModel> trackScores = await GetTrackScores(track);

            foreach(var trackScore in trackScores)
            {
                if(trackScore.UserId == userId)
                {
                    return true;
                }
            }
            return false;
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
            int affinityCount = 0;
            int creativityCount = 0;
            int complexityCount = 0;
            int voicesCount = 0;
            int lyricsCount = 0;
            int instrumentalCount = 0;

           
            foreach (ScoreModel score in artistScores)
            {
                if (score.Value != 0)
                {
                    switch (score.Stat)
                    {
                        case "Affinity":
                            affinityCount++;
                            comparableArtist.AffinityScore += score.Value;
                            break;
                        case "Creativity":
                            creativityCount++;
                            comparableArtist.CreativityScore += score.Value;
                            break;
                        case "Complexity":
                            complexityCount++;
                            comparableArtist.ComplexityScore += score.Value;
                            break;
                        case "Voices":
                            voicesCount++;
                            comparableArtist.VoicesScore += score.Value;
                            break;
                        case "Lyrics":
                            lyricsCount++;
                            comparableArtist.LyricsScore += score.Value;
                            break;
                        case "Instrumental":
                            instrumentalCount++;
                            comparableArtist.InstrumentalScore += score.Value;
                            break;
                        default:
                            throw new InvalidOperationException("Unhandled exception");
                    }
                }
            }

            comparableArtist.AffinityScore /= affinityCount;
            comparableArtist.CreativityScore /= creativityCount;
            comparableArtist.ComplexityScore /= complexityCount;

            if(voicesCount != 0)
                comparableArtist.VoicesScore /= voicesCount;

            if(lyricsCount != 0)
                comparableArtist.LyricsScore /= lyricsCount;

            if(instrumentalCount != 0)
                comparableArtist.InstrumentalScore /= instrumentalCount;

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
