using System;
using System.Web.Mvc;

using Lohana.Models.Master;
using LohanaBusinessEntities.Common;
using LohanaRepo.Master;
using Newtonsoft.Json;
using LohanaHelper.Logging;
using Lohana.Common;
using Lohana.Models;
using LohanaHelper.Authorization;
using LohanaBusinessEntities;

namespace Lohana.Controllers.PostLogin.Master
{
    [SessionExpired]
    public class CountryController : BaseController
    {
        public CountryRepo _cRepo;

        public CountryController()
        {
            _cRepo = new CountryRepo();
        }

        [AuthorizeUser(RoleModule.Country, Function.View)]
        public ActionResult Index(CountryViewModel cViewModel)
        {
            return View("Index", cViewModel);
        }

        [AuthorizeUser(RoleModule.Country, Function.View)]
        public ActionResult Search()
        {
            return View();
        }

        [AuthorizeUser(RoleModule.Country, Function.Create)]
        public JsonResult Insert(CountryViewModel cViewModel)
        {
            try
            {
                Set_Date_Session(cViewModel.Country);

                cViewModel.Country.CountryId = _cRepo.Insert(cViewModel.Country);

                cViewModel.FriendlyMessage.Add(MessageStore.Get("COUNTRY01"));

                Logger.Debug("Country Controller Insert");

            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Country Controller - Insert " + ex.Message);
            }

            return Json(cViewModel);
        }

        [AuthorizeUser(RoleModule.Country, Function.View)]
        public JsonResult GetCountries(CountryViewModel cViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = cViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _cRepo.GetCountries(cViewModel.Country.CountryCode, cViewModel.Country.CountryName, ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("Country Controller GetCountries");
            }

            catch (Exception ex)
            {
                cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Country Controller - GetCountries" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        [AuthorizeUser(RoleModule.Country, Function.Edit)]
        public JsonResult Update(CountryViewModel cViewModel)
        {
            try
            {
                Set_Date_Session(cViewModel.Country);

                _cRepo.Update(cViewModel.Country);

                cViewModel.FriendlyMessage.Add(MessageStore.Get("COUNTRY02"));

                Logger.Debug("Country Controller Update");
            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Country Controller - Update  " + ex.Message);
            }

            return Json(cViewModel);
        }

        [AuthorizeUser(RoleModule.Country, Function.View)]
        public JsonResult CheckCountryCodeExist(string countryCode)
        {
            bool check = false;

            CountryViewModel cViewModel = new CountryViewModel();

            try
            {
                check = _cRepo.CheckCountryCodeExist(countryCode);

                Logger.Debug("Country Controller CheckCountryCodeExist");
            }
            catch (Exception ex)
            {
                Logger.Error("Country Controller - CheckCountryCodeExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);
        }

        [AuthorizeUser(RoleModule.Country, Function.View)]
        public JsonResult CheckCountryNameExist(string countryName)
        {
            bool check = false;

            CountryViewModel cViewModel = new CountryViewModel();

            try
            {
                check = _cRepo.CheckCountryNameExist(countryName);

                Logger.Debug("Country Controller CheckCountryNameExist");
            }
            catch (Exception ex)
            {
                Logger.Error("Country Controller - CheckCountryNameExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);

        }

    }
}





















