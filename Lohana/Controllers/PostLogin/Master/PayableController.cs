using Lohana.Common;
using Lohana.Models;
using Lohana.Models.Master;
using LohanaBusinessEntities;
using LohanaBusinessEntities.Common;
using LohanaHelper.Authorization;
using LohanaHelper.Logging;
using LohanaRepo.Master;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Lohana.Controllers.PostLogin
{
    public class PayableController : BaseController
    {
        public PayableRepo _payablerepo;

        public PayableController()
        {
            _payablerepo = new PayableRepo();
        }

        public ActionResult AddPayable()
        {
            return View();
        }

        public ActionResult Search(PayableViewModel PViewModel)
        {

            if (TempData["PViewModel"] != null)
            {
                PViewModel = (PayableViewModel)TempData["PViewModel"];
            }

            if (TempData["MessageModel"] != null)
            {
                PViewModel.FriendlyMessage = (List<FriendlyMessage>)TempData["MessageModel"];
            }


            return View("Search", PViewModel);
        }
    
        public JsonResult GetPayable(PayableViewModel PViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = PViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _payablerepo.GetPayable(PViewModel.PayableInfo.VendorName, PViewModel.PayableInfo.BookingNo, PViewModel.PayableInfo.ProductId, PViewModel.PayableInfo.PaymentStatus, ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("Payable Controller GetCustomer");

            }

            catch (Exception ex)
            {
                PViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Payable Controller - GetPayable" + ex.ToString());
            }
            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);
        }
    
        public ActionResult GetBookingById(PayableViewModel PViewModel)
        {

            try
            {
                PaginationInfo pager = new PaginationInfo();

                pager = PViewModel.Pager;

                PaginationViewModel pViewModel = new PaginationViewModel();
                PViewModel.PayableInfo = _payablerepo.GetVendorDetailsById(PViewModel.PayableInfo.BookingId);             
                PViewModel.PayableHistoryList = _payablerepo.GetPaymentHistoryForPayment(PViewModel.PayableInfo.BookingId);            
                decimal temptotalpaid = 0;
                foreach (var item in PViewModel.PayableHistoryList)
                {
                    temptotalpaid += item.AmountPaid;
                }

                PViewModel.PayableInfo.TotalAmountPaid = temptotalpaid;
                Logger.Debug("Customer Controller GetVendorById");
            }
            catch (Exception ex)
            {
                PViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Payable Controller - GetVendorById" + ex.ToString());
            }
            TempData["PViewModel"] = PViewModel;
            return View("AddPayable", PViewModel);
        }

        public ActionResult Insert(PayableViewModel PViewModel)
        {
            try
            {

                Set_Date_Session(PViewModel.PayableInfo);
                Set_Date_Session(PViewModel.PayableHistoryInfo);
                Set_Date_Session(PViewModel.TransactionInfo);
                Set_Date_Session(PViewModel.PayableInfo.PayableHistoryInfo);

                PViewModel.PayableInfo.PayableId = _payablerepo.InsertPayable(PViewModel.PayableInfo);

                int PayableId = PViewModel.PayableInfo.PayableId;

                if (PViewModel.PayableInfo.PayableHistoryInfo.Cheque_No != null)
                {
                    PViewModel.PayableInfo.PayableHistoryInfo.TransactionModeNo = PViewModel.PayableInfo.PayableHistoryInfo.Cheque_No;
                }
                else if (PViewModel.PayableInfo.PayableHistoryInfo.Debit_Card_No != null)
                {
                    PViewModel.PayableInfo.PayableHistoryInfo.TransactionModeNo = PViewModel.PayableInfo.PayableHistoryInfo.Debit_Card_No;
                }
                else if (PViewModel.PayableInfo.PayableHistoryInfo.Credit_Card_No != null)
                {
                    PViewModel.PayableInfo.PayableHistoryInfo.TransactionModeNo = PViewModel.PayableInfo.PayableHistoryInfo.Credit_Card_No;
                }
                if (PViewModel.PayableInfo.PayableHistoryInfo.Transaction_No != null)
                {
                    PViewModel.PayableInfo.PayableHistoryInfo.TransactionModeNo = PViewModel.PayableInfo.PayableHistoryInfo.Transaction_No;
                }
                var PayableHistoryInfo = PViewModel.PayableInfo.PayableHistoryInfo;

                PViewModel.PayableInfo.PayableHistoryInfo.PayableHistoryId = _payablerepo.InsertPayableHistory(PayableHistoryInfo, PayableId);

                PViewModel.PayableInfo.PayableHistoryInfo.PayableHistoryId = _payablerepo.InsertPayableHistory(PayableHistoryInfo, PayableId);


                PViewModel.FriendlyMessage.Add(MessageStore.Get("Pa01"));

                TempData["MessageModel"] = PViewModel.FriendlyMessage;

                Logger.Debug("Payable Controller Insert");

            }
            catch (Exception ex)
            {
                PViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Payable Controller - Insert " + ex.Message);
            }
            return RedirectToAction("Search");          
        }
      
        public ActionResult Update(PayableViewModel PViewModel)
        {           

            try
            {
                Set_Date_Session(PViewModel.PayableInfo);
                Set_Date_Session(PViewModel.PayableHistoryInfo);
                Set_Date_Session(PViewModel.TransactionInfo);
                Set_Date_Session(PViewModel.PayableInfo.PayableHistoryInfo);

                _payablerepo.UpdatePayable(PViewModel.PayableInfo);

                int PayableId = PViewModel.PayableInfo.PayableId;
            
                if (PViewModel.PayableInfo.PayableHistoryInfo.Cheque_No != null)
                {
                    PViewModel.PayableInfo.PayableHistoryInfo.TransactionModeNo = PViewModel.PayableInfo.PayableHistoryInfo.Cheque_No;
                }
                else if (PViewModel.PayableInfo.PayableHistoryInfo.Debit_Card_No != null)
                {
                    PViewModel.PayableInfo.PayableHistoryInfo.TransactionModeNo = PViewModel.PayableInfo.PayableHistoryInfo.Debit_Card_No;
                }
                else if (PViewModel.PayableInfo.PayableHistoryInfo.Credit_Card_No != null)
                {
                    PViewModel.PayableInfo.PayableHistoryInfo.TransactionModeNo = PViewModel.PayableInfo.PayableHistoryInfo.Credit_Card_No;
                }
                if (PViewModel.PayableInfo.PayableHistoryInfo.Transaction_No != null)
                {
                    PViewModel.PayableInfo.PayableHistoryInfo.TransactionModeNo = PViewModel.PayableInfo.PayableHistoryInfo.Transaction_No;
                }
                var PayableHistoryInfo = PViewModel.PayableInfo.PayableHistoryInfo;
                       
                PViewModel.PayableInfo.PayableHistoryInfo.PayableHistoryId = _payablerepo.InsertPayableHistory(PayableHistoryInfo, PayableId);
             
                PViewModel.PayableHistoryList = _payablerepo.GetPaymentHistoryForPayment(PViewModel.PayableInfo.BookingId);
                decimal temptotalpaid = 0;
                foreach (var item in PViewModel.PayableHistoryList)
                {
                    temptotalpaid += item.AmountPaid;
                }

                PViewModel.PayableInfo.TotalAmountPaid = temptotalpaid;
                PViewModel.FriendlyMessage.Add(MessageStore.Get("Pa02"));

                Logger.Debug("Payable Controller Updatepayable");
            }
            catch (Exception ex)
            {

                PViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Payable Controller - UpdatePayable  " + ex.Message);
            }

            TempData["MessageModel"] = PViewModel.FriendlyMessage;
          
            return RedirectToAction("Search");
        }        

    }
}
