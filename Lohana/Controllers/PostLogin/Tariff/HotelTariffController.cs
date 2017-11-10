using Lohana.Common;
using Lohana.Models;
using Lohana.Models.Tariff.HotelTariff;
using LohanaBusinessEntities.Occupancy;
using LohanaBusinessEntities;
using LohanaBusinessEntities.Common;
using LohanaHelper.Authorization;
using LohanaHelper.Logging;
using LohanaRepo.HotelTariff;
using LohanaRepo.Master;
using LohanaRepo.Tariff.VehicleTariff;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;

namespace Lohana.Controllers.PostLogin
{
    public class HotelTariffController : BaseController
    {

         public HotelTariffRepo _htRepo;

         TaxFormulaRepo _tRepo;

         ChargesRepo _cRepo;

         VehicleTariffRepo _vtRepo;

         public HotelTariffController()
        {
            _htRepo = new HotelTariffRepo();

            _tRepo = new TaxFormulaRepo();

            _cRepo = new ChargesRepo();

            _vtRepo = new VehicleTariffRepo();
        }

         [AuthorizeUser(RoleModule.HotelTariff, Function.View)]
         public ActionResult Index(HotelTariffViewModel htViewModel)
            {
                if (TempData["htViewModel"] != null)
                {
                    htViewModel = (HotelTariffViewModel)TempData["htViewModel"];
                }
                Set_Date_Session(htViewModel.HotelTariff);

				//htViewModel.Vendors = _htRepo.drpGetVendors();

				//htViewModel.Hotels = _htRepo.drpGetHotels();

				//htViewModel.RoomTypes = _htRepo.drpGetRoomTypes();

				//htViewModel.Meals = _htRepo.drpGetMeals();

				//htViewModel.Occupancies = _htRepo.drpGetOccupancies();

				////Price dropdowns

				htViewModel.LstTaxFormula = _tRepo.drpGetTaxFormula();

				htViewModel.LstStandardCharges = _cRepo.GetStandardCharges();

				htViewModel.CustomerCategories = _vtRepo.drpGetCustomerCategories();

                return View("Index", htViewModel);
            }

         [AuthorizeUser(RoleModule.HotelTariff, Function.View)]
		 public ActionResult Search()
		{
			return View();
        }

        #region HotelTariff Basic

        [AuthorizeUser(RoleModule.HotelTariff, Function.Create)]
        public JsonResult InsertHotelTariff(HotelTariffViewModel htViewModel)
        {
            try
            {
                Set_Date_Session(htViewModel.HotelTariff);

                htViewModel.HotelTariff.HotelTariffId = _htRepo.InsertHotelTariff(htViewModel.HotelTariff);


                htViewModel.FriendlyMessage.Add(MessageStore.Get("HotelTariff01"));

                Logger.Debug("HotelTariff Controller Insert");

            }
            catch (Exception ex)
            {
                htViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("HotelTariff Controller - Insert " + ex.Message);
            }

            return Json(htViewModel);
        }

        [AuthorizeUser(RoleModule.HotelTariff, Function.View)]
        public JsonResult GetHotelTariff(HotelTariffViewModel htViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = htViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {


                pViewModel.dt = _htRepo.GetHotelTariff(htViewModel.HotelTariff.VendorId, htViewModel.HotelTariff.HotelId,htViewModel.HotelTariff.CityId, ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("HotelTariff Controller GetHotelTariff");

            }

            catch (Exception ex)
            {
                htViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("HotelTariff Controller - GetHotelTariff" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        [AuthorizeUser(RoleModule.HotelTariff, Function.Edit)]
        public JsonResult UpdateHotelTariff(HotelTariffViewModel htViewModel)
        {
            try
            {
                Set_Date_Session(htViewModel.HotelTariff);

                _htRepo.UpdateHotelTariff(htViewModel.HotelTariff);

                htViewModel.FriendlyMessage.Add(MessageStore.Get("HotelTariff02"));

                Logger.Debug("HotelTariff Controller UpdateHotelTariff");
            }
            catch (Exception ex)
            {

                htViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("HotelTariff Controller - UpdateHotelTariff  " + ex.Message);
            }

            return Json(htViewModel);

        }

		public JsonResult IsSameHotelVendorExists(int hotelId, int vendorId = 0)
		{
			bool result = false;	

			try
			{
				if(!_htRepo.IsSameHotelVendorExists(vendorId,hotelId))
				{
					result = true;
				}
			}
			catch(Exception ex)
			{
				Logger.Error("HotelTariff Controller - IsSameHotelVendorExists  " + ex.Message);
			}

			return Json(result, JsonRequestBehavior.AllowGet);
		}
        #endregion

        #region HotelTariffRoom

        [AuthorizeUser(RoleModule.HotelTariff, Function.Create)]
        public JsonResult InsertRoom(HotelTariffViewModel htViewModel)
        {
            try
            {
                Set_Date_Session(htViewModel.HotelTariffRoom);

                htViewModel.HotelTariffRoom.HotelTariffRoomDetailsId = _htRepo.InsertHotelTariffRoomDetails(htViewModel.HotelTariffRoom);

                htViewModel.FriendlyMessage.Add(MessageStore.Get("HotelTariffRoom01"));

                Logger.Debug("HotelTariff Controller InsertRoom");

            }
            catch (Exception ex)
            {
                htViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("HotelTariff Controller - InsertRoom " + ex.Message);
            }

            return Json(htViewModel);
        }

        [AuthorizeUser(RoleModule.HotelTariff, Function.View)]
        public JsonResult GetRoom(HotelTariffViewModel htViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = htViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {


                pViewModel.dt = _htRepo.GetRoom(htViewModel.HotelTariffRoom.HotelTariffId, ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("HotelTariff Controller GetRoom");

            }

            catch (Exception ex)
            {
                htViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("HotelTariff Controller - GetRoom" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        [AuthorizeUser(RoleModule.HotelTariff, Function.Edit)]
        public JsonResult UpdateRoom(HotelTariffViewModel htViewModel)
        {
            try
            {
                Set_Date_Session(htViewModel.HotelTariffRoom);

                _htRepo.UpdateHotelTariffRoomDetails(htViewModel.HotelTariffRoom);

                htViewModel.FriendlyMessage.Add(MessageStore.Get("HotelTariffRoom02"));

                Logger.Debug("HotelTariff Controller UpdateRoom");
            }
            catch (Exception ex)
            {

                htViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("HotelTariff Controller - UpdateRoom  " + ex.Message);
            }

            return Json(htViewModel);

        }

        [AuthorizeUser(RoleModule.HotelTariff, Function.View)]
        public JsonResult DeleteRoom(HotelTariffViewModel htViewModel)
        {
            try
            {
                _htRepo.DeleteRoom(htViewModel.HotelTariffRoom.HotelTariffId,htViewModel.HotelTariffRoom.HotelTariffRoomDetailsId);

                htViewModel.FriendlyMessage.Add(MessageStore.Get("HotelTariffRoom03"));

            }
            catch (Exception ex)
            {
                htViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));


                Logger.Error("HotelTariff Controller - DeleteRoom" + ex.ToString());
            }

            return Json(htViewModel);
        }


        #endregion

        #region HotelTariffRoomOccupancy

        // [AuthorizeUser(RoleModule.HotelTariff, Function.Create)]
        public JsonResult InsertRoomOccupancy(HotelTariffViewModel htViewModel)
        {
            try
            {
                Set_Date_Session(htViewModel.HotelTariffRoomOccupancy);

                htViewModel.HotelTariffRoomOccupancy.HotelTariffRoomOccupancyId = _htRepo.InsertHotelTariffRoomOccupancy(htViewModel.HotelTariffRoomOccupancy);

                htViewModel.FriendlyMessage.Add(MessageStore.Get("HotelTariffRoomOccupancy01"));

                Logger.Debug("HotelTariff Controller InsertRoomOccupancy");

            }
            catch (Exception ex)
            {
                htViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("HotelTariff Controller - InsertRoomOccupancy " + ex.Message);
            }

            return Json(htViewModel);
        }

      //  [AuthorizeUser(RoleModule.HotelTariff, Function.View)]
        public JsonResult GetRoomOccupancy(HotelTariffViewModel htViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = htViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {


                pViewModel.dt = _htRepo.GetRoomOccupancy(htViewModel.HotelTariffRoomOccupancy.HotelTariffRoomDetailsId, ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("HotelTariff Controller GetRoomOccupancy");

            }

            catch (Exception ex)
            {
                htViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("HotelTariff Controller - GetRoomOccupancy" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        //[AuthorizeUser(RoleModule.HotelTariff, Function.Edit)]
        public JsonResult UpdateRoomOccupancy(HotelTariffViewModel htViewModel)
        {
            try
            {
                Set_Date_Session(htViewModel.HotelTariffRoomOccupancy);

                _htRepo.UpdateHotelTariffRoomOccupancy(htViewModel.HotelTariffRoomOccupancy);

                htViewModel.FriendlyMessage.Add(MessageStore.Get("HotelTariffRoomOccupancy02"));

                Logger.Debug("HotelTariff Controller UpdateRoomOccupancy");
            }
            catch (Exception ex)
            {

                htViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("HotelTariff Controller - UpdateRoomOccupancy  " + ex.Message);
            }

            return Json(htViewModel);

        }

        [AuthorizeUser(RoleModule.HotelTariff, Function.View)]
        public JsonResult DeleteRoomOccupancy(HotelTariffViewModel htViewModel)
        {
            try
            {
                _htRepo.DeleteRoomOccupancy(htViewModel.HotelTariffRoomOccupancy.HotelTariffRoomDetailsId, htViewModel.HotelTariffRoomOccupancy.HotelTariffRoomOccupancyId);

                htViewModel.FriendlyMessage.Add(MessageStore.Get("HotelTariffRoomOccupancy03"));

            }
            catch (Exception ex)
            {
                htViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));


                Logger.Error("HotelTariff Controller - DeleteRoomOccupancy" + ex.ToString());
            }

            return Json(htViewModel);
        }


        #endregion

        #region HotelTariffPrice   

        public PartialViewResult GetTaxFormulaCharges(int TaxFormulaId, int HotelTriffPriceDetailsId)
        {
            HotelTariffViewModel htViewModel = new HotelTariffViewModel();

            PaginationInfo pager = null;

            if (HotelTriffPriceDetailsId != 0)
            {
				htViewModel.LstTaxFormulaCharges = _htRepo.GetTaxFormulaChargesByPriceId(TaxFormulaId, HotelTriffPriceDetailsId, ref pager);

                if (htViewModel.LstTaxFormulaCharges.Count > 0)
                {
                    htViewModel.HotelTariffPrice.TotalTaxPrice = htViewModel.LstTaxFormulaCharges[0].HotelTariffCharge.TotalTaxPrice;
                }
                else
                {
                    htViewModel.LstTaxFormulaCharges = _tRepo.GetTaxFormulaCharges(TaxFormulaId, ref pager);
                }
            }
            else
            {
                htViewModel.LstTaxFormulaCharges = _tRepo.GetTaxFormulaCharges(TaxFormulaId, ref pager);

            }
        
            return PartialView("_PriceTaxFormulaCharges", htViewModel);
        }

        public JsonResult InsertPrice(HotelTariffViewModel htViewModel)
        {
            try
            {
                Set_Date_Session(htViewModel.HotelTariffPrice);

				//htViewModel.HotelTariffPrice.Color = GetRandomColorName();

                htViewModel.HotelTariffPrice.HotelTariffPriceDetailsId = _htRepo.InsertHotelTariffPriceDetails(htViewModel.HotelTariffPrice);

                //List<DateTime> Dates=_htRepo.GetFilteredDate(htViewModel.HotelTariffPrice);

                //_htRepo.InsertHotelTariffDateDetails(Dates,htViewModel.HotelTariffPrice);

                htViewModel.FriendlyMessage.Add(MessageStore.Get("HotelTariffPrice01"));

            }
            catch (Exception ex)
            {
                htViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("HotelTariff Controller - InsertPrice " + ex.Message);
            }

            return Json(htViewModel);
        }

        public PartialViewResult GetHotelTariffPrice(int hotelTariffRoomOccupancyId)
        {
			HotelTariffViewModel htViewModel = new HotelTariffViewModel();

            try
            {
                htViewModel.HotelTariffPrices = _htRepo.GetHotelTariffPrice(hotelTariffRoomOccupancyId);
            }
            catch (Exception ex)
            {
                htViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

				Logger.Error("HotelTariff Controller - GetHotelTariffPrice" + ex.ToString());
            }

            TempData["htViewModel"] = htViewModel;

            return PartialView("_PriceList",htViewModel);
        }

        public JsonResult UpdatePrice(HotelTariffViewModel htViewModel)
        {
            try
            {
                Set_Date_Session(htViewModel.HotelTariffPrice);

				//htViewModel.HotelTariffPrice.Color = GetRandomColorName();

                _htRepo.UpdateHotelTariffPriceDetails(htViewModel.HotelTariffPrice);

				//_htRepo.DeleteHotelTariffDates(htViewModel.HotelTariffPrice.HotelTariffPriceDetailsId);

				//List<DateTime> Dates = _htRepo.GetFilteredDate(htViewModel.HotelTariffPrice);

				//_htRepo.InsertHotelTariffDateDetails(Dates, htViewModel.HotelTariffPrice);

                htViewModel.FriendlyMessage.Add(MessageStore.Get("HotelTariffPrice02"));

                Logger.Debug("HotelTariff Controller InsertPrice");
            }
            catch (Exception ex)
            {

                htViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Hotel Tariff Controller - UpdatePrice  " + ex.Message);
            }

            return Json(htViewModel);

        }

		public JsonResult GetHotelTariffPriceById(HotelTariffViewModel htViewModel)
		{
			try
			{
				htViewModel.HotelTariffPrice = _htRepo.GetHotelTariffPriceById(htViewModel.HotelTariffPrice.HotelTariffPriceDetailsId);
			}
			catch(Exception ex)
			{
				htViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

				Logger.Error("Hotel Tariff Controller - GetHotelTariffPriceById  " + ex.Message);
			}

			return Json(htViewModel);
		}

        #endregion

		#region HotelTariffPriceDuration

		public PartialViewResult GetHotelTariffDuration(int hotelTariffPriceDetailsId)
		{
			HotelTariffViewModel htViewModel = new HotelTariffViewModel();

			try
			{

			}
			catch(Exception ex)
			{
				htViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

				Logger.Error("Hotel Tariff Controller - GetHotelTariffDuration  " + ex.Message);
			}

			return PartialView("_DurationDetails", htViewModel);
		}

        public JsonResult GetHotelTariffDurationPrice(int hotelTariffRoomOccupancyId)
		{
			HotelTariffViewModel htViewModel = new HotelTariffViewModel();

			try
			{
                htViewModel.HotelTariffDates = _htRepo.GetHotelTariffDurationPrice(hotelTariffRoomOccupancyId);

                htViewModel.HotelTariffPrices = _htRepo.GetHotelTariffPrice(hotelTariffRoomOccupancyId);
			}
			catch(Exception ex)
			{
				htViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

				Logger.Error("Hotel Tariff Controller - GetHotelTariffDuration  " + ex.Message);
			}

			return Json(htViewModel,JsonRequestBehavior.AllowGet);
		}

        public JsonResult SaveHotelTariffDurationWithCustomerCategories(HotelTariffViewModel htViewModel)
		{
			List<DateTime> filterDates = new List<DateTime>(); 

			try
			{
                foreach(var item in htViewModel.HotelTariffCustomerCategories)
                {
                    Set_Date_Session(item);
                }

				filterDates = _htRepo.GetFilteredDateForDuration(htViewModel.HotelTariffDuration);

				htViewModel.HotelTariffPrice = _htRepo.GetHotelTariffPriceById(htViewModel.HotelTariffDuration.HotelTariffPriceDetailsId);

				htViewModel.HotelTariffDate.NoOfNight = htViewModel.HotelTariffDuration.NoOfNight;

				htViewModel.HotelTariffDate.NetRate  =  htViewModel.HotelTariffPrice.NetRatePerNight;

				htViewModel.HotelTariffDate.HotelTariffPriceDetailsId = htViewModel.HotelTariffDuration.HotelTariffPriceDetailsId;

                htViewModel.HotelTariffDate.HotelTariffRoomOccupancyId = htViewModel.HotelTariffDuration.HotelTariffRoomOccupancyId;

                _htRepo.SaveHotelTariffDurationWithCustomerCategories(filterDates, htViewModel.HotelTariffDate, htViewModel.HotelTariffCustomerCategories);

				htViewModel.FriendlyMessage.Add(MessageStore.Get("HotelTariffDuration01"));
			}
			catch(Exception ex)
			{
				htViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

				Logger.Error("Hotel Tariff Controller - GetHotelTariffDuration  " + ex.Message);
			}

			return Json(htViewModel);
		}

		public JsonResult IsOverrideDate(HotelTariffViewModel htViewModel)
		{
			List<DateTime> filterDates = new List<DateTime>();

			bool isOverride = false;

			try
			{
				filterDates = _htRepo.GetFilteredDateForDuration(htViewModel.HotelTariffDuration);

				htViewModel.HotelTariffDates = _htRepo.GetHotelTariffDurationPrice(htViewModel.HotelTariffDuration.HotelTariffRoomOccupancyId);

				foreach(var item in filterDates)
				{
					if(htViewModel.HotelTariffDates.Where(a => a.TariffDate == item).Count() > 0)
					{
						isOverride = true;

						break;
					}
				}
			}
			catch(Exception ex)
			{
				htViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

				Logger.Error("Hotel Tariff Controller - IsOverrideDate  " + ex.Message);
			}

			return Json(isOverride);
		}

		#endregion

		#region HoteltariffCustomerCategory

		public ActionResult GetCustomerCategoryMargin(HotelTariffViewModel htViewModel)
        {

            try
            {
                htViewModel.CustomerCategories = _vtRepo.GetCustomerCategoryDetailsById(htViewModel.HotelTariffCustomerCategory.CustomerCategoryId);

                Logger.Debug("HotelTariff Controller GetCustomerCategoryDetailsById");
            }
            catch (Exception ex)
            {

                htViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("VehicleTariff Controller - GetCustomerCategoryDetailsById  " + ex.Message);
            }

            return Json(htViewModel, JsonRequestBehavior.AllowGet);

        }

        public JsonResult InsertCustomerCategory(HotelTariffViewModel htViewModel)
        {
            try
            {
                Set_Date_Session(htViewModel.HotelTariffCustomerCategory);

                _htRepo.SaveHotelTariffCustomerCategory(htViewModel.HotelTariffCustomerCategory);

                htViewModel.FriendlyMessage.Add(MessageStore.Get("HotelTariffCustomerCategory01"));

                Logger.Debug("HotelTariff Controller InsertCustomerCategory");

            }
            catch (Exception ex)
            {
                htViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("HotelTariff Controller - InsertCustomerCategory " + ex.Message);
            }

            return Json(htViewModel);
        }

        [AuthorizeUser(RoleModule.HotelTariff, Function.View)]
        public JsonResult GetCustomerCategory(HotelTariffViewModel htViewModel)
        {
            //PaginationInfo pager = new PaginationInfo();

            //pager = htViewModel.Pager;

            //PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {


               // htViewModel.dt = _htRepo.GetCustomerCategory(htViewModel.HotelTariffCustomerCategory.HotelTariffDateDetailsId, ref pager);

                htViewModel.HotelTariffCustomerCategories = _htRepo.GetCustomerCategory();

               // pViewModel.Pager = pager;

                Logger.Debug("HotelTariff Controller GetCustomerCategory");

            }

            catch (Exception ex)
            {
                htViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("HotelTariff Controller - GetCustomerCategory" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(htViewModel), JsonRequestBehavior.AllowGet);

        }

        [AuthorizeUser(RoleModule.HotelTariff, Function.Edit)]
        public JsonResult UpdateCustomerCategory(HotelTariffViewModel htViewModel)
        {
            try
            {
                Set_Date_Session(htViewModel.HotelTariffCustomerCategory);

                _htRepo.UpdateCustomerCategory(htViewModel.HotelTariffCustomerCategory);

                htViewModel.FriendlyMessage.Add(MessageStore.Get("HotelTariffCustomerCategory02"));

                Logger.Debug("HotelTariff Controller UpdateCustomerCategory");
            }
            catch (Exception ex)
            {

                htViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("HotelTariff Controller - UpdateCustomerCategory " + ex.Message);
            }

            return Json(htViewModel);

        }

		//[AuthorizeUser(RoleModule.HotelTariff, Function.View)]
		//public JsonResult DeleteCustomerCategory(HotelTariffViewModel htViewModel)
		//{
		//	try
		//	{
		//		_htRepo.DeleteCustomerCategory(htViewModel.HotelTariffCustomerCategory.HotelTariffDurationDetailsId,htViewModel.HotelTariffCustomerCategory.HotelTariffRoomDetailsId, htViewModel.HotelTariffCustomerCategory.HotelTariffCustomerCategoryId);

		//		htViewModel.FriendlyMessage.Add(MessageStore.Get("HotelTariffCustomerCategory03"));

		//	}
		//	catch (Exception ex)
		//	{
		//		htViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));


		//		Logger.Error("HotelTariff Controller - DeleteCustomerCategory" + ex.ToString());
		//	}

		//	return Json(htViewModel);
		//}

        #endregion

        public PartialViewResult GetCustomerCategoryByOccupencyIdTariffDate(int hotelTariffRoomOccupancyId, DateTime tariffDate)
        {
            HotelTariffViewModel htViewModel = new HotelTariffViewModel();
            try
            {

                htViewModel.HotelTariffCustomerCategories = _htRepo.GetHotelTariffCustomerCategory(hotelTariffRoomOccupancyId, tariffDate);
            }

            catch (Exception ex)
            {
                htViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Hotel Tariff Controller - GetHotelTariffDuration  " + ex.Message);
            }
            return PartialView("_CustomerCategory", htViewModel);
        }
    }
}
