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
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lohana.Controllers.PostLogin.Master
{
    public class CustomerController :BaseController
    {
       
         public CustomerRepo _cRepo;

         public CustomerController()
        {
            _cRepo = new CustomerRepo();
        }

         [AuthorizeUser(RoleModule.Customer, Function.View)]
         public ActionResult Index(CustomerViewModel cViewModel)
        {

            if (TempData["cViewModel"] != null)
            {
                cViewModel = (CustomerViewModel)TempData["cViewModel"];
            }
            Set_Date_Session(cViewModel.Customer);

            cViewModel.CustomerCategory = _cRepo.drpGetCustomerCategory();

            return View("Index", cViewModel);
        
        }

         [AuthorizeUser(RoleModule.Customer, Function.View)]
         public ActionResult Search(CustomerViewModel cViewModel)
        {
            return View("Search", cViewModel);
        }

         [AuthorizeUser(RoleModule.Customer, Function.Create)]
         public JsonResult Insert(CustomerViewModel cViewModel)
        {
            try
            {
                Set_Date_Session(cViewModel.Customer);

                cViewModel.Customer.CustomerId = _cRepo.Insert(cViewModel.Customer);

                cViewModel.FriendlyMessage.Add(MessageStore.Get("Cu01"));

                Logger.Debug("Customer Controller Insert");

            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Customer Controller - Insert " + ex.Message);
            }

            return Json(cViewModel);
        }

         [AuthorizeUser(RoleModule.Customer, Function.View)]
         public JsonResult GetCustomer(CustomerViewModel cViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = cViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _cRepo.GetCustomer(cViewModel.Customer.FirstName, cViewModel.Customer.MiddleName, cViewModel.Customer.LastName, cViewModel.Customer.MobileNo, ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("Customer Controller GetCustomer");

            }

            catch (Exception ex)
            {
                cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Customer Controller - GetCustomer" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

         [AuthorizeUser(RoleModule.Customer, Function.View)]
         public ActionResult GetCustomerById(CustomerViewModel cViewModel)
        {

            try
            {
                cViewModel.Customer = _cRepo.GetCustomerById(cViewModel.Filter.CustomerId);

                Logger.Debug("Customer Controller GetCustomerById");
            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Customer Controller - GetCustomerById" + ex.ToString());
            }

            TempData["cViewModel"] = cViewModel;

            return Index(cViewModel);
        }

         [AuthorizeUser(RoleModule.Customer, Function.Edit)]
         public JsonResult Update(CustomerViewModel cViewModel)
        {
            try
            {
                Set_Date_Session(cViewModel.Customer);

                _cRepo.UpdateCustomer(cViewModel.Customer);

                cViewModel.FriendlyMessage.Add(MessageStore.Get("Cu02"));

                Logger.Debug("Customer Controller UpdateCustomer");
            }
            catch (Exception ex)
            {

                cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Customer Controller - UpdateCustomer  " + ex.Message);
            }

            return Json(cViewModel);

        }

         [AuthorizeUser(RoleModule.Customer, Function.View)]
         public JsonResult CheckEmailIdExist(string emailid)
        {
            bool check = false;

            CustomerViewModel cViewModel = new CustomerViewModel();

            try
            {
                check = _cRepo.CheckEmailIdExist(emailid);

                Logger.Debug("Customer Controller CheckEmailIdExist");
            }
            catch (Exception ex)
            {
                Logger.Error("Customer Controller - CheckEmailIdExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);

        }

         public ActionResult Demo(CustomerViewModel cViewModel)
         {
             return View("Demo", cViewModel);
         }

    }
}
