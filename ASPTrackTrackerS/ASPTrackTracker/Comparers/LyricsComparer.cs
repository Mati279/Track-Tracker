namespace ASPTrackTracker.Comparers
{
    internal class LyricsComparer : IComparer<ComparableBase>
    {

        public int Compare(ComparableBase? x, ComparableBase? y)
        {

            return y.LyricsScore.CompareTo(x.LyricsScore);
        }
    }
}
