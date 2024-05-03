namespace ASPTrackTracker.Comparers
{
    internal class VoicesComparer : IComparer<ComparableBase>
    {

        public int Compare(ComparableBase? x, ComparableBase? y)
        {

            return y.VoicesScore.CompareTo(x.VoicesScore);
        }
    }
}
