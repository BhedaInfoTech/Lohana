using Lohana.Common;
using Lohana.Models;
using Lohana.Models.Master;
using LohanaBusinessEntities.Common;
using LohanaHelper.Logging;
using LohanaRepo.Master;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lohana.Controllers.PostLogin.Master
{
    public class TaxController : BaseController
    {
        public TaxRepo _tRepo;
   
        public TaxController()
        {
            _tRepo = new TaxRepo();
        }

        public ActionResult Index(TaxViewModel tViewModel)
        {
            if (TempData["tViewModel"] != null)
            {
                tViewModel = (TaxViewModel)TempData["tViewModel"];
            }
            
            return View("Index", tViewModel);
        }

        public ActionResult Search(TaxViewModel tViewModel)
        {
            return View("Search", tViewModel);
        }

        public JsonResult Insert(TaxViewModel tViewModel)
        {
            try
            {
                Set_Date_Session(tViewModel.Tax);

                tViewModel.Tax.TaxId = _tRepo.Insert(tViewModel.Tax);

                tViewModel.FriendlyMessage.Add(MessageStore.Get("To01"));

                Logger.Debug("Tax Controller Insert");

            }
            catch(Exception ex)
            {
                tViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Tax Controller - Insert " + ex.Message);
            }

            return Json (tViewModel);
        }

        public JsonResult GetTaxes(TaxViewModel tViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = tViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _tRepo.GetTaxes(tViewModel.Filter.TaxName, tViewModel.Filter.IsActive, ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("Tax Controller GetTaxes");
            }

            catch (Exception ex)
            {
                tViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Tax Controller - GetTaxes" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetTaxById(TaxViewModel tViewModel)
        {
            try
            {
                tViewModel.Tax = _tRepo.GetTaxById(tViewModel.Tax.TaxId);

                Logger.Debug("Tax Controller GetTaxById");
            }
            catch (Exception ex)
            {
                tViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Tax Controller - GetTaxById" + ex.ToString());
            }

            TempData["tViewModel"] = tViewModel;

            return RedirectToAction("Index");
        }

        public JsonResult Update(TaxViewModel tViewModel)
        {
            try
            {
                Set_Date_Session(tViewModel.Tax);
                                
                _tRepo.Update(tViewModel.Tax);

                tViewModel.FriendlyMessage.Add(MessageStore.Get("To02"));

                Logger.Debug("Tax Controller Update");

            }
            catch (Exception ex)
            {

                tViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Tax Controller - Update  " + ex.Message);
            }

            return Json(tViewModel);
        }

        public JsonResult CheckTaxNameExist(string taxName)
        {
            bool check = false;

            TaxViewModel tViewModel = new TaxViewModel();

            try
            {
                check = _tRepo.CheckTaxNameExist(taxName);

                Logger.Debug("Tax Controller CheckTaxNameExist");
            }
            catch (Exception ex)
            {
                Logger.Error("Tax Controller - CheckTaxNameExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);

        }

        public JsonResult CheckTaxCodeExist(string taxCode)
        {
            bool check = false;

            TaxViewModel tViewModel = new TaxViewModel();

            try
            {
                check = _tRepo.CheckTaxCodeExist(taxCode);

                Logger.Debug("Tax Controller CheckTaxCodeExist");
            }
            catch (Exception ex)
            {
                Logger.Error("Tax Controller - CheckTaxCodeExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);
        }
    }
}
