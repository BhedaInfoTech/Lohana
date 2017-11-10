using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Lohana.Models.Quotation;
using LohanaBusinessEntities.Quotation;
using Lohana.Models.Booking;
using LohanaRepo.Booking;
using Newtonsoft.Json;
using LohanaBusinessEntities.Common;
using Lohana.Models;
using LohanaHelper.Logging;
using Lohana.Common;
using System.IO;
using System.Configuration;


namespace Lohana.Controllers.PostLogin
{
    public class BookingController : BaseController
    {
        public BookigRepo _bRepo;

        public BookingController()
        {
            _bRepo = new BookigRepo();
        }

        #region Booking

        public ActionResult Index(BookingViewModel bViewModel)
        {
            HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies["Bookings"];
            // bViewModel.Customers=_bRepo.GetCusti
            var Info = cookie.Value;
            bViewModel.cookiesdata = cookie.Value;
            //HttpContext.Request.Cookies.Clear();
            return View("Index", bViewModel);
        }

        public JsonResult InsertTravellersDetails(BookingViewModel bViewModel)
        {
            Set_Date_Session(bViewModel.BookingCartDetailsInfo);

            if (bViewModel.BookingCartDetailsInfo.BookingId == 0)
            {
                bViewModel.BookingCartDetailsInfo.BookingId = _bRepo.InsertBooking(bViewModel.BookingCartDetailsInfo);
            }

            //if (bViewModel.BookingCartDetailsInfo.IsActive == true)
            //{
            bViewModel.BookingCartDetailsInfo.TravellerId = _bRepo.InsertTravellerInformation(bViewModel.BookingCartDetailsInfo);
            //}

            bViewModel.FriendlyMessage.Add(MessageStore.Get("Booking01"));



            return Json(bViewModel);
        }

        public JsonResult UpdateTravellersDetails(BookingViewModel bViewModel)
        {
            Set_Date_Session(bViewModel.BookingCartDetailsInfo);
            // if (bViewModel.BookingCartDetailsInfo.IsActive == true)
            //  {
            bViewModel.BookingCartDetailsInfo.TravellerId = _bRepo.UpdateTravellerInformation(bViewModel.BookingCartDetailsInfo);
            //  }
            // else
            // {
            //    _bRepo.DeleteTravellerDetails(bViewModel.BookingCartDetailsInfo.TravellerId);
            //  }

            bViewModel.FriendlyMessage.Add(MessageStore.Get("Booking02"));

            return Json(bViewModel);
        }

        public JsonResult GetTravellersDetails(BookingViewModel bViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = bViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _bRepo.GetTravellersDetails(bViewModel.BookingCartDetailsInfo, ref pager);
                pViewModel.Pager = pager;
            }

            catch (Exception ex)
            {
                bViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Booking Controller - GetTravellersDetails" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult TravellerDocumentDetails(BookingViewModel bViewModel)
        {
            return PartialView("_TravellerDocumentDetails", bViewModel);
        }

        public JsonResult InsertTravellersDocumentDetails(BookingViewModel bViewModel)
        {
            Set_Date_Session(bViewModel.BookingCartDetailsInfo);
            if (bViewModel.BookingCartDetailsInfo.TravellerDocumentId == 0)
            {
                bViewModel.BookingCartDetailsInfo.TravellerDocumentId = _bRepo.InsertTravellerDocumentDetails(bViewModel.BookingCartDetailsInfo);
            }

            bViewModel.DocumentDetailsList = _bRepo.GetTravellerDocumentDetails(bViewModel.BookingCartDetailsInfo.BookingId);

            bViewModel.FriendlyMessage.Add(MessageStore.Get("Booking04"));


            return Json(bViewModel);
        }

        public JsonResult GetTravellersDocumentDetails(BookingViewModel bViewModel)
        {
            bViewModel.DocumentDetailsList = _bRepo.GetTravellerDocumentDetails(bViewModel.BookingCartDetailsInfo.BookingId);
            return Json(bViewModel);
        }

        public JsonResult DeleteTravellersDetails(BookingViewModel bViewModel)
        {
            _bRepo.DeleteTravellerDetails(bViewModel.BookingCartDetailsInfo.TravellerId);
            bViewModel.FriendlyMessage.Add(MessageStore.Get("Booking03"));


            return Json(bViewModel);
        }

        public JsonResult DeleteTravellersDocumentDetails(BookingViewModel bViewModel)
        {
            _bRepo.DeleteTravellerDocument(bViewModel.BookingCartDetailsInfo.TravellerDocumentId);
            bViewModel.DocumentDetailsList = _bRepo.GetTravellerDocumentDetails(bViewModel.BookingCartDetailsInfo.BookingId);
            return Json(bViewModel);
        }

        public JsonResult SaveGitDetails(BookingViewModel bViewModel)
        {
            Set_Date_Session(bViewModel.BookingCartDetailsInfo);
            _bRepo.InserPackageDetails(bViewModel.BookingCartDetailsInfo.GitDetailsList, bViewModel.BookingCartDetailsInfo);
            _bRepo.UpdateBookingAmount(bViewModel.BookingCartDetailsInfo.BookingId);
            return Json(bViewModel);
        }
        public JsonResult SaveFitDetails(BookingViewModel bViewModel)
        {
            Set_Date_Session(bViewModel.BookingCartDetailsInfo);
            _bRepo.InserPackageDetails(bViewModel.BookingCartDetailsInfo.FitDetailsList, bViewModel.BookingCartDetailsInfo);
            _bRepo.UpdateBookingAmount(bViewModel.BookingCartDetailsInfo.BookingId);

            return Json(bViewModel);
        }

        public JsonResult SaveFlightDetails(BookingViewModel bViewModel)
        {
            try
            {
                Set_Date_Session(bViewModel.BookingCartDetailsInfo);
                if (bViewModel.BookingCartDetailsInfo.Train_FlightMainId == 0)
                {
                    bViewModel.BookingCartDetailsInfo.Train_FlightMainId = _bRepo.InsertTrainOrFlightDetails(bViewModel.BookingCartDetailsInfo);
                    bViewModel.FriendlyMessage.Add(MessageStore.Get("Booking05"));
                }
                else
                {
                    _bRepo.UpdateTrainOrFlightDetails(bViewModel.BookingCartDetailsInfo);
                    bViewModel.FriendlyMessage.Add(MessageStore.Get("Booking06"));
                }
                bViewModel.BookingCartDetailsInfo.TrainFlightDetails = _bRepo.GetTrainFlightDetails(bViewModel.BookingCartDetailsInfo.BookingId);
            }
            catch (Exception ex)
            {
                bViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Booking Controller - SaveFlightDetails" + ex.ToString());
            }
            return Json(bViewModel);
        }

        public JsonResult SaveFlightpassangerDetails(BookingViewModel bViewModel)
        {
            try
            {
                _bRepo.SaveFlightpassangerDetails(bViewModel.BookingCartDetailsInfo);
                bViewModel.BookingCartDetailsInfo.TrainFlightPassangerDetails = _bRepo.GetPassangerDetails(bViewModel.BookingCartDetailsInfo.Train_FlightMainId);
                bViewModel.FriendlyMessage.Add(MessageStore.Get("Booking08"));
            }
            catch (Exception ex)
            {
                bViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Booking Controller - SaveFlightpassangerDetails" + ex.ToString());
            }
            return Json(bViewModel);
        }

        public PartialViewResult ViewTravellerDetails(int BookingId, int Train_FlightMainId)
        {
            BookingViewModel bViewModel = new BookingViewModel();
            try
            {
                bViewModel.BookingCartDetailsInfo.BookingId = BookingId;
                bViewModel.BookingCartDetailsInfo.Train_FlightMainId = Train_FlightMainId;
                bViewModel.BookingCartDetailsInfo.TrainFlightPassangerDetails = _bRepo.GetPassangerDetails(bViewModel.BookingCartDetailsInfo.Train_FlightMainId);
            }
            catch (Exception ex)
            {
                bViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Booking Controller - ViewTravellerDetails" + ex.ToString());
            }
            return PartialView("_AddTravellersFlightDetails", bViewModel);
        }

        public JsonResult DeletePassangerDetails(BookingViewModel bViewModel)
        {
            try
            {
                _bRepo.DeletePassangerDetails(bViewModel.BookingCartDetailsInfo.Train_FlightdetailId);
                bViewModel.BookingCartDetailsInfo.TrainFlightPassangerDetails = _bRepo.GetPassangerDetails(bViewModel.BookingCartDetailsInfo.Train_FlightMainId);
                bViewModel.FriendlyMessage.Add(MessageStore.Get("Booking09"));

            }
            catch (Exception ex)
            {
                bViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Booking Controller - DeletePassangerDetails" + ex.ToString());
            }
            return Json(bViewModel);
        }

        public JsonResult DeleteFlightDetails(BookingViewModel bViewModel)
        {
            try
            {
                _bRepo.DeleteFlightDetails(bViewModel.BookingCartDetailsInfo.Train_FlightMainId);
                bViewModel.BookingCartDetailsInfo.TrainFlightDetails = _bRepo.GetTrainFlightDetails(bViewModel.BookingCartDetailsInfo.BookingId);
                bViewModel.FriendlyMessage.Add(MessageStore.Get("Booking07"));
            }
            catch (Exception ex)
            {
                bViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Booking Controller - DeleteFlightDetails" + ex.ToString());
            }
            return Json(bViewModel);
        }

        public JsonResult GetPassangerDetails(BookingViewModel bViewModel)
        {
            try
            {
                bViewModel.BookingCartDetailsInfo.TrainFlightPassangerDetails = _bRepo.GetPassangerDetails(bViewModel.BookingCartDetailsInfo.Train_FlightMainId);
            }
            catch (Exception ex)
            {
                bViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Booking Controller - GetPassangerDetails" + ex.ToString());
            }
            return Json(bViewModel);
        }

        //Train
        public JsonResult SaveTrainDetails(BookingViewModel bViewModel)
        {
            try
            {
                Set_Date_Session(bViewModel.BookingCartDetailsInfo);
                if (bViewModel.BookingCartDetailsInfo.Train_FlightMainId == 0)
                {
                    bViewModel.BookingCartDetailsInfo.Train_FlightMainId = _bRepo.InsertTrainDetails(bViewModel.BookingCartDetailsInfo);
                    bViewModel.FriendlyMessage.Add(MessageStore.Get("Booking10"));
                }
                else
                {
                    _bRepo.UpdateTrainDetails(bViewModel.BookingCartDetailsInfo);
                    bViewModel.FriendlyMessage.Add(MessageStore.Get("Booking11"));
                }
                bViewModel.BookingCartDetailsInfo.TrainDetails = _bRepo.GetTrainDetails(bViewModel.BookingCartDetailsInfo.BookingId);
            }
            catch (Exception ex)
            {
                bViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Booking Controller - SaveTrainDetails" + ex.ToString());
            }
            return Json(bViewModel);
        }

        public JsonResult DeleteTrainDetails(BookingViewModel bViewModel)
        {
            try
            {
                _bRepo.DeleteFlightDetails(bViewModel.BookingCartDetailsInfo.Train_FlightMainId);
                bViewModel.BookingCartDetailsInfo.TrainDetails = _bRepo.GetTrainDetails(bViewModel.BookingCartDetailsInfo.BookingId);
                bViewModel.FriendlyMessage.Add(MessageStore.Get("Booking07"));
            }
            catch (Exception ex)
            {
                bViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Booking Controller - DeleteTrainDetails" + ex.ToString());
            }
            return Json(bViewModel);
        }


        #endregion Booking

        #region GenerateInvoice

        public ActionResult GenerateInvoice(BookingViewModel bViewModel)
        {
            return View("GenerateInvoice", bViewModel);
        }

        public ActionResult GetInvoiceDetails(BookingViewModel bViewModel)
        {
            try
            {
                bViewModel.DocumentDetailsList = _bRepo.GetInvoiceDetails(bViewModel.BookingCartDetailsInfo);
            }
            catch (Exception ex)
            {
                bViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Booking Controller - GetInvoiceDetails" + ex.ToString());
            }
            TempData["bViewModel"] = bViewModel;

            return GenerateInvoice(bViewModel);


        }

        public ActionResult SearchReceivablePayment(BookingViewModel bViewModel)
        {
            return View("SearchReceivablePayment", bViewModel);
        }

        public JsonResult GetBookingList(BookingViewModel bViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = bViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _bRepo.GetBookingList(bViewModel.BookingCartDetailsInfo, ref pager);
                pViewModel.Pager = pager;
            }

            catch (Exception ex)
            {
                bViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Booking Controller - GetTravellersDetails" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddCustomerPayment(BookingViewModel bViewModel)
        {
            Set_Date_Session(bViewModel.PaymentDetailsInfo);

            try
            {
                _bRepo.AddCustomerPayment(bViewModel.PaymentDetailsInfo);

                bViewModel.FriendlyMessage.Add(MessageStore.Get("PAY01"));
            }
            catch (Exception ex)
            {
                bViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Booking Controller - AddCustomerPayment" + ex.ToString());
            }
            TempData["bViewModel"] = bViewModel;
            return Json(bViewModel);
            // return View("_AddPayment", bViewModel);
            // return RedirectToAction ("GetBookingList", bViewModel);       
        }

        //public PartialViewResult GetPaymentHistoryListing(int BookingId)
        //{
        //    BookingViewModel bViewModel = new BookingViewModel();
        //    try
        //    {
        //        bViewModel.PaymentHistoryList = _bRepo.GetPaymentHistory(BookingId);              
        //    }
        //    catch (Exception ex)
        //    {
        //        bViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

        //        Logger.Error("Booking Controller - GetPaymentHistoryListing" + ex.ToString());
        //    }           

        //    return PartialView("_PaymentHistory", bViewModel);
        //}   

        public ActionResult GetPaymentHistoryListing(BookingViewModel bViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = bViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            // BookingViewModel bViewModel = new BookingViewModel();
            try
            {
                pViewModel.dt = _bRepo.GetPaymentHistory(bViewModel.PaymentDetailsInfo.BookingId, ref pager);

                pViewModel.Pager = pager;
            }
            catch (Exception ex)
            {
                bViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Booking Controller - GetPaymentHistoryListing" + ex.ToString());
            }
            //TempData["bViewModel"] = bViewModel;

            //return View("_AddPayment", bViewModel);
            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult GetBookingById(string BookingNo, decimal UnpaidAmount, int BookingId)
        {
            BookingViewModel bViewModel = new BookingViewModel();

            bViewModel.PaymentDetailsInfo.BookingNo = BookingNo;

            bViewModel.PaymentDetailsInfo.UnpaidAmount = UnpaidAmount;

            bViewModel.PaymentDetailsInfo.BookingId = BookingId;

            GetPaymentHistoryListing(bViewModel);
            // bViewModel.PaymentHistoryList = _bRepo.GetPaymentHistory(ref pager);       

            return PartialView("_AddPayment", bViewModel);
        }

        public ActionResult PaymentReceipt(BookingViewModel bViewModel)
        {
            return View("PaymentReceipt", bViewModel);
        }

        public ActionResult ViewReceipt(BookingViewModel bViewModel)
        {
            int PaymentReceivableId = bViewModel.PaymentDetailsInfo.PaymentReceivableId;

            int BookingId = bViewModel.BookingCartDetailsInfo.BookingId;
            try
            {
                bViewModel.PaymentHistoryList = _bRepo.GetReceiptDetails(PaymentReceivableId, BookingId);
            }
            catch (Exception ex)
            {
                bViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Receipt Controller - ViewReceipt" + ex.ToString());
            }

            return View("PaymentReceipt", bViewModel);
        }

        public ActionResult Invoice_DownloadPDF(BookingViewModel bViewModel)
        {
            try
            {
                int bookingId = bViewModel.BookingCartDetailsInfo.BookingId;

                bViewModel.DocumentDetailsList = _bRepo.GetInvoiceDetails(bViewModel.BookingCartDetailsInfo);

                string Path = Server.MapPath(ConfigurationManager.AppSettings["SampleDownloadInvoice"].ToString());

                MemoryStream SampleProductInvoiceMS = _bRepo.CreateInvoice_DownloadPDF(bViewModel.DocumentDetailsList);

                bool directoryExists = System.IO.Directory.Exists(Path);

                if (!directoryExists)
                {
                    System.IO.Directory.CreateDirectory(Path);
                }
                System.IO.DirectoryInfo di = new DirectoryInfo(Path);
                string folderPath = Path;

                if (System.IO.File.Exists(folderPath + "\\" + bViewModel.DocumentDetailsList[0].InvoiceNo + ".pdf"))
                    System.IO.File.Delete(folderPath + "\\" + bViewModel.DocumentDetailsList[0].InvoiceNo + ".pdf");

                System.IO.File.WriteAllBytes(folderPath + "\\" + bViewModel.DocumentDetailsList[0].InvoiceNo + ".pdf", SampleProductInvoiceMS.ToArray());

                string sFileName = bViewModel.DocumentDetailsList[0].InvoiceNo + ".pdf";
                string filePath = folderPath + "\\" + bViewModel.DocumentDetailsList[0].InvoiceNo + ".pdf";

                Download_File(sFileName, filePath);

            }
            catch
            {

            }

            return RedirectToAction("PaymentReceipt");
        }

        public void Download_File(string sFileName, string sFilePath)
        {
            string filePath = sFilePath;
            if (System.IO.File.Exists(filePath))
            {
                HttpContext.Response.Clear();
                HttpContext.Response.BufferOutput = false;
                HttpContext.Response.ContentType = "application/octet-stream";
                //  HttpContext.Current.Response.AddHeader("Content-Length", fileLength);
                HttpContext.Response.AddHeader("content-disposition", "attachment; filename=" + sFileName);
                HttpContext.Response.TransmitFile(filePath);
                HttpContext.Response.Flush();
            }

        }

        public ActionResult Receipt_DownloadPDF(BookingViewModel bViewModel)
        {
            try
            {
                int bookingId = bViewModel.BookingCartDetailsInfo.BookingId;

                int PaymentReceivableId = bViewModel.PaymentDetailsInfo.PaymentReceivableId;

                bViewModel.PaymentHistoryList = _bRepo.GetReceiptDetails(PaymentReceivableId, bookingId);

                string Path = Server.MapPath(ConfigurationManager.AppSettings["SampleDownloadInvoice"].ToString());

                MemoryStream SampleProductInvoiceMS = _bRepo.CreateReceipt_DownloadPDF(bViewModel.PaymentHistoryList);

                bool directoryExists = System.IO.Directory.Exists(Path);

                if (!directoryExists)
                {
                    System.IO.Directory.CreateDirectory(Path);
                }
                System.IO.DirectoryInfo di = new DirectoryInfo(Path);
                string folderPath = Path;

                if (System.IO.File.Exists(folderPath + "\\" + bViewModel.PaymentHistoryList[0].ReceiptNo + ".pdf"))
                    System.IO.File.Delete(folderPath + "\\" + bViewModel.PaymentHistoryList[0].ReceiptNo + ".pdf");

                System.IO.File.WriteAllBytes(folderPath + "\\" + bViewModel.PaymentHistoryList[0].ReceiptNo + ".pdf", SampleProductInvoiceMS.ToArray());

                string sFileName = bViewModel.PaymentHistoryList[0].ReceiptNo + ".pdf";
                string filePath = folderPath + "\\" + bViewModel.PaymentHistoryList[0].ReceiptNo + ".pdf";

                Download_File(sFileName, filePath);

            }
            catch
            {

            }

            return RedirectToAction("PaymentReceipt");
        }

        #endregion

        #region PreviousCode

        public ActionResult ApproveBooking()
        {
            return View();
        }

        public PartialViewResult GetHotel()
        {
            return PartialView("_GetHotelBooking");
        }

        public ActionResult CreateBooking()
        {
            QuotationViewModel qsViewModel = new QuotationViewModel();
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();

            try
            {
                if (Request.Cookies["Bookings"].Value != null)
                {
                    qsViewModel.Quotation.QuatationItem = json_serializer.Deserialize<List<BookingCartDetailsInfo>>(Request.Cookies["Bookings"].Value);
                }
            }
            catch (Exception)
            {

            }

            return View();
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

        public PartialViewResult GetPackages()
        {
            return PartialView("_Packages");
        }

        public JsonResult GetBookingItem()
        {
            book b = new book();
            //string a = "";
            dynamic d = null;
            d = Request.Cookies["Booking"].Value;

            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            book routes_list = (book)json_serializer.DeserializeObject(Request.Cookies["Booking"].Value);


            return Json("");
        }



        public class book
        {
            public string bookName
            {
                get;
                set;
            }
        }


        #endregion
    }
}
