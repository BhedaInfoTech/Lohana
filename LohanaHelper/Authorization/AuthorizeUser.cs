using System;
using System.Web.Mvc;
using System.Web;
using System.Net;
using System.Linq;

using LohanaHelper.Logging;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities;

namespace LohanaHelper.Authorization
{
    /// <summary>
    /// Contains method for authorization of user depending on access function
    /// </summary>

    public class AuthorizeUser : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly int _moduleId;

        private readonly int _functionId1;

        /// <summary>
        /// Initializes a new instance of the <see cref="PKAuthorize"/> class.
        /// </summary>
        /// <param name="appFunction">The app function.</param>
        public AuthorizeUser(RoleModule module, Function function1)
        {
            _moduleId = Convert.ToInt32(module);

            _functionId1 = Convert.ToInt32(function1);            
        }

        /// <summary>
        /// Called when authorization is required.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        /// <remarks></remarks>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            SessionInfo sessionInfo = (SessionInfo)HttpContext.Current.Session["SessionInfo"];

            //check if user contains specified access function
            if (HasAccess(sessionInfo, _moduleId, _functionId1))
            {
                Logger.Debug(string.Format("{0} Accessed {1} on {2}", sessionInfo.UserName, _moduleId, DateTime.Now.ToString()));
            }
            else
            {
                filterContext.Result = new HttpUnauthorizedResult();

                /* check if request is ajax, then send unathorize status code.*/
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    HttpContext.Current.Response.Clear();                      
                                      
                    HttpContext.Current.Response.StatusCode = Convert.ToInt32(HttpStatusCode.Unauthorized);

                    filterContext.RequestContext.HttpContext.Response.Redirect(string.Format("/Error/UnAuthorizedAjaxRequest/?returnURL={0}", HttpContext.Current.Request.Url.AbsolutePath));
                }
                else
                {
                    filterContext.RequestContext.HttpContext.Response.Redirect(string.Format("/Error/UnAuthorizedAccess/?returnURL={0}", HttpContext.Current.Request.Url.AbsolutePath));
                }

                // Log Activity
                Logger.Debug(string.Format("Unauthorized user tried accessing {0} on {1}", _moduleId, DateTime.Now.ToString()));
            }
        }

        public static bool HasAccess(SessionInfo sessionInfo, int _moduleId, int _functionId1)
        {
            bool hasAccess = false;

            if (sessionInfo != null && sessionInfo.LstModule != null && sessionInfo.LstModule.Count > 0
                && sessionInfo.LstModule.Exists(c => c.ModuleId == _moduleId && c.HasAccess == true))                
            {  
                if (_functionId1 == Convert.ToInt32(Function.Create) && sessionInfo.LstModule.Exists(c => c.ModuleId == _moduleId && c.IsCreate == true))
                {
                    hasAccess = true;
                }
                else if (_functionId1 == Convert.ToInt32(Function.Edit) && sessionInfo.LstModule.Exists(c => c.ModuleId == _moduleId && c.IsEdit == true))
                {
                    hasAccess = true;
                }
                else if (_functionId1 == Convert.ToInt32(Function.View) && sessionInfo.LstModule.Exists(c => c.ModuleId == _moduleId && c.IsView == true))
                {
                    hasAccess = true;
                }
                else if (_functionId1 == Convert.ToInt32(Function.Delete))
                {
                    hasAccess = true;
                }
            }

            return hasAccess;
        }
    }
}
