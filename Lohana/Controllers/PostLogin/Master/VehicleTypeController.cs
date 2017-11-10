using Lohana.Common;
using Lohana.Models;
using Lohana.Models.Master;
using LohanaBusinessEntities.Common;
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
    public class VehicleTypeController: BaseController
    {
        
         public VehicleTypeRepo _vtRepo;

         public VehicleTypeController()
        {
            _vtRepo = new VehicleTypeRepo();
        }

        public ActionResult Index(VehicleTypeViewModel vtViewModel)
        {
            return View("Index", vtViewModel);
        }

        public ActionResult Search()
        {
            return View();
        }

        public JsonResult Insert(VehicleTypeViewModel vtViewModel)
        {
            try
            {
                Set_Date_Session(vtViewModel.VehicleType);

                vtViewModel.VehicleType.VehicleTypeId = _vtRepo.Insert(vtViewModel.VehicleType);

                vtViewModel.FriendlyMessage.Add(MessageStore.Get("Vt01"));

                Logger.Debug("VehicleType Controller Insert");

            }
            catch (Exception ex)
            {
                vtViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("VehicleType Controller - Insert " + ex.Message);
            }

            return Json(vtViewModel);
        }

        public JsonResult GetVehicleTypes(VehicleTypeViewModel vtViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = vtViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _vtRepo.GetVehicleTypes(vtViewModel.VehicleType.VehicleTypeName, ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("VehicleType Controller GetVehicleBrands");
            }

            catch (Exception ex)
            {
                vtViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("VehicleType Controller - GetVehicleBrands" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        public JsonResult Update(VehicleTypeViewModel vtViewModel)
        {
            try
            {
                Set_Date_Session(vtViewModel.VehicleType);

                _vtRepo.Update(vtViewModel.VehicleType);

                vtViewModel.FriendlyMessage.Add(MessageStore.Get("Vt02"));

                Logger.Debug("VehicleType Controller Update");
            }
            catch (Exception ex)
            {
                vtViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("VehicleType Controller - Update  " + ex.Message);
            }

            return Json(vtViewModel);
        }

        public JsonResult CheckVehicleTypeNameExist(string vehicleTypeName)
        {
            bool check = false;

            VehicleBrandViewModel vtViewModel = new VehicleBrandViewModel();

            try
            {
                check = _vtRepo.CheckVehicleTypeNameExist(vehicleTypeName);

                Logger.Debug("VehicleType Controller VehicleTypeNameExist");
            }
            catch (Exception ex)
            {
                Logger.Error("VehicleType Controller -VehicleTypeNameExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);

        }
    }
}