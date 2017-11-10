using Lohana.Common;
using Lohana.Models.Master;

using System.Web.Mvc;

namespace Lohana.Controllers.PostLogin.Error
{
    public class ErrorController : Controller
    {
        public ActionResult UnAuthorizedAccess()
        {
            return View("Error");

            //return RedirectToAction("Index", "Login");
        }

        public JsonResult UnAuthorizedAjaxRequest()
        {
            AuthenticationViewModel model = new AuthenticationViewModel();

            model.FriendlyMessage.Add(MessageStore.Get("AUTHENTICATION01"));

            return Json(model, JsonRequestBehavior.AllowGet);            
        }
    }
}
