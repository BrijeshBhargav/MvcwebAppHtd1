using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
namespace MVCcoreWebAppHTD1
{
    public class SetSessionGlobally:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filtercontext)
        {
            var value = filtercontext.HttpContext.Session.GetString("UserName");
            if(value == null)
            {
                filtercontext.Result =
                    new RedirectToRouteResult(
                        new RouteValueDictionary {
                        {
                           "Controller","student" },
                            {"action","Login" }
                       
                        });
            }
            
        }
    }
}
