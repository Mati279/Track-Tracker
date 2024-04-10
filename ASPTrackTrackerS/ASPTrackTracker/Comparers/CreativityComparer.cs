namespace ASPTrackTracker.Comparers
{
    internal class CreativityComparer : IComparer<TrackComparable>
    {

        public int Compare(TrackComparable? x, TrackComparable? y)
        {

            return y.CreativityScore.CompareTo(x.CreativityScore);
        }
    }
}
