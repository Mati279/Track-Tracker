namespace ASPTrackTracker.Comparers
{
    internal class LyricsComparer : IComparer<ComparableTrack>
    {

        public int Compare(ComparableTrack? x, ComparableTrack? y)
        {

            return y.LyricsScore.CompareTo(x.LyricsScore);
        }
    }
}
