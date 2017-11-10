using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Lohana.Models.Master;
using LohanaBusinessEntities.FacilityType;
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
    public class FacilityTypeController : BaseController
    {

        public FacilityTypeRepo _ftRepo;

        public FacilityTypeController()
        {
            _ftRepo = new FacilityTypeRepo();
        }

        [AuthorizeUser(RoleModule.FacilityType, Function.View)]
        public ActionResult Index(FacilityTypeViewModel ftViewModel)
        {
            return View("Index", ftViewModel);
        }

        [AuthorizeUser(RoleModule.FacilityType, Function.View)]
        public ActionResult Search()
        {
            return View();
        }

        [AuthorizeUser(RoleModule.FacilityType, Function.Create)]
        public JsonResult Insert(FacilityTypeViewModel ftViewModel)
        {
            try
            {
                Set_Date_Session(ftViewModel.FacilityType);

                ftViewModel.FacilityType.FacilityTypeId = _ftRepo.Insert(ftViewModel.FacilityType);

                ftViewModel.FriendlyMessage.Add(MessageStore.Get("FT01"));

                Logger.Debug("FacilityType Controller Insert");

            }
            catch (Exception ex)
            {
                ftViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("FacilityType Controller - Insert " + ex.Message);
            }

            return Json(ftViewModel);
        }

        [AuthorizeUser(RoleModule.FacilityType, Function.View)]
        public JsonResult GetFacilityTypes(FacilityTypeViewModel ftViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = ftViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                
                pViewModel.dt = _ftRepo.GetFacilityTypes(ftViewModel.FacilityType.FacilityTypeName,ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("FacilityType Controller GetFacilityTypes");
            }

            catch (Exception ex)
            {
                ftViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("FacilityType Controller - GetFacilityTypes" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        [AuthorizeUser(RoleModule.FacilityType, Function.Edit)]
        public JsonResult Update(FacilityTypeViewModel ftViewModel)
        {
            try
            {
                Set_Date_Session(ftViewModel.FacilityType);

                _ftRepo.Update(ftViewModel.FacilityType);

                ftViewModel.FriendlyMessage.Add(MessageStore.Get("FT02"));

                Logger.Debug("FacilityType Controller Update");
            }
            catch (Exception ex)
            {
                ftViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("FacilityType Controller - Update  " + ex.Message);
            }

            return Json(ftViewModel);
        }

        [AuthorizeUser(RoleModule.FacilityType, Function.View)]
        public JsonResult CheckFacilityTypeNameExist(string facilitytypeName)
        {
            bool check = false;

            FacilityTypeViewModel ftViewModel = new FacilityTypeViewModel();

            try
            {
                check = _ftRepo.CheckFacilityTypeNameExist(facilitytypeName);

                Logger.Debug("FacilityType Controller CheckFacilityTypeNameExist");
            }
            catch (Exception ex)
            {
                Logger.Error("FacilityType Controller - CheckFacilityTypeNameExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);

        }
    }
}
