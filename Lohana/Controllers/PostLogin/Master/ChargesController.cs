using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lohana.Models.Master;
using LohanaBusinessEntities.Charges;
using LohanaBusinessEntities.Common;
using LohanaRepo.Master;
using LohanaHelper;
using Newtonsoft.Json;
using LohanaHelper.Logging;
using Lohana.Common;
using Lohana.Models;
using LohanaHelper.Authorization;
using LohanaBusinessEntities;

namespace Lohana.Controllers.PostLogin.Master
{
    public class ChargesController : BaseController
    {
        public ChargesRepo _cRepo;

        public ChargesController()
        {
            _cRepo = new ChargesRepo();
        }

        [AuthorizeUser(RoleModule.Charges, Function.View)]
        public ActionResult Index(ChargesViewModel cViewModel)
        {
            return View(cViewModel);
        }

        [AuthorizeUser(RoleModule.Charges, Function.View)]
        public ActionResult Search()
        {
            return View();
        }

        [AuthorizeUser(RoleModule.Charges, Function.Create)]
        public JsonResult Insert(ChargesViewModel cViewModel)
        {
            try
            {
                Set_Date_Session(cViewModel.Charges);

                cViewModel.Charges.ChargesId = _cRepo.Insert(cViewModel.Charges);

                cViewModel.FriendlyMessage.Add(MessageStore.Get("Cr01"));

                Logger.Debug("Charges Controller Insert");

            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Charges Controller - Insert " + ex.Message);
            }

            return Json(cViewModel);
        }

        [AuthorizeUser(RoleModule.Charges, Function.View)]
        public JsonResult GetCharges(ChargesViewModel cViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = cViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _cRepo.GetCharges(cViewModel.Charges.ChargesName, cViewModel.Charges.Abbreviation,ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("Charges Controller GetCharges");
            }

            catch (Exception ex)
            {
                cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Charges Controller - GetCharges" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        [AuthorizeUser(RoleModule.Charges, Function.Edit)]
        public JsonResult Update(ChargesViewModel cViewModel)
        {
            try
            {
                Set_Date_Session(cViewModel.Charges);

                _cRepo.Update(cViewModel.Charges);

                cViewModel.FriendlyMessage.Add(MessageStore.Get("Cr02"));

                Logger.Debug("Charges Controller Update");
            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Charges Controller - Update  " + ex.Message);
            }

            return Json(cViewModel);
        }

        [AuthorizeUser(RoleModule.Charges, Function.View)]
        public JsonResult CheckChargesNameExist(string chargesName)
        {
            bool check = false;

            ChargesViewModel cViewModel = new ChargesViewModel();

            try
            {
                check = _cRepo.CheckChargesNameExist(chargesName);

                Logger.Debug("Charges Controller CheckChargesNameExist");
            }
            catch (Exception ex)
            {
                Logger.Error("Charges Controller - CheckChargesNameExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);

        }

        [AuthorizeUser(RoleModule.Charges, Function.View)]
        public JsonResult CheckChargesAbbrevationExist(string chargesabbr)
        {
            bool check = false;

            ChargesViewModel cViewModel = new ChargesViewModel();

            try
            {
                check = _cRepo.CheckChargesAbbrevationExist(chargesabbr);

                Logger.Debug("Charges Controller CheckChargesAbbrevationExist");
            }
            catch (Exception ex)
            {
                Logger.Error("Charges Controller - CheckChargesAbbrevationExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);

        }

    }
}
