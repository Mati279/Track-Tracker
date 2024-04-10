namespace ASPTrackTracker.Comparers
{
    internal class AffinityComparer : IComparer<TrackComparable>
    {

        public int Compare(TrackComparable? x, TrackComparable? y)
        {

            return y.AffinityScore.CompareTo(x.AffinityScore);
        }
    }
}
