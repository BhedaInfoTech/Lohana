using Lohana.Common;
using Lohana.Models;
using Lohana.Models.SightSeeingTariff;
using LohanaBusinessEntities;
using LohanaBusinessEntities.Common;
using LohanaHelper.Authorization;
using LohanaHelper.Logging;
using LohanaRepo.SightSeeingTariff;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LohanaRepo.Tariff.VehicleTariff;
using LohanaRepo.Master;

namespace Lohana.Controllers.PostLogin
{
    public class SightSeeingTariffController : BaseController
    {
        public SightSeeingTariffRepo _sstRepo;

        VehicleTariffRepo _vtRepo;

        TaxFormulaRepo _tRepo;

        ChargesRepo _cRepo;

       
        public SightSeeingTariffController()
        {
            _sstRepo = new SightSeeingTariffRepo();

            _vtRepo = new VehicleTariffRepo();

            _tRepo = new TaxFormulaRepo();

            _cRepo = new ChargesRepo();
            
        }

        [AuthorizeUser(RoleModule.SightSeeingTariff, Function.View)]
        public ActionResult Index(SightSeeingTariffViewModel sstViewModel)
        {
            if (TempData["sstViewModel"] != null)
            {
                sstViewModel = (SightSeeingTariffViewModel)TempData["sstViewModel"];
            }
            Set_Date_Session(sstViewModel.SightSeeingTariff);

            sstViewModel.LstTaxFormula = _tRepo.drpGetTaxFormula();

            sstViewModel.Vendors = _sstRepo.drpGetVendors();

            sstViewModel.LstStandardCharges = _cRepo.GetStandardCharges();

            sstViewModel.SightSeeings = _sstRepo.drpGetSightSeeings();

            

            return View("Index", sstViewModel);
        }

        #region Basic Details

        [AuthorizeUser(RoleModule.SightSeeingTariff, Function.Create)]
        public JsonResult InsertSightSeeingTariff(SightSeeingTariffViewModel sstViewModel)
        {
            try
            {
                Set_Date_Session(sstViewModel.SightSeeingTariff);

                sstViewModel.SightSeeingTariff.SightSeeingTariffId = _sstRepo.InsertSightSeeingTariff(sstViewModel.SightSeeingTariff);
   
                sstViewModel.FriendlyMessage.Add(MessageStore.Get("SightSeeingTariff01"));

                Logger.Debug("SightSeeingTariff Controller Insert");

            }
            catch (Exception ex)
            {
                sstViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("SightSeeingTariff Controller - Insert " + ex.Message);
            }

            return Json(sstViewModel);
        }

        [AuthorizeUser(RoleModule.SightSeeingTariff, Function.View)]
        public JsonResult GetSightSeeingTariffBasic(SightSeeingTariffViewModel sstViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = sstViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _sstRepo.GetSightSeeingTariffBasic(sstViewModel.SightSeeingTariff.VendorId, sstViewModel.SightSeeingTariff.SightSeeingId, ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("SightSeeingTariff Controller GetSightSeeingTariffBasic");

            }

            catch (Exception ex)
            {
                sstViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("SightSeeingTariff Controller - GetSightSeeingTariffBasic" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        [AuthorizeUser(RoleModule.SightSeeingTariff, Function.Edit)]
        public JsonResult UpdateSightSeeingTariff(SightSeeingTariffViewModel sstViewModel)
        {
            try
            {
                Set_Date_Session(sstViewModel.SightSeeingTariff);

                _sstRepo.UpdateSightSeeingTariff(sstViewModel.SightSeeingTariff);

                sstViewModel.FriendlyMessage.Add(MessageStore.Get("SightSeeingTariff02"));

                Logger.Debug("SightSeeingTariff Controller Update");
            }
            catch (Exception ex)
            {

                sstViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("SightSeeingTariff Controller - Update  " + ex.Message);
            }

            return Json(JsonConvert.SerializeObject(sstViewModel));

        }

        public JsonResult IsSameSightSeeingVendorExists(int sightseeingId, int vendorId = 0)
        {
            bool result = false;

            try
            {
                if (!_sstRepo.IsSameSightSeeingVendorExists(vendorId, sightseeingId))
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                Logger.Error("SightSeeingTariff Controller - IsSameSightSeeingVendorExists  " + ex.Message);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region SightSeeingTariffOccupancy

        public JsonResult InsertSightSeeingTariffOccupancy(SightSeeingTariffViewModel sstViewModel)
        {
            try
            {
                Set_Date_Session(sstViewModel.SightSeeingTariffOccupancy);

                sstViewModel.SightSeeingTariffOccupancy.SightSeeingTariffOccupancyId = _sstRepo.InsertSightSeeingtTariffOccupancy(sstViewModel.SightSeeingTariffOccupancy);

                sstViewModel.FriendlyMessage.Add(MessageStore.Get("SightSeeingTariff03"));

                Logger.Debug("SightSeeingTariffOccupancy Controller Insert");

            }
            catch (Exception ex)
            {
                sstViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("SightSeeingTariffOccupancy Controller - InsertSightSeeingtTariffOccupancy " + ex.Message);
            }

            return Json(sstViewModel);
        }

        public JsonResult UpdateSightSeeingtTariffOccupancy(SightSeeingTariffViewModel sstViewModel)
        {
            try
            {
                Set_Date_Session(sstViewModel.SightSeeingTariffOccupancy);

                _sstRepo.UpdateSightSeeingtTariffOccupancy(sstViewModel.SightSeeingTariffOccupancy);

                sstViewModel.FriendlyMessage.Add(MessageStore.Get("SightSeeingTariffOccupancy04"));

                Logger.Debug("SightSeeingTariff Controller UpdateOccupancy");
            }
            catch (Exception ex)
            {

                sstViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("SightSeeingTariffOccupancy Controller - UpdateSightSeeingtTariffOccupancy  " + ex.Message);
            }

            return Json(sstViewModel);

        }

        public JsonResult GetSightSeeingTariffOccupancy(SightSeeingTariffViewModel sstViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = sstViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {


                pViewModel.dt = _sstRepo.GetSightSeeingTariffOccupancy(sstViewModel.SightSeeingTariffOccupancy.SightSeeingTariffId, ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("SightSeeingTariffOccupancy Controller GetSightSeeingTariffOccupancy");

            }

            catch (Exception ex)
            {
                sstViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("SightSeeingTariffOccupancy Controller - GetSightSeeingTariffOccupancy" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        public JsonResult DeleteSightSeeingTariffOccupancy(SightSeeingTariffViewModel sstViewModel)
        {
            try
            {
                _sstRepo.DeleteSightSeeingTariffOccupancy(sstViewModel.SightSeeingTariffOccupancy.SightSeeingTariffId, sstViewModel.SightSeeingTariffOccupancy.SightSeeingTariffOccupancyId);

                sstViewModel.FriendlyMessage.Add(MessageStore.Get("SightSeeingTariffOccupancy05"));

            }
            catch (Exception ex)
            {
                sstViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));


                Logger.Error("SightSeeingTariffOccupancy Controller - DeleteSightSeeingTariffOccupancy" + ex.ToString());
            }

            return Json(sstViewModel);
        }

        #endregion


        #region SightSeeingTariffPrice

        public PartialViewResult GetTaxFormulaCharges(int TaxFormulaId, int SightSeeingTariffPriceId)
        {
            SightSeeingTariffViewModel sstViewModel = new SightSeeingTariffViewModel();

            PaginationInfo pager = null;

            if (SightSeeingTariffPriceId != 0)
            {
                sstViewModel.LstTaxFormulaCharges = _sstRepo.GetTaxFormulaChargesByPriceId(TaxFormulaId, SightSeeingTariffPriceId, ref pager);

                if (sstViewModel.LstTaxFormulaCharges.Count > 0)
                {
                    sstViewModel.SightSeeingTariffPrice.TotalTaxPrice = sstViewModel.LstTaxFormulaCharges[0].SightSeeingTariffCharge.TotalTaxPrice;
                }
                else
                {
                    sstViewModel.LstTaxFormulaCharges = _sstRepo.GetTaxFormulaCharges(TaxFormulaId, ref pager);
                }
            }
            else
            {
                sstViewModel.LstTaxFormulaCharges = _sstRepo.GetTaxFormulaCharges(TaxFormulaId, ref pager);

            }

            return PartialView("_PriceTaxFormulaCharges", sstViewModel);
        }

        public JsonResult InsertSightSeeingTariffPrice(SightSeeingTariffViewModel sstViewModel)
        {
            try
            {
                Set_Date_Session(sstViewModel.SightSeeingTariffPrice);

                //htViewModel.HotelTariffPrice.Color = GetRandomColorName();

                sstViewModel.SightSeeingTariffPrice.SightSeeingTariffPriceId = _sstRepo.InsertSightSeeingTariffPrice(sstViewModel.SightSeeingTariffPrice);

                sstViewModel.FriendlyMessage.Add(MessageStore.Get("SightSeeingTariffPrice06"));

            }
            catch (Exception ex)
            {
                sstViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("SightSeeingTariff Controller - InsertPrice " + ex.Message);
            }

            return Json(sstViewModel);
        }

        public PartialViewResult GetSightSeeingTariffPrice(int sightseeingTariffOccupancyId)
        {
            SightSeeingTariffViewModel sstViewModel = new SightSeeingTariffViewModel();

            try
            {
                sstViewModel.SightSeeingTariffPrices = _sstRepo.GetSightSeeingTariffPrice(sightseeingTariffOccupancyId);
            }
            catch (Exception ex)
            {
                sstViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("SightSeeing Controller - GetSightSeeingTariffPrice" + ex.ToString());
            }

            TempData["sstViewModel"] = sstViewModel;

            return PartialView("_PriceList", sstViewModel);
        }

        public JsonResult UpdateSightSeeingTariffPrice(SightSeeingTariffViewModel sstViewModel)
        {
            try
            {
                Set_Date_Session(sstViewModel.SightSeeingTariffPrice);

                //htViewModel.HotelTariffPrice.Color = GetRandomColorName();

                _sstRepo.UpdateSightSeeingTariffPrice(sstViewModel.SightSeeingTariffPrice);

                sstViewModel.FriendlyMessage.Add(MessageStore.Get("SightSeeingTariffPrice07"));

                Logger.Debug("SightSeeing Controller InsertPrice");
            }
            catch (Exception ex)
            {

                sstViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("SightSeeing Controller - UpdatePrice  " + ex.Message);
            }

            return Json(sstViewModel);

        }

        public JsonResult GetSightSeeingTariffPriceById(SightSeeingTariffViewModel sstViewModel)
        {
            try
            {
                sstViewModel.SightSeeingTariffPrice = _sstRepo.GetSightSeeingTariffPriceById(sstViewModel.SightSeeingTariffPrice.SightSeeingTariffPriceId);
            }
            catch (Exception ex)
            {
                sstViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("SightSeeing Controller - GetSightSeeingTariffPriceById  " + ex.Message);
            }

            return Json(sstViewModel);
        }
        #endregion

        #region SightSeeingTariffPriceDuration

        public JsonResult GetSightSeeingTariffDurationPrice(int sightseeingTariffOccupancyId)
        {
            SightSeeingTariffViewModel sstViewModel = new SightSeeingTariffViewModel();

            try
            {
                sstViewModel.SightSeeingTariffDates = _sstRepo.GetSightSeeingTariffDurationPrice(sightseeingTariffOccupancyId);

                sstViewModel.SightSeeingTariffPrices = _sstRepo.GetSightSeeingTariffPrice(sightseeingTariffOccupancyId);
            }
            catch (Exception ex)
            {
                sstViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("SightSeeing Tariff Controller - GetHotelTariffDuration  " + ex.Message);
            }

            return Json(sstViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveSightSeeingTariffDurationWithCustomerCategories(SightSeeingTariffViewModel sstViewModel)
        {
            List<DateTime> filterDates = new List<DateTime>();

            try
            {
                foreach (var item in sstViewModel.SightSeeingTariffCustomerCategories)
                {
                    Set_Date_Session(item);
                }

                filterDates = _sstRepo.GetFilteredDateForDuration(sstViewModel.SightSeeingTariffDuration);

                sstViewModel.SightSeeingTariffPrice = _sstRepo.GetSightSeeingTariffPriceById(sstViewModel.SightSeeingTariffDuration.SightSeeingTariffPriceId);

                sstViewModel.SightSeeingTariffDate.NetRate = sstViewModel.SightSeeingTariffPrice.NetRate;

                sstViewModel.SightSeeingTariffDate.SightSeeingTariffPriceId = sstViewModel.SightSeeingTariffDuration.SightSeeingTariffPriceId;

                sstViewModel.SightSeeingTariffDate.SightSeeingTariffOccupancyId = sstViewModel.SightSeeingTariffDuration.SightSeeingTariffOccupancyId;

                _sstRepo.SaveSightSeeingTariffDurationWithCustomerCategories(filterDates, sstViewModel.SightSeeingTariffDate, sstViewModel.SightSeeingTariffCustomerCategories);

                sstViewModel.FriendlyMessage.Add(MessageStore.Get("SightSeeingTariffDuration08"));
            }
            catch (Exception ex)
            {
                sstViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("SightSeeing Tariff Controller - GetSightSeeingTariffDuration  " + ex.Message);
            }

            return Json(sstViewModel);
        }

        public JsonResult IsOverrideDate(SightSeeingTariffViewModel sstViewModel)
        {
            List<DateTime> filterDates = new List<DateTime>();

            bool isOverride = false;

            try
            {
                filterDates = _sstRepo.GetFilteredDateForDuration(sstViewModel.SightSeeingTariffDuration);

                sstViewModel.SightSeeingTariffDates = _sstRepo.GetSightSeeingTariffDurationPrice(sstViewModel.SightSeeingTariffDuration.SightSeeingTariffOccupancyId);

                foreach (var item in filterDates)
                {
                    if (sstViewModel.SightSeeingTariffDates.Where(a => a.TariffDate == item).Count() > 0)
                    {
                        isOverride = true;

                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                sstViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("SightSeeing Tariff Controller - IsOverrideDate  " + ex.Message);
            }

            return Json(isOverride);
        }

        public PartialViewResult GetSightSeeingTariffDuration(int sightseeingTariffPriceId)
        {
            SightSeeingTariffViewModel sstViewModel = new SightSeeingTariffViewModel();

            try
            {

            }
            catch (Exception ex)
            {
                sstViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("SightSeeing Tariff Controller - GetSightSeeingTariffDuration  " + ex.Message);
            }

            return PartialView("_DurationDetails", sstViewModel);
        }

        #endregion

        #region SightSeeingtariffCustomerCategory

        public ActionResult GetCustomerCategoryMargin(SightSeeingTariffViewModel sstViewModel)
        {

            try
            {
                sstViewModel.CustomerCategories = _vtRepo.GetCustomerCategoryDetailsById(sstViewModel.SightSeeingTariffCustomerCategory.CustomerCategoryId);

                Logger.Debug("SightSeeingTariff Controller GetCustomerCategoryById");
            }
            catch (Exception ex)
            {

                sstViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("VehicleTariff Controller - GetCustomerCategoryById  " + ex.Message);
            }

            return Json(sstViewModel, JsonRequestBehavior.AllowGet);

        }

        public JsonResult InsertCustomerCategory(SightSeeingTariffViewModel sstViewModel)
        {
            try
            {
                Set_Date_Session(sstViewModel.SightSeeingTariffCustomerCategory);

                _sstRepo.SaveSightSeeingTariffCustomerCategory(sstViewModel.SightSeeingTariffCustomerCategory);

                sstViewModel.FriendlyMessage.Add(MessageStore.Get("SightSeeingTariffCustomerCategory01"));

                Logger.Debug("SightSeeingTariff Controller InsertCustomerCategory");

            }
            catch (Exception ex)
            {
                sstViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("SightSeeingTariff Controller - InsertCustomerCategory " + ex.Message);
            }

            return Json(sstViewModel);
        }

        [AuthorizeUser(RoleModule.SightSeeingTariff, Function.View)]
        public JsonResult GetCustomerCategory(SightSeeingTariffViewModel sstViewModel)
        {

            try
            {

                sstViewModel.SightSeeingTariffCustomerCategories = _sstRepo.GetCustomerCategory();

                Logger.Debug("SightSeeingTariff Controller GetCustomerCategory");

            }

            catch (Exception ex)
            {
                sstViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("SightSeeingTariff Controller - GetCustomerCategory" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(sstViewModel), JsonRequestBehavior.AllowGet);

        }

        [AuthorizeUser(RoleModule.SightSeeingTariff, Function.Edit)]
        public JsonResult UpdateCustomerCategory(SightSeeingTariffViewModel sstViewModel)
        {
            try
            {
                Set_Date_Session(sstViewModel.SightSeeingTariffCustomerCategory);

                _sstRepo.UpdateCustomerCategory(sstViewModel.SightSeeingTariffCustomerCategory);

                sstViewModel.FriendlyMessage.Add(MessageStore.Get("SightSeeingTariffCustomerCategory02"));

                Logger.Debug("SightSeeingTariff Controller UpdateCustomerCategory");
            }
            catch (Exception ex)
            {

                sstViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("SightSeeingTariff Controller - UpdateCustomerCategory " + ex.Message);
            }

            return Json(sstViewModel);

        }

        public PartialViewResult GetCustomerCategoryByOccupencyIdTariffDate(int sightseeingTariffOccupancyId, DateTime tariffDate)
        {
            SightSeeingTariffViewModel sstViewModel = new SightSeeingTariffViewModel();
            try
            {

                sstViewModel.SightSeeingTariffCustomerCategories = _sstRepo.GetSightSeeingTariffCustomerCategory(sightseeingTariffOccupancyId, tariffDate);
            }

            catch (Exception ex)
            {
                sstViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("SightSeeing Tariff Controller - GetSightSeeingTariffDuration  " + ex.Message);
            }
            return PartialView("_CustomerCategory", sstViewModel);
        }

        #endregion

        #region Duration Details

        [AuthorizeUser(RoleModule.SightSeeingTariff, Function.Create)]
        public JsonResult InsertDuration(SightSeeingTariffViewModel sstViewModel)
        {
            try
            {
                Set_Date_Session(sstViewModel.Duration);

                
                _sstRepo.InsertDuration(sstViewModel.Duration);


                sstViewModel.FriendlyMessage.Add(MessageStore.Get("SightSeeingTariff01"));

                Logger.Debug("SightSeeingTariff Controller InsertDuration");

            }
            catch (Exception ex)
            {
                sstViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("SightSeeingTariff Controller - InsertDuration " + ex.Message);
            }

            return Json(sstViewModel);
        }

        [AuthorizeUser(RoleModule.SightSeeingTariff, Function.View)]
        public JsonResult GetDuration(SightSeeingTariffViewModel sstViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = sstViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _sstRepo.GetDuration(ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("SightSeeingTariff Controller GetDuration");

            }

            catch (Exception ex)
            {
                sstViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("SightSeeingTariff Controller - GetDuration" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        #endregion

        #region SightSeeing Details

        [AuthorizeUser(RoleModule.SightSeeingTariff, Function.View)]
        public ActionResult GetSightSeeingById(SightSeeingTariffViewModel sstViewModel)
        {

            try
            {
                sstViewModel.SightSeeing = _sstRepo.GetSightSeeingById(sstViewModel.SightSeeing.SightSeeingId);

                Logger.Debug("SightSeeingTariff Controller GetSightSeeingDetailsById");
            }
            catch (Exception ex)
            {
                sstViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("SightSeeingTariff Controller - GetSightSeeingDetailsById" + ex.ToString());
            }

            TempData["sstViewModel"] = sstViewModel;

            return Json(sstViewModel, JsonRequestBehavior.AllowGet);

        }

        #endregion

    }
}
