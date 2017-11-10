using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Lohana.Models.Master;
using LohanaBusinessEntities.Facility;
using LohanaBusinessEntities.Common;
using LohanaRepo.Master;
using LohanaHelper;
using Newtonsoft.Json;
using LohanaHelper.Logging;
using Lohana.Common;
using Lohana.Models;
using LohanaHelper.Authorization;
using LohanaBusinessEntities;

namespace Lohana.Controllers.PostLogin.Master
{
    public class FacilityController : BaseController
    {
       
        public FacilityRepo _sRepo;

        public FacilityController()
        {
            _sRepo = new FacilityRepo();
        }

        [AuthorizeUser(RoleModule.Facility, Function.View)]
        public ActionResult Index(FacilityViewModel fViewModel)
        {

            Set_Date_Session(fViewModel.Facility);

            fViewModel.FacilityTypes = _sRepo.drpGetFacilityTypes();



            return View("Index", fViewModel);
        }

        [AuthorizeUser(RoleModule.Facility, Function.View)]
        public ActionResult Search()
        {
            return View();
        }

        [AuthorizeUser(RoleModule.Facility, Function.Create)]
        public JsonResult Insert(FacilityViewModel fViewModel)
        
        {
            try
            {
                Set_Date_Session(fViewModel.Facility);

                fViewModel.Facility.FacilityId = _sRepo.Insert(fViewModel.Facility);

                fViewModel.FriendlyMessage.Add(MessageStore.Get("F01"));

                Logger.Debug("Facility Controller Insert");
            }
            catch(Exception ex)
            {
                fViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Facility Controller - Insert " + ex.Message);
            }

            return Json(fViewModel);
        }

        [AuthorizeUser(RoleModule.Facility, Function.View)]
        public JsonResult GetFacilities(FacilityViewModel fViewModel)
        {

            PaginationInfo pager = new PaginationInfo();

            pager = fViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _sRepo.GetFacilities(fViewModel.Facility.FacilityTypeId, fViewModel.Facility.FacilityName,ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("Facility Controller GetFacilities");

            }

            catch (Exception ex)
            {

                fViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Facility Controller - GetFacilities" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        [AuthorizeUser(RoleModule.Facility, Function.Edit)]
        public JsonResult Update(FacilityViewModel fViewModel)
        {
            try
            {
                Set_Date_Session(fViewModel.Facility);

                _sRepo.Update(fViewModel.Facility);

                fViewModel.FriendlyMessage.Add(MessageStore.Get("F02"));

                Logger.Debug("Facility Controller Update");
            }
            catch (Exception ex)
            {

                fViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Facility Controller - Update  " + ex.Message);
            }

            return Json(fViewModel);
        }

        [AuthorizeUser(RoleModule.Facility, Function.View)]
        public JsonResult CheckFacilityNameExist(string facilityName)
        {
            bool check = false;

            FacilityViewModel fViewModel = new FacilityViewModel();

            try
            {
                check = _sRepo.CheckFacilityNameExist(facilityName);

                Logger.Debug("Facility Controller CheckFacilityNameExist");
            }
            catch (Exception ex)
            {
                Logger.Error("Facility Controller - CheckFacilityNameExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);

        }


    }
}
