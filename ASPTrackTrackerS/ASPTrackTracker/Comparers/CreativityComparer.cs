namespace ASPTrackTracker.Comparers
{
    internal class CreativityComparer : IComparer<ComparableBase>
    {

        public int Compare(ComparableBase? x, ComparableBase? y)
        {

            return y.CreativityScore.CompareTo(x.CreativityScore);
        }
    }
}
