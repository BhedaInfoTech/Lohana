using Lohana.Models.Master;
using LohanaBusinessEntities.CustomerCategory;
using LohanaBusinessEntities.Common;
using LohanaRepo.Master;
using LohanaHelper;
using Newtonsoft.Json;
using LohanaHelper.Logging;
using Lohana.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using LohanaHelper.Authorization;
using LohanaBusinessEntities;


namespace Lohana.Controllers.PostLogin.Master
{
    public class CustomerCategoryController : BaseController
    {
        public CustomerCategoryRepo _cRepo;

        public CustomerCategoryController()
        {
            _cRepo = new CustomerCategoryRepo();
        }

        [AuthorizeUser(RoleModule.CustomerCategory, Function.View)]
        public ActionResult Index(CustomerCategoryViewModel cViewModel)
        {
            return View("Index", cViewModel);
        }

        [AuthorizeUser(RoleModule.CustomerCategory, Function.View)]
        public ActionResult Search()
        {
            return View();
        }

        [AuthorizeUser(RoleModule.CustomerCategory, Function.Create)]
        public JsonResult Insert(CustomerCategoryViewModel cViewModel)
        {
            try
            {
                Set_Date_Session(cViewModel.CustomerCategory);

                cViewModel.CustomerCategory.CustomerCategoryId = _cRepo.Insert(cViewModel.CustomerCategory);

                cViewModel.FriendlyMessage.Add(MessageStore.Get("CustomerCategory01"));

                Logger.Debug("CustomerCategory Controller Insert");

            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("CustomerCategory Controller - Insert " + ex.Message);
            }

            return Json(cViewModel);
        }

        [AuthorizeUser(RoleModule.CustomerCategory, Function.View)]
        public JsonResult GetCustomerCategory(CustomerCategoryViewModel cViewModel)
        {

            try
            {

                cViewModel.CustomerCategories = _cRepo.GetCustomerCategory(cViewModel.CustomerCategory.CustomerCategoryName, cViewModel.CustomerCategory.Margin);

                cViewModel.Pager = new PaginationInfo(cViewModel.CustomerCategories.Count(), cViewModel.Pager.CurrentPage);

                cViewModel.CustomerCategories = cViewModel.CustomerCategories.Skip((cViewModel.Pager.CurrentPage - 1) * cViewModel.Pager.PageSize).Take(cViewModel.Pager.PageSize).ToList();

                Logger.Debug("CustomerCategory Controller GetCustomerCategory");
            }

            catch (Exception ex)
            {
                cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("CustomerCategory Controller - GetCustomerCategory" + ex.ToString());
            }

            return Json(cViewModel, JsonRequestBehavior.AllowGet);

        }

        [AuthorizeUser(RoleModule.CustomerCategory, Function.Edit)]
        public JsonResult Update(CustomerCategoryViewModel cViewModel)
        {
            try
            {
                Set_Date_Session(cViewModel.CustomerCategory);

                _cRepo.Update(cViewModel.CustomerCategory);

                cViewModel.FriendlyMessage.Add(MessageStore.Get("CustomerCategory02"));

                Logger.Debug("CustomerCategory Controller Update");
            }
            catch (Exception ex)
            {
                cViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("CustomerCategory Controller - Update  " + ex.Message);
            }

            return Json(cViewModel);
        }

        [AuthorizeUser(RoleModule.CustomerCategory, Function.View)]
        public JsonResult CheckCustomerCategoryNameExist(string customerCategoryName)
        {
            bool check = false;

            CustomerCategoryViewModel cViewModel = new CustomerCategoryViewModel();

            try
            {
                check = _cRepo.CustomerCategoryNameExist(customerCategoryName);

                Logger.Debug("CustomerCategory Controller CheckCustomerCategoryNameExist");
            }
            catch (Exception ex)
            {
                Logger.Error("CustomerCategory Controller - CheckCustomerCategoryNameExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);

        }

    }
}







