using Lohana.Models;
using LohanaHelper.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lohana.Controllers.PostLogin
{
    public class CommonController : Controller
    {
        //
        // GET: /Common/

		public PartialViewResult GetConformationPopup(string message)
		{
			CommonViewModel cViewModel = new CommonViewModel();
			try
			{
				cViewModel.Message = message;
			}
			catch(Exception ex)
			{
				Logger.Error("Common Controller - GetConformationPopup  " + ex.Message);
			}

			return PartialView("_ConformationPopup", cViewModel);
		}

    }
}
