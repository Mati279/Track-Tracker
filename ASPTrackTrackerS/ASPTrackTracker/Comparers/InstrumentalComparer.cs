namespace ASPTrackTracker.Comparers
{
    internal class InstrumentalComparer : IComparer<ComparableTrack>
    {

        public int Compare(ComparableTrack? x, ComparableTrack? y)
        {

            return y.InstrumentalScore.CompareTo(x.InstrumentalScore);
        }
    }
}
