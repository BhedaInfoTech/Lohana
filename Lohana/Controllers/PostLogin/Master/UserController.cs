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
        [SessionExpired]
    public class UserController : BaseController
    {
        public UserRepo _uRepo;

        public UserController()
        {
            _uRepo = new UserRepo();
        }

        public ActionResult Index(UserViewModel uViewModel)
        {
            if (TempData["uViewModel"] != null)
            {
                uViewModel = (UserViewModel)TempData["uViewModel"];
            }
            uViewModel.Cities = _uRepo.drpGetCountryStateCity();

            uViewModel.Users = _uRepo.GetUsers();
                      
            Set_Date_Session(uViewModel.User);

            uViewModel.Role = _uRepo.drpGetRole();

            uViewModel.Specialization = _uRepo.GetSpecialization();

            return View("Index", uViewModel);
        }

        public ActionResult Search(UserViewModel uViewModel)
        {
            try
            {
                Set_Date_Session(uViewModel.User);

                uViewModel.Role = _uRepo.drpGetRole();
            }
            catch(Exception ex)
            {
                uViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("User Controller - Search " + ex.Message);
            }
            return View("Search", uViewModel);
        }

        public JsonResult Insert(UserViewModel uViewModel)
        {
            try
            {
                Set_Date_Session(uViewModel.User);

                uViewModel.User.UserId = _uRepo.Insert(uViewModel.User);

                _uRepo.InsertUserLocations(uViewModel.User);

                _uRepo.InsertUserTeamLead(uViewModel.User);

                _uRepo.InsertUserSpecialization(uViewModel.User);

             

                uViewModel.FriendlyMessage.Add(MessageStore.Get("U01"));

                Logger.Debug("User Controller Insert");

            }
            catch (Exception ex)
            {
                uViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("User Controller - Insert " + ex.Message);
            }

            return Json(uViewModel);
        }

        public JsonResult GetUser(UserViewModel uViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = uViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {


                pViewModel.dt = _uRepo.GetUser(uViewModel.User.UserName, uViewModel.User.RoleId,ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("User Controller GetUser");

            }

            catch (Exception ex)
            {
                uViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("User Controller - GetUser" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetUserById(UserViewModel uViewModel)
        {

            try
            {
                uViewModel.User = _uRepo.GetUserById(uViewModel.Filter.UserId);

                Logger.Debug("User Controller GetUserById");
            }
            catch (Exception ex)
            {
                uViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("User Controller - GetUserById" + ex.ToString());
            }

            TempData["uViewModel"] = uViewModel;

            return Index(uViewModel);
        }

        public JsonResult Update(UserViewModel uViewModel)
        {
            try
            {
                Set_Date_Session(uViewModel.User);

                _uRepo.UpdateUser(uViewModel.User);

                _uRepo.InsertUserLocations(uViewModel.User);

                _uRepo.InsertUserTeamLead(uViewModel.User);

                uViewModel.FriendlyMessage.Add(MessageStore.Get("U02"));

                Logger.Debug("User Controller UpdateUser");
            }
            catch (Exception ex)
            {

                uViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("User Controller - UpdateUser  " + ex.Message);
            }

            return Json(uViewModel);

        }

        public JsonResult CheckUserNameExist(string userid)
        {
            bool check = false;

            UserViewModel uViewModel = new UserViewModel();

            try
            {
                check = _uRepo.CheckUserNameExist(userid);

                Logger.Debug("User Controller CheckUserNameExist");
            }
            catch (Exception ex)
            {
                Logger.Error("User Controller - CheckUserNameExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);

        }

    }
}
