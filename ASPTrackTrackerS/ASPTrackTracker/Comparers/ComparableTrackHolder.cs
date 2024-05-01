namespace ASPTrackTracker.Comparers
{
    public class ComparableTrackHolder
    {
        public string Name { get; }
        public string Artist { get; }
        public string Genre { get; }
        public string Style { get; }
       

        public ComparableTrackHolder(string name, string artist, string genre, string style)
        {
            Name = name;
            Artist = artist;
            Genre = genre;
            Style = style;
        }

    }
}
