using ASPTrackTracker.Comparers;

namespace ASPTrackTracker.ScoreHelpers
{
    public class ScoresSorter
    {

        public void SortTracks(List<ComparableTrack> comparableTracks, string stat)
        {
            switch (stat)
            {
                case "Average":
                    comparableTracks.Sort(new AverageComparer());
                    break;
                case "Affinity":
                    comparableTracks.Sort(new AffinityComparer());
                    break;
                case "Creativity":
                    comparableTracks.Sort(new CreativityComparer());
                    break;
                case "Complexity":
                    comparableTracks.Sort(new ComplexityComparer());
                    break;
                case "Voices":
                    comparableTracks.Sort(new VoicesComparer());
                    break;
                case "Lyrics":
                    comparableTracks.Sort(new LyricsComparer());
                    break;
                case "Instrumental":
                    comparableTracks.Sort(new InstrumentalComparer());
                    break;
                default:
                    throw new InvalidOperationException("Unhandled exception");
            }
        }


    }
}
