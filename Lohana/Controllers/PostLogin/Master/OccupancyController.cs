using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Lohana.Models.Master;
using LohanaBusinessEntities.Occupancy;
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
    public class OccupancyController : BaseController
    {
        public OccupancyRepo _oRepo;

        public OccupancyController()
        {
            _oRepo = new OccupancyRepo();
        }

        [AuthorizeUser(RoleModule.Occupancy, Function.View)]
        public ActionResult Index(OccupancyViewModel oViewModel)
        {
            return View("Index", oViewModel);
        }

        [AuthorizeUser(RoleModule.Occupancy, Function.View)]
        public ActionResult Search()
        {
            return View();
        }

        [AuthorizeUser(RoleModule.Occupancy, Function.Create)]
        public JsonResult Insert(OccupancyViewModel oViewModel)
        
        {
            try
            {
                Set_Date_Session(oViewModel.Occupancy);

                oViewModel.Occupancy.OccupancyId = _oRepo.Insert(oViewModel.Occupancy);

                oViewModel.FriendlyMessage.Add(MessageStore.Get("O01"));

                Logger.Debug("Occupancy Controller Insert");

            }
            catch(Exception ex)
            {
                oViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Occupancy Controller - Insert " + ex.Message);
            }

            return Json(oViewModel);
        }

        [AuthorizeUser(RoleModule.Occupancy, Function.View)]
        public JsonResult GetOccupancies(OccupancyViewModel oViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = oViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _oRepo.GetOccupancies(oViewModel.Occupancy.OccupancyName, oViewModel.Occupancy.OccupancyValue, oViewModel.Occupancy.OccupancyType,ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("Occupancy Controller GetOccupancies");
             
            }

            catch (Exception ex)
            {
                oViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - GetOccupancies" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        [AuthorizeUser(RoleModule.Occupancy, Function.Edit)]
        public JsonResult Update(OccupancyViewModel oViewModel)
        {
            try
            {
                Set_Date_Session(oViewModel.Occupancy);

                _oRepo.Update(oViewModel.Occupancy);

                oViewModel.FriendlyMessage.Add(MessageStore.Get("O02"));

                Logger.Debug("Occupancy Controller Update");
            }
            catch (Exception ex)
            {

                oViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Occupancy Controller - Update  " + ex.Message);
            }

            return Json(oViewModel);
        }

        [AuthorizeUser(RoleModule.Occupancy, Function.View)]
        public JsonResult CheckOccupancyNameExist(string occupancyName)
        {
            bool check = false;

            OccupancyViewModel oViewModel = new OccupancyViewModel();

            try
            {
                check = _oRepo.CheckOccupancyNameExist(occupancyName);

                Logger.Debug("Occupancy Controller CheckOccupancyNameExist");
            }
            catch (Exception ex)
            {
                Logger.Error("Occupancy Controller - CheckOccupancyNameExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);

        }


    }
}
