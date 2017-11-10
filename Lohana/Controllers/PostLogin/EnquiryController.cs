using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LohanaBusinessEntities;
using LohanaBusinessEntities.Common;
using Lohana.Models.Enquiry;
using LohanaRepo.Master;
using LohanaRepo.Enquiry;
using Lohana.Common;
using LohanaHelper.Logging;
using Lohana.Models;
using Newtonsoft.Json;


namespace Lohana.Controllers.PostLogin
{
    public class EnquiryController : BaseController
    {

        public PackageRepo _pRepo;

        public HotelRepo _hRepo;

        public EnquiryRepo _enqRepo;

        public CityRepo _cRepo;

        public EnquiryController()
        {
            _pRepo = new PackageRepo();

            _hRepo = new HotelRepo();

            _enqRepo = new EnquiryRepo();

            _cRepo = new CityRepo();
        }

        public ActionResult Index(EnquiryViewModel enqViewModel)
        {
            if (TempData["enqViewModel"] != null)
            {
                enqViewModel = (EnquiryViewModel)TempData["enqViewModel"];
            }

            enqViewModel.Specialization = _enqRepo.GetSpecialization();

            enqViewModel.Users = _enqRepo.drpGetUsers();

            return View("Index", enqViewModel);
        }

        public ActionResult Search(EnquiryViewModel enqViewModel)
        {
            if (TempData["enqViewModel"] != null)
            {
                enqViewModel = (EnquiryViewModel)TempData["enqViewModel"];
            }

            return View("Search", enqViewModel);
        }

        #region View EnquiryItem

        public PartialViewResult GetGitDetails(EnquiryViewModel enqViewModel)
        {
            enqViewModel.Countries = _cRepo.drpGetCountries();

            enqViewModel.States = _cRepo.drpGetstates();

            enqViewModel.cityes = _enqRepo.drpGetcity();

            TempData["enqViewModel"] = enqViewModel;

           
            //enqViewModel.PackageTypes = _pRepo.drpGetPackageTypes();

            return PartialView("_GitDetails", enqViewModel);
        }

        public PartialViewResult GetFitDetails(EnquiryViewModel enqViewModel)
        {
            enqViewModel.PackageTypes = _pRepo.drpGetPackageTypes();

            enqViewModel.HotelTypes = _hRepo.drpGetHotelTypes();

            enqViewModel.RoomTypes = _hRepo.drpGetRoomTypes();

            return PartialView("_FitDetails", enqViewModel);
        }

        public PartialViewResult GetHotelDetails(EnquiryViewModel enqViewModel)
        {
            enqViewModel.HotelTypes = _hRepo.drpGetHotelTypes();

            enqViewModel.RoomTypes = _hRepo.drpGetRoomTypes();

            return PartialView("_HotelDetails", enqViewModel);
        }

        public PartialViewResult GetAirplaneDetails(EnquiryViewModel enqViewModel)
        {
            enqViewModel.Cities = _pRepo.drpGetCountryStateCity();
            return PartialView("_AirPlaneDetails", enqViewModel);
        }

        public PartialViewResult GetBusDetails(EnquiryViewModel enqViewModel)
        {
            return PartialView("_TransferDetails", enqViewModel);
        }

        public PartialViewResult GetCarDetails(EnquiryViewModel enqViewModel)
        {
            return PartialView("_SightseeingDetails", enqViewModel);
        }

        public PartialViewResult GetTrainDetails(EnquiryViewModel enqViewModel)
        {
            enqViewModel.Cities = _pRepo.drpGetCountryStateCity();
            return PartialView("_TrainDetails", enqViewModel);
        }

        public PartialViewResult GetSightSeeingDetails(EnquiryViewModel enqViewModel)
        {
            enqViewModel.Countries = _cRepo.drpGetCountries();

            enqViewModel.States = _cRepo.drpGetstates();

            enqViewModel.cityes = _enqRepo.drpGetcity();

            TempData["enqViewModel"] = enqViewModel;


            //enqViewModel.PackageTypes = _pRepo.drpGetPackageTypes();

            return PartialView("_SightseeingDetails", enqViewModel);
        }

        #endregion

        #region Insert Enquiry

        public JsonResult Insert(EnquiryViewModel enqViewModel)
        {
            try
            {
                Set_Date_Session(enqViewModel.Enquiry);

                enqViewModel.Enquiry.EnquiryId = _enqRepo.InsertEnquiryBasic(enqViewModel.Enquiry);

                enqViewModel.FriendlyMessage.Add(MessageStore.Get("Enq01"));

                Logger.Debug("Enquiry Controller Insert");

            }
            catch (Exception ex)
            {
                enqViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - Insert " + ex.Message);
            }

            return Json(enqViewModel);
        }

        public JsonResult Update(EnquiryViewModel enqViewModel)
        {
            try
            {
                Set_Date_Session(enqViewModel.Enquiry);

                _enqRepo.UpdateEnquiryBasic(enqViewModel.Enquiry);

                enqViewModel.FriendlyMessage.Add(MessageStore.Get("Enq02"));

                Logger.Debug("Enquiry Controller UpdateEnquiry");
            }
            catch (Exception ex)
            {

                enqViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - UpdateEnquiry  " + ex.Message);
            }

            return Json(enqViewModel);

        }

        public JsonResult GetEnquiry(EnquiryViewModel enqViewModel)
        {

            PaginationInfo pager = new PaginationInfo();

            pager = enqViewModel.Pager;

            PaginationViewModel pgViewModel = new PaginationViewModel();

            try
            {

                if (Session["SessionInfo"] != null)
                {
                    enqViewModel.Enquiry.UserID= (((SessionInfo)HttpContext.Session["SessionInfo"]).UserId);

                    pgViewModel.dt = _enqRepo.GetEnquiry(enqViewModel.Enquiry.CustomerType, enqViewModel.Enquiry.EnquiryStatus, enqViewModel.Enquiry.EnquirySource, enqViewModel.Enquiry.UserID, ref pager);
                   
                }

                

                pgViewModel.Pager = pager;

            }

            catch (Exception ex)
            {
                enqViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - GetEnquiry" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pgViewModel), JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetEnquiryById(EnquiryViewModel enqViewModel)
        {
            try
            {
                enqViewModel.Enquiry = _enqRepo.GetEnquiryById(enqViewModel.EnquiryFilter.EnquiryId);

            }
            catch (Exception ex)
            {
                enqViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - GetEnquiryById" + ex.ToString());
            }

            TempData["enqViewModel"] = enqViewModel;

            return Index(enqViewModel);
        }


        #endregion

        #region Common EnquiryItem

        public JsonResult InsertEnquiryItem(EnquiryViewModel enqViewModel)
        {
            try
            {
                Set_Date_Session(enqViewModel.Enquiry);



                enqViewModel.Enquiry.EnquiryItemId = _enqRepo.InsertEnquiryItem(enqViewModel.Enquiry);

                enqViewModel.FriendlyMessage.Add(MessageStore.Get("Enq04"));

                Logger.Debug("Enquiry Controller InsertEnquiryItem");

            }
            catch (Exception ex)
            {
                enqViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - InsertEnquiryItem " + ex.Message);
            }

            return Json(enqViewModel);
        }

        public PartialViewResult GetEnquiryItemDetailsView(int enquiryId)
        {
            EnquiryViewModel enqViewModel = new EnquiryViewModel();

            try
            {
                enqViewModel.Enquiries = _enqRepo.GetEnquiryItemDetails(enquiryId);

            }
            catch (Exception ex)
            {
                enqViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - GetEnquiryItemDetailsView  " + ex.Message);
            }

            TempData["enqViewModel"] = enqViewModel;

            return PartialView("_EnquiryItem", enqViewModel);

        }

        public PartialViewResult DeleteEnquiryItemById(int enquiryItemId)
        {
            EnquiryViewModel enqViewModel = new EnquiryViewModel();

            try
            {
                _enqRepo.DeleteEnquiryItemById(enquiryItemId);

                _enqRepo.DeleteEnquiryItemTypeById(enquiryItemId);

                _enqRepo.DeleteEnquiryItemPassById(enquiryItemId);

                _enqRepo.DeleteEnquiryItemTransferById(enquiryItemId);
            }
            catch (Exception ex)
            {
                enqViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - DeleteEnquiryItemById  " + ex.Message);
            }

            TempData["enqViewModel"] = enqViewModel;

            // enqViewModel.PackageTypes = _pRepo.drpGetPackageTypes();

            return PartialView("_EnquiryItem", enqViewModel);

        }

        #endregion

        #region Git Enquiry Item

        public PartialViewResult GetGitDetailsById(int enquiryItemId)
        {
            EnquiryViewModel enqViewModel = new EnquiryViewModel();

            try
            {
                enqViewModel.Enquiry = _enqRepo.GetGitDetailsById(enquiryItemId);
            }
            catch (Exception ex)
            {
                enqViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - GetGitDetails  " + ex.Message);
            }

            TempData["enqViewModel"] = enqViewModel;

            enqViewModel.PackageTypes = _pRepo.drpGetPackageTypes();

            enqViewModel.Users = _enqRepo.drpGetUsers();

            enqViewModel.Cities = _pRepo.drpGetCountryStateCity();

            enqViewModel.Countries = _cRepo.drpGetCountries();

            enqViewModel.States = _cRepo.drpGetstates();

            enqViewModel.cityes = _enqRepo.drpGetcity();

            return PartialView("_GitDetails", enqViewModel);

        }

        public JsonResult UpdateEnquiryGitDetails(EnquiryViewModel enqViewModel)
        {
            try
            {
                Set_Date_Session(enqViewModel.Enquiry);

                _enqRepo.UpdateEnquiryGitDetails(enqViewModel.Enquiry);

                enqViewModel.FriendlyMessage.Add(MessageStore.Get("Enq05"));

                Logger.Debug("Enquiry Controller UpdateEnquiry");
            }
            catch (Exception ex)
            {

                enqViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - UpdateGitDetails  " + ex.Message);
            }

            return Json(enqViewModel);

        }

        #endregion

        #region Fit Enquiry Item

        public PartialViewResult GetFitDetailsById(int enquiryItemId)
        {
            EnquiryViewModel enqViewModel = new EnquiryViewModel();

            try
            {
                enqViewModel.Enquiry = _enqRepo.GetFitDetailsById(enquiryItemId);

                
            }
            catch (Exception ex)
            {
                enqViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - GetFitDetailsById  " + ex.Message);
            }

            TempData["enqViewModel"] = enqViewModel;

            enqViewModel.PackageTypes = _pRepo.drpGetPackageTypes();

            enqViewModel.HotelTypes = _hRepo.drpGetHotelTypes();

            enqViewModel.RoomTypes = _hRepo.drpGetRoomTypes();

            enqViewModel.Users = _enqRepo.drpGetUsers();

            enqViewModel.Cities = _pRepo.drpGetCountryStateCity();

            enqViewModel.Countries = _cRepo.drpGetCountries();

            enqViewModel.States = _cRepo.drpGetstates();

            enqViewModel.cityes = _enqRepo.drpGetcity();

            return PartialView("_FitDetails", enqViewModel);

        }

        public JsonResult UpdateEnquiryFitDetails(EnquiryViewModel enqViewModel)
        {
            try
            {
                Set_Date_Session(enqViewModel.Enquiry);

                _enqRepo.UpdateEnquiryFitDetails(enqViewModel.Enquiry);

                enqViewModel.FriendlyMessage.Add(MessageStore.Get("Enq05"));

                Logger.Debug("Enquiry Controller UpdateEnquiryFitDetails");
            }
            catch (Exception ex)
            {

                enqViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - UpdateEnquiryFitDetails  " + ex.Message);
            }

            return Json(enqViewModel);

        }

        #endregion

        #region Hotel Enquiry Item

        public PartialViewResult GetHotelDetailsById(int enquiryItemId)
        {
            EnquiryViewModel enqViewModel = new EnquiryViewModel();

            try
            {
                enqViewModel.Enquiry = _enqRepo.GetHotelDetailsById(enquiryItemId);
            }
            catch (Exception ex)
            {
                enqViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - GetHotelDetailsById  " + ex.Message);
            }

            TempData["enqViewModel"] = enqViewModel;

            enqViewModel.HotelTypes = _hRepo.drpGetHotelTypes();

            enqViewModel.RoomTypes = _hRepo.drpGetRoomTypes();

            enqViewModel.Cities = _pRepo.drpGetCountryStateCity();

            enqViewModel.Users = _enqRepo.drpGetUsers();

            enqViewModel.Countries = _cRepo.drpGetCountries();

            enqViewModel.States = _cRepo.drpGetstates();

            enqViewModel.cityes = _enqRepo.drpGetcity();

            return PartialView("_HotelDetails", enqViewModel);

        }

        public JsonResult UpdateEnquiryHotelDetails(EnquiryViewModel enqViewModel)
        {
            try
            {
                Set_Date_Session(enqViewModel.Enquiry);

                _enqRepo.UpdateEnquiryHotelDetails(enqViewModel.Enquiry);

                enqViewModel.FriendlyMessage.Add(MessageStore.Get("Enq05"));

                Logger.Debug("Enquiry Controller UpdateEnquiryHotelDetails");
            }
            catch (Exception ex)
            {

                enqViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - UpdateEnquiryHotelDetails  " + ex.Message);
            }

            return Json(enqViewModel);

        }

        #endregion

        #region Sightseeing Enquiry Item

        public PartialViewResult GetSightseeingDetailsById(int enquiryItemId)
        {
            EnquiryViewModel enqViewModel = new EnquiryViewModel();

            try
            {
                enqViewModel.Enquiry = _enqRepo.GetSightseeingDetailsById(enquiryItemId);
            }
            catch (Exception ex)
            {
                enqViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - GetSightseeingDetailsById  " + ex.Message);
            }

            TempData["enqViewModel"] = enqViewModel;

            enqViewModel.Cities = _pRepo.drpGetCountryStateCity();

            enqViewModel.Users = _enqRepo.drpGetUsers();

            return PartialView("_SightseeingDetails", enqViewModel);

        }

        public JsonResult UpdateEnquirySightseeingDetails(EnquiryViewModel enqViewModel)
        {
            try
            {
                Set_Date_Session(enqViewModel.Enquiry);

                _enqRepo.UpdateEnquirySightseeingDetails(enqViewModel.Enquiry);

                enqViewModel.FriendlyMessage.Add(MessageStore.Get("Enq05"));

                Logger.Debug("Enquiry Controller UpdateEnquirySightseeingDetails");
            }
            catch (Exception ex)
            {

                enqViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - UpdateEnquirySightseeingDetails  " + ex.Message);
            }

            return Json(enqViewModel);

        }

        #endregion

        #region Flight Enquiry Item

        public JsonResult InsertFlightEnquiryItem(EnquiryViewModel enqViewModel)
        {
            try
            {
                Set_Date_Session(enqViewModel.Enquiry);

                enqViewModel.Enquiry.EnquiryItemId = _enqRepo.InsertFlightEnquiryItem(enqViewModel.Enquiry);

                enqViewModel.FriendlyMessage.Add(MessageStore.Get("Enq04"));

                Logger.Debug("Enquiry Controller InsertFlightEnquiryItem");

            }
            catch (Exception ex)
            {
                enqViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - InsertFlightEnquiryItem " + ex.Message);
            }

            return Json(enqViewModel);
        }

        public PartialViewResult GetFlightDetailsById(int enquiryItemId)
        {
            EnquiryViewModel enqViewModel = new EnquiryViewModel();

            try
            {
                enqViewModel.Enquiry = _enqRepo.GetFlightDetailsById(enquiryItemId);

                enqViewModel.Enquiry.EnquiryItemTypeDetails = _enqRepo.GetFlightTypeDetailsById(enquiryItemId);
            }
            catch (Exception ex)
            {
                enqViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - GetFlightDetailsById  " + ex.Message);
            }

            TempData["enqViewModel"] = enqViewModel;

            enqViewModel.Cities = _pRepo.drpGetCountryStateCity();

            enqViewModel.Users = _enqRepo.drpGetUsers();

            return PartialView("_AirPlaneDetails", enqViewModel);

        }

        public JsonResult UpdateEnquiryFlightDetails(EnquiryViewModel enqViewModel)
        {
            try
            {
                Set_Date_Session(enqViewModel.Enquiry);

                _enqRepo.UpdateEnquiryFlightDetails(enqViewModel.Enquiry);

                enqViewModel.FriendlyMessage.Add(MessageStore.Get("Enq05"));

                Logger.Debug("Enquiry Controller UpdateEnquiryFlightDetails");
            }
            catch (Exception ex)
            {

                enqViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - UpdateEnquiryFlightDetails  " + ex.Message);
            }

            return Json(enqViewModel);

        }

        #endregion

        #region Transfer Enquiry Item

        public JsonResult InsertTransferEnquiryItem(EnquiryViewModel enqViewModel)
        {
            try
            {
                Set_Date_Session(enqViewModel.Enquiry);

                enqViewModel.Enquiry.EnquiryItemId = _enqRepo.InsertTransferEnquiryItem(enqViewModel.Enquiry);

                enqViewModel.FriendlyMessage.Add(MessageStore.Get("Enq04"));

                Logger.Debug("Enquiry Controller InsertTransferEnquiryItem");

            }
            catch (Exception ex)
            {
                enqViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - InsertTransferEnquiryItem " + ex.Message);
            }

            return Json(enqViewModel);
        }

        public PartialViewResult GetTransferDetailsById(int enquiryItemId)
        {
            EnquiryViewModel enqViewModel = new EnquiryViewModel();

            try
            {
                enqViewModel.Enquiry = _enqRepo.GetTransferDetailsById(enquiryItemId);

                enqViewModel.Enquiry.EnquiryItemTransferDetails = _enqRepo.GetTransferTypeDetailsById(enquiryItemId);
            }
            catch (Exception ex)
            {
                enqViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - GetTransferDetailsById  " + ex.Message);
            }

            TempData["enqViewModel"] = enqViewModel;

            enqViewModel.Users = _enqRepo.drpGetUsers();

            return PartialView("_TransferDetails", enqViewModel);

        }

        public JsonResult UpdateEnquiryTransferDetails(EnquiryViewModel enqViewModel)
        {
            try
            {
                Set_Date_Session(enqViewModel.Enquiry);

                _enqRepo.UpdateEnquiryTransferDetails(enqViewModel.Enquiry);

                enqViewModel.FriendlyMessage.Add(MessageStore.Get("Enq05"));

                Logger.Debug("Enquiry Controller UpdateEnquiryTransferDetails");
            }
            catch (Exception ex)
            {

                enqViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - UpdateEnquiryTransferDetails  " + ex.Message);
            }

            return Json(enqViewModel);

        }

        #endregion

        #region Train Enquiry Item

        public JsonResult InsertTrainEnquiryItem(EnquiryViewModel enqViewModel)
        {
            try
            {
                Set_Date_Session(enqViewModel.Enquiry);

                enqViewModel.Enquiry.EnquiryItemId = _enqRepo.InsertTrainEnquiryItem(enqViewModel.Enquiry);

                enqViewModel.FriendlyMessage.Add(MessageStore.Get("Enq04"));

                Logger.Debug("Enquiry Controller InsertTrainEnquiryItem");

            }
            catch (Exception ex)
            {
                enqViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - InsertTrainEnquiryItem " + ex.Message);
            }

            return Json(enqViewModel);
        }

        public PartialViewResult GetTrainDetailsById(int enquiryItemId)
        {
            EnquiryViewModel enqViewModel = new EnquiryViewModel();

            try
            {
                enqViewModel.Enquiry = _enqRepo.GetTrainDetailsById(enquiryItemId);

                enqViewModel.Enquiry.EnquiryItemTypeDetails = _enqRepo.GetTrainTypeDetailsById(enquiryItemId);

                enqViewModel.Enquiry.EnquiryItemPassDetails = _enqRepo.GetTrainPassDetailsById(enquiryItemId);

            }
            catch (Exception ex)
            {
                enqViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - GetTrainDetailsById  " + ex.Message);
            }

            TempData["enqViewModel"] = enqViewModel;

            enqViewModel.Cities = _pRepo.drpGetCountryStateCity();

            enqViewModel.Users = _enqRepo.drpGetUsers();

            return PartialView("_TrainDetails", enqViewModel);

        }

        public JsonResult UpdateEnquiryTrainDetails(EnquiryViewModel enqViewModel)
        {
            try
            {
                Set_Date_Session(enqViewModel.Enquiry);

                _enqRepo.UpdateEnquiryTrainDetails(enqViewModel.Enquiry);

                enqViewModel.FriendlyMessage.Add(MessageStore.Get("Enq05"));

                Logger.Debug("Enquiry Controller UpdateEnquiryTrainDetails");
            }
            catch (Exception ex)
            {

                enqViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - UpdateEnquiryTrainDetails  " + ex.Message);
            }

            return Json(enqViewModel);

        }

        #endregion

        public ActionResult SaveTask(int EnquiryId)
        {
            EnquiryViewModel enqViewModel = new EnquiryViewModel();
            try
            {
                enqViewModel.Enquiry.EnquiryId = EnquiryId;

                Set_Date_Session(enqViewModel.Enquiry);

                 _enqRepo.InsertTask(enqViewModel.Enquiry);

                 enqViewModel.FriendlyMessage.Add(MessageStore.Get("EnqTask01"));

                Logger.Debug("Enquiry Controller InsertTask");

            }
            catch (Exception ex)
            {
                enqViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - InsertTask " + ex.Message);
            }

            TempData["enqViewModel"] = enqViewModel;

            return RedirectToAction("Search");
        }

    }
}











































