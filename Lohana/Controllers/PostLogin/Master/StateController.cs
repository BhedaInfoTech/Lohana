using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lohana.Models.Master;
using LohanaBusinessEntities.State;
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
    public class StateController : BaseController
    {
        public StateRepo _sRepo;

        public StateController()
        {
            _sRepo = new StateRepo();
        }

        [AuthorizeUser(RoleModule.State, Function.View)]
        public ActionResult Index(StateViewModel sViewModel)
        {

            Set_Date_Session(sViewModel.State);

            sViewModel.Countries = _sRepo.drpGetCountries();

            return View("Index", sViewModel);
        }

        [AuthorizeUser(RoleModule.State, Function.View)]
        public ActionResult Search()
        {
            return View();
        }

        [AuthorizeUser(RoleModule.State, Function.Create)]
        public JsonResult Insert(StateViewModel sViewModel)
        
        {
            try
            {
                Set_Date_Session(sViewModel.State);

                sViewModel.State.StateId = _sRepo.Insert(sViewModel.State);

                sViewModel.FriendlyMessage.Add(MessageStore.Get("STATE01"));

                Logger.Debug("State Controller Insert");

            }
            catch(Exception ex)
            {
                sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("State Controller - Insert " + ex.Message);
            }

            return Json(sViewModel);
        }

        [AuthorizeUser(RoleModule.State, Function.View)]
        public JsonResult GetStates(StateViewModel sViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = sViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {

                pViewModel.dt = _sRepo.GetStates(sViewModel.State.CountryId, sViewModel.State.StateCode, sViewModel.State.StateName, ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("State Controller GetStates");
            }

            catch (Exception ex)
            {

                sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("State Controller - GetStates" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        [AuthorizeUser(RoleModule.State, Function.Edit)]
        public JsonResult Update(StateViewModel sViewModel)
        {
            try
            {
                Set_Date_Session(sViewModel.State);

                _sRepo.Update(sViewModel.State);

                sViewModel.FriendlyMessage.Add(MessageStore.Get("STATE02"));

                Logger.Debug("State Controller Update");

            }
            catch (Exception ex)
            {

                sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("State Controller - Update  " + ex.Message);
            }

            return Json(sViewModel);
        }

        [AuthorizeUser(RoleModule.State, Function.View)]
        public JsonResult CheckStateCodeExist (string stateCode)
        
        {
            bool check = false;

            StateViewModel sViewModel = new StateViewModel();

            try
            {
                check = _sRepo.CheckStateCodeExist(stateCode);

                Logger.Debug("State Controller CheckStateCodeExist");
            }
            catch (Exception ex)
            {
                Logger.Error("State Controller - CheckStateCodeExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);
        }

        [AuthorizeUser(RoleModule.State, Function.View)]
        public JsonResult CheckStateNameExist(string stateName)
        {
            bool check = false;

            StateViewModel sViewModel = new StateViewModel();

            try
            {
                check = _sRepo.CheckStateNameExist(stateName);

                Logger.Debug("State Controller CheckStateNameExist");
            }
            catch (Exception ex)
            {
                Logger.Error("State Controller - CheckStateNameExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);

        }


    }
}
