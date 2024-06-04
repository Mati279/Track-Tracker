using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class UserModel : ITrackHolderModel
    {
        public int Id { get; set; }

        [StringLength(50, ErrorMessage = "Name too long.")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "A valid email address is required.")]
        public string eMail { get; set; }

        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string Password { get; set; }
    }
}
