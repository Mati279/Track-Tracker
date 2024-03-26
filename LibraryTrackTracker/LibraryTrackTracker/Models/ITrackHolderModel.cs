using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public interface ITrackHolderModel
    {
        public int Id { get; }
        public string Name { get; }
    }
}
