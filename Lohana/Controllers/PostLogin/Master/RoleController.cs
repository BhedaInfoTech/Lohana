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
    public class RoleController : BaseController
    {
       
        public RoleRepo _rRepo;
   
        public RoleController()
        {
            _rRepo = new RoleRepo();
        }

        public ActionResult Index(RoleViewModel rViewModel)
        {
            if (TempData["rViewModel"] != null)
            {
                rViewModel = (RoleViewModel)TempData["rViewModel"];
            }
            
           if(rViewModel.Role.RoleId == 0)
           {
               rViewModel.Role.Modules = _rRepo.GetModuleByRoleId(rViewModel.Role.RoleId);
           }

            return View("Index", rViewModel);
        }

		public ActionResult Search(RoleViewModel rViewModel)
		{
            return View("Search", rViewModel);
		}

        public JsonResult Insert(RoleViewModel rViewModel)
        {
            try
            {
                Set_Date_Session(rViewModel.Role);

                foreach (var item in rViewModel.Role.Modules)
                {
                    Set_Date_Session(item);
                }
                rViewModel.Role.RoleId = _rRepo.Insert(rViewModel.Role);

                rViewModel.FriendlyMessage.Add(MessageStore.Get("Ro01"));

            }
            catch (Exception ex)
            {
                rViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Role Controller - Insert " + ex.Message);
            }

            return Json(rViewModel);
        }
               
        public JsonResult GetRoles(RoleViewModel rViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = rViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {
                pViewModel.dt = _rRepo.GetRoles(rViewModel.Filter.RoleName, ref pager);

                pViewModel.Pager = pager;
            }

            catch (Exception ex)
            {
                rViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Test Controller - GetRoles" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }
          
        public ActionResult GetRoleById(RoleViewModel rViewModel)
        {

            try
            {
                rViewModel.Role = _rRepo.GetRoleById(rViewModel.Role.RoleId);

                rViewModel.Role.Modules = _rRepo.GetModuleByRoleId(rViewModel.Role.RoleId);
            }
            catch (Exception ex)
            {
                rViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Role Controller - GetRoleById" + ex.ToString());
            }

            TempData["rViewModel"] = rViewModel;
                        
            return RedirectToAction("Index");
        }
               
        public JsonResult Update(RoleViewModel rViewModel)
        {
            try
            {
                Set_Date_Session(rViewModel.Role);

                foreach(var item in rViewModel.Role.Modules)
                {
                    Set_Date_Session(item);
                }

                _rRepo.Update(rViewModel.Role);

                rViewModel.FriendlyMessage.Add(MessageStore.Get("Ro02"));

            }
            catch (Exception ex)
            {

                rViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Role Controller - Update  " + ex.Message);
            }

            return Json(rViewModel);
        }

        public JsonResult CheckRoleNameExist(string rolename)
        {
            bool check = false;

            RoleViewModel rViewModel = new RoleViewModel();

            try
            {
                check = _rRepo.CheckRoleNameExist(rolename);
            }
            catch (Exception ex)
            {
                Logger.Error("Role Controller - CheckRoleNameExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);

        }
    }
}
