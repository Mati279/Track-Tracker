namespace ASPTrackTracker.Comparers
{
    internal class ComplexityComparer : IComparer<ComparableTrack>
    {

        public int Compare(ComparableTrack? x, ComparableTrack? y)
        {

            return y.ComplexityScore.CompareTo(x.ComplexityScore);
        }
    }
}
