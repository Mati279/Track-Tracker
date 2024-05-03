using System.Reflection.Metadata.Ecma335;

namespace ASPTrackTracker.Comparers
{
    internal class AverageComparer : IComparer<ComparableBase>
    {
        
        public int Compare(ComparableBase? x, ComparableBase? y)
        {

            return y.AverageScore.CompareTo(x.AverageScore);
        }
    }
}
