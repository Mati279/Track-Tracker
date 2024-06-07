using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;
using BCrypt.Net;
using Microsoft.Data.SqlClient;
using ASPTrackTracker.Auth;


namespace ASPTrackTracker.Pages.Users
{
    public class UserRegisterModel : AuthenticatedPageModel
    {
        private readonly IUserData userData;

        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public string eMail { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string RepeatedPassword { get; set; }

        [BindProperty]
        public string ErrorMessage { get; set; }

        public UserRegisterModel(IUserData userData)
        {
            this.userData = userData;
        }

        public async Task<IActionResult> OnPostAsync()
        {

             if (string.IsNullOrEmpty(RepeatedPassword) || RepeatedPassword != Password)
            {
                ErrorMessage = "Please rewrite your password exactly.";
                return Page();
            }

            try
            {
                UserModel newUser = new UserModel
                {
                    Name = UserName,
                    eMail = eMail,
                    Password = BCrypt.Net.BCrypt.HashPassword(Password)
                };
                try
                {
                    int Id = await userData.Create(newUser);
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        ErrorMessage = "Mail already in use.";
                        return Page();
                    }
                }
            }
            catch
            {
                ErrorMessage = "Error.";
                return Page();
            }
            return RedirectToPage("/Users/UserLogin");
        }
    }
}
