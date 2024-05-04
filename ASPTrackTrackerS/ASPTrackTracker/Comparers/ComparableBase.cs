namespace ASPTrackTracker.Comparers
{
    public abstract class ComparableBase
    {
        public string Name { get; set; }
        public string Genre { get; set; }
        public string Style { get; set; }
        public double AverageScore { get; set; }
        public double AffinityScore { get; set; }
        public double ComplexityScore { get; set; }
        public double CreativityScore { get; set; }
        public double VoicesScore { get; set; }
        public double LyricsScore { get; set; }
        public double InstrumentalScore { get; set; }
        public int ModelId { get; set; }

        protected ComparableBase(string name, string genre, int modelId)
        {
            Name = name;
            Genre = genre;
            ModelId = modelId; 
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
    }
}
