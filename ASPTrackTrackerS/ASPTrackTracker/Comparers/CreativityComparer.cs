namespace ASPTrackTracker.Comparers
{
    internal class CreativityComparer : IComparer<ComparableTrack>
    {

        public int Compare(ComparableTrack? x, ComparableTrack? y)
        {

            return y.CreativityScore.CompareTo(x.CreativityScore);
        }
    }
}
