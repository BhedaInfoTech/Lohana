using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LohanaHelper.Logging;
using LohanaRepo.Master;
using Lohana.Models.Master;
using Lohana.Common;
using Newtonsoft.Json;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities;
using Lohana.Models;
using LohanaHelper.Authorization;
using LohanaBusinessEntities.Business;
using LohanaBusinessEntities.Vendor;

namespace Lohana.Controllers.PostLogin
{
        [SessionExpired]
    public class VendorController : BaseController
    {
        public VendorRepo _vRepo;

        public VendorController()
        {
            _vRepo = new VendorRepo();
        }

        [AuthorizeUser(RoleModule.Vendor, Function.View)]
        public ActionResult Index(VendorViewModel vViewModel)
        {

            if (TempData["vViewModel"] != null)
            {
                vViewModel = (VendorViewModel)TempData["vViewModel"];
            }
            Set_Date_Session(vViewModel.Vendor);

            vViewModel.Designations = _vRepo.drpGetDesignations();

            vViewModel.Cities = _vRepo.drpGetCities();

            vViewModel.Business = _vRepo.drpGetBusiness();

            return View("Index", vViewModel);
        }

        [AuthorizeUser(RoleModule.Vendor, Function.View)]
        public ActionResult Search()
        {
            return View();
        }

        #region Vendor
        //Vendor

        [AuthorizeUser(RoleModule.Vendor, Function.Create)]
        public JsonResult Insert(VendorViewModel vViewModel)
        {
            try
            {
                Set_Date_Session(vViewModel.Vendor);

                vViewModel.Vendor.VendorId = _vRepo.Insert(vViewModel.Vendor);

                vViewModel.FriendlyMessage.Add(MessageStore.Get("V01"));

                Logger.Debug("Vendor Controller Insert Vendor");

            }
            catch (Exception ex)
            {
                vViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Vendor Controller - Insert Vendor " + ex.Message);
            }

           // return Json(JsonConvert.SerializeObject(vViewModel));
            return Json(vViewModel);
        }

        [AuthorizeUser(RoleModule.Vendor, Function.View)]
        public JsonResult GetVendor(VendorViewModel vViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = vViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _vRepo.GetVendor(vViewModel.Vendor.VendorName, vViewModel.Vendor.MobileNo, ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("Vendor Controller GetVendor");
            }

            catch (Exception ex)
            {
                vViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Vendor Controller - GetVendor" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        [AuthorizeUser(RoleModule.Vendor, Function.View)]
        public ActionResult GetVendorById(VendorViewModel vViewModel)
        {

            try
            
            {
                vViewModel.Vendor = _vRepo.GetVendorById(vViewModel.Filter.VendorId);
                               
                var Business = vViewModel.Vendor.BusinessId.Split(',');               
                                
                int number = Business.Length;
                
                if (Business.Length == 1)
                {
                    number = 2;
                }  

                vViewModel.BusinessList = new List<BusinessInfo>();

                for (int i = 0; i < number - 1; i++)
                {
                    vViewModel.BusinessList.Add(new BusinessInfo());
                }

                if (Business.Length != 0)
                {
                    int i = 0;

                    foreach (var item in Business)
                    {
                        if (item != "")
                        {
                            vViewModel.BusinessList[i].BusinessId = item;

                            i++;
                        }
                    }
                }

                var Payment = vViewModel.Vendor.PaymentOptionId.Split(',');

                int number1 = Payment.Length;

                if(Payment.Length == 1)
                {
                    number1 = 2;
                }

                vViewModel.PaymentOptionList = new List<VendorInfo>();

                for (int i = 0; i < number1 - 1; i++)
                {
                    vViewModel.PaymentOptionList.Add(new VendorInfo());
                }

                if (Payment.Length != 0)
                {
                    int i = 0;

                    foreach (var item1 in Payment)
                    {
                        if (item1 != "")
                        {
                            vViewModel.PaymentOptionList[i].PaymentOptionId = item1;

                            i++;
                        }
                    }
                }

                    Logger.Debug("Vendor Controller GetVendorById");
            }
            catch (Exception ex)
            {
                vViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Vendor Controller - GetVendorById" + ex.ToString());
            }

            TempData["vViewModel"] = vViewModel;

            return Index(vViewModel);
        }

        [AuthorizeUser(RoleModule.Vendor, Function.Edit)]
        public JsonResult UpdateVendor(VendorViewModel vViewModel)
        {
            try
            {
                Set_Date_Session(vViewModel.Vendor);

                _vRepo.UpdateVendor(vViewModel.Vendor);

                vViewModel.FriendlyMessage.Add(MessageStore.Get("V02"));

                Logger.Debug("Vendor Controller UpdateVendor");
            }
            catch (Exception ex)
            {

                vViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Vendor Controller - UpdateVendor  " + ex.Message);
            }

            return Json(vViewModel);

        }

        [AuthorizeUser(RoleModule.Vendor, Function.View)]
        public JsonResult CheckVendorNameExist(string vendorName)
        {
            bool check = false;

            VendorViewModel vViewModel = new VendorViewModel();

            try
            {
                check = _vRepo.CheckVendorNameExist(vendorName);

                Logger.Debug("Vendor Controller CheckVendorNameExist");
            }
            catch (Exception ex)
            {
                Logger.Error("Vendor Controller - CheckVendorNameExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);

        }

        [AuthorizeUser(RoleModule.Vendor, Function.View)]
        public JsonResult CheckEmailIdExist(string emailid)
        {
            bool check = false;

            VendorViewModel vViewModel = new VendorViewModel();

            try
            {
                check = _vRepo.CheckEmailIdExist(emailid);

                Logger.Debug("Vendor Controller CheckEmailIdExist");
            }
            catch (Exception ex)
            {
                Logger.Error("Vendor Controller - CheckEmailIdExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);

        }

        #endregion

        #region Contact Person
        //ContactPerson

        [AuthorizeUser(RoleModule.Vendor, Function.Create)]
        public JsonResult InsertContactPerson(VendorViewModel vViewModel)
        {

            try
            {
                Set_Date_Session(vViewModel.ContactPerson);

                vViewModel.ContactPerson.ContactPersonId = _vRepo.InsertContactPerson(vViewModel.ContactPerson);

                vViewModel.ContactPerson.RefType = (int)ContactType.Vendor;

                vViewModel.FriendlyMessage.Add(MessageStore.Get("CP01"));

                Logger.Debug("Vendor Controller Insert ContactPerson");

            }
            catch (Exception ex)
            {
                vViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Vendor Controller - Insert ContactPerson" + ex.Message);
            }

            return Json(vViewModel);
        }

        [AuthorizeUser(RoleModule.Vendor, Function.View)]
        public JsonResult GetContactPerson(VendorViewModel vViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = vViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {

                vViewModel.ContactPerson.RefType = (int)ContactType.Vendor;

                pViewModel.dt = _vRepo.GetContactPerson(vViewModel.ContactPerson.RefId, vViewModel.ContactPerson.RefType,ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("Vendor Controller GetContactPerson");
               

            }

            catch (Exception ex)
            {
                vViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Vendor Controller - GetContactPerson" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);
        }

        [AuthorizeUser(RoleModule.Vendor, Function.View)]
        public JsonResult GetContactPersonById(VendorViewModel vViewModel)
        {

            try
            {
                vViewModel.ContactPerson = _vRepo.GetContactPersonById(vViewModel.ContactPerson.ContactPersonId);

                Logger.Debug("Vendor Controller GetcontactPersonById");
            }
            catch (Exception ex)
            {
                vViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Vendor Controller - GetContactPersonById" + ex.ToString());
            }

            TempData["vViewModel"] = vViewModel;
    

            return Json(vViewModel, JsonRequestBehavior.AllowGet);
        }

        [AuthorizeUser(RoleModule.Vendor, Function.Edit)]
        public JsonResult UpdateContactPerson(VendorViewModel vViewModel)
        {
            try
            {
                Set_Date_Session(vViewModel.ContactPerson);

                _vRepo.UpdateContactPerson(vViewModel.ContactPerson);

                vViewModel.FriendlyMessage.Add(MessageStore.Get("CP02"));

                Logger.Debug("Vendor Controller UpdateContactPerson");
            }
            catch (Exception ex)
            {

                vViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Vendor Controller - UpdateContactPerson  " + ex.Message);
            }

            return Json(vViewModel);

        }

        [AuthorizeUser(RoleModule.Vendor, Function.View)]
        public JsonResult DeleteContactPerson(VendorViewModel vViewModel)
        {
            try
            {
                _vRepo.DeleteContactPerson(vViewModel.ContactPerson.ContactPersonId,vViewModel.ContactPerson.RefId);

                Logger.Debug("Vendor Controller DeleteContactPerson");
            }
            catch (Exception ex)
            {

                vViewModel.FriendlyMessage.Add(MessageStore.Get("CP03"));

                Logger.Error("Vendor Controller - DeleteContactPerson" + ex.ToString());
            }

            return Json(vViewModel);
        }

        #endregion

        #region Vendor Bank
        //Vendor Bank


        [AuthorizeUser(RoleModule.Vendor, Function.Create)]
        public JsonResult InsertVendorBank(VendorViewModel vViewModel)
        {

            try
            {
                Set_Date_Session(vViewModel.Bank);

                vViewModel.Bank.BankId = _vRepo.InsertVendorBank(vViewModel.Bank);

                vViewModel.FriendlyMessage.Add(MessageStore.Get("VB01"));

                Logger.Debug("Vendor Controller Insert VendorBank");

            }
            catch (Exception ex)
            {
                vViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Vendor Controller - Insert VendorBank " + ex.Message);
            }

            return Json(vViewModel);
        }

        [AuthorizeUser(RoleModule.Vendor, Function.View)]
        public JsonResult GetVendorBank(VendorViewModel vViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = vViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _vRepo.GetVendorBank(vViewModel.Bank.VendorId,ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("Vendor Controller GetVendorBank");

            }

            catch (Exception ex)
            {
                vViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Vendor Controller - GetVendorBank" + ex.ToString());
        }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        [AuthorizeUser(RoleModule.Vendor, Function.View)]
        public JsonResult GetVendorBankById(VendorViewModel vViewModel)
        {

            try
            {
                vViewModel.Bank = _vRepo.GetVendorBankById(vViewModel.Bank.BankId);

                Logger.Debug("Vendor Controller GetContactPersonById");
            }
            catch (Exception ex)
            {
                vViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Vendor Controller - GetContactPersonById" + ex.ToString());
            }

            TempData["vViewModel"] = vViewModel;

            return Json(vViewModel, JsonRequestBehavior.AllowGet);
        }

        [AuthorizeUser(RoleModule.Vendor, Function.Edit)]
        public JsonResult UpdateVendorBank(VendorViewModel vViewModel)
        {
            try
            {
                Set_Date_Session(vViewModel.Bank);

                _vRepo.UpdateVendorBank(vViewModel.Bank);

                vViewModel.FriendlyMessage.Add(MessageStore.Get("VB02"));

                Logger.Debug("Vendor Controller UpdateVendorBank");
            }
            catch (Exception ex)
            {

                vViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Vendor Controller - UpdateVendorBank  " + ex.Message);
            }

            return Json(vViewModel);

        }

        [AuthorizeUser(RoleModule.Vendor, Function.View)]
        public JsonResult DeleteVendorBank(VendorViewModel vViewModel)
        {
            try
            {
                _vRepo.DeleteVendorBank(vViewModel.Bank.BankId,vViewModel.Bank.VendorId);

                Logger.Debug("Vendor Controller DeleteVendorBank");
            }
            catch (Exception ex)
            {

                vViewModel.FriendlyMessage.Add(MessageStore.Get("VB03"));

                Logger.Error("Vendor Controller - DeleteVendorBank" + ex.ToString());
            }

            return Json(vViewModel);
        }

        #endregion

    }
}
