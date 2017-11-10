using Lohana.Common;
using Lohana.Models;
using Lohana.Models.Tariff.LohanaPackageTariff;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Hotel;
using LohanaHelper.Logging;
using LohanaRepo.HotelTariff;
using LohanaRepo.Master;
using LohanaRepo.Tariff.LohanaPackageTariff;
using LohanaRepo.Tariff.VehicleTariff;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lohana.Controllers.PostLogin
{
    public class LohanaPackageTariffController : BaseController
    {
        public LohanaPackageTariffRepo _lpRepo;

        public HotelRepo _hRepo;

        public HotelTariffRepo _htRepo;

       public VehicleTariffRepo _vtRepo;

       public PackageRepo _pRepo;

        public LohanaPackageTariffController()
        {
            _lpRepo = new LohanaPackageTariffRepo();

            _hRepo = new HotelRepo();

            _htRepo = new HotelTariffRepo();

            _vtRepo = new VehicleTariffRepo();

            _pRepo = new PackageRepo();
        }

        public ActionResult Index(LohanaPackageTariffViewModel lpViewModel)
        {

            lpViewModel.Cities = _hRepo.drpGetCountryStateCity();

            lpViewModel.RoomTypes = _htRepo.drpGetRoomTypes();

            lpViewModel.Meals = _htRepo.drpGetMeals();

            lpViewModel.Vendors = _vtRepo.drpGetVendors();

            lpViewModel.Vehicles = _vtRepo.drpGetVehicles();

            lpViewModel.PackageTypes = _pRepo.drpGetPackageTypes();

            return View("Index", lpViewModel);
        }

        public ActionResult Search()
        {
            return View();
        }

        #region Basic Details


        public JsonResult InsertLohanaPackageTariff(LohanaPackageTariffViewModel lpViewModel)
        {
            try
            {
                Set_Date_Session(lpViewModel.LohanaPackageTariff);

                lpViewModel.LohanaPackageTariff.LohanaPackageTariffId = _lpRepo.InsertLohanaPackageTariff(lpViewModel.LohanaPackageTariff);


                lpViewModel.FriendlyMessage.Add(MessageStore.Get("LohanaTariff01"));

                Logger.Debug("LohanaPackageTariff Controller Insert");

            }
            catch (Exception ex)
            {
                lpViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("LohanaPackageTariff Controller - Insert " + ex.Message);
            }

            return Json(lpViewModel);
        }

        public JsonResult GetLohanaPackageTariff(LohanaPackageTariffViewModel lpViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = lpViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {


                pViewModel.dt = _lpRepo.GetLohanaPackageTariff(lpViewModel.LohanaPackageTariff.PackageName ,ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("LohanaPackageTariff Controller GetLohanaPackageTariff");

            }

            catch (Exception ex)
            {
                lpViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("LohanaPackageTariff Controller - GetLohanaPackageTariff" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        public JsonResult UpdateLohanaPackageTariff(LohanaPackageTariffViewModel lpViewModel)
        {
            try
            {
                Set_Date_Session(lpViewModel.LohanaPackageTariff);

                _lpRepo.UpdateLohanaPackageTariff(lpViewModel.LohanaPackageTariff);

                lpViewModel.FriendlyMessage.Add(MessageStore.Get("LohanaTariff02"));

                Logger.Debug("LohanaPackageTariff Controller UpdateLohanaPackageTariff");
            }
            catch (Exception ex)
            {

                lpViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("LohanaPackageTariff Controller - UpdateLohanaPackageTariff  " + ex.Message);
            }

            return Json(lpViewModel);

        }

        #endregion

        #region Hotel Details

        public JsonResult GetHotelListing(LohanaPackageTariffViewModel lpViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = lpViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {

                pViewModel.dt = _lpRepo.GetHotelListing(lpViewModel.LohanaPackageTariffHotel.CityId,lpViewModel.LohanaPackageTariffHotel.HotelId,lpViewModel.LohanaPackageTariffHotel.RoomTypeId,lpViewModel.LohanaPackageTariffHotel.MealId,ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("LohanaPackageTariff Controller GetHotelListing");

            }

            catch (Exception ex)
            {
                lpViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("LohanaPackageTariff Controller - GetHotelListing" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }
  
        public JsonResult GetHotelsDrp(int CityId)
        {
            List<HotelInfo> Hotels = new List<HotelInfo>();
            try
            {
                Hotels = _lpRepo.GetHotelsDrp(CityId);

                Logger.Debug("LohanaPackageTariff Controller GetHotelsDrp");
            }
            catch (Exception ex)
            {
                Logger.Error("LohanaPackageTariff Controller-GetHotelsDrp " + ex.ToString());
            }

            return Json(Hotels, JsonRequestBehavior.AllowGet);
        }

        public JsonResult InsertLohanaPackageTariffHotel(LohanaPackageTariffViewModel lpViewModel)
        {
            try
            {
                Set_Date_Session(lpViewModel.LohanaPackageTariffHotel);

                lpViewModel.LohanaPackageTariffHotel.LohanaPackageTariffHotelId = _lpRepo.InsertLohanaPackageTariffHotel(lpViewModel.LohanaPackageTariffHotel);


                lpViewModel.FriendlyMessage.Add(MessageStore.Get("LohanaTariff04"));

                Logger.Debug("LohanaPackageTariff Controller InsertLohanaPackageTariffHotel");

            }
            catch (Exception ex)
            {
                lpViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("LohanaPackageTariff Controller - InsertLohanaPackageTariffHotel " + ex.Message);
            }

            return Json(lpViewModel);
        }

        public JsonResult GetLohanaPackageTariffHotel(LohanaPackageTariffViewModel lpViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = lpViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {


                pViewModel.dt = _lpRepo.GetLohanaPackageTariffHotel(lpViewModel.LohanaPackageTariffHotel.HotelTariffRoomDetailsId,lpViewModel.LohanaPackageTariffHotel.NoOfNight, lpViewModel.LohanaPackageTariffHotel.LohanaPackageTariffId, ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("LohanaPackageTariff Controller GetLohanaPackageTariffHotel");

            }

            catch (Exception ex)
            {
                lpViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("LohanaPackageTariff Controller - GetLohanaPackageTariffHotel" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        public JsonResult UpdateLohanaPackageTariffHotel(LohanaPackageTariffViewModel lpViewModel)
        {
            try
            {
                Set_Date_Session(lpViewModel.LohanaPackageTariffHotel);

                _lpRepo.UpdateLohanaPackageTariffHotel(lpViewModel.LohanaPackageTariffHotel);

                lpViewModel.FriendlyMessage.Add(MessageStore.Get("LohanaTariff05"));

                Logger.Debug("LohanaPackageTariff Controller UpdateLohanaPackageTariffHotel");
            }
            catch (Exception ex)
            {

                lpViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("LohanaPackageTariff Controller - UpdateLohanaPackageTariffHotel  " + ex.Message);
            }

            return Json(lpViewModel);

        }

        public JsonResult DeleteLohanaPackageTariffHotel(LohanaPackageTariffViewModel lpViewModel)
        {
            try
            {
                _lpRepo.DeleteLohanaPackageTariffHotel(lpViewModel.LohanaPackageTariffHotel.LohanaPackageTariffId, lpViewModel.LohanaPackageTariffHotel.LohanaPackageTariffHotelId);

                lpViewModel.FriendlyMessage.Add(MessageStore.Get("LohanaTariff06"));

            }
            catch (Exception ex)
            {
                lpViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));


                Logger.Error("LohanaPackageTariff Controller - DeleteLohanaPackageTariffHotel" + ex.ToString());
            }

            return Json(lpViewModel);
        }



        #endregion

        #region Vehicle Details

        public JsonResult GetVehicleListing(LohanaPackageTariffViewModel lpViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = lpViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {

                pViewModel.dt = _lpRepo.GetVehicleListing(lpViewModel.LohanaPackageTariffVehicle.VendorId, lpViewModel.LohanaPackageTariffVehicle.VehicleId,ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("LohanaPackageTariff Controller GetVehicleListing");

            }

            catch (Exception ex)
            {
                lpViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("LohanaPackageTariff Controller - GetVehicleListing" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        public JsonResult InsertLohanaPackageTariffVehicle(LohanaPackageTariffViewModel lpViewModel)
        {
            try
            {
                Set_Date_Session(lpViewModel.LohanaPackageTariffVehicle);

                lpViewModel.LohanaPackageTariffVehicle.LohanaPackageTariffVehicleId = _lpRepo.InsertLohanaPackageTariffVehicle(lpViewModel.LohanaPackageTariffVehicle);


                lpViewModel.FriendlyMessage.Add(MessageStore.Get("LohanaTariff07"));

                Logger.Debug("LohanaPackageTariff Controller InsertLohanaPackageTariffVehicle");

            }
            catch (Exception ex)
            {
                lpViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("LohanaPackageTariff Controller - InsertLohanaPackageTariffVehicle " + ex.Message);
            }

            return Json(lpViewModel);
        }

        public JsonResult GetLohanaPackageTariffVehicle(LohanaPackageTariffViewModel lpViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = lpViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {


                pViewModel.dt = _lpRepo.GetLohanaPackageTariffVehicle(lpViewModel.LohanaPackageTariffVehicle.LohanaPackageTariffId, lpViewModel.LohanaPackageTariffVehicle.VehicleTariffId,lpViewModel.LohanaPackageTariffVehicle.VehicleTariffPriceDetailsId, ref pager);
               
               

                pViewModel.Pager = pager;

                Logger.Debug("LohanaPackageTariff Controller GetLohanaPackageTariffVehicle");

            }

            catch (Exception ex)
            {
                lpViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("LohanaPackageTariff Controller - GetLohanaPackageTariffVehicle" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        public JsonResult UpdateLohanaPackageTariffVehicle(LohanaPackageTariffViewModel lpViewModel)
        {
            try
            {
                Set_Date_Session(lpViewModel.LohanaPackageTariffVehicle);

                _lpRepo.UpdateLohanaPackageTariffVehicle(lpViewModel.LohanaPackageTariffVehicle);

                lpViewModel.FriendlyMessage.Add(MessageStore.Get("LohanaTariff08"));

                Logger.Debug("LohanaPackageTariff Controller UpdateLohanaPackageTariffVehicle");
            }
            catch (Exception ex)
            {

                lpViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("LohanaPackageTariff Controller - UpdateLohanaPackageTariffVehicle  " + ex.Message);
            }

            return Json(lpViewModel);

        }

        public JsonResult DeleteLohanaPackageTariffVehicle(LohanaPackageTariffViewModel lpViewModel)
        {
            try
            {
                _lpRepo.DeleteLohanaPackageTariffVehicle(lpViewModel.LohanaPackageTariffVehicle.LohanaPackageTariffId, lpViewModel.LohanaPackageTariffVehicle.LohanaPackageTariffVehicleId);

                lpViewModel.FriendlyMessage.Add(MessageStore.Get("LohanaTariff06"));

            }
            catch (Exception ex)
            {
                lpViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));


                Logger.Error("LohanaPackageTariff Controller - DeleteLohanaPackageTariffVehicle" + ex.ToString());
            }

            return Json(lpViewModel);
        }


        #endregion 

        #region Root Details

        public JsonResult InsertLohanaPackageTariffRootDetail(LohanaPackageTariffViewModel lpViewModel)
        {
            try
            {
                Set_Date_Session(lpViewModel.LohanaPackageTariffRoot);
                lpViewModel.LohanaPackageTariffRoot.LohanaPackageTariffRootDetailId = _lpRepo.InsertLohanaPackageTariffRootDetail(lpViewModel.LohanaPackageTariffRoot);
                lpViewModel.FriendlyMessage.Add(MessageStore.Get("LohanaTariff10"));

                Logger.Debug("LohanaPackageTariffRoot Controller Insert");

            }
            catch (Exception ex)
            {
                lpViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("LohanaPackageTariffRoot Controller - Insert " + ex.Message);
            }

            return Json(lpViewModel);
        }

        public JsonResult GetLohanaPackageTariffRootList(LohanaPackageTariffViewModel lpViewModel)
        {
            System.Data.DataSet ds = new System.Data.DataSet();
            try
            {
                ds = _lpRepo.GetLohanaPackageTariffRootList(lpViewModel.LohanaPackageTariff.LohanaPackageTariffId);
                Logger.Debug("LohanaPackageTariff Controller GetLohanaPackageTariffRootList");
            }
            catch (Exception ex)
            {
                lpViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
                Logger.Error("LohanaPackageTariff Controller - GetLohanaPackageTariffRootList" + ex.ToString());
            }
            return Json(JsonConvert.SerializeObject(ds), JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateLohanaPackageTariffRootTitle(LohanaPackageTariffViewModel lpViewModel)
        {
            try
            {
                Set_Date_Session(lpViewModel.LohanaPackageTariffRoot);
                _lpRepo.UpdateLohanaPackageTariffRootTitle(lpViewModel.LohanaPackageTariffRoot);
                lpViewModel.FriendlyMessage.Add(MessageStore.Get("LohanaTariff11"));

                Logger.Debug("LohanaPackageTariffRoot Controller Update");

            }
            catch (Exception ex)
            {
                lpViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("LohanaPackageTariffRoot Controller - Insert " + ex.Message);
            }

            return Json(lpViewModel);
        }

        //public JsonResult CheckLohanaPackageTariffRootDetailExist(LohanaPackageTariffViewModel lpViewModel)
        public JsonResult CheckLohanaPackageTariffRootDetailExist(int LohanaPackageTariffId, int LohanaPackageTariffRootId, int LohanaPackageTariffRefId, int LohanaPackageTariffTypeId)
        {
            int count = 0;
            try
            {
                //count = _lpRepo.CheckLohanaPackageTariffRootDetailExist(lpViewModel.LohanaPackageTariffRoot);
                count = _lpRepo.CheckLohanaPackageTariffRootDetailExist(LohanaPackageTariffId, LohanaPackageTariffRootId, LohanaPackageTariffRefId, LohanaPackageTariffTypeId);

                Logger.Debug("LohanaPackageTariffRoot Controller Check Lohana Package Tariff Root Detail.");

            }
            catch (Exception ex)
            {
                //lpViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
                Logger.Error("LohanaPackageTariffRoot Controller - Check " + ex.Message);
            }

            return Json(count, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteLohanaPackageTariffRootDetail(LohanaPackageTariffViewModel lpViewModel)
        {
            try
            {
                _lpRepo.DeleteLohanaPackageTariffRootDetail(lpViewModel.LohanaPackageTariffRoot);
                lpViewModel.FriendlyMessage.Add(MessageStore.Get("LohanaTariff13"));

                Logger.Debug("LohanaPackageTariffRoot Controller Delete");

            }
            catch (Exception ex)
            {
                lpViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("LohanaPackageTariffRoot Controller - Delete " + ex.Message);
            }

            return Json(lpViewModel);
        }

        #endregion
    }
}
