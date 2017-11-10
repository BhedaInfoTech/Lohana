using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Lohana.Models.Master;
using LohanaBusinessEntities.Package;
using LohanaBusinessEntities.Common;
using LohanaRepo.Master;
using LohanaHelper;
using Newtonsoft.Json;
using LohanaHelper.Logging;
using Lohana.Common;
using LohanaBusinessEntities;
using Lohana.Models;
using LohanaHelper.Authorization;
using LohanaRepo.Accessories;
using System.Text;
using LohanaBusinessLogic.Utilities;
using System.IO;
using System.Configuration;
using Lohana.Models.Quotation;
using System.Web.Script.Serialization;
using LohanaBusinessEntities.Quotation;

namespace Lohana.Controllers.PostLogin.Master
{

    [SessionExpired]

    public class PackageController : BaseController
    {

        public PackageRepo _pRepo;

        public PackageController()
        {
            _pRepo = new PackageRepo();
        }

        [AuthorizeUser(RoleModule.PackageItienaryBased, Function.View)]
        public ActionResult Index(PackageViewModel pViewModel)
        {
            if (TempData["pViewModel"] != null)
            {
                pViewModel = (PackageViewModel)TempData["pViewModel"];
            }
             
            pViewModel.Cities = _pRepo.drpGetCities();

            pViewModel.PackageTypes = _pRepo.drpGetPackageTypes(); 

            pViewModel.Meals = _pRepo.drpGetMeals();

            return View("Index", pViewModel);
        }

        [AuthorizeUser(RoleModule.PackageItienaryBased, Function.View)]
        public ActionResult Search(PackageViewModel pViewModel)
        {

            pViewModel.PackageTypes = _pRepo.drpGetPackageTypes();

            return View("Search", pViewModel);
        }


        #region Package
        //Package

        [AuthorizeUser(RoleModule.PackageItienaryBased, Function.Create)]
        public JsonResult InsertPackage(PackageViewModel pViewModel)
        {
            try
            {
                Set_Date_Session(pViewModel.Package);

                for (int i = 1; i <= pViewModel.Package.DayDuration; i++)
                {
                    PackageDaysTriffInfo perDates = new PackageDaysTriffInfo();

                  
                    Set_Date_Session(perDates);

                    pViewModel.Package.PackageDaysTriffInfo.Add(perDates);

                }

                pViewModel.Package.PackageId = _pRepo.InsertPackage(pViewModel.Package);

                pViewModel.FriendlyMessage.Add(MessageStore.Get("PKG01"));

            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - Insert " + ex.Message);
            }

            return Json(pViewModel);

        }

        public JsonResult InsertPackageDayItem(PackageViewModel pViewModel)
            {
            try
            {
                Set_Date_Session(pViewModel.packageDayItems);

                _pRepo.Insert_PackageDayItem(pViewModel.packageDayItems);

                pViewModel.FriendlyMessage.Add(MessageStore.Get("SUPPLIERHOTELTARIFF16"));

            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("SupplierHotel Controller- UpdateSupplierHotelDays" + ex.ToString());
            }

            return Json(pViewModel);
        }


        public JsonResult UpdatePackagedays(PackageViewModel pViewModel)
        {
            try
            {
                Set_Date_Session(pViewModel.packagedaytriff);

                _pRepo.Update_GitDayTitles(pViewModel.packagedaytriff);

                pViewModel.FriendlyMessage.Add(MessageStore.Get("SUPPLIERHOTELTARIFF15"));

            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("SupplierHotel Controller- UpdateSupplierHotelDays" + ex.ToString());
            }

            return Json(pViewModel);
        }



     

        [AuthorizeUser(RoleModule.PackageItienaryBased, Function.Edit)]
        public JsonResult UpdatePackage(PackageViewModel pViewModel)
        {
            try
            {
                Set_Date_Session(pViewModel.Package);

                _pRepo.UpdatePackage(pViewModel.Package);

                pViewModel.FriendlyMessage.Add(MessageStore.Get("PKG02"));
            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - UpdatePackage  " + ex.Message);
            }

            return Json(pViewModel);

        }

        [AuthorizeUser(RoleModule.PackageItienaryBased, Function.Edit)]
        public JsonResult UpdatePackageOtherDetails(PackageViewModel pViewModel)
        {
            try
            {
                Set_Date_Session(pViewModel.Package);

                _pRepo.UpdatePackageOtherDetails(pViewModel.Package);

                pViewModel.FriendlyMessage.Add(MessageStore.Get("PKGO02"));
            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - UpdatepackageOtherDetails  " + ex.Message);
            }

            return Json(pViewModel);

        }

        [AuthorizeUser(RoleModule.PackageItienaryBased, Function.View)]
        public JsonResult GetPackage(PackageViewModel pViewModel)
        {

            PaginationInfo pager = new PaginationInfo();

            pager = pViewModel.Pager;

            PaginationViewModel pgViewModel = new PaginationViewModel();

            try
            {
                pgViewModel.dt = _pRepo.GetPackage(pViewModel.Package.PackageName, pViewModel.Package.PackageCategoryId, ref pager);

                pgViewModel.Pager = pager;

            }

            catch (Exception ex)
            {
                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - GetPackage" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pgViewModel), JsonRequestBehavior.AllowGet);

        }

        public JsonResult DeleteDayItem(PackageViewModel pViewModel)
        {


            try
            {

                _pRepo.DeleteDayItem(pViewModel.packageDayItems.PackageItemDayID);

                Logger.Debug("package Controller Delete");

            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("SupplierHotel Controller- DeleteDayItem" + ex.ToString());
            }

            return Json(pViewModel);

        }

        [AuthorizeUser(RoleModule.PackageItienaryBased, Function.View)]
        public ActionResult GetPackageById(PackageViewModel pViewModel)
        {
            try
            {
                pViewModel.Package = _pRepo.GetPackageById(pViewModel.PackageFilter.PackageId);
               // pViewModel.DayItemTriff = _pRepo.Get_SupplierHotelTariffDays(pViewModel.PackageFilter.PackageId);

            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - GetVendorById" + ex.ToString());
            }

            TempData["pViewModel"] = pViewModel;

            return Index(pViewModel);
        }

        #endregion

        #region Package Date
        //Package Date

        [AuthorizeUser(RoleModule.PackageItienaryBased, Function.Create)]
        public JsonResult InsertPackageDate(PackageViewModel pViewModel)
        {

            try
            {
                Set_Date_Session(pViewModel.PackageDate);

                pViewModel.PackageDate.PackageDateId = _pRepo.InsertPackageDate(pViewModel.PackageDate);

                pViewModel.FriendlyMessage.Add(MessageStore.Get("PKGD01"));

            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - InsertPackageDate " + ex.Message);
            }

            return Json(pViewModel);
        }

        [AuthorizeUser(RoleModule.PackageItienaryBased, Function.View)]
        public JsonResult GetPackageDate(PackageViewModel pViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = pViewModel.Pager;

            PaginationViewModel pgViewModel = new PaginationViewModel();

            try
            {
                pgViewModel.dt = _pRepo.GetPackageDate(pViewModel.PackageDate.PackageId, ref pager);

                pgViewModel.Pager = pager;

            }

            catch (Exception ex)
            {
                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - GetPackageDate" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pgViewModel), JsonRequestBehavior.AllowGet);

        }

        [AuthorizeUser(RoleModule.PackageItienaryBased, Function.View)]
        public JsonResult GetPackageDateById(PackageViewModel pViewModel)
        {

            try
            {
                pViewModel.PackageDate = _pRepo.GetPackageDateById(pViewModel.PackageDate.PackageDateId);
            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - GetPackageDateById" + ex.ToString());
            }

            TempData["pViewModel"] = pViewModel;

            return Json(pViewModel, JsonRequestBehavior.AllowGet);
        }

        [AuthorizeUser(RoleModule.PackageItienaryBased, Function.Edit)]
        public JsonResult UpdatePackageDate(PackageViewModel pViewModel)
        {
            try
            {
                Set_Date_Session(pViewModel.PackageDate);

                _pRepo.UpdatePackageDate(pViewModel.PackageDate);

                pViewModel.FriendlyMessage.Add(MessageStore.Get("PKGD02"));
            }
            catch (Exception ex)
            {

                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - UpdatePackageDate  " + ex.Message);
            }

            return Json((pViewModel));

        }

        [AuthorizeUser(RoleModule.PackageItienaryBased, Function.View)]
        public JsonResult DeletePackageDate(PackageViewModel pViewModel)
        {
            try
            {
                _pRepo.DeletePackageDate(pViewModel.PackageDate.PackageDateId, pViewModel.PackageDate.PackageId);

                pViewModel.FriendlyMessage.Add(MessageStore.Get("PKGD04"));
            }
            catch (Exception ex)
            {

                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - DeletePackageDate" + ex.ToString());
            }

            return Json(pViewModel, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Package Itinerary
        //Package Itinerary 

        [AuthorizeUser(RoleModule.PackageItienaryBased, Function.Create)]
        public JsonResult InsertPackageItinerary(PackageViewModel pViewModel)
        {

            try
            {
                Set_Date_Session(pViewModel.PackageItinerary);

                pViewModel.PackageItinerary.PackageItineraryId = _pRepo.InsertPackageItinerary(pViewModel.PackageItinerary);

                pViewModel.FriendlyMessage.Add(MessageStore.Get("PKGI01"));

            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - Insert " + ex.Message);
            }

            return Json(pViewModel);
        }

        [AuthorizeUser(RoleModule.PackageItienaryBased, Function.View)]
        public JsonResult GetPackageItinerary(PackageViewModel pViewModel) 
        {
            PaginationInfo pager = new PaginationInfo();

            pager = pViewModel.Pager;

            PaginationViewModel pgViewModel = new PaginationViewModel();

            try
            {
                pgViewModel.dt = _pRepo.GetPackageItinerary(pViewModel.PackageItinerary.PackageId, ref pager);

                pgViewModel.Pager = pager;

            }

            catch (Exception ex)
            {
                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - GetPackageItinerary" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pgViewModel), JsonRequestBehavior.AllowGet);

        }

        [AuthorizeUser(RoleModule.PackageItienaryBased, Function.View)]
        public JsonResult GetPackageItineraryById(PackageViewModel pViewModel)
        {

            try
            {
                pViewModel.PackageItinerary = _pRepo.GetPackageItineraryById(pViewModel.PackageItinerary.PackageItineraryId);
            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - GetPackageItineraryById" + ex.ToString());
            }

            TempData["pViewModel"] = pViewModel;

            return Json(pViewModel, JsonRequestBehavior.AllowGet);
        }

        [AuthorizeUser(RoleModule.PackageItienaryBased, Function.Edit)]
        public JsonResult UpdatePackageItinerary(PackageViewModel pViewModel)
        {
            try
            {
                Set_Date_Session(pViewModel.PackageItinerary);

                _pRepo.UpdatePackageItinerary(pViewModel.PackageItinerary);

                pViewModel.FriendlyMessage.Add(MessageStore.Get("PKGI02"));
            }
            catch (Exception ex)
            {

                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - UpdatePackageItinerary  " + ex.Message);
            }

            return Json((pViewModel));

        }

        [AuthorizeUser(RoleModule.PackageItienaryBased, Function.View)]
        public JsonResult DeletePackageItinerary(PackageViewModel pViewModel)
        {
            try
            {
                _pRepo.DeletePackageItinerary(pViewModel.PackageItinerary.PackageItineraryId, pViewModel.PackageItinerary.PackageId);

                pViewModel.FriendlyMessage.Add(MessageStore.Get("PKGI04"));
            }
            catch (Exception ex)
            {

                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - DeletePackageItinerary" + ex.ToString());
            }

            return Json(pViewModel, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Package Itinerary Hotels

        public PartialViewResult PackageItineraryHotel(PackageViewModel pViewModel)
        { 
            return PartialView("_PackageItineraryHotel", pViewModel);
        }

       // [AuthorizeUser(RoleModule.PackageItienaryHotelBased, Function.Create)]
        public JsonResult InsertPackageItineraryHotel(PackageViewModel pViewModel)
        {

            try
            {
                Set_Date_Session(pViewModel.PackageItinerary.PackageItineraryHotel);

                pViewModel.PackageItinerary.PackageItineraryHotel.PackageItineraryHotelId = _pRepo.InsertPackageItineraryHotel(pViewModel.PackageItinerary.PackageItineraryHotel);

                pViewModel.FriendlyMessage.Add(MessageStore.Get("PKGH01"));

            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - Insert " + ex.Message);
            }

            return Json(pViewModel);
        }

        //[AuthorizeUser(RoleModule.PackageItienaryHotelBased, Function.Edit)]
        public JsonResult UpdatePackageItineraryHotel(PackageViewModel pViewModel)
        {
            try
            {
                Set_Date_Session(pViewModel.PackageItinerary.PackageItineraryHotel);

                _pRepo.UpdatePackageItineraryHotel(pViewModel.PackageItinerary.PackageItineraryHotel);

                pViewModel.FriendlyMessage.Add(MessageStore.Get("PKGH02"));
            }
            catch (Exception ex)
            {

                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - UpdatePackageItineraryHotel  " + ex.Message);
            }

            return Json((pViewModel));

        }

        //[AuthorizeUser(RoleModule.PackageItienaryHotelBased, Function.View)]
        public JsonResult GetPackageItineraryHotelById(PackageViewModel pViewModel)
        {

            try
            {
                pViewModel.PackageItinerary.PackageItineraryHotel = _pRepo.GetPackageItineraryHotelById(pViewModel.PackageItinerary.PackageItineraryHotel.PackageItineraryHotelId);
            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - GetPackageItineraryHotelById" + ex.ToString());
            }

            TempData["pViewModel"] = pViewModel;

            return Json(pViewModel, JsonRequestBehavior.AllowGet);
        }

        //[AuthorizeUser(RoleModule.PackageItienaryHotelBased, Function.View)]
        public JsonResult GetPackageItineraryHotels(PackageViewModel pViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = pViewModel.Pager;

            PaginationViewModel pgViewModel = new PaginationViewModel();

            try
            {
                pgViewModel.dt = _pRepo.GetPackageItineraryHotels(pViewModel.PackageItinerary.PackageItineraryId, ref pager);

                pgViewModel.Pager = pager;

            }

            catch (Exception ex)
            {
                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - GetPackageItineraryHotels" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pgViewModel), JsonRequestBehavior.AllowGet); 
        }

       // [AuthorizeUser(RoleModule.PackageItienaryHotelBased, Function.View)]
        public JsonResult DeletePackageItineraryHotel(PackageViewModel pViewModel)
        {
            try
            {
                _pRepo.DeletePackageItineraryHotel(pViewModel.PackageItinerary.PackageItineraryHotel.PackageItineraryHotelId, pViewModel.PackageItinerary.PackageItineraryId);

                pViewModel.FriendlyMessage.Add(MessageStore.Get("PKGH03"));
            }
            catch (Exception ex)
            {

                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - DeletePackageItineraryHotel" + ex.ToString());
            }

            return Json(pViewModel, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Package Itinerary Flights

        public PartialViewResult PackageItineraryFlight(PackageViewModel pViewModel)
        {
            return PartialView("_PackageItineraryFlight", pViewModel);
        }

        //[AuthorizeUser(RoleModule.PackageItienaryFlightBased, Function.Create)]
        public JsonResult InsertPackageItineraryFlight(PackageViewModel pViewModel)
        {

            try
            {
                Set_Date_Session(pViewModel.PackageItinerary.PackageItineraryFlight);

                pViewModel.PackageItinerary.PackageItineraryFlight.PackageItineraryFlightId = _pRepo.InsertPackageItineraryFlight(pViewModel.PackageItinerary.PackageItineraryFlight);

                pViewModel.FriendlyMessage.Add(MessageStore.Get("PKGF01"));

            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - Insert " + ex.Message);
            }

            return Json(pViewModel);
        }

        //[AuthorizeUser(RoleModule.PackageItienaryFlightBased, Function.Edit)]
        public JsonResult UpdatePackageItineraryFlight(PackageViewModel pViewModel)
        {
            try
            {
                Set_Date_Session(pViewModel.PackageItinerary.PackageItineraryFlight);

                _pRepo.UpdatePackageItineraryFlight(pViewModel.PackageItinerary.PackageItineraryFlight);

                pViewModel.FriendlyMessage.Add(MessageStore.Get("PKGF02"));
            }
            catch (Exception ex)
            {

                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - UpdatePackageItineraryFlight  " + ex.Message);
            }

            return Json((pViewModel));

        }

        //[AuthorizeUser(RoleModule.PackageItienaryFlightBased, Function.View)]
        public JsonResult GetPackageItineraryFlightById(PackageViewModel pViewModel)
        {

            try
            {
                pViewModel.PackageItinerary.PackageItineraryFlight = _pRepo.GetPackageItineraryFlightById(pViewModel.PackageItinerary.PackageItineraryFlight.PackageItineraryFlightId);
            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - GetPackageItineraryFlightById" + ex.ToString());
            }

            TempData["pViewModel"] = pViewModel;

            return Json(pViewModel, JsonRequestBehavior.AllowGet);
        }

        //[AuthorizeUser(RoleModule.PackageItienaryFlightBased, Function.View)]
        public JsonResult GetPackageItineraryFlights(PackageViewModel pViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = pViewModel.Pager;

            PaginationViewModel pgViewModel = new PaginationViewModel();

            try
            {
                pgViewModel.dt = _pRepo.GetPackageItineraryFlights(pViewModel.PackageItinerary.PackageItineraryId, ref pager);

                pgViewModel.Pager = pager;

            }

            catch (Exception ex)
            {
                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - GetPackageItineraryFlights" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pgViewModel), JsonRequestBehavior.AllowGet);
        }

        //[AuthorizeUser(RoleModule.PackageItienaryFlightBased, Function.View)]
        public JsonResult DeletePackageItineraryFlight(PackageViewModel pViewModel)
        {
            try
            {
                _pRepo.DeletePackageItineraryFlight(pViewModel.PackageItinerary.PackageItineraryFlight.PackageItineraryFlightId, pViewModel.PackageItinerary.PackageItineraryId);

                pViewModel.FriendlyMessage.Add(MessageStore.Get("PKGF03"));
            }
            catch (Exception ex)
            {

                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - DeletePackageItineraryFlight" + ex.ToString());
            }

            return Json(pViewModel, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Package Itinerary Trains

        public PartialViewResult PackageItineraryTrain(PackageViewModel pViewModel)
        {
            return PartialView("_PackageItineraryTrain", pViewModel);
        }

        //[AuthorizeUser(RoleModule.PackageItienaryTrainBased, Function.Create)]
        public JsonResult InsertPackageItineraryTrain(PackageViewModel pViewModel)
        {

            try
            {
                Set_Date_Session(pViewModel.PackageItinerary.PackageItineraryTrain);

                pViewModel.PackageItinerary.PackageItineraryTrain.PackageItineraryTrainId = _pRepo.InsertPackageItineraryTrain(pViewModel.PackageItinerary.PackageItineraryTrain);

                pViewModel.FriendlyMessage.Add(MessageStore.Get("PKGT01"));

            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - Insert " + ex.Message);
            }

            return Json(pViewModel);
        }

        //[AuthorizeUser(RoleModule.PackageItienaryTrainBased, Function.Edit)]
        public JsonResult UpdatePackageItineraryTrain(PackageViewModel pViewModel)
        {
            try
            {
                Set_Date_Session(pViewModel.PackageItinerary.PackageItineraryTrain);

                _pRepo.UpdatePackageItineraryTrain(pViewModel.PackageItinerary.PackageItineraryTrain);

                pViewModel.FriendlyMessage.Add(MessageStore.Get("PKGT02"));
            }
            catch (Exception ex)
            {

                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - UpdatePackageItineraryTrain  " + ex.Message);
            }

            return Json((pViewModel));

        }

        //[AuthorizeUser(RoleModule.PackageItienaryTrainBased, Function.View)]
        public JsonResult GetPackageItineraryTrainById(PackageViewModel pViewModel)
        {

            try
            {
                pViewModel.PackageItinerary.PackageItineraryTrain = _pRepo.GetPackageItineraryTrainById(pViewModel.PackageItinerary.PackageItineraryTrain.PackageItineraryTrainId);
            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - GetPackageItineraryTrainById" + ex.ToString());
            }

            TempData["pViewModel"] = pViewModel;

            return Json(pViewModel, JsonRequestBehavior.AllowGet);
        }

        //[AuthorizeUser(RoleModule.PackageItienaryTrainBased, Function.View)]
        public JsonResult GetPackageItineraryTrains(PackageViewModel pViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = pViewModel.Pager;

            PaginationViewModel pgViewModel = new PaginationViewModel();

            try
            {
                pgViewModel.dt = _pRepo.GetPackageItineraryTrains(pViewModel.PackageItinerary.PackageItineraryId, ref pager);

                pgViewModel.Pager = pager;

            }

            catch (Exception ex)
            {
                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - GetPackageItineraryTrains" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pgViewModel), JsonRequestBehavior.AllowGet);
        }

        //[AuthorizeUser(RoleModule.PackageItienaryTrainBased, Function.View)]
        public JsonResult DeletePackageItineraryTrain(PackageViewModel pViewModel)
        {
            try
            {
                _pRepo.DeletePackageItineraryTrain(pViewModel.PackageItinerary.PackageItineraryTrain.PackageItineraryTrainId, pViewModel.PackageItinerary.PackageItineraryId);

                pViewModel.FriendlyMessage.Add(MessageStore.Get("PKGT03"));
            }
            catch (Exception ex)
            {

                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - DeletePackageItineraryTrain" + ex.ToString());
            }

            return Json(pViewModel, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Package Itinerary Bus

        public PartialViewResult PackageItineraryBus(PackageViewModel pViewModel)
        {
            return PartialView("_PackageItineraryBus", pViewModel);
        }

        //[AuthorizeUser(RoleModule.PackageItienaryBusBased, Function.Create)]
        public JsonResult InsertPackageItineraryBus(PackageViewModel pViewModel)
        {

            try
            {
                Set_Date_Session(pViewModel.PackageItinerary.PackageItineraryBus);

                pViewModel.PackageItinerary.PackageItineraryBus.PackageItineraryBusId = _pRepo.InsertPackageItineraryBus(pViewModel.PackageItinerary.PackageItineraryBus);

                pViewModel.FriendlyMessage.Add(MessageStore.Get("PKGB01"));

            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - Insert " + ex.Message);
            }

            return Json(pViewModel);
        }

        //[AuthorizeUser(RoleModule.PackageItienaryBusBased, Function.Edit)]
        public JsonResult UpdatePackageItineraryBus(PackageViewModel pViewModel)
        {
            try
            {
                Set_Date_Session(pViewModel.PackageItinerary.PackageItineraryBus);

                _pRepo.UpdatePackageItineraryBus(pViewModel.PackageItinerary.PackageItineraryBus);

                pViewModel.FriendlyMessage.Add(MessageStore.Get("PKGB02"));
            }
            catch (Exception ex)
            {

                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - UpdatePackageItineraryBus  " + ex.Message);
            }

            return Json((pViewModel));

        }

        //[AuthorizeUser(RoleModule.PackageItienaryBusBased, Function.View)]
        public JsonResult GetPackageItineraryBusById(PackageViewModel pViewModel)
        {

            try
            {
                pViewModel.PackageItinerary.PackageItineraryBus = _pRepo.GetPackageItineraryBusById(pViewModel.PackageItinerary.PackageItineraryBus.PackageItineraryBusId);
            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - GetPackageItineraryBusById" + ex.ToString());
            }

            TempData["pViewModel"] = pViewModel;

            return Json(pViewModel, JsonRequestBehavior.AllowGet);
        }

        //[AuthorizeUser(RoleModule.PackageItienaryBusBased, Function.View)]
        public JsonResult GetPackageItineraryBuss(PackageViewModel pViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = pViewModel.Pager;

            PaginationViewModel pgViewModel = new PaginationViewModel();

            try
            {
                pgViewModel.dt = _pRepo.GetPackageItineraryBuss(pViewModel.PackageItinerary.PackageItineraryId, ref pager);

                pgViewModel.Pager = pager;

            }

            catch (Exception ex)
            {
                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - GetPackageItineraryBuss" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pgViewModel), JsonRequestBehavior.AllowGet);
        }

        //[AuthorizeUser(RoleModule.PackageItienaryBusBased, Function.View)]
        public JsonResult DeletePackageItineraryBus(PackageViewModel pViewModel)
        {
            try
            {
                _pRepo.DeletePackageItineraryBus(pViewModel.PackageItinerary.PackageItineraryBus.PackageItineraryBusId, pViewModel.PackageItinerary.PackageItineraryId);

                pViewModel.FriendlyMessage.Add(MessageStore.Get("PKGB03"));
            }
            catch (Exception ex)
            {

                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - DeletePackageItineraryBus" + ex.ToString());
            }

            return Json(pViewModel, JsonRequestBehavior.AllowGet);
        }

        #endregion
        
        #region Package Itinerary Vehicle

        public PartialViewResult PackageItineraryVehicle(PackageViewModel pViewModel)
        {
            return PartialView("_PackageItineraryVehicle", pViewModel);
        }

        //[AuthorizeUser(RoleModule.PackageItienaryVehicleBased, Function.Create)]
        public JsonResult InsertPackageItineraryVehicle(PackageViewModel pViewModel)
        {

            try
            {
                Set_Date_Session(pViewModel.PackageItinerary.PackageItineraryVehicle);

                pViewModel.PackageItinerary.PackageItineraryVehicle.PackageItineraryVehicleId = _pRepo.InsertPackageItineraryVehicle(pViewModel.PackageItinerary.PackageItineraryVehicle);

                pViewModel.FriendlyMessage.Add(MessageStore.Get("PKGV01"));

            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - Insert " + ex.Message);
            }

            return Json(pViewModel);
        }

        //[AuthorizeUser(RoleModule.PackageItienaryVehicleBased, Function.Edit)]
        public JsonResult UpdatePackageItineraryVehicle(PackageViewModel pViewModel)
        {
            try
            {
                Set_Date_Session(pViewModel.PackageItinerary.PackageItineraryVehicle);

                _pRepo.UpdatePackageItineraryVehicle(pViewModel.PackageItinerary.PackageItineraryVehicle);

                pViewModel.FriendlyMessage.Add(MessageStore.Get("PKGV02"));
            }
            catch (Exception ex)
            {

                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - UpdatePackageItineraryVehicle  " + ex.Message);
            }

            return Json((pViewModel));

        }

        //[AuthorizeUser(RoleModule.PackageItienaryVehicleBased, Function.View)]
        public JsonResult GetPackageItineraryVehicleById(PackageViewModel pViewModel)
        {

            try
            {
                pViewModel.PackageItinerary.PackageItineraryVehicle = _pRepo.GetPackageItineraryVehicleById(pViewModel.PackageItinerary.PackageItineraryVehicle.PackageItineraryVehicleId);
            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - GetPackageItineraryVehicleById" + ex.ToString());
            }

            TempData["pViewModel"] = pViewModel;

            return Json(pViewModel, JsonRequestBehavior.AllowGet);
        }

        //[AuthorizeUser(RoleModule.PackageItienaryVehicleBased, Function.View)]
        public JsonResult GetPackageItineraryVehicles(PackageViewModel pViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = pViewModel.Pager;

            PaginationViewModel pgViewModel = new PaginationViewModel();

            try
            {
                pgViewModel.dt = _pRepo.GetPackageItineraryVehicles(pViewModel.PackageItinerary.PackageItineraryId, ref pager);

                pgViewModel.Pager = pager;

            }

            catch (Exception ex)
            {
                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - GetPackageItineraryVehicles" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pgViewModel), JsonRequestBehavior.AllowGet);
        }

        //[AuthorizeUser(RoleModule.PackageItienaryVehicleBased, Function.View)]
        public JsonResult DeletePackageItineraryVehicle(PackageViewModel pViewModel)
        {
            try
            {
                _pRepo.DeletePackageItineraryVehicle(pViewModel.PackageItinerary.PackageItineraryVehicle.PackageItineraryVehicleId, pViewModel.PackageItinerary.PackageItineraryId);

                pViewModel.FriendlyMessage.Add(MessageStore.Get("PKGV03"));
            }
            catch (Exception ex)
            {

                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - DeletePackageItineraryVehicle" + ex.ToString());
            }

            return Json(pViewModel, JsonRequestBehavior.AllowGet);
        }

        #endregion

        [AuthorizeUser(RoleModule.PackageItienaryBased, Function.View)]
        public JsonResult CheckPackageCodeExist(string PackageCode)
        {
            bool check = false;

            PackageViewModel pViewModel = new PackageViewModel();

            try
            {
                check = _pRepo.CheckPackageCodeExist(PackageCode);
            }
            catch (Exception ex)
            {
                Logger.Error("Package Controller - CheckPackageCodeExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);
        }

        [AuthorizeUser(RoleModule.PackageItienaryBased, Function.View)]
        public JsonResult CheckPackageNameExist(string PackageName)
        {
            bool check = false;

            PackageViewModel pViewModel = new PackageViewModel();

            try
            {
                check = _pRepo.CheckPackageNameExist(PackageName);
            }
            catch (Exception ex)
            {
                Logger.Error("Package Controller - CheckPackageNameExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);

        }


        #region Package View
        public ActionResult PackageView(PackageViewModel pViewModel)
        {
            AccessoriesRepo _aRepo = new AccessoriesRepo();

            int PackageId = pViewModel.PackageFilter.PackageId;

         //   pViewModel.Packages = _pRepo.GetPackagesById(PackageId);

            pViewModel.Package = _pRepo.GetPackagesInfoById(PackageId);

            pViewModel.PackageItineraries = _pRepo.GetPackageItineraryDtailsById(PackageId);

            pViewModel.PackageDates = _pRepo.GetPackagedatesById(PackageId);

            pViewModel.Images = _aRepo.GetImagesByRefType(PackageId, (int)Attachment.Package);

            pViewModel.Package.PackageItinerarys = pViewModel.PackageItineraries;
            pViewModel .Package.PackageDates= pViewModel.PackageDates;
            pViewModel.Package.Images = pViewModel.Images;
          //  GeneratePackage_PDF(pViewModel.Package, "d" );

            return View("PackageView", pViewModel);
        }

       #endregion

        #region Search Packages

        public ActionResult SearchPackage(PackageViewModel pViewModel)
        {
            return View("SearchPackage", pViewModel);
        }

        public PartialViewResult GetSearchPackageDetails(PackageViewModel pViewModel)
        {
            AccessoriesRepo _aRepo = new AccessoriesRepo();
            try
            {
                pViewModel.AddtoCart = true;
                pViewModel.PackageSearchList = _pRepo.GetSearchPackageDetails(pViewModel.Package);            
            
            }

            catch (Exception ex)
            {
                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - GetPackage" + ex.ToString());
            }

            TempData["pViewModel"] = pViewModel;

            return PartialView("_SearchPackageDetails", pViewModel);
        }


        public JsonResult GITAddToCart(QuotationViewModel qViewModel)
        {
            QuotationViewModel qsViewModel = new QuotationViewModel();

            #region--comment--
            //HttpCookie cookieObj = new HttpCookie("Bookings");
            //HttpCookie cookieObj = Request.Cookies["Bookings"];
            //string data = Server.HtmlEncode(cookieObj.Value);

            //if (cookieObj != null)
            //{  
            //    JavaScriptSerializer json_serializer = new JavaScriptSerializer(); 

            //    string jsonData = json_serializer.Serialize(qViewModel.Quotation.QuatationItem);

            //    cookieObj.Value = jsonData;

            //    //HttpContext.Response.SetCookie(cookieObj);

            //    qsViewModel.Quotation.QuatationItem = json_serializer.Deserialize<List<BookingCartDetailsInfo>>(cookieObj.Value);

            //    Response.Cookies.Add(new HttpCookie("Bookings", jsonData));

            //}
            //else
            //{
            //HttpCookie cookieNewObj = new HttpCookie("Bookings");
            #endregion

            JavaScriptSerializer json_serializer = new JavaScriptSerializer();

            try
            {
                if (Request.Cookies["Bookings"].Value != null)
                {
                    if (Request.Cookies["Bookings"].Value != "")
                    {
                        qsViewModel.Quotation.QuatationItem = json_serializer.Deserialize<List<BookingCartDetailsInfo>>(Request.Cookies["Bookings"].Value);

                        string PackageName = qViewModel.Quotation.QuatationItem.Select(x => x.PackageName).FirstOrDefault();

                        if (!qsViewModel.Quotation.QuatationItem.Where(x => x.PackageName == PackageName).Any())
                        {
                            qsViewModel.Quotation.QuatationItem.AddRange(qViewModel.Quotation.QuatationItem);

                            string jsonData = json_serializer.Serialize(qsViewModel.Quotation.QuatationItem);

                            Response.Cookies["Bookings"].Value = jsonData;

                            HttpContext.Response.SetCookie(Response.Cookies["Bookings"]);
                        }
                    }
                    else
                    {
                        string jsonData = json_serializer.Serialize(qViewModel.Quotation.QuatationItem);

                        Response.Cookies["Bookings"].Value = jsonData;

                        HttpContext.Response.SetCookie(Response.Cookies["Bookings"]);
                    }
                }
            }
            catch (Exception ex)
            {
                qsViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - GITAddToCart" + ex.ToString());

                Request.Cookies["Bookings"].Value = null;
            }

            return Json(qsViewModel, JsonRequestBehavior.AllowGet);
        }


        #endregion

        #region Git 

        public PartialViewResult GetEnquiryGitDetailsById(  PackageViewModel pViewmodel)
        {

            QuotationViewModel qViewModel = new QuotationViewModel();

            try
            {
                pViewmodel.Flags = true;
                pViewmodel.PackageSearchList = _pRepo.GetSearchgitDetails(pViewmodel.Package);
            }
            catch (Exception ex)
            {
                pViewmodel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - GetFitDetailsById  " + ex.Message);
            }

            TempData["qViewModel"] = pViewmodel;

            return PartialView("_SearchPackageDetails", pViewmodel);

        }

        public PartialViewResult GetPackageGitTariffDays(int PackageId)
        {
            PackageViewModel pViewModel = new PackageViewModel();

            try
            {

                pViewModel.DayItemTriff = _pRepo.Get_PackageGitTariffDays(PackageId);

            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("package Controller- GetSupplierHotelTariffDays" + ex.ToString());
            }

            //return Json(sViewModel);
            return PartialView("_package_triff_Day", pViewModel);
        }


        #endregion
               
        public void GeneratePackage_PDF(PackageInfo packageInfo, string FolderName)
        {
            string Path = (ConfigurationManager.AppSettings["CustomerFileUpload"].ToString()) + FolderName;

            bool directoryExists = System.IO.Directory.Exists(Path);

            if (!directoryExists)
            {
                System.IO.Directory.CreateDirectory(Path);
            }           

            StringBuilder body = new StringBuilder();

            body.Append("<html><body>");
            body.Append("<ul style='background-color:yellow; font-size:xx-large'>");
            body.Append("<li><a><h5><span style='vertical-align: middle;' class='s-icon'></span>&nbsp; Package Details:</h5></a></li>");
            body.Append("</ul>");

            body.Append("<table>");
            body.Append("<tr><th align='left'>Package Name</th><td>:</td><td>"+packageInfo.PackageName+"</td></tr>");
            body.Append("<tr><th align='left'>Package Type</th><td>:</td><td>"+packageInfo.PackageType+"</td></tr>");
            body.Append("<tr><th align='left'>Package Category</th><td>:</td><td>"+packageInfo.PackageCategoryName+"</td></tr>");
            body.Append("<tr><th align='left'>Package Duration</th><td>:</td><td>"+packageInfo.PackageDuration+"</td></tr>");
            body.Append("<tr><th align='left'>Package Cost</th><td>:</td><td>"+packageInfo.PackageCost+"/-</td></tr>");
            body.Append("</table>");
  

            body.Append("<ul style='background-color:yellow; font-size:xx-large'>");
            body.Append("<li><a><h5><span style='vertical-align: middle;' class='s-icon'></span>&nbsp; Itinerary Details:</h5></a></li>");
            body.Append("</ul>");
           
            body.Append("<table><tbody>");
            foreach (var item in packageInfo.PackageItinerarys)
            {
               // body.Append("<tr><td style='color:red;font-size:large'>Day-" + item.Day + "</td><td> : </td> <td style='background-color:pink'>" + item.DayTitle + "</td></tr>");
                body.Append("<tr><td style='color:red;font-size:large'>Day-" + item.Day + "  : " + item.DayTitle + " </td></tr>");
                body.Append("<tr><td>&nbsp;&nbsp;&nbsp;&nbsp;</td></tr>");
                body.Append("<tr><td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + item.SightSeeing + "</td></tr>");
                body.Append("<tr><td>&nbsp;&nbsp;&nbsp;&nbsp;</td></tr>");
                body.Append("<tr><td><i style='color:darkcyan'></i>Meal: " + item.MealName + "</td></tr>");

                foreach (var itemhotel in item.PackageItineraryHotels)
                {
                    body.Append("<tr>");
                    if (itemhotel.HotelName != null)
                    {
                        body.Append("<td><i style='color:darkcyan'></i><img src='C:/Users/abacus/Pictures/Saved Pictures/hotel.png' style='width:20px;height:20px'/><b style='color:pink'> >> </b>" + itemhotel.HotelName + "<b style='color:pink'> >> </b>Location: " + itemhotel.Location + "</td>");
                    }
                    body.Append("</tr>");
                }

                if (item.PackageItineraryFlights.Count() != 0 || item.PackageItineraryTrains.Count() != 0 || item.PackageItineraryBuses.Count() != 0 || item.PackageItineraryVehicles.Count() != 0)
                {

                    body.Append("<tr><td><table border='1' cellpadding='5' style='border-color:black; width:110%; border-collapse: collapse'>");
                    body.Append("<tr><th style='background-color:black;color:white;text-align:center'>Types</th><th style='background-color:black;color:white;text-align:center'>Name</th><th style='background-color:black;color:white;text-align:center'>From</th><th style='background-color:black;color:white;text-align:center'>To</th><th style='background-color:black;color:white;text-align:center'>Time</th><th style='background-color:black;color:white;text-align:center'>Pick up</th><th style='background-color:black;color:white;text-align:center'>Drop off</th></tr>");

                    foreach (var itemflight in item.PackageItineraryFlights)
                    {
                        body.Append("<tr>");
                        if (itemflight.FlightName != null)
                        {
                            body.Append("<td style='text-align:center'><i style='color:darkcyan'></i><img src='C:/Users/abacus/Pictures/Saved Pictures/flight.png' style='width:20px;height:20px'/></td>");
                            body.Append("<td style='text-align:center'>" + itemflight.FlightName + "</td>");
                            body.Append("<td style='text-align:center'>" + itemflight.FlightFromName + "</td>");
                            body.Append("<td style='text-align:center'>" + itemflight.FlightToName + "</td>");
                            body.Append("<td style='text-align:center'>" + itemflight.FlightTime.ToShortTimeString() + "</td>");
                            body.Append("<td style='text-align:center'>-</td><td style='text-align:center'>-</td>");
                        }
                        body.Append("</tr>");
                    }

                    foreach (var itemtrain in item.PackageItineraryTrains)
                    {
                        body.Append("<tr>");
                        if (itemtrain.TrainName != null)
                        {
                            body.Append("<td style='text-align:center'><i style='color:darkcyan'></i><img src='C:/Users/abacus/Pictures/Saved Pictures/train.png' style='width:20px;height:20px'/></td>");
                            body.Append("<td style='text-align:center'>" + itemtrain.TrainName + "</td>");
                            body.Append("<td style='text-align:center'>" + itemtrain.TrainFromName + "</td>");
                            body.Append("<td style='text-align:center'>" + itemtrain.TrainToName + "</td>");
                            body.Append("<td style='text-align:center'>" + itemtrain.TrainTime.ToShortTimeString() + "</td>");
                            body.Append("<td style='text-align:center'>-</td><td style='text-align:center'>-</td>");
                        }
                        body.Append("</tr>");
                    }

                    foreach (var itembus in item.PackageItineraryBuses)
                    {
                        body.Append("<tr>");
                        if (itembus.BusName != null)
                        {
                            body.Append("<td style='text-align:center'><i style='color:darkcyan'></i><img src='C:/Users/abacus/Pictures/Saved Pictures/bus.png' style='width:20px;height:20px'/></td>");
                            body.Append("<td style='text-align:center'>" + itembus.BusName + "</td>");
                            body.Append("<td style='text-align:center'>" + itembus.BusFromName + "</td>");
                            body.Append("<td style='text-align:center'>" + itembus.BusToName + "</td>");
                            body.Append("<td style='text-align:center'>" + itembus.BusTime.ToShortTimeString() + "</td>");
                            body.Append("<td style='text-align:center'>-</td><td style='text-align:center'>-</td>");
                        }
                        body.Append("</tr>");
                    }

                    foreach (var itemvehicle in item.PackageItineraryVehicles)
                    {
                        body.Append("<tr>");
                        if (itemvehicle.VehicleName != null)
                        {
                            body.Append("<td style='text-align:center'><i style='color:darkcyan'></i><img src='C:/Users/abacus/Pictures/Saved Pictures/vehicle.png' style='width:20px;height:20px'/></td>");
                            body.Append("<td style='text-align:center'>" + itemvehicle.VehicleName + "</td>");
                            body.Append("<td style='text-align:center'>" + itemvehicle.VehicleFromName + "</td>");
                            body.Append("<td style='text-align:center'>" + itemvehicle.VehicleToName + "</td>");
                            body.Append("<td style='text-align:center'>" + itemvehicle.VehicleTime.ToShortTimeString() + "</td>");
                            body.Append("<td style='text-align:center'>" + itemvehicle.PickUp + "</td>");
                            body.Append("<td style='text-align:center'>" + itemvehicle.DropOff + "</td>");
                        }
                        body.Append("</tr><br/>");
                    }
                    body.Append("</table><br/><br/></td></tr>");
                }
            }
            body.Append("</tbody></table>");


            body.Append("<ul style='background-color:yellow; font-size:xx-large'>");
            body.Append("<li><a><h5><span style='vertical-align: middle;' class='s-icon'></span>&nbsp; Package Dates:</h5></a></li>");
            body.Append("</ul>");
            body.Append("<table border='1' cellpadding='10' cellspacing='10' style='border-color:black; width:70%'>");
            body.Append("<tr>");
            body.Append("<th style='background-color:black;color:white;text-align:center'>Start Date</th><th style='background-color:black;color:white; text-align:center'>End Date</th>");
            body.Append("</tr>");
            foreach (var item in packageInfo.PackageDates)
            {
              body.Append("<tr>");
              body.Append("<td style='color:black; text-align:center'>" + item.PackageStartDate + "</td>");
              body.Append("<td style='color:black; text-align:center'>" + item.PackageEndDate + "</td>");
              body.Append("</tr>");
            }
           body.Append("</table>");


            body.Append("<ul style='background-color:yellow; font-size:xx-large'>");
            body.Append("<li><a><h5><span style='vertical-align: middle;' class='s-icon'></span>&nbsp;  Exclusion/Inclusion:</h5></a></li>");
            body.Append("</ul>");
            body.Append("<h4><span style='color:black'>Exclusion:</span></h4>" + packageInfo.Exclusions + "");
            body.Append("<h4><span style='color:black'>Inclusion:</span></h4>" + packageInfo.Inclusions + "");


            body.Append("<ul style='background-color:yellow; font-size:xx-large'>");
            body.Append("<li><a><h5><span style='vertical-align: middle;' class='s-icon'></span>&nbsp;  Package Images:</h5></a></li>");
            body.Append("</ul>");
            body.Append("<table><tbody>");
            if (packageInfo.Images.Count > 0)
            {
                int i = 0;
                for (int j = i; j < packageInfo.Images.Count; j++)
                {
                    if ((j + 3) % 3 == 0)
                    {
                        body.Append("<tr>");
                    }
                    body.Append("<td>");
                    body.Append("<img src='" + Server.MapPath("~/Upload/" + packageInfo.Images[j].UniqueAttachmentId) + "' style='width:250px;height:200px' alt='" + packageInfo.Images[j].AttachmentName + "' />");
                    body.Append("</td>");
                    if (j != 0)
                    {
                        if ((j + 1) % 3 == 0)
                        {
                            body.Append("</tr>");
                        }
                    }
                    i = j;
                }
                if ((i - 2) % 3 != 0)
                {
                    body.Append("</tr>");
                }
            }
            body.Append("</tbody></table>");  
            body.Append("</body></html>");  


            CommonMethods.GeneratePDF(packageInfo.PackageId, Server.MapPath(@"/Upload"), body.ToString(), "Package");
        }

        //public ActionResult Demo(PackageViewModel pViewModel)
        //{
        //    return View("Demo", pViewModel);
        //}


        //public JsonResult GetGitpackageList(PackageViewModel pViewModel)
        //{
        //    System.Data.DataSet ds = new System.Data.DataSet();
        //    try
        //    {
        //        ds = _pRepo.GetLohanaPackageTariffRootList(pViewModel.LohanaPackageTariff.LohanaPackageTariffId);
        //        Logger.Debug("package Controller GetGitpackageList");
        //    }
        //    catch (Exception ex)
        //    {
        //        pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
        //        Logger.Error("Package Controller - GetGitpackageList" + ex.ToString());
        //    }
        //    return Json(JsonConvert.SerializeObject(ds), JsonRequestBehavior.AllowGet);
        //}



        #region package Itinarary

        public PartialViewResult GetDayPackageTitle(PackageViewModel pViewModel, int PackageDayId, int PackageId)
        {
            pViewModel.packagedaytriff.PackageDayId = PackageDayId;
            pViewModel.packagedaytriff.PackageId = PackageId;
            return PartialView("_package-Day-title", pViewModel);
        }


        public PartialViewResult GetPackageAddHotel(PackageViewModel pViewModel)
        {
           // sViewModel.SupplierHotelTariffDayInfo.SupplierHotelDayId = SupplierHotelDayId;

            return PartialView("_Package-Hotel-room", pViewModel);
        }

        public PartialViewResult GetPackageAddSightseeing(PackageViewModel pViewModel)
        {
           // sViewModel.SupplierHotelTariffDayInfo.SupplierHotelDayId = SupplierHotelDayId;

            return PartialView("_Package-SightSeeing", pViewModel);
        }

        public PartialViewResult GetpackageAddVehicle(PackageViewModel pViewModel)
        {
           // sViewModel.SupplierHotelTariffDayInfo.SupplierHotelDayId = SupplierHotelDayId;

            return PartialView("_Package-Vehicals", pViewModel);
        }

        public PartialViewResult GetpackageAddMeal(PackageViewModel pViewModel)
        {
           // sViewModel.SupplierHotelTariffDayInfo.SupplierHotelDayId = SupplierHotelDayId;


            return PartialView("_Package-Meal", pViewModel);
        }
        #endregion



        #region PackageCategory

        public JsonResult SavePackageNetRateAndCustomerCategories(PackageViewModel pViewModel)
        {
            List<DateTime> filterDates = new List<DateTime>();

            try
            {
                foreach (var item in pViewModel.PackageCustomerCategory)
                {
                    Set_Date_Session(item);
                }

                

                filterDates = _pRepo.GetFilteredDateForDuration(pViewModel.Packageduration);

                _pRepo.SavePackageDurationWithCustomerCategories(filterDates,pViewModel.Packageduration,pViewModel.PackageCustomerCategory);

                pViewModel.FriendlyMessage.Add(MessageStore.Get("SUPPLIERHOTELTARIFF14"));
            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("package Tariff Controller - GetHotelTariffDuration  " + ex.Message);
            }

            return Json(pViewModel);
        }




        public JsonResult IsOverrideDate(PackageViewModel pViewModel)
        {
            List<DateTime> filterDates = new List<DateTime>();

            bool isOverride = false;

            try
            {
                filterDates = _pRepo.GetFilteredDateForDuration(pViewModel.Packageduration);

               
                foreach (var item in filterDates)
                {
                    if (pViewModel.PackageDurationNetrate.Where(a => a.TariffDate == item).Count() > 0)
                    {
                        isOverride = true;

                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Hotel Tariff Controller - IsOverrideDate  " + ex.Message);
            }

            return Json(isOverride);
        }


        public JsonResult GetPackageDurationPrice(int PackageId)
        {
            PackageViewModel pViewModel = new PackageViewModel();

            try
            {
                pViewModel.PriceList = _pRepo.GetpackagePrice(PackageId);
                
            }
            catch (Exception ex)
            {
                pViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("package Tariff Controller - GetHotelTariffDuration  " + ex.Message);
            }

            return Json(pViewModel.PriceList, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
