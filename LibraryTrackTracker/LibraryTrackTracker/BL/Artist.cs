using DataLibrary.Data;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BL
{
    public class Artist : TrackHolderBase
    {
        private readonly ITrackData trackData;
        public int Id { get; set; }
        public string Name { get; set; }

        public List<TrackModel> Tracks { get; private set; } = new List<TrackModel> { };

        public Artist(ITrackData _trackData, int _id, string _name) : base(_trackData, _id, _name)
        {
            trackData = _trackData;
            Id = _id;
            Name = _name;
        }
    }
}
