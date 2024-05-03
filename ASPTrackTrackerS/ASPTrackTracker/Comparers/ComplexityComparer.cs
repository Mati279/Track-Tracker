namespace ASPTrackTracker.Comparers
{
    internal class ComplexityComparer : IComparer<ComparableBase>
    {

        public int Compare(ComparableBase? x, ComparableBase? y)
        {

            return y.ComplexityScore.CompareTo(x.ComplexityScore);
        }
    }
}
