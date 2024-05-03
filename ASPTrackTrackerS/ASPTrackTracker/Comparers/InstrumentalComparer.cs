namespace ASPTrackTracker.Comparers
{
    internal class InstrumentalComparer : IComparer<ComparableBase>
    {

        public int Compare(ComparableBase? x, ComparableBase? y)
        {

            return y.InstrumentalScore.CompareTo(x.InstrumentalScore);
        }
    }
}
