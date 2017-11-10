using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Lohana.Models.Master;
using LohanaBusinessEntities.Business;
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
    public class BusinessController : BaseController
    {
        public BusinessRepo _bRepo;

        public BusinessController()
        {
            _bRepo = new BusinessRepo();
        }

        [AuthorizeUser(RoleModule.Business, Function.View)]
        public ActionResult Index(BusinessViewModel bViewModel)
        {
            return View("Index", bViewModel);
        }

        [AuthorizeUser(RoleModule.Business, Function.View)]
        public ActionResult Search()
        {
            return View();
        }

        [AuthorizeUser(RoleModule.Business, Function.Create)]
        public JsonResult Insert(BusinessViewModel bViewModel)
        
        {
            try
            {
                Set_Date_Session(bViewModel.Business);

                //bViewModel.Business.BusinessId = _bRepo.Insert(bViewModel.Business);

                bViewModel.FriendlyMessage.Add(MessageStore.Get("B01"));

                Logger.Debug("Business Controller Insert");

            }
            catch(Exception ex)
            {
                bViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Business Controller - Insert " + ex.Message);
            }

            return Json(bViewModel);
        }

        [AuthorizeUser(RoleModule.Business, Function.View)]
        public JsonResult GetBusinesses(BusinessViewModel bViewModel)
        {

            PaginationInfo pager = new PaginationInfo();

            pager = bViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {

                pViewModel.dt = _bRepo.GetBusinesses(bViewModel.Business.BusinessName,ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("Business Controller GetBusinesses");

            }

            catch (Exception ex)
            {
                bViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Business Controller - GetBusinesses" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        [AuthorizeUser(RoleModule.Business, Function.Edit)]
        public JsonResult Update(BusinessViewModel bViewModel)
        {
            try
            {
                Set_Date_Session(bViewModel.Business);

                _bRepo.Update(bViewModel.Business);

                bViewModel.FriendlyMessage.Add(MessageStore.Get("B02"));

                Logger.Debug("Business Controller Update");
            }
            catch (Exception ex)
            {
                bViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Business Controller - Update  " + ex.Message);
            }

            return Json(bViewModel);
        }

        [AuthorizeUser(RoleModule.Business, Function.View)]
        public JsonResult CheckBusinessNameExist(string businessName)
        {
            bool check = false;

            BusinessViewModel bViewModel = new BusinessViewModel();

            try
            {
                check = _bRepo.CheckBusinessNameExist(businessName);

                Logger.Debug("Business Controller CheckBusinessNameExist");
            }
            catch (Exception ex)
            {
                Logger.Error("Business Controller - CheckBusinessNameExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);

        }


    }
}
