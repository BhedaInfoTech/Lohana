using LohanaBusinessEntities.City;
using LohanaRepo.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using LohanaBusinessEntities.Common;
using LohanaRepo.Utilities;

namespace Lohana.Controllers.PostLogin.Master
{
    public class BedController : Controller
    {
        //
        // GET: /Bed/

		public HotelRepo _hRepo;


		public BedController()
		{
			_hRepo = new HotelRepo();
		}

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

		public JsonResult GetCities(string q, int page)
		{
			List<CityInfo> cities = new List<CityInfo>();

			int totalCount = 0;

			try
			{
				cities = _hRepo.drpGetCountryStateCity();

				//cities = cities.Where(a => a.CityName.Contains(q) && a.CityId != selectedId).ToList();

				totalCount = cities.Count;

				//cities = cities.Skip((page-1) * 10).Take(10).ToList();

                //cities.Add(_hRepo.drpGetCountryStateCity().Where(a => a.CityId == selectedId).FirstOrDefault());
			}
			catch(Exception ex)
			{

			}

			return Json(new
			{
				cities, totalCount, page
			},JsonRequestBehavior.AllowGet); //  { cities:cities, totalCount :totalCount, page:page} ,JsonRequestBehavior.AllowGet);
		}

		
    }
}
