using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lohana.Controllers.PreLogin
{
    public class LoginController : Controller
    {
     
        public ActionResult Index()
        {
            if (Session["SessionInfo"] != null)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {                
                return View("Index");
            }
        }

          

    }
}
