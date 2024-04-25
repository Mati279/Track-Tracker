using DataLibrary.BL;
using DataLibrary.Models;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata.Ecma335;

namespace ASPTrackTracker.Comparers
{
    public class ComparableTrack
    {
        public string Name { get; set; }

        public string Link { get; set; }

        public string UserName { get; set; }

        public string ArtistName { get; set; }

        public string GenreName { get; set; }

        public string StyleName { get; set; }
        public int Voted { get; set; }

        public double AverageScore { get; set; }
        public double AffinityScore { get; set; }
        public double ComplexityScore { get; set; }
        public double CreativityScore { get; set; }
        public double VoicesScore { get; set; }
        public double LyricsScore { get; set; }
        public double InstrumentalScore { get; set; }

        public ComparableTrack(string name, string link, string userName, string artistName, string genreName, string styleName)
        {
            Name = name;
            Link = link;
            UserName = userName;
            ArtistName = artistName;
            GenreName = genreName;
            StyleName = styleName;
        }

        public void GetComparableTrackScores(List<ScoreModel> scores)
        {

            Voted = TimesVoted(scores);

            foreach (ScoreModel score in scores)
            {
                switch (score.Stat)
                {
                    case "Affinity":
                        AffinityScore = score.Value;
                        break;
                    case "Creativity":
                        CreativityScore = score.Value;
                        break;
                    case "Complexity":
                        ComplexityScore = score.Value;
                        break;
                    case "Voices":
                        VoicesScore = score.Value;
                        break;
                    case "Lyrics":
                        LyricsScore = score.Value;
                        break;
                    case "Instrumental":
                        InstrumentalScore = score.Value;
                        break;
                    default:
                        throw new InvalidOperationException("Unhandled exception");
                }
            }
            

            AverageScore = (AffinityScore + ComplexityScore + CreativityScore + VoicesScore + LyricsScore + InstrumentalScore) / (6 - GetCount());

            int GetCount()
            {
                int zeroCount = 0;

       
                if (VoicesScore == 0)
                    zeroCount++;

                if (LyricsScore == 0)
                    zeroCount++;

                if (InstrumentalScore == 0)
                    zeroCount++;

                return zeroCount;
            }
        }
        public string GetScoreByStat(string stat)
        {
            double score = 0;

            switch (stat)
            {
                case "Average":
                    score = this.AverageScore;
                    break;
                case "Affinity":
                    score = this.AffinityScore;
                    break;
                case "Creativity":
                    score = this.CreativityScore;
                    break;
                case "Complexity":
                    score = this.ComplexityScore;
                    break;
                case "Voices":
                    score = this.VoicesScore;
                    break;
                case "Lyrics":
                    score = this.LyricsScore;
                    break;
                case "Instrumental":
                    score = this.InstrumentalScore;
                    break;
                default:
                    throw new InvalidOperationException("Unhandled exception");
            }

            double roundedScore = Math.Round(score, 1);

            string resultString = roundedScore == 0 ? "- -" : roundedScore.ToString();
            return resultString;
        }

        public int TimesVoted(List<ScoreModel> scores)
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
    }
}
