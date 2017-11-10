using Lohana.Common;
using Lohana.Models;
using Lohana.Models.Tariff.VehicleTariff;
using LohanaBusinessEntities;
using LohanaBusinessEntities.Common;
using LohanaHelper.Authorization;
using LohanaHelper.Logging;
using LohanaRepo.Tariff.VehicleTariff;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lohana.Controllers.PostLogin.Tariff
{
    public class VehicleTariffController : BaseController
    {
       
        public VehicleTariffRepo _vtRepo;

        public VehicleTariffController()
        {
            _vtRepo = new VehicleTariffRepo();
        }

        #region Vehicle Tariff

        [AuthorizeUser(RoleModule.VehicleTariff, Function.View)]
        public ActionResult Index(VehicleTariffViewModel vtViewModel)
        {
            if (TempData["vtViewModel"] != null)
            {
                vtViewModel = (VehicleTariffViewModel)TempData["vtViewModel"];
            }

            Set_Date_Session(vtViewModel.VehicleTariff);

            vtViewModel.Vendors = _vtRepo.drpGetVendors();

            vtViewModel.Vehicles = _vtRepo.drpGetVehicles();

            vtViewModel.CustomerCategories = _vtRepo.drpGetCustomerCategories();
                
            return View("Index", vtViewModel);
        }

        [AuthorizeUser(RoleModule.VehicleTariff, Function.Create)]
        public JsonResult InsertVehicleTariffBasicDetails(VehicleTariffViewModel vtViewModel)
        {
            try
            {
                Set_Date_Session(vtViewModel.VehicleTariff);

                vtViewModel.VehicleTariff.VehicleTariffId = _vtRepo.InsertVehicleTariff(vtViewModel.VehicleTariff);
   
                vtViewModel.FriendlyMessage.Add(MessageStore.Get("VT01"));

                Logger.Debug("VehicleTariff Controller Insert");

            }
            catch (Exception ex)
            {
                vtViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("VehicleTariff Controller - Insert " + ex.Message);
            }

            return Json(vtViewModel);
        }

        //[AuthorizeUser(RoleModule.VehicleTariff, Function.View)]
        //public JsonResult GetVehicleTariffBasicDetails(VehicleTariffViewModel vtViewModel)
        //{
        //    PaginationInfo pager = new PaginationInfo();

        //    pager = vtViewModel.Pager;

        //    PaginationViewModel pViewModel = new PaginationViewModel();

        //    try
        //    {
        //        pViewModel.dt = _vtRepo.GetVehicleTariffBasicDetails(ref pager);

        //        pViewModel.Pager = pager;

        //    }

        //    catch (Exception ex)
        //    {
        //        vtViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

        //        Logger.Error("Vehicle Tariff Controller - GetVehicleTariffBasicDetails" + ex.ToString());
        //    }

        //    return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        //}

        [AuthorizeUser(RoleModule.VehicleTariff, Function.Edit)]
        public JsonResult UpdateVehicleTariffBasicDetails(VehicleTariffViewModel vtViewModel)
        {
            try
            {
                Set_Date_Session(vtViewModel.VehicleTariff);

                _vtRepo.Update(vtViewModel.VehicleTariff);

                vtViewModel.FriendlyMessage.Add(MessageStore.Get("VT02"));

                Logger.Debug("VehicleTariff Controller Update");
            }

            catch (Exception ex)
            {

                vtViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("VehicleTariff Controller - Update  " + ex.Message);
            }

            return Json(vtViewModel);

        }

        #endregion

        #region Vehicle Tariff Price Details

        [AuthorizeUser(RoleModule.VehicleTariff, Function.View)]
        public JsonResult GetVehicleDetailsById(VehicleTariffViewModel vtViewModel)
        {
            
            try
            {
                vtViewModel.Vehicles = _vtRepo.GetVehicleDetailsById(vtViewModel.VehicleTariffPriceDetail.VehicleId);

                Logger.Debug("VehicleTariff Controller GetVehicleDetailsById");
            }
            catch (Exception ex)
            {
               
                vtViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
                
                Logger.Error("VehicleTariff Controller - GetVehicleDetailsById  " + ex.Message);//Added by vinod mane on 06/10/2016
            }

            return Json(vtViewModel.Vehicles, JsonRequestBehavior.AllowGet);
        }

        [AuthorizeUser(RoleModule.VehicleTariff, Function.Create)]
        public JsonResult InsertVehicleTariffPriceDetails(VehicleTariffViewModel vtViewModel)
        {
            try
            {
                Set_Date_Session(vtViewModel.VehicleTariffPriceDetail);

                vtViewModel.VehicleTariffPriceDetail.VehicleTariffPriceDetailsId = _vtRepo.InsertVehicleTariffPriceDetails(vtViewModel.VehicleTariffPriceDetail);

                vtViewModel.FriendlyMessage.Add(MessageStore.Get("VTP01"));

                Logger.Debug("VehicleTariff Controller InsertVehicleTariffPriceDetails");

            }
            catch (Exception ex)
            {
                vtViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("VehicleTariff Controller - InsertVehicleTariffPriceDetails " + ex.Message);
            }

            return Json(vtViewModel);
        }

        [AuthorizeUser(RoleModule.VehicleTariff, Function.View)]
        public JsonResult GetVehicleTariffPriceDetails(VehicleTariffViewModel vtViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = vtViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _vtRepo.GetVehicleTariffPriceDetails(vtViewModel.VehicleTariffPriceDetail.VehicleTariffId, ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("VehicleTariff Controller GetVehicleTariffPriceDetails");

            }

            catch (Exception ex)
            {
                vtViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("VehicleTariff Controller - GetVehicleTariffPriceDetails" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        [AuthorizeUser(RoleModule.VehicleTariff, Function.Edit)]
        public JsonResult UpdateVehicleTariffPriceDetails(VehicleTariffViewModel vtViewModel)
        {
            try
            {
                Set_Date_Session(vtViewModel.VehicleTariffPriceDetail);

                _vtRepo.UpdateVehicleTariffPrice(vtViewModel.VehicleTariffPriceDetail);

                vtViewModel.FriendlyMessage.Add(MessageStore.Get("VTP02"));

                Logger.Debug("VehicleTariff Controller UpdateVehicleTariffPriceDetails");
            }

            catch (Exception ex)
            {

                vtViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("VehicleTariff Controller - UpdateVehicleTariffPriceDetails  " + ex.Message);
            }

            return Json(vtViewModel);

        }

        [AuthorizeUser(RoleModule.VehicleTariff, Function.View)]
        public JsonResult DeleteVehicleTariffPriceDetails(VehicleTariffViewModel vtViewModel)
        {
            try
            {
                _vtRepo.DeleteVehicleTariffPriceDetails(vtViewModel.VehicleTariffPriceDetail.VehicleTariffPriceDetailsId, vtViewModel.VehicleTariffPriceDetail.VehicleTariffId);

                vtViewModel.FriendlyMessage.Add(MessageStore.Get("VTP04"));

                Logger.Debug("VehicleTariff Controller DeleteVehicleTariffPriceDetails");
            }
            catch (Exception ex)
            {
                vtViewModel.FriendlyMessage.Add(MessageStore.Get("VTP04"));

                Logger.Error("VehicleTariff Controller - DeleteVehicleTariffPriceDetails" + ex.ToString());
            }

            return Json(vtViewModel, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Vehicle Tariff Customer Category Details

        [AuthorizeUser(RoleModule.VehicleTariff, Function.View)]
        public JsonResult GetCustomerCategoryDetailsById(VehicleTariffViewModel vtViewModel)
        {

            try
            {
                vtViewModel.CustomerCategories = _vtRepo.GetCustomerCategoryDetailsById(vtViewModel.VehicleTariffCustomerCategory.CustomerCategoryId);

                Logger.Debug("VehicleTariff Controller GetCustomerCategoryDetailsById");
            }
            catch (Exception ex)
            {

                vtViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("VehicleTariff Controller - GetCustomerCategoryDetailsById  " + ex.Message);
            }

            return Json(vtViewModel.CustomerCategories, JsonRequestBehavior.AllowGet);
        }

        [AuthorizeUser(RoleModule.VehicleTariff, Function.Create)]
        public JsonResult InsertVehicleTariffCustomerCategoryDetails(VehicleTariffViewModel vtViewModel)
        {
            try
            {
                foreach (var item in vtViewModel.VehicleTariffCustomerCategories)
                {
                    Set_Date_Session(item); 
                }

                _vtRepo.InsertVehicleTariffCustomerCategoryDetails(vtViewModel.VehicleTariffCustomerCategories);

                vtViewModel.FriendlyMessage.Add(MessageStore.Get("VTCP01"));

                Logger.Debug("VehicleTariff Controller InsertVehicleTariffCustomerCategoryDetails");

            }
            catch (Exception ex)
            {
                vtViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("VehicleTariff Controller - InsertVehicleTariffCustomerCategoryDetails " + ex.Message);
            }

            return Json(vtViewModel);
        }

        [AuthorizeUser(RoleModule.VehicleTariff, Function.View)]
        public JsonResult GetVehicleTariffCustomerCategoryDetails(VehicleTariffViewModel vtViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = vtViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _vtRepo.GetVehicleTariffCustomerCategoryDetails(vtViewModel.VehicleTariffCustomerCategory.VehicleTariffId , ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("VehicleTariff Controller GetVehicleTariffCustomerCategoryDetails");

            }

            catch (Exception ex)
            {
                vtViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("VehicleTariff Controller - GetVehicleTariffCustomerCategoryDetails" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        [AuthorizeUser(RoleModule.VehicleTariff, Function.Edit)]
        public JsonResult UpdateVehicleTariffCustomerCategoryDetails(VehicleTariffViewModel vtViewModel)
        {
            try
            {
                foreach (var item in vtViewModel.VehicleTariffCustomerCategories)
                {
                    Set_Date_Session(item); 
                }

                _vtRepo.UpdateVehicleTariffCustomerCategoryDetails(vtViewModel.VehicleTariffCustomerCategories);

                vtViewModel.FriendlyMessage.Add(MessageStore.Get("VTCP02"));

                Logger.Debug("VehicleTariff Controller UpdateVehicleTariffCustomerCategoryDetails");
            }

            catch (Exception ex)
            {

                vtViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("VehicleTariff Controller - UpdateVehicleTariffCustomerCategoryDetails  " + ex.Message);
            }

            return Json(vtViewModel);

        }

        [AuthorizeUser(RoleModule.VehicleTariff, Function.View)]
        public JsonResult DeleteVehicleTariffCustomerCategoryDetails(VehicleTariffViewModel vtViewModel)
        {
            try
            {
                _vtRepo.DeleteVehicleTariffCustomerCategoryDetails(vtViewModel.VehicleTariffCustomerCategory.VehicleTariffCustomerCategoryDetailsId, vtViewModel.VehicleTariffCustomerCategory.VehicleTariffId);

                vtViewModel.FriendlyMessage.Add(MessageStore.Get("VTCP04"));

                Logger.Debug("VehicleTariff Controller DeleteVehicleTariffCustomerCategoryDetails");
            }
            catch (Exception ex)
            {
                vtViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("VehicleTariff Controller - DeleteVehicleTariffCustomerCategoryDetails" + ex.ToString());
            }

            return Json(vtViewModel, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Vehicle Tariff Search Details

        [AuthorizeUser(RoleModule.VehicleTariff, Function.View)]
        public ActionResult Search()
        {
            return View();
        }

        [AuthorizeUser(RoleModule.VehicleTariff, Function.View)]
        public JsonResult SearchVehicleTariffBasicDetails(VehicleTariffViewModel vtViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = vtViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _vtRepo.SearchVehicleTariffBasicDetails(vtViewModel.VehicleTariff.VendorId,vtViewModel.VehicleTariff.PackageName,ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("VehicleTariff Controller SearchVehicleTariffBasicDetails");
            }

            catch (Exception ex)
            {
                vtViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("VehicleTariff Controller - SearchVehicleTariffBasicDetails" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        #endregion

    }
}
