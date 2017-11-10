using Lohana.Models.Master;
using LohanaBusinessEntities.Common;
using LohanaRepo.Master;
using Newtonsoft.Json;
using LohanaHelper.Logging;
using Lohana.Common;
using System;
using System.Web.Mvc;
using Lohana.Models;
using LohanaHelper.Authorization;
using LohanaBusinessEntities;

namespace Lohana.Controllers.PostLogin.Master
{
    [SessionExpired]
    public class TaxFormulaController : BaseController
    {
        TaxFormulaRepo _tRepo;

        public TaxFormulaController()
        {
            _tRepo = new TaxFormulaRepo();
        }

        #region ActionResult

        [AuthorizeUser(RoleModule.TaxFormula, Function.Create)]
        public ActionResult Index(TaxFormulaViewModel tViewModel)
        {
            if (TempData["tViewModel"] != null)
            {
                tViewModel = (TaxFormulaViewModel)TempData["tViewModel"];
            }

            Set_Date_Session(tViewModel.TaxFormula);

            tViewModel.Charges = _tRepo.drpGetCharges();

            return View("Index", tViewModel);
        }

        [AuthorizeUser(RoleModule.TaxFormula, Function.View)]
        public ActionResult Search(TaxFormulaViewModel tViewModel)
        {
            return View("Search", tViewModel);
        }

        [AuthorizeUser(RoleModule.TaxFormula, Function.Edit)]
        public ActionResult GetTaxFormulaById(TaxFormulaViewModel tViewModel)
        {
            try
            {
                tViewModel.TaxFormula = _tRepo.GetTaxFormulaById(tViewModel.TaxFormula.TaxFormulaId);

                Logger.Debug("TaxFormula Controller GetTaxFormulaById");
            }
            catch (Exception ex)
            {
                tViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("TaxFormula Controller - GetTaxFormulaById" + ex.ToString());
            }

            TempData["tViewModel"] = tViewModel;

            return Index(tViewModel);
        }

        #endregion

        #region JsonResult

        [AuthorizeUser(RoleModule.TaxFormula, Function.Create)]
        public JsonResult Insert(TaxFormulaViewModel tViewModel)
        {
            try
            {
                Set_Date_Session(tViewModel.TaxFormula);

                tViewModel.TaxFormula.TaxFormulaId = _tRepo.InsertTaxFormula(tViewModel.TaxFormula);

                tViewModel.FriendlyMessage.Add(MessageStore.Get("TF01"));

                Logger.Debug("TaxFormula Controller Insert");
            }

            catch (Exception ex)
            {
                tViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("TaxFormula Controller - Insert " + ex.Message);
            }

            return Json(tViewModel);
        }

        [AuthorizeUser(RoleModule.TaxFormula, Function.Edit)]
        public JsonResult Update(TaxFormulaViewModel tViewModel)
        {
            try
            {
                Set_Date_Session(tViewModel.TaxFormula);

                _tRepo.UpdateTaxFormula(tViewModel.TaxFormula);

                tViewModel.FriendlyMessage.Add(MessageStore.Get("TF02"));

                Logger.Debug("TaxFormula Controller Update");
            }
            catch (Exception ex)
            {
                tViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("TaxFormula Controller - Update  " + ex.Message);
            }

            return Json(tViewModel);
        }

        [AuthorizeUser(RoleModule.TaxFormula, Function.View)]
        public JsonResult GetTaxFormulaChargeBehaviour(TaxFormulaViewModel tViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = tViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                tViewModel.TaxFormulaCharges = _tRepo.GetTaxFormulaCharges(tViewModel.TaxFormula.TaxFormulaId, ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("TaxFormula Controller GetTaxFormulaChargeBehaviour");
            }

            catch (Exception ex)
            {
                tViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("TaxFormula Controller - GetTaxFormulaChargeBehaviour" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(tViewModel), JsonRequestBehavior.AllowGet);
        }

        [AuthorizeUser(RoleModule.TaxFormula, Function.View)]
        public JsonResult GetTaxFormula(TaxFormulaViewModel tViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = tViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _tRepo.GetTaxFormula(tViewModel.TaxFormula.TaxFormulaName, ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("TaxFormula Controller GetTaxFormula");
            }

            catch (Exception ex)
            {
                tViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("TaxFormula Controller - GetTaxFormula" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);
        }

        [AuthorizeUser(RoleModule.TaxFormula, Function.View)]
        public JsonResult CheckTaxFormulaNameExist(string taxFormulaName, int taxFormulaId)
        {
            bool check = false;

            TaxFormulaViewModel tViewModel = new TaxFormulaViewModel();

            try
            {
                check = _tRepo.CheckTaxFormulaNameExist(taxFormulaName, taxFormulaId);

                Logger.Debug("TaxFormula Controller CheckTaxFormulaNameExist");
            }
            catch (Exception ex)
            {
                Logger.Error("TaxFormula Controller - CheckTaxFormulaNameExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);
        }  

        #endregion

        #region PartialViewResult

        [AuthorizeUser(RoleModule.TaxFormula, Function.View)]
        public PartialViewResult GetFormulaCharges(int TaxFormulaId)
        {
            TaxFormulaViewModel tViewModel = new TaxFormulaViewModel();

            PaginationInfo pager = null;

            tViewModel.TaxFormulaCharges = _tRepo.GetTaxFormulaCharges(TaxFormulaId, ref pager);            

            return PartialView("_FormulaCharges", tViewModel);
        }

        #endregion

        //public PartialViewResult GetChargesRateBehaviour(int[] chargeIds)
        //{
        //    TaxFormulaChargesCalOnModel tViewModel = new TaxFormulaChargesCalOnModel();

        //    tViewModel.Charges = _tRepo.drpGetCharges();

        //    return PartialView("_ChargesRateBehaviour", tViewModel);
        //}

        //public PartialViewResult GetChargesCalOn(int level, int[] chargeIds)
        //{

        //    TaxFormulaChargesModel tViewModel = new TaxFormulaChargesModel();

        //    tViewModel.Charges = _tRepo.drpGetCharges();

        //    return PartialView("_ChargesTypeCalculatedOn", tViewModel);
        //}
    }
}
















