namespace ASPTrackTracker.Comparers
{
    internal class AffinityComparer : IComparer<ComparableBase>
    {

        public int Compare(ComparableBase? x, ComparableBase? y)
        {

            return y.AffinityScore.CompareTo(x.AffinityScore);
        }
    }
}
