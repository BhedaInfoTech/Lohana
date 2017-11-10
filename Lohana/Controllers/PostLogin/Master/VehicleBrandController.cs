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
    public class VehicleBrandController: BaseController
    {

         public VehicleBrandRepo _vbRepo;

         public VehicleBrandController()
        {
            _vbRepo = new VehicleBrandRepo();
        }

        public ActionResult Index(VehicleBrandViewModel vbViewModel)
        {
            return View("Index", vbViewModel);
        }

        public ActionResult Search()
        {
            return View();
        }

        public JsonResult Insert(VehicleBrandViewModel vbViewModel)
        {
            try
            {
                Set_Date_Session(vbViewModel.VehicleBrand);

                vbViewModel.VehicleBrand.VehicleBrandId = _vbRepo.Insert(vbViewModel.VehicleBrand);

                vbViewModel.FriendlyMessage.Add(MessageStore.Get("Vb01"));

                Logger.Debug("VehicleBrand Controller Insert ");

            }
            catch (Exception ex)
            {
                vbViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("VehicleBrand Controller - Insert " + ex.Message);
            }

            return Json(vbViewModel);
        }

        public JsonResult GetVehicleBrands(VehicleBrandViewModel vbViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = vbViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _vbRepo.GetVehicleBrands(vbViewModel.VehicleBrand.VehicleBrandName, ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("VehicleBrand Controller GetVehicleBrands");
            }

            catch (Exception ex)
            {
                vbViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("VehicleBrand Controller - GetVehicleBrands" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        public JsonResult Update(VehicleBrandViewModel vbViewModel)
        {
            try
            {
                Set_Date_Session(vbViewModel.VehicleBrand);

                _vbRepo.Update(vbViewModel.VehicleBrand);

                vbViewModel.FriendlyMessage.Add(MessageStore.Get("Vb02"));

                Logger.Debug("VehicleBrand Controller Update ");
            }
            catch (Exception ex)
            {
                vbViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("VehicleBrand Controller - Update  " + ex.Message);
            }

            return Json(vbViewModel);
        }

        public JsonResult CheckVehicleBrandNameExist(string vehicleBrandName)
        {
            bool check = false;

            VehicleBrandViewModel vbViewModel = new VehicleBrandViewModel();

            try
            {
                check = _vbRepo.CheckVehicleBrandNameExist(vehicleBrandName);

                Logger.Debug("VehicleBrand Controller VehicleBrandNameExist");
            }
            catch (Exception ex)
            {
                Logger.Error("VehicleBrand Controller -VehicleBrandNameExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);

        }
    }
}