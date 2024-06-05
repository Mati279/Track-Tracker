using DataLibrary.BL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace ASPTrackTracker.Auth
{
    public class AuthenticatedPageModel : PageModel
    {
        public int UserId { get; private set; }

        public override void OnPageHandlerExecuting(PageHandlerExecutingContext context)
        {
            base.OnPageHandlerExecuting(context);

            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim != null)
            {
                UserId = int.Parse(userIdClaim.Value);
            }
        }
    }
}
