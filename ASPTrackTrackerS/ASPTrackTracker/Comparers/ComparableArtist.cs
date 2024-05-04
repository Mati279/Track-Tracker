namespace ASPTrackTracker.Comparers
{
    public class ComparableArtist : ComparableBase
    {
        public int ModelId { get; set; }
        public ComparableArtist(string name, string genre, int modelId) : base(name, genre, modelId)
        {
            Name = name;
            Genre = genre;
            ModelId = modelId;
        }
    }
}
