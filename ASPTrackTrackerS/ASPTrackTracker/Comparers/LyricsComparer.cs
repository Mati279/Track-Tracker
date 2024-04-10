namespace ASPTrackTracker.Comparers
{
    internal class LyricsComparer : IComparer<TrackComparable>
    {

        public int Compare(TrackComparable? x, TrackComparable? y)
        {

            return y.LyricsScore.CompareTo(x.LyricsScore);
        }
    }
}
