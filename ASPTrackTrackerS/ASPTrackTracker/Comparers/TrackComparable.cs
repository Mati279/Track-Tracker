using DataLibrary.BL;
using System.Reflection.Metadata.Ecma335;

namespace ASPTrackTracker.Comparers
{
    public class TrackComparable
    {
        public string Name { get; set; }

        public string Link { get; set; }

        public string UserName { get; set; }

        public string ArtistName { get; set; }

        public string GenreName { get; set; }

        public string StyleName { get; set; }

        public double AverageScore { get; set; }
        public double AffinityScore { get; set; }
        public double ComplexityScore { get; set; }
        public double CreativityScore { get; set; }
        public double VoicesScore { get; set; }
        public double LyricsScore { get; set; }
        public double InstrumentalScore { get; set; }

        public TrackComparable(string name, string link, string userName, string artistName, string genreName, string styleName)
        {
            Name = name;
            Link = link;
            UserName = userName;
            ArtistName = artistName;
            GenreName = genreName;
            StyleName = styleName;
        }

        public void GetScores(double affinity, double complexity, double creativity, double voices, double lyrics, double instrumental)
        {
            AffinityScore = affinity;
            ComplexityScore = complexity;
            CreativityScore = creativity;
            VoicesScore = voices;
            LyricsScore = lyrics;
            InstrumentalScore = instrumental;

            

            AverageScore = (affinity + complexity + creativity + voices + lyrics + instrumental) / (6 - GetCount());

            int GetCount()
            {
                int zeroCount = 0;

                if (voices == 0)
                    zeroCount++;

                if (lyrics == 0)
                    zeroCount++;

                if (instrumental == 0)
                    zeroCount++;

                return zeroCount;
            }
        }

    }
}
