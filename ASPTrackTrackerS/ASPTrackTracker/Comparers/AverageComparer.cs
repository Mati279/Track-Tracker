using System.Reflection.Metadata.Ecma335;

namespace ASPTrackTracker.Comparers
{
    internal class AverageComparer : IComparer<TrackComparable>
    {
        
        public int Compare(TrackComparable? x, TrackComparable? y)
        {

            return y.AverageScore.CompareTo(x.AverageScore);
        }
    }
}
