using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lohana.Models.Master;
using LohanaRepo;
using LohanaHelper.Authorization;
using LohanaBusinessEntities;
using LohanaHelper.Logging;
using Lohana.Common;
using Newtonsoft.Json;
using Lohana.Models;
using LohanaBusinessEntities.Common;

namespace Lohana.Controllers.PostLogin.Master
{
    public class HotelTypeController : BaseController
    {
        //
        // GET: /HotelType/

        public HotelTypeRepo _hRepo;

        public HotelTypeController()
        {
            _hRepo = new HotelTypeRepo();
        }



        public ActionResult Index(HotelTypeViewModel hViewModel)
        {
          
            return View("Index", hViewModel);
        }




        [AuthorizeUser(RoleModule.HotelType, Function.View)]
        public ActionResult Search()
        {
            return View();
        }

        [AuthorizeUser(RoleModule.HotelType, Function.Create)]
        public JsonResult Insert(HotelTypeViewModel hViewModel)
        {
            try
            {
                Set_Date_Session(hViewModel.HotelTypeInfo);

                hViewModel.HotelTypeInfo.HotelTypeId = _hRepo.Insert(hViewModel.HotelTypeInfo);

                hViewModel.FriendlyMessage.Add(MessageStore.Get("HOTELTYPE01"));

                Logger.Debug("Hotel Type Controller Insert");

            }
            catch (Exception ex)
            {
                hViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("HotelType Controller - Insert " + ex.Message);
            }

            return Json(hViewModel);
        }
        [AuthorizeUser(RoleModule.HotelType, Function.View)]
        public JsonResult GetHotelType(HotelTypeViewModel hViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = hViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _hRepo.GetHotelType(hViewModel.HotelTypeInfo.HotelType, ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("HotelType Controller GetHotelType");
            }

            catch (Exception ex)
            {
                hViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("HotelType Controller - GetHotelType" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);
        }
            [AuthorizeUser(RoleModule.HotelType, Function.Edit)]
        public JsonResult Update(HotelTypeViewModel hViewModel)
        {
            try
            {
                Set_Date_Session(hViewModel.HotelTypeInfo);

                _hRepo.Update(hViewModel.HotelTypeInfo);

                 hViewModel.FriendlyMessage.Add(MessageStore.Get("HOTELTYPE02"));

                Logger.Debug("HotelType Controller Update");
            }
            catch (Exception ex)
            {
                hViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("HotelType Controller - Update  " + ex.Message);
            }

            return Json(hViewModel);
        }

        [AuthorizeUser(RoleModule.HotelType, Function.View)]
        public JsonResult CheckHotelTypeExist(string HotelType)
        {
            bool check = false;

            HotelTypeViewModel hViewModel = new HotelTypeViewModel();

            try
            {
                check = _hRepo.CheckHotelTypeExist(HotelType);

                Logger.Debug("HotelType Controller CheckHotelTypeExist");
            }
            catch (Exception ex)
            {
                Logger.Error("HotelType Controller - CheckHotelTypeExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);
        }

        

        }

    }


