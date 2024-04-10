namespace ASPTrackTracker.Comparers
{
    internal class ComplexityComparer : IComparer<TrackComparable>
    {

        public int Compare(TrackComparable? x, TrackComparable? y)
        {

            return y.ComplexityScore.CompareTo(x.ComplexityScore);
        }
    }
}
