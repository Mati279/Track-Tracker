using DataLibrary.Data;
using DataLibrary.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using ASPTrackTracker.Auth;

namespace ASPTrackTracker.Pages.Users
{
    public class UserLoginModel : AuthenticatedPageModel
    {
        private readonly IUserData userData;

        [BindProperty]
        public string eMail { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string errorMessage { get; set; }

        public UserLoginModel(IUserData userData)
        {
            this.userData = userData;
        }
        public async Task<IActionResult> OnPostAsync()
        {

            UserModel user = await GetUserByEmail(eMail);

            if (string.IsNullOrEmpty(Password))
            {
                errorMessage = "A password is required.";
                return Page();
            }
            else
            {

                if (user == null || !BCrypt.Net.BCrypt.Verify(Password, user?.Password))
                {
                    errorMessage = "Invalid email or password.";
                    return Page();
                }
            }
            var claims = new List<Claim>
            {
                 new Claim(ClaimTypes.Name, user.Name),
                 new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true // Esto hace que la cookie sea persistente
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);


            return RedirectToPage("/Index");
        }

        public async Task<UserModel> GetUserByEmail(string eMail)
        {
            List<UserModel> allUsers = new List<UserModel>();

            allUsers = await userData.GetAll<UserModel>();  

            foreach(UserModel user in allUsers)
            {
                if(user.eMail == eMail)
                {
                    return user;
                }
            }
            return null;
        }
    }
}
