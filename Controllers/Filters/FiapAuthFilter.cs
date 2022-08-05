using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Fiap.Web.AspNet3.Controllers.Filters
{
    public class FiapAuthFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            var email = context.HttpContext.Session.GetString("email");
            if ( String.IsNullOrEmpty (email) )
            {
                context.Result = new RedirectResult("~/Login/Index");
            } 
            else
            {
                base.OnActionExecuting(context);
            }

        }
    }
}
