namespace ASPTrackTracker.Comparers
{
    internal class VoicesComparer : IComparer<TrackComparable>
    {

        public int Compare(TrackComparable? x, TrackComparable? y)
        {

            return y.VoicesScore.CompareTo(x.VoicesScore);
        }
    }
}
