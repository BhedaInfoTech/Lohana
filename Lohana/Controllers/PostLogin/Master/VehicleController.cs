using Lohana.Common;
using Lohana.Models;
using Lohana.Models.Master;
using LohanaBusinessEntities;
using LohanaBusinessEntities.Common;
using LohanaHelper.Authorization;
using LohanaHelper.Logging;
using LohanaRepo.Master;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lohana.Controllers.PostLogin.Master
{
    public class VehicleController : BaseController
    {
        public VehicleRepo _vRepo;

        public VehicleController()
        {
            _vRepo = new VehicleRepo();
        }

        [AuthorizeUser(RoleModule.Vehicle, Function.View)]
        public ActionResult Index(VehicleViewModel vViewModel)
        {
            if (TempData["vViewModel"] != null)
            {
                vViewModel = (VehicleViewModel)TempData["vViewModel"];
            }

            Set_Date_Session(vViewModel.Vehicle);

            vViewModel.VehicleTypeId = _vRepo.drpGetVehicleType();

            vViewModel.VehicleBrandId = _vRepo.drpGetVehicleBrand();

            return View("Index", vViewModel);
        }

        [AuthorizeUser(RoleModule.Vehicle, Function.View)]
        public ActionResult Search(VehicleViewModel vViewModel)
		{
            try
            {
                Set_Date_Session(vViewModel.Vehicle);

                vViewModel.VehicleTypeId = _vRepo.drpGetVehicleType();

                vViewModel.VehicleBrandId = _vRepo.drpGetVehicleBrand();
            }
            catch(Exception ex)
            {
                vViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Vehicle Controller - Insert " + ex.Message);
            }

            return View("Search", vViewModel);
                        
		}

        [AuthorizeUser(RoleModule.Vehicle, Function.Create)]
        public JsonResult Insert(VehicleViewModel vViewModel)
        {
            try
            {
                Set_Date_Session(vViewModel.Vehicle);

                vViewModel.Vehicle.VehicleId = _vRepo.Insert(vViewModel.Vehicle);

                vViewModel.FriendlyMessage.Add(MessageStore.Get("Ve01"));

                Logger.Debug("Vehicle Controller Insert");

            }
            catch (Exception ex)
            {
                vViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Vehicle Controller - Insert " + ex.Message);
            }

            return Json(vViewModel);
        }

        [AuthorizeUser(RoleModule.Vehicle, Function.View)]
        public JsonResult GetVehicles(VehicleViewModel vViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = vViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _vRepo.GetVehicles(vViewModel.Vehicle.VehicleName, vViewModel.Vehicle.VehicleTypeId, vViewModel.Vehicle.VehicleBrandId, ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("Vehicle Controller GetVehicles");
            }

            catch (Exception ex)
            {
                vViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Vehicle Controller - GetVehicles" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        [AuthorizeUser(RoleModule.Vehicle, Function.View)]
        public ActionResult GetVehicleById(VehicleViewModel vViewModel)
       {
            try
            {
                vViewModel.Vehicle = _vRepo.GetVehicleById(vViewModel.Vehicle.VehicleId);

                Logger.Debug("Vehicle Controller GetVehicleById");
            }
            catch (Exception ex)
            {
                vViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Vehicle Controller - GetVehicleById" + ex.ToString());
            }

            TempData["vViewModel"] = vViewModel;

            return RedirectToAction("Index");
        }

        [AuthorizeUser(RoleModule.Vehicle, Function.Edit)]
        public JsonResult Update(VehicleViewModel vViewModel)
        {
            try
            {
                Set_Date_Session(vViewModel.Vehicle);

                _vRepo.UpdateVehicle(vViewModel.Vehicle);

                vViewModel.FriendlyMessage.Add(MessageStore.Get("Ve02"));

                Logger.Debug("Vehicle Controller UpdateVehicle");
            }
            catch (Exception ex)
            {

                vViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Vehicle Controller - UpdateVehicle  " + ex.Message);
            }

            return Json(vViewModel);

        }

        [AuthorizeUser(RoleModule.Vehicle, Function.View)]
        public JsonResult CheckVehicleNameExist(string vehicleName)
        {
            bool check = false;

            VehicleViewModel vViewModel = new VehicleViewModel();

            try
            {
                check = _vRepo.CheckVehicleNameExist(vehicleName);

                Logger.Debug("Vehicle Controller CheckVehicleNameExist");
            }
            catch (Exception ex)
            {
                Logger.Error("Vehicle Controller - CheckVehicleNameExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);

        }

    }
}
