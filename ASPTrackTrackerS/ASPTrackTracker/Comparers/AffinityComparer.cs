namespace ASPTrackTracker.Comparers
{
    internal class AffinityComparer : IComparer<ComparableTrack>
    {

        public int Compare(ComparableTrack? x, ComparableTrack? y)
        {

            return y.AffinityScore.CompareTo(x.AffinityScore);
        }
    }
}
