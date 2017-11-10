using Lohana.Models.Master;
using LohanaBusinessEntities;
using LohanaBusinessEntities.Common;
using LohanaRepo.Master;
using LohanaHelper;

using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;

namespace Lohana.Controllers
{
    public class BaseController : Controller
    {

        //public ActionResult Index()
        //{
        //    return View();
        //}

        public void Set_Date_Session(object obj)
        {
            SessionInfo session = new SessionInfo();
            if (Session["SessionInfo"] != null)
            {
                session = (SessionInfo)HttpContext.Session["SessionInfo"];
            }
            PropertyInfo prop = obj.GetType().GetProperty("CreatedDate");

            prop.SetValue(obj, DateTime.Now);

            prop = obj.GetType().GetProperty("UpdatedDate");

            prop.SetValue(obj, DateTime.Now);

            prop = obj.GetType().GetProperty("CreatedBy");

            prop.SetValue(obj, session.UserId);

            prop = obj.GetType().GetProperty("UpdatedBy");

            prop.SetValue(obj, session.UserId);

         
        }


		public string GetRandomColorName()
		{
			Random random = new Random();

			Color color = Color.FromArgb(random.Next(0,255),random.Next(0,255),random.Next(0,255));

			return color.Name;
		}
      
    }
}
