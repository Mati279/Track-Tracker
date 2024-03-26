using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class UserModel : ITrackHolderModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string eMail { get; set; }
        public string Password { get; set; }
    }
}
