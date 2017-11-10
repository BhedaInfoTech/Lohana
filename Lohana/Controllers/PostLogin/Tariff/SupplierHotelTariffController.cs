using Lohana.Common;
using Lohana.Models;
using Lohana.Models.Tariff.SupplierHotelTariff;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.SupplierHotelTariff;
using LohanaHelper.Logging;
using LohanaRepo.Master;
using LohanaRepo.Tariff.SupplierHotelTariff;
using LohanaRepo.Tariff.VehicleTariff;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Linq;

namespace Lohana.Controllers.PostLogin
{
    public class SupplierHotelTariffController : BaseController
    {
        SupplierHotelTariffRepo _sRepo;

        VehicleTariffRepo _vtRepo;

		TaxFormulaRepo _tRepo;

		ChargesRepo _cRepo;

        public SupplierHotelTariffController()
        {
            _sRepo = new SupplierHotelTariffRepo();

            _vtRepo = new VehicleTariffRepo();

			_tRepo = new TaxFormulaRepo();

			_cRepo = new ChargesRepo();
        }

        #region ActionResult

        public ActionResult Index(SupplierHotelTariffViewModel sViewModel)
        {
            // Fill Tax Formula Drop- down
			sViewModel.LstTaxFormula = _tRepo.drpGetTaxFormula();

            //Fill Customer Category Drop-down

            sViewModel.CustomerCategories = _vtRepo.drpGetCustomerCategories();

            sViewModel.LstStandardCharges = _cRepo.GetStandardCharges();

            return View(sViewModel);
        }

        public ActionResult GetCustomerCategoryMargin(SupplierHotelTariffViewModel sViewModel)
        {

            try
            {
                sViewModel.CustomerCategories = _vtRepo.GetCustomerCategoryDetailsById(sViewModel.SupplierHotelCustomerCategory.CustomerCategoryId);

                Logger.Debug("SupplierHotelTariff Controller GetCustomerCategoryMargin");
            }
            catch (Exception ex)
            {

                sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("SupplierHotelTariff Controller - GetCustomerCategoryMargin  " + ex.Message);
            }

            return Json(sViewModel, JsonRequestBehavior.AllowGet);

        }

        #endregion

       

		#region Supplier Hotel

		public JsonResult InsertSupplierHotel(SupplierHotelTariffViewModel sViewModel)
        {
            try
            {
                Set_Date_Session(sViewModel.SupplierHotelTariff);

                for (int i = 1; i <= sViewModel.SupplierHotelTariff.DayDuration; i++)
                {
                    SupplierHotelTariffDayInfo SupplierHotelDay = new SupplierHotelTariffDayInfo();

                    SupplierHotelDay.IsActive = true;
                    Set_Date_Session(SupplierHotelDay);

                    sViewModel.SupplierHotelTariff.supplierHotelTariffDays.Add(SupplierHotelDay);

                }

                _sRepo.InsertSupplierHotel(sViewModel.SupplierHotelTariff);

                sViewModel.FriendlyMessage.Add(MessageStore.Get("SUPPLIERHOTELTARIFF01"));

            }
            catch (Exception ex)
            {
                sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Insert Supplier Hotel Tariff Detail " + ex.Message);
            }

            return Json(sViewModel);
        }

		public JsonResult UpdateSupplierHotel(SupplierHotelTariffViewModel sViewModel)
        {
            try
            {
                Set_Date_Session(sViewModel.SupplierHotelTariff);

                _sRepo.UpdateSupplierHotel(sViewModel.SupplierHotelTariff);

                sViewModel.FriendlyMessage.Add(MessageStore.Get("SUPPLIERHOTELTARIFF01"));

            }
            catch (Exception ex)
            {
                sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Insert Supplier Hotel Tariff Detail " + ex.Message);
            }

            return Json(sViewModel);
        }

		public JsonResult GetSupplierHotel(SupplierHotelTariffViewModel sViewModel)
		{
			PaginationInfo pager = new PaginationInfo();

			pager = sViewModel.Pager;

			PaginationViewModel pViewModel = new PaginationViewModel();

			try
			{
				pViewModel.dt = _sRepo.GetSupplierHotel(ref pager);

				pViewModel.Pager = pager;
			}

			catch(Exception ex)
			{
				sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

				Logger.Error("SupplierHotel Controller- GetSupplierHotel" + ex.ToString());
			}

			return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);
		}

		#endregion

		#region Supplier Hotel Details

		public JsonResult InsertSupplierHotelDetail(SupplierHotelTariffViewModel sViewModel)
		{
			try
			{
				Set_Date_Session(sViewModel.SupplierHotelDetail);

				_sRepo.InsertSupplierHotelDetail(sViewModel.SupplierHotelDetail);

				sViewModel.FriendlyMessage.Add(MessageStore.Get("SUPPLIERHOTELTARIFF02"));

			}
			catch(Exception ex)
			{
				sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

				Logger.Error("Insert Supplier Hotel Detail " + ex.Message);
			}

			return Json(sViewModel);
		}

		public JsonResult UpdateSupplierHotelDetail(SupplierHotelTariffViewModel sViewModel)
		{
			try
			{
				Set_Date_Session(sViewModel.SupplierHotelDetail);

				_sRepo.UpdateSupplierHotelDetail(sViewModel.SupplierHotelDetail);

				sViewModel.FriendlyMessage.Add(MessageStore.Get("SUPPLIERHOTELTARIFF06"));

			}
			catch(Exception ex)
			{
				sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

				Logger.Error("Update Supplier Hotel Detail " + ex.Message);
			}

			return Json(sViewModel);
		}

		public JsonResult DeleteSupplierHotelDetail(int supplierHoteDetaillId)
		{
			SupplierHotelTariffViewModel sViewModel = new SupplierHotelTariffViewModel();

			try
			{
				_sRepo.DeleteSupplierHotelDetail(supplierHoteDetaillId);

				sViewModel.FriendlyMessage.Add(MessageStore.Get("SUPPLIERHOTELTARIFF07"));

			}
			catch(Exception ex)
			{
				sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

				Logger.Error("Delete Supplier Hotel Detail " + ex.Message);
			}

			return Json(sViewModel, JsonRequestBehavior.AllowGet);
		}

		public JsonResult GetSupplierHotelDetail(SupplierHotelTariffViewModel sViewModel)
		{
			PaginationInfo pager = new PaginationInfo();

			pager = sViewModel.Pager;

			PaginationViewModel pViewModel = new PaginationViewModel();

			try
			{
				pViewModel.dt = _sRepo.GetSupplierHotelDetail(sViewModel.SupplierHotelDetail.SupplierHotelId, ref pager);

				pViewModel.Pager = pager;
			}
			catch(Exception ex)
			{
				sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

				Logger.Error("SupplierHotel Controller- GetSupplierHotelDetail" + ex.ToString());
			}
			return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);
		}

		#endregion

        #region OccupancyDetails

        public JsonResult InsertSupplierOccupancyDetail(SupplierHotelTariffViewModel sViewModel)
        {
            try
            {
                Set_Date_Session(sViewModel.SupplierOccupancyDetail);

                _sRepo.InsertSupplierOccupancyDetail(sViewModel.SupplierOccupancyDetail);

                sViewModel.FriendlyMessage.Add(MessageStore.Get("SUPPLIERHOTELTARIFF12"));

            }
            catch (Exception ex)
            {
                sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Insert Supplier Hotel Detail " + ex.Message);
            }

            return Json(sViewModel);
        }

        public JsonResult UpdateSupplierOccupancyDetail(SupplierHotelTariffViewModel sViewModel)
        {
            try
            {
                Set_Date_Session(sViewModel.SupplierOccupancyDetail);

                _sRepo.UpdateSupplierOccupancyDetail(sViewModel.SupplierOccupancyDetail);

                sViewModel.FriendlyMessage.Add(MessageStore.Get("SUPPLIERHOTELTARIFF13"));

            }
            catch (Exception ex)
            {
                sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Insert Supplier Hotel Tariff Detail " + ex.Message);
            }

            return Json(sViewModel);
        }

        public JsonResult GetSupplierOccupancyDetail(SupplierHotelTariffViewModel sViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = sViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _sRepo.GetSupplierOccupancyDetail(sViewModel.SupplierOccupancyDetail.SupplierHotelId, ref pager);

                pViewModel.Pager = pager;
            }
            catch (Exception ex)
            {
                sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("SupplierHotel Controller- GetSupplierHotelDetail" + ex.ToString());
            }
            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Supplier Hotel Price Details

        public PartialViewResult GetTaxFormulaCharges(int taxFormulaId, int supplierHotelTriffPriceId)
		{
			SupplierHotelTariffViewModel sViewModel = new SupplierHotelTariffViewModel();

			PaginationInfo pager = null;

			if(supplierHotelTriffPriceId != 0)
			{
				sViewModel.LstTaxFormulaCharges = _sRepo.GetSupplierHotelTaxFormulaChargesByPriceId(taxFormulaId, supplierHotelTriffPriceId, ref pager);

				if(sViewModel.LstTaxFormulaCharges.Count > 0)
				{
					sViewModel.SupplierHotelPrice.TotalTaxPrice = sViewModel.LstTaxFormulaCharges[0].HotelTariffCharge.TotalTaxPrice;
				}
				else
				{
					sViewModel.LstTaxFormulaCharges = _tRepo.GetTaxFormulaCharges(taxFormulaId, ref pager);
				}
			}
			else
			{
				sViewModel.LstTaxFormulaCharges = _tRepo.GetTaxFormulaCharges(taxFormulaId, ref pager);

			}

			return PartialView("_PriceTaxFormulaCharges", sViewModel);
		}

		public JsonResult InsertSupplierHotelPrice(SupplierHotelTariffViewModel sViewModel)
		{
			try
			{
				Set_Date_Session(sViewModel.SupplierHotelPrice);

				_sRepo.InsertSupplierHotelPrice(sViewModel.SupplierHotelPrice);

				sViewModel.FriendlyMessage.Add(MessageStore.Get("HotelTariffPrice01"));

			}
			catch(Exception ex)
			{
				sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

				Logger.Error("SupplierHotelTariff Controller - InsertSupplierHotelPrice " + ex.Message);
			}

			return Json(sViewModel);
		}

		public JsonResult UpdateSupplierHotelPrice(SupplierHotelTariffViewModel sViewModel)
		{
			try
			{
				Set_Date_Session(sViewModel.SupplierHotelPrice);

				_sRepo.UpdateSupplierHotelPrice(sViewModel.SupplierHotelPrice);

				sViewModel.FriendlyMessage.Add(MessageStore.Get("HotelTariffPrice02"));

				Logger.Debug("HotelTariff Controller InsertPrice");
			}
			catch(Exception ex)
			{

				sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

				Logger.Error("Hotel Tariff Controller - UpdatePrice  " + ex.Message);
			}

			return Json(sViewModel);

		}

		public PartialViewResult GetSupplierHotelTariffPrice(int OccupancyDetailId)
		{
			SupplierHotelTariffViewModel sViewModel = new SupplierHotelTariffViewModel();

			try
			{
                sViewModel.LstSupplierHotelPrice = _sRepo.GetSupplierHotelPrice(OccupancyDetailId);
			}
			catch(Exception ex)
			{
				sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

				Logger.Error("HotelTariff Controller - GetHotelTariffPrice" + ex.ToString());
			}

			TempData["sViewModel"] = sViewModel;

			return PartialView("_PriceList", sViewModel);
		}

		public JsonResult GetSupplierHotelPriceById(SupplierHotelTariffViewModel sViewModel)
		{
			try
			{
				sViewModel.SupplierHotelPrice = _sRepo.GetSupplierHotelPriceById(sViewModel.SupplierHotelPrice.SupplierHotelPriceId);
			}
			catch(Exception ex)
			{
				sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

				Logger.Error("Hotel Tariff Controller - GetHotelTariffPriceById  " + ex.Message);
			}

			return Json(sViewModel);
		}

		#endregion

        #region SupplierHotelTariffPriceDuration

        public PartialViewResult GetSupplierHotelTariffDuration(int SupplierHotelPriceId)
        {
            SupplierHotelTariffViewModel sViewModel = new SupplierHotelTariffViewModel();

            try
            {

            }
            catch (Exception ex)
            {
                sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Supplier Hotel Tariff Controller - GetSupplierHotelTariffDuration  " + ex.Message);
            }

            return PartialView("_DurationDetails", sViewModel);
        }

        public JsonResult GetSupplierHotelTariffDurationPrice(int OccupancyDetailId)
        {
            SupplierHotelTariffViewModel sViewModel = new SupplierHotelTariffViewModel();

            try
            {
                sViewModel.SupplierHotelTariffDurations = _sRepo.GetSupplierHotelTariffDurationPrice(OccupancyDetailId);

                sViewModel.LstSupplierHotelPrice = _sRepo.GetSupplierHotelPrice(OccupancyDetailId);
            }
            catch (Exception ex)
            {
                sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Hotel Tariff Controller - GetHotelTariffDuration  " + ex.Message);
            }

            return Json(sViewModel, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveSupplierHotelTariffDurationWithCustomerCategories(SupplierHotelTariffViewModel sViewModel)
        {
            List<DateTime> filterDates = new List<DateTime>();

            try
            {
                foreach (var item in sViewModel.SupplierHotelCustomerCategories)
                {
                    Set_Date_Session(item);
                }

                

                filterDates = _sRepo.GetFilteredDateForDuration(sViewModel.SupplierHotelDuration);

                sViewModel.SupplierHotelPrice = _sRepo.GetSupplierHotelPriceById(sViewModel.SupplierHotelDuration.SupplierHotelPriceId);

                //htViewModel.HotelTariffDate.NoOfNight = htViewModel.HotelTariffDuration.NoOfNight;

                sViewModel.SupplierHotelTariffDuration.NetRate = sViewModel.SupplierHotelPrice.NetRate;

                sViewModel.SupplierHotelTariffDuration.SupplierHotelPriceId = sViewModel.SupplierHotelDuration.SupplierHotelPriceId;

                sViewModel.SupplierHotelTariffDuration.OccupancyDetailId = sViewModel.SupplierHotelDuration.OccupancyDetailId;

                _sRepo.SaveSupplierHotelTariffDurationWithCustomerCategories(filterDates, sViewModel.SupplierHotelTariffDuration, sViewModel.SupplierHotelCustomerCategories);

                sViewModel.FriendlyMessage.Add(MessageStore.Get("SUPPLIERHOTELTARIFF14"));
            }
            catch (Exception ex)
            {
                sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Hotel Tariff Controller - GetHotelTariffDuration  " + ex.Message);
            }

            return Json(sViewModel);
        }

        public JsonResult IsOverrideDate(SupplierHotelTariffViewModel sViewModel)
        {
            List<DateTime> filterDates = new List<DateTime>();

            bool isOverride = false;

            try
            {
                filterDates = _sRepo.GetFilteredDateForDuration(sViewModel.SupplierHotelDuration);

                sViewModel.SupplierHotelTariffDurations = _sRepo.GetSupplierHotelTariffDurationPrice(sViewModel.SupplierHotelDuration.OccupancyDetailId);

                foreach (var item in filterDates)
                {
                    if (sViewModel.SupplierHotelTariffDurations.Where(a=> a.TariffDate == item).Count() > 0)
                    {
                        isOverride = true;

                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Hotel Tariff Controller - IsOverrideDate  " + ex.Message);
            }

            return Json(isOverride);
        }




        #endregion


        #region View Customer Category

        public PartialViewResult GetCustomerCategoryByOccupencyIdTariffDate(int SupplierHotelPriceId, DateTime TariffDate)
       
        {
        SupplierHotelTariffViewModel sViewModel = new SupplierHotelTariffViewModel();

         try
          
           {

               sViewModel.SupplierHotelCustomerCategories = _sRepo.GetSupplierHotelTariffCustomerCategory(SupplierHotelPriceId, TariffDate);
          
        }

        catch (Exception ex)
            {
                sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error(" Supplier Hotel Tariff Controller - GetHotelTariffDuration  " + ex.Message);
            }
            
            return PartialView("_CustomerCategoryPopup", sViewModel);
        }

        




            #endregion


        

        #region Supplier Hotels Days

        #region Partial View

        public PartialViewResult GetDayTitle(SupplierHotelTariffViewModel sViewModel, int SupplierHotelDayId, int SupplierHotelId)
        {
            sViewModel.SupplierHotelTariffDayInfo.SupplierHotelDayId = SupplierHotelDayId;

            sViewModel.SupplierHotelTariffDayInfo.SupplierHotelId = SupplierHotelId;

            return PartialView("_DayTitle", sViewModel);
        }

        public PartialViewResult GetAddHotel(SupplierHotelTariffViewModel sViewModel)
        {

            return PartialView("_HotelRoomDetails", sViewModel);
        }

        public PartialViewResult GetAddSightseeing(SupplierHotelTariffViewModel sViewModel)
        {
           
            return PartialView("_SightseeingDetails", sViewModel);
        }

        public PartialViewResult GetAddVehicle(SupplierHotelTariffViewModel sViewModel)
        {
          
            return PartialView("_VehicleDetails", sViewModel);
        }

        public PartialViewResult GetAddMeal(SupplierHotelTariffViewModel sViewModel)
        {
           

            return PartialView("_MealDetails", sViewModel);
        }

        #endregion

        public JsonResult UpdateSupplierHotelDays(SupplierHotelTariffViewModel sViewModel)
        {
            try
            {
                Set_Date_Session(sViewModel.SupplierHotelTariffDayInfo);

                _sRepo.Update_SupplierHotelDay(sViewModel.SupplierHotelTariffDayInfo);

                sViewModel.FriendlyMessage.Add(MessageStore.Get("SUPPLIERHOTELTARIFF15"));

            }
            catch (Exception ex)
            {
                sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("SupplierHotel Controller- UpdateSupplierHotelDays" + ex.ToString());
            }

            return Json(sViewModel);
        }

        public PartialViewResult GetSupplierHotelTariffDays(int SupplierHotelId)
        {
            SupplierHotelTariffViewModel sViewModel = new SupplierHotelTariffViewModel();

            try
            {

                sViewModel.SupplierHotelTariffDays = _sRepo.Get_SupplierHotelTariffDays(SupplierHotelId);

            }
            catch (Exception ex)
            {
                sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("SupplierHotel Controller- GetSupplierHotelTariffDays" + ex.ToString());
            }

           
            return PartialView("_Itinerary_Days", sViewModel);
        }

        public JsonResult InsertSupplierHotelDayItem(SupplierHotelTariffViewModel sViewModel)
        {
            try
            {
                Set_Date_Session(sViewModel.SupplierHotelDayItem);

                _sRepo.Insert_SupplierHotelDayItem(sViewModel.SupplierHotelDayItem);

                sViewModel.FriendlyMessage.Add(MessageStore.Get("SUPPLIERHOTELTARIFF16"));

            }
            catch (Exception ex)
            {
                sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("SupplierHotel Controller- UpdateSupplierHotelDays" + ex.ToString());
            }

            return Json(sViewModel);
        }
        public ActionResult DeleteDayItem(SupplierHotelTariffViewModel sViewModel)
        {


            try
            {

                _sRepo.DeleteDayItem(sViewModel.SupplierHotelDayItem.SupplierHotelDayItemId);

                sViewModel.FriendlyMessage.Add(MessageStore.Get("SUPPLIERHOTELTARIFF17"));

             Logger.Debug("SupplierHotelTariff Controller Delete");

            }
            catch (Exception ex)
            {
                sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("SupplierHotel Controller- DeleteDayItem" + ex.ToString());
            }

            return Json(sViewModel);

           

        }

        #endregion

    }
}
