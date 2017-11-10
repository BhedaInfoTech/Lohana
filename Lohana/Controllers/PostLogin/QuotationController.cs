using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LohanaBusinessEntities;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Quotation;
using Lohana.Models.Quotation;
using Lohana.Models.Master;

using LohanaRepo.Master;
using LohanaRepo.Enquiry;
using LohanaRepo.Quotation;
using Lohana.Common;
using LohanaHelper.Logging;
using Lohana.Models;
using Newtonsoft.Json;
using System.Text;
using LohanaHelper.Utilities;
using System.Net.Mail;

namespace Lohana.Controllers.PostLogin
{
    public class QuotationController : BaseController
    {
        //
        // GET: /Quotation/

        public EnquiryRepo _enqRepo;

        public PackageRepo _pRepo;

        public QuotationRepo _qRepo;

        public QuotationController()
        {
            _enqRepo = new EnquiryRepo();

            _pRepo = new PackageRepo();

            _qRepo = new QuotationRepo();
        }

        public ActionResult Index(QuotationViewModel qViewModel)
        {
            qViewModel.Enquiries = _enqRepo.GetEnquiryItemDetails(qViewModel.Enquiry.EnquiryId);
            _qRepo.GetQuotationTaskInfo(qViewModel.Quotation);
            qViewModel.Users = _enqRepo.drpGetUsers();
            return View("Index", qViewModel);
        }

        public ActionResult Search(QuotationViewModel qViewModel)
        {
            return View("Search", qViewModel);
        }

        public ActionResult GetEnquiryById(QuotationViewModel qViewModel)
        {
            try
            {
                qViewModel.Enquiry = _enqRepo.GetEnquiryById(qViewModel.Quotation.EnquiryId);

            }
            catch (Exception ex)
            {
                qViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Quotation Controller - GetEnquiryById" + ex.ToString());
            }

            TempData["qViewModel"] = qViewModel;

            return Index(qViewModel);
        }

        public PartialViewResult GetEnquiryItemDetailsView(int enquiryId, int quotationId, bool isapproval)
        {
            QuotationViewModel qViewModel = new QuotationViewModel();

            try
            {
                qViewModel.IsApproval = isapproval; 

                qViewModel.Enquiries = _enqRepo.GetEnquiryItemDetails(enquiryId);

                qViewModel.GitQuotation = _qRepo.GetQuotationItemGitDetails(quotationId);

                qViewModel.SightSeeingQuatation = _qRepo.GetQuotationItemSightSeeingDetails(quotationId);

                qViewModel.QuotaionItems = _qRepo.GetQuotationItemDetails(quotationId);

                //qViewModel.QuotaionItems = _qRepo.GetQuotationItemDetails(quotationId);

                qViewModel.FlightQuotations = _qRepo.GetQuotationFlightDetailsByQuotationId(quotationId);

                qViewModel.TrainQuotations = _qRepo.GetQuotationTrainDetailsByQuotationId(quotationId);

                qViewModel.FlightQuotationItemTypeDetails = _qRepo.GetQuotationFlightTypeDetails(quotationId);

                qViewModel.TrainQuotationItemTypeDetails = _qRepo.GetQuotationTrainTypeDetails(quotationId);

                qViewModel.TrainQuotationItemPassDetails = _qRepo.GetQuotationTrainPassDetails(quotationId);


            }
            catch (Exception ex)
            {
                qViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Quotation Controller - GetEnquiryItemDetails  " + ex.Message);
            }

            TempData["qViewModel"] = qViewModel;

            return PartialView("_QuotationEnquiryItem", qViewModel);

        }

        #region View EnquiryItem

        public PartialViewResult AddFlightCTS(QuotationViewModel qViewModel)
        {

            qViewModel.Cities = _pRepo.drpGetCountryStateCity();

            qViewModel.Users = _enqRepo.drpGetUsers();

            return PartialView("_AddFlightCTS", qViewModel);
        }

        #endregion

        #region Insert Quotation

        public JsonResult Insert(QuotationViewModel qViewModel)
        {
            try
            {
                //Set_Date_Session(qViewModel.Quotation);

                //qViewModel.Quotation.QuotationId = _qRepo.InsertQuotationBasic(qViewModel.Quotation);

               // _qRepo.InsertQuotationTask(qViewModel.Quotation);

                //qViewModel.FriendlyMessage.Add(MessageStore.Get("Q01"));

                //Logger.Debug("Quotation Controller Insert");
            }
            catch (Exception ex)
            {
                qViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Quotation Controller - Insert " + ex.Message);
            }

            return Json(qViewModel);
        }

        public JsonResult Update(QuotationViewModel qViewModel)
        {
            try
            {
                Set_Date_Session(qViewModel.Quotation);

                _qRepo.UpdateQuotationBasic(qViewModel.Quotation);
                if (qViewModel.IsApproval && qViewModel.QuotaionItems != null && qViewModel.QuotaionItems.Any())
                {
                    foreach (var item in qViewModel.QuotaionItems)
                    {
                        Set_Date_Session(item);
                        _qRepo.UpdateQuotationItemStatus(item);
                    }
                    SendApprovedQuotationEmail(qViewModel.Quotation.QuotationId);
                }

                qViewModel.FriendlyMessage.Add(MessageStore.Get("Q02"));

                Logger.Debug("Quotation Controller UpdateQuotation");
            }
            catch (Exception ex)
            {

                qViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Quotation Controller - UpdateQuotation  " + ex.Message);
            }

            return Json(qViewModel);
            //return RedirectToAction("Index");
        }

        public void SendApprovedQuotationEmail(int quotationId)
        {
            List<QuotationInfo> QuotationList = new List<QuotationInfo>();
            string bodyString = string.Empty;
            QuotationList = _qRepo.GetApprovedQuotationItem(quotationId);
            string CustomerEmail = QuotationList.Select(a => a.CustomerEmailId).FirstOrDefault().ToString();
            StringBuilder str = new StringBuilder();
            foreach (var enqTypeitem in QuotationList.Select(a => a.EnquiryType).Distinct())
            {
                str.Append(" Enquiry Type: " + (enqTypeitem != 0 ? Convert.ToString((EnquiryType)enqTypeitem) : ""));
                foreach (var item in QuotationList.Where(a => a.EnquiryType == enqTypeitem))
                {
                    str.Append(" \n Package: " + item.PackageName);
                    str.Append(", Package Duration: " + item.PackageDuration);
                    str.Append(", Cost: " + item.Cost);
                    str.Append(", From Date: " + item.FromDate.ToString("dd/MM/yyyy"));
                    str.Append("\n");
                }
            }
            bodyString = str.ToString();
            MailAddress to_EMail = new MailAddress(CustomerEmail);//new MailAddress("siddartha.mote@abacusinfosystem.com");
            Communication.SendEmail(to_EMail, " Demo Subject", bodyString, false, null);
        }

        #endregion

        #region Common EnquiryItem

        public JsonResult InsertQuotationItem(QuotationViewModel qViewModel)
        {
            try
            {
                Set_Date_Session(qViewModel.Quotation);

                if (qViewModel.Quotation.QuotationId == 0)
                {
                    qViewModel.Quotation.QuotationId = _qRepo.InsertQuotationBasic(qViewModel.Quotation);

                    _qRepo.InsertQuotationTask(qViewModel.Quotation);
                }

                qViewModel.Quotation.QuotationItemId = _qRepo.InsertQuotationItem(qViewModel.Quotation);

                qViewModel.FriendlyMessage.Add(MessageStore.Get("Q04"));

                Logger.Debug("Quotation Controller InsertQuotationItem");

            }
            catch (Exception ex)
            {
                qViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Quotation Controller - InsertQuotationItem " + ex.Message);
            }

            return Json(qViewModel);
        }

        #endregion

        #region Flight Enquiry Item

        public JsonResult InsertFlightQuotationItem(QuotationViewModel qViewModel)
        {
            try
            {
                Set_Date_Session(qViewModel.Quotation);

                qViewModel.Quotation.QuotationItemId = _qRepo.InsertFlightQuotationItem(qViewModel.Quotation);

                qViewModel.FriendlyMessage.Add(MessageStore.Get("Q04"));

                Logger.Debug("Quotation Controller InsertFlightEnquiryItem");

            }
            catch (Exception ex)
            {
                qViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Quotation Controller - InsertFlightQuotationItem " + ex.Message);
            }

            return Json(qViewModel);
        }

        public PartialViewResult GetQuotationFlightDetailsById(int quotationItemId)
        {
            QuotationViewModel qViewModel = new QuotationViewModel();

            try
            {
                qViewModel.Quotation = _qRepo.GetQuotationFlightDetailsById(quotationItemId);

                qViewModel.Quotation.QuotationItemTypeDetail = _qRepo.GetQuotationTrainTypeDetailsById(quotationItemId);

                qViewModel.Enquiry.EnquiryItemId = qViewModel.Quotation.EnquiryItemId;
            }
            catch (Exception ex)
            {
                qViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Quotation Controller - GetQuotationFlightDetailsById  " + ex.Message);
            }

            TempData["enqViewModel"] = qViewModel;

            qViewModel.Cities = _pRepo.drpGetCountryStateCity();

            qViewModel.Users = _enqRepo.drpGetUsers();

            return PartialView("_AddFlightCTS", qViewModel);

        }

        public JsonResult UpdateQuotationFlightDetails(QuotationViewModel qViewModel)
        {
            try
            {
                Set_Date_Session(qViewModel.Quotation);

                _qRepo.UpdateQuotationFlightDetails(qViewModel.Quotation);

                qViewModel.FriendlyMessage.Add(MessageStore.Get("Q05"));

                Logger.Debug("Quotation Controller UpdateQuotationFlightDetails");
            }
            catch (Exception ex)
            {

                qViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Quotation Controller - UpdateQuotationFlightDetails  " + ex.Message);
            }

            return Json(qViewModel);

        }

        public PartialViewResult GetEnquiryFlightDetailsById(int enquiryItemId)
        {
            QuotationViewModel qViewModel = new QuotationViewModel();

            try
            {
                qViewModel.Enquiry = _qRepo.GetFlightDetailsById(enquiryItemId);

                //qViewModel.Enquiry.EnquiryItemTypeDetails = _enqRepo.GetFlightTypeDetailsById(enquiryItemId);
            }
            catch (Exception ex)
            {
                qViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - GetFitDetailsById  " + ex.Message);
            }

            TempData["qViewModel"] = qViewModel;

            qViewModel.Cities = _pRepo.drpGetCountryStateCity();

            qViewModel.Users = _enqRepo.drpGetUsers();

            return PartialView("_AddFlightCTS", qViewModel);

        }

        public PartialViewResult CloneFlightDetails(int quotationItemId)
        {
            QuotationViewModel qViewModel = new QuotationViewModel();

            try
            {
                qViewModel.Quotation = _qRepo.GetQuotationFlightDetailsById(quotationItemId);

                qViewModel.Quotation.QuotationItemTypeDetail = _qRepo.GetQuotationTrainTypeDetailsById(quotationItemId);

                Set_Date_Session(qViewModel.Quotation);

                qViewModel.Quotation.QuotationItemId = 0;

                qViewModel.Quotation.QuotationItemId = _qRepo.InsertTrainQuotationItemType(qViewModel.Quotation);
            }
            catch (Exception ex)
            {
                qViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Quotation Controller - CloneFlightDetails  " + ex.Message);
            }

            TempData["enqViewModel"] = qViewModel;

            //return RedirectToAction("Index");

            return PartialView("_QuotationEnquiryItem", qViewModel);

        }

        #endregion

        #region Train Enquiry Item

        public JsonResult InsertTrainQuotationItem(QuotationViewModel qViewModel)
        {
            try
            {
                Set_Date_Session(qViewModel.Quotation);

                qViewModel.Quotation.QuotationItemId = _qRepo.InsertTrainQuotationItem(qViewModel.Quotation);

                qViewModel.FriendlyMessage.Add(MessageStore.Get("Q04"));

                Logger.Debug("Quotation Controller InsertTrainQuotationItem");

            }
            catch (Exception ex)
            {
                qViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Quotation Controller - InsertTrainQuotationItem " + ex.Message);
            }

            return Json(qViewModel);
        }

        public PartialViewResult GetQuotationTrainTypeDetailsById(int quotationItemId)
        {
            QuotationViewModel qViewModel = new QuotationViewModel();

            try
            {

                qViewModel.Quotation = _qRepo.GetQuotationTrainDetailsById(quotationItemId);

                qViewModel.Quotation.QuotationItemTypeDetail = _qRepo.GetQuotationTrainTypeDetailsById(quotationItemId);

                qViewModel.Quotation.QuotationItemPassDetail = _qRepo.GetQuotationTrainPassDetailsById(quotationItemId);

                qViewModel.Enquiry.EnquiryItemId = qViewModel.Quotation.EnquiryItemId;
            }
            catch (Exception ex)
            {
                qViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Quotation Controller - GetQuotationTrainDetailsById  " + ex.Message);
            }

            TempData["enqViewModel"] = qViewModel;

            qViewModel.Cities = _pRepo.drpGetCountryStateCity();

            qViewModel.Users = _enqRepo.drpGetUsers();

            return PartialView("_AddTrainCTS", qViewModel);

        }

        public PartialViewResult GetQuotationTrainPassDetailsById(int quotationItemId)
        {
            QuotationViewModel qViewModel = new QuotationViewModel();

            try
            {
                qViewModel.Quotation = _qRepo.GetQuotationTrainDetailsById(quotationItemId);

                qViewModel.Quotation.QuotationItemTypeDetail = _qRepo.GetQuotationTrainTypeDetailsById(quotationItemId);

                qViewModel.Quotation.QuotationItemPassDetail = _qRepo.GetQuotationTrainPassDetailsById(quotationItemId);
            }
            catch (Exception ex)
            {
                qViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Quotation Controller - GetQuotationTrainDetailsById  " + ex.Message);
            }

            TempData["enqViewModel"] = qViewModel;

            qViewModel.Cities = _pRepo.drpGetCountryStateCity();

            qViewModel.Users = _enqRepo.drpGetUsers();

            return PartialView("_AddTrainCTS", qViewModel);

        }

        public JsonResult UpdateQuotationTrainDetails(QuotationViewModel qViewModel)
        {
            try
            {
                Set_Date_Session(qViewModel.Quotation);

                _qRepo.UpdateQuotationTrainDetails(qViewModel.Quotation);

                qViewModel.FriendlyMessage.Add(MessageStore.Get("Q05"));

                Logger.Debug("Quotation Controller UpdateQuotationTrainDetails");
            }
            catch (Exception ex)
            {

                qViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Quotation Controller - UpdateQuotationTrainDetails  " + ex.Message);
            }

            return Json(qViewModel);

        }

        public PartialViewResult GetEnquiryTrainDetailsById(int enquiryItemId)
        {
            QuotationViewModel qViewModel = new QuotationViewModel();

            try
            {
                qViewModel.Enquiry = _qRepo.GetTrainDetailsById(enquiryItemId);
            }
            catch (Exception ex)
            {
                qViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Enquiry Controller - GetEnquiryTrainDetailsById  " + ex.Message);
            }

            TempData["qViewModel"] = qViewModel;

            qViewModel.Cities = _pRepo.drpGetCountryStateCity();

            qViewModel.Users = _enqRepo.drpGetUsers();

            return PartialView("_AddTrainCTS", qViewModel);

        }

        public PartialViewResult CloneTrainTypeDetails(int quotationItemId)
        {
            QuotationViewModel qViewModel = new QuotationViewModel();

            try
            {
                qViewModel.Quotation = _qRepo.GetQuotationTrainDetailsById(quotationItemId);

                qViewModel.Quotation.QuotationItemTypeDetail = _qRepo.GetQuotationTrainTypeDetailsById(quotationItemId);

                Set_Date_Session(qViewModel.Quotation);

                qViewModel.Quotation.QuotationItemId = 0;

                qViewModel.Quotation.QuotationItemId = _qRepo.InsertTrainQuotationItemType(qViewModel.Quotation);

            }
            catch (Exception ex)
            {
                qViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Quotation Controller - CloneTrainTypeDetails  " + ex.Message);
            }

            TempData["enqViewModel"] = qViewModel;

            return PartialView("_QuotationEnquiryItem", qViewModel);

        }

        public PartialViewResult CloneTrainPassDetails(int quotationItemId)
        {
            QuotationViewModel qViewModel = new QuotationViewModel();

            try
            {
                qViewModel.Quotation = _qRepo.GetQuotationTrainDetailsById(quotationItemId);

                qViewModel.Quotation.QuotationItemPassDetail = _qRepo.GetQuotationTrainPassDetailsById(quotationItemId);

                Set_Date_Session(qViewModel.Quotation);

                qViewModel.Quotation.QuotationItemId = 0;

                qViewModel.Quotation.QuotationItemId = _qRepo.InsertTrainQuotationItemPass(qViewModel.Quotation);
            }
            catch (Exception ex)
            {
                qViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Quotation Controller - CloneTrainTypeDetails  " + ex.Message);
            }

            TempData["enqViewModel"] = qViewModel;

            return PartialView("_QuotationEnquiryItem", qViewModel);

        }

        #endregion

        #region Git

        //public JsonResult InsertGitQuotationItem(QuotationViewModel qViewModel)
        //{

        //    try
        //    {
        //        Set_Date_Session(qViewModel.Quotation);


        //        //qViewModel.Enquiry = _pRepo.GetGitDetailsById(enquiryItemId);
        //        qViewModel.Quotation.QuotationItemId = _qRepo.InsertQuotationItem(qViewModel.Quotation);

        //        qViewModel.FriendlyMessage.Add(MessageStore.Get("Q04"));

        //        Logger.Debug("Quotation Controller InsertFlightEnquiryItem");

        //    }
        //    catch (Exception ex)
        //    {
        //        qViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

        //        Logger.Error("Quotation Controller - InsertFlightQuotationItem " + ex.Message);
        //    }

        //    return Json(qViewModel);
        //}

        public PartialViewResult DeleteGitItemById(int QuotationitemId)
        {
            QuotationViewModel qViewModel = new QuotationViewModel();

            try
            {
                _qRepo.DeleteGitItemById(QuotationitemId);


            }
            catch (Exception ex)
            {
                qViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Quotation Controller - DeleteGitItemById  " + ex.Message);
            }

            TempData["qViewModel"] = qViewModel;


            return PartialView("_QuotationEnquiryItem", qViewModel);

        }


        #endregion

        #region Fit

        //public JsonResult InsertFitQuotationItem(QuotationViewModel qViewModel)
        //{

        //    try
        //    {
        //        Set_Date_Session(qViewModel.Quotation);

        //        qViewModel.Quotation.QuotationItemId = _qRepo.InsertQuotationItem(qViewModel.Quotation);

        //        qViewModel.FriendlyMessage.Add(MessageStore.Get("Q04"));

        //        Logger.Debug("Quotation Controller InsertFlightEnquiryItem");

        //    }
        //    catch (Exception ex)
        //    {
        //        qViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

        //        Logger.Error("Quotation Controller - InsertFlightQuotationItem " + ex.Message);
        //    }

        //    return Json(qViewModel);
        //}

        #endregion

        #region SightSeeing

        //public JsonResult InsertSightSeeingQuotationItem(QuotationViewModel qViewModel)
        //{
        //    try
        //    {
        //        Set_Date_Session(qViewModel.Quotation);

        //        qViewModel.Quotation.QuotationItemId = _qRepo.InsertQuotationItem(qViewModel.Quotation);

        //        qViewModel.FriendlyMessage.Add(MessageStore.Get("Q04"));

        //        Logger.Debug("Quotation Controller InsertFlightEnquiryItem");

        //    }
        //    catch (Exception ex)
        //    {
        //        qViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

        //        Logger.Error("Quotation Controller - InsertSightSeeingQuotationItem " + ex.Message);
        //    }

        //    return Json(qViewModel);
        //}

        public PartialViewResult DeleteSightSeeingItemById(int QuotationitemId)
        {
            QuotationViewModel qViewModel = new QuotationViewModel();

            try
            {
                _qRepo.DeleteSightSeeingItemById(QuotationitemId);

            }
            catch (Exception ex)
            {
                qViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Quotation Controller - DeleteGitItemById  " + ex.Message);
            }

            TempData["qViewModel"] = qViewModel;

            return PartialView("_QuotationEnquiryItem", qViewModel);
        }
        #endregion

        #region Spt
        //public JsonResult InsertSptQuotationItem(QuotationViewModel qViewModel)
        //{

        //    try
        //    {
        //        Set_Date_Session(qViewModel.Quotation);

        //        qViewModel.Quotation.QuotationItemId = _qRepo.InsertQuotationItem(qViewModel.Quotation);

        //        qViewModel.FriendlyMessage.Add(MessageStore.Get("Q04"));

        //        Logger.Debug("Quotation Controller InsertSptEnquiryItem");

        //    }
        //    catch (Exception ex)
        //    {
        //        qViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

        //        Logger.Error("Quotation Controller - InsertSptQuotationItem " + ex.Message);
        //    }

        //    return Json(qViewModel);
        //}
        #endregion



        public ActionResult ApproveQuotation()
        {
            return View();
        }

        public PartialViewResult GetPackageDetails()
        {
            return PartialView("_PackageDetails");
        }

        public PartialViewResult GetAirplaneDetails()
        {
            return PartialView("_AirPlaneDetails");
        }

        public PartialViewResult GetBusDetails()
        {
            return PartialView("_BusDetails");
        }

        public PartialViewResult GetCarDetails()
        {
            return PartialView("_CarDetails");
        }

        public PartialViewResult GetTrainDetails()
        {
            return PartialView("_TrainDetails");
        }

        public PartialViewResult GetViewPackageDetails()
        {
            return PartialView("_ViewPackageDetails");
        }

        public PartialViewResult GetViewAirplaneDetails()
        {
            return PartialView("_ViewAirPlaneDetails");
        }

        public PartialViewResult GetViewBusDetails()
        {
            return PartialView("_ViewBusDetails");
        }

        public PartialViewResult GetViewCarDetails()
        {
            return PartialView("_ViewCarDetails");
        }

        public PartialViewResult GetViewTrainDetails()
        {
            return PartialView("_ViewTrainDetails");
        }

        public PartialViewResult GetPackages()
        {
            return PartialView("_Packages");
        }

        public PartialViewResult AddPriceQuotation()
        {
            return PartialView("_AddPriceQuotation");
        }

        public PartialViewResult AddPriceQuotation2()
        {
            return PartialView("_AddPriceQuotation2");
        }

        public PartialViewResult AddPriceQuotation3()
        {
            return PartialView("_AddPriceQuotation3");
        }

        public PartialViewResult CustomizeTravelServices()
        {
            return PartialView("_CustomizeTravelServices");
        }

        public PartialViewResult CustomizeTravelServicesApproval()
        {
            return PartialView("_CustomizeTravelServicesApproval");
        }

        public PartialViewResult GetGitCTS()
        {
            return PartialView("_GetGitCTS");
        }

        public PartialViewResult GetFitCTS()
        {
            return PartialView("_GetFitCTS");
        }

        public PartialViewResult GetHotelCTS()
        {
            return PartialView("_GetHotelsCTS");
        }

        public PartialViewResult GetVehiclesCTS()
        {
            return PartialView("_GetVehicleCTS");
        }

        public PartialViewResult AddFlightCTS()
        {
            return PartialView("_AddFlightCTS");
        }

        public PartialViewResult AddTrainCTS()
        {
            return PartialView("_AddTrainCTS");
        }

        public PartialViewResult GetSightseeingCTS()
        {
            return PartialView("_GetSightSeeingCTS");
        }

        public PartialViewResult EditFlightCTS()
        {
            return PartialView("_EditFlightCTS");
        }

        public PartialViewResult EditTrainCTS()
        {
            return PartialView("_EditTrainCTS");
        }

        public PartialViewResult AddFlightPP()
        {
            return PartialView("_AddFlightPP");
        }

        public PartialViewResult AddTrainPP()
        {
            return PartialView("_AddTrainPP");
        }

        public PartialViewResult EditFlightPP()
        {
            return PartialView("_EditFlightPP");
        }

        public PartialViewResult EditTrainPP()
        {
            return PartialView("_EditTrainPP");
        }

        public PartialViewResult GetSightSeeing()
        {
            return PartialView("_GetSightSeeing");
        }
    }
}
