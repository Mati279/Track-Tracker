using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BL
{
    public interface ITrackHolder
    {
        int Id { get; set; }
        string Name { get; set; }
        Task<List<TrackModel>> GetTracks();
    }
}
