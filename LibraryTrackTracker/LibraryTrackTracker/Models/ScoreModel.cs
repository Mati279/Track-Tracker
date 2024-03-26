using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class ScoreModel
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public int TrackId {  get; set; }
        public int UserId { get; set; }
        public string Stat {  get; set; }
    }
}
