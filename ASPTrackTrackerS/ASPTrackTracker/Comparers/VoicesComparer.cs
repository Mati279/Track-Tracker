namespace ASPTrackTracker.Comparers
{
    internal class VoicesComparer : IComparer<ComparableTrack>
    {

        public int Compare(ComparableTrack? x, ComparableTrack? y)
        {

            return y.VoicesScore.CompareTo(x.VoicesScore);
        }
    }
}
