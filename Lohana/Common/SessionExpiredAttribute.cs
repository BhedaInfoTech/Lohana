using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lohana.Common
{
    public class SessionExpiredAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContext ctx = HttpContext.Current;           
            
            if (HttpContext.Current.Session["SessionInfo"] == null)
            {
                filterContext.Result = new RedirectResult("~/Home/SystemError");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}