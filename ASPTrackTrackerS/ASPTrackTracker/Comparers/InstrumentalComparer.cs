namespace ASPTrackTracker.Comparers
{
    internal class InstrumentalComparer : IComparer<TrackComparable>
    {

        public int Compare(TrackComparable? x, TrackComparable? y)
        {

            return y.InstrumentalScore.CompareTo(x.InstrumentalScore);
        }
    }
}
