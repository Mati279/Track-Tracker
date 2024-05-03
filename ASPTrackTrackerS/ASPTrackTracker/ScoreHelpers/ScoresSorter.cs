using ASPTrackTracker.Comparers;

namespace ASPTrackTracker.ScoreHelpers
{
    public class ScoresSorter
    {

        public void SortComparable<T>(List<T> comparableList, string stat) where T : ComparableBase
        {
            switch (stat)
            {
                case "Average":
                    comparableList.Sort(new AverageComparer());
                    break;
                case "Affinity":
                    comparableList.Sort(new AffinityComparer());
                    break;
                case "Creativity":
                    comparableList.Sort(new CreativityComparer());
                    break;
                case "Complexity":
                    comparableList.Sort(new ComplexityComparer());
                    break;
                case "Voices":
                    comparableList.Sort(new VoicesComparer());
                    break;
                case "Lyrics":
                    comparableList.Sort(new LyricsComparer());
                    break;
                case "Instrumental":
                    comparableList.Sort(new InstrumentalComparer());
                    break;
                default:
                    throw new InvalidOperationException("Unhandled exception");
            }
        }




    }
}
