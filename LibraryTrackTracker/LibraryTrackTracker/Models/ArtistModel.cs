﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class ArtistModel : ITrackHolderModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GenreId { get; set; }
    }
}
