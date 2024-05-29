using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class TrackModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string Link { get; set; }
        public int UserId { get; set; } 
        public int ArtistId { get; set; } 
        public int GenreId { get; set; } 
        public int StyleId { get; set; } 
    }
}
