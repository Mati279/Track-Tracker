using System.Reflection.Metadata.Ecma335;

namespace ASPTrackTracker.Comparers
{
    internal class AverageComparer : IComparer<ComparableTrack>
    {
        
        public int Compare(ComparableTrack? x, ComparableTrack? y)
        {

            return y.AverageScore.CompareTo(x.AverageScore);
        }
    }
}
