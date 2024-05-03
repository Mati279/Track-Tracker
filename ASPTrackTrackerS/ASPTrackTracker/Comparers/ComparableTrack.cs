using DataLibrary.BL;
using DataLibrary.Models;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata.Ecma335;

namespace ASPTrackTracker.Comparers
{
    public class ComparableTrack : ComparableBase
    {

        public string Link { get; set; }
        public string UserName { get; set; }
        public string ArtistName { get; set; }
        public string StyleName { get; set; }
        public int Voted { get; set; }


        public ComparableTrack(string name, string link, string userName, string artistName, string genre, string styleName):base(name, genre)
        {
            Name = name;
            Link = link;
            UserName = userName;
            ArtistName = artistName;
            Genre = genre;
            StyleName = styleName;
        }
       
        
    }
}
