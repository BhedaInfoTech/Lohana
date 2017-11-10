using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Lohana.Models.Master;
using LohanaBusinessEntities.Designation;
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
    public class DesignationController : BaseController
    {
        public DesignationRepo _dRepo;

        public DesignationController()
        {
            _dRepo = new DesignationRepo();
        }

        [AuthorizeUser(RoleModule.Designation, Function.View)]
        public ActionResult Index(DesignationViewModel dViewModel)
        {
            return View("Index", dViewModel);
        }

        [AuthorizeUser(RoleModule.Designation, Function.View)]
        public ActionResult Search()
        {
            return View();
        }

        [AuthorizeUser(RoleModule.Designation, Function.Create)]
        public JsonResult Insert(DesignationViewModel dViewModel)
        
        {
            try
            {
                Set_Date_Session(dViewModel.Designation);

                dViewModel.Designation.DesignationId = _dRepo.Insert(dViewModel.Designation);

                dViewModel.FriendlyMessage.Add(MessageStore.Get("D01"));

                Logger.Debug("Designation Controller Insert");

            }
            catch(Exception ex)
            {
                dViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Designation Controller - Insert " + ex.Message);
            }

            return Json(dViewModel);
        }

        [AuthorizeUser(RoleModule.Designation, Function.View)]
        public JsonResult GetDesignations(DesignationViewModel dViewModel)
        {

            PaginationInfo pager = new PaginationInfo();

            pager = dViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _dRepo.GetDesignations(dViewModel.Designation.DesignationName,ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("Designation Controller GetDesignations");
             
            }

            catch (Exception ex)
            {
                dViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Designation Controller - GetDesignations" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        [AuthorizeUser(RoleModule.Designation, Function.Edit)]
        public JsonResult Update(DesignationViewModel dViewModel)
        {
            try
            {
                Set_Date_Session(dViewModel.Designation);

                _dRepo.Update(dViewModel.Designation);

                dViewModel.FriendlyMessage.Add(MessageStore.Get("D02"));

                Logger.Debug("Designation Controller Update");
            }
            catch (Exception ex)
            {

                dViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Designation Controller - Update  " + ex.Message);
            }

            return Json(dViewModel);
        }

        [AuthorizeUser(RoleModule.Designation, Function.View)]
        public JsonResult CheckDesignationNameExist(string designationName)
        {
            bool check = false;

            DesignationViewModel dViewModel = new DesignationViewModel();

            try
            {
                check = _dRepo.CheckDesignationNameExist(designationName);

                Logger.Debug("Designation Controller CheckDesignationNameExist");
            }
            catch (Exception ex)
            {
                Logger.Error("Designation Controller - CheckDesignationNameExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);

        }

        [AuthorizeUser(RoleModule.Designation, Function.View)]
        public PartialViewResult GetDesignationPartialView()
        {
            DesignationViewModel dViewModel = new DesignationViewModel();

            return PartialView("_designation", dViewModel);
        }

    }
}
