using DataLibrary.Data;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BL
{
    public class User : TrackHolderBase
    {
        private ITrackData trackData;

        public int Id { get; set; }
        public string Name { get; set; }
        public string eMail { get; set; }
        public string Password { get; set; }


        public List<TrackModel> Tracks { get; private set; } = new List<TrackModel> { };

        public User(ITrackData _trackData, int _id, string _name, string _eMail, string _password) : base(_trackData, _id, _name)
        {
            trackData = _trackData;
            Id = _id;
            Name = _name;
            eMail = _eMail;
            Password = _password;
        }
    }
}
