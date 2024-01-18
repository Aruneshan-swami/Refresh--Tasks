using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TimeMate.Controllers
{
    public class CustomAuthenticationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Your authentication logic goes here
            // For example, check if the user is logged in and has a valid session
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                // Redirect the user to the login page or return an unauthorized response
                context.Result = new UnauthorizedResult();
            }
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Optionally, you can handle the action result after the authentication
            // For example, you can redirect the user to a specific page if they are unauthorized
            if (context.Result == null || context.Result is UnauthorizedResult)
            {
                // Redirect the user to the login page or return an unauthorized response
                context.Result = new RedirectToActionResult("Login", "Account", null);
            }
        }
    }
}
