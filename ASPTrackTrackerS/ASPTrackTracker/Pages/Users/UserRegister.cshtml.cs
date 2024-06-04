using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;
using BCrypt.Net;
using Microsoft.Data.SqlClient;


namespace ASPTrackTracker.Pages.Users
{
    public class UserRegisterModel : PageModel
    {
        private readonly IUserData userData;

        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public string eMail { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string errorMessage { get; set; }

        public UserRegisterModel(IUserData userData)
        {
            this.userData = userData;
        }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
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
                    errorMessage = "Mail already in use.";
                    return Page();
                }
            }

            return Page();
        }

        public async Task<bool> CheckEmail(string email)
        {
            List<string> allEmails = new List<string>();

            List<UserModel> allUsers = new List<UserModel>();

            allUsers = await userData.GetAll<UserModel>();

            foreach (var user in allUsers)
            {
                if (allEmails.Contains(user.eMail))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
