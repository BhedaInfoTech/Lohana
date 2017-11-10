using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lohana.Common
{
	public class CustomRazorViewEngine:RazorViewEngine
	{
		public CustomRazorViewEngine()
			: base()
		{
			//ViewLocationFormats = new[] { 
			//    "~/Views/CMS/{1}/{0}.cshtml", 
			//    "~/Views/CRM/{1}/{0}.cshtml", 
			//    "~/Views/Planning/{1}/{0}.cshtml", 
			//    "~/Views/PostLogin/{1}/{0}.cshtml",
			//    "~/Views/PreLogin/{1}/{0}.cshtml", 
			//    "~/Views/Sales/{1}/{0}.cshtml", 
			//    "~/Views/Shared/{0}.cshtml",
			//    "~/Views/SystemConfig/{1}/{0}.cshtml"
			//     };

			ViewLocationFormats = new[] { 

                //This would search for view in
                //Views/PostLogin/<calling controllers name>/<view name>.cshtml

                //This would search for view in
                //Views/PostLogin/CRM/<calling controllers name>/<view name>.cshtml

                //This would search for view in
                //Views/PostLogin/Masters/<calling controllers name>/<view name>.cshtml

                //This would search for view in
                //Views/PreLogin/<calling controllers name>/<view name>.cshtml
                "~/Views/PreLogin/{1}/{0}.cshtml",

                "~/Views/Shared/{0}.cshtml",

				"~/Views/PostLogin/Master/{1}/{0}.cshtml", 

				"~/Views/PostLogin/{1}/{0}.cshtml", 

                "~/Views/PostLogin/Master/Vehicle/{1}/{0}.cshtml", 

                //"~/Views/PostLogin/Dashboard/{1}/{0}.cshtml", 
            };

			this.ViewLocationFormats = ViewLocationFormats;
			this.PartialViewLocationFormats = ViewLocationFormats;
			this.MasterLocationFormats = ViewLocationFormats;
		}
	}
}