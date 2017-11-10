using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Lohana.Models.Master;
using LohanaBusinessEntities.Meal;
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
    public class MealController : BaseController
    {
        public MealRepo _mRepo;

        public MealController()
        {
            _mRepo = new MealRepo();
        }

        [AuthorizeUser(RoleModule.Meal, Function.View)]
        public ActionResult Index(MealViewModel mViewModel)
        {
            return View("Index", mViewModel);
        }

        [AuthorizeUser(RoleModule.Meal, Function.View)]
        public ActionResult Search()
        {
            return View();
        }

        [AuthorizeUser(RoleModule.Meal, Function.Create)]
        public JsonResult Insert(MealViewModel mViewModel)
        
        {
            try
            {
                Set_Date_Session(mViewModel.Meal);

                mViewModel.Meal.MealId = _mRepo.Insert(mViewModel.Meal);                

                mViewModel.FriendlyMessage.Add(MessageStore.Get("M01"));

                Logger.Debug("Meal Controller Insert");

            }
            catch(Exception ex)
            {
                mViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Meal Controller - Insert " + ex.Message);
            }

            return Json(mViewModel);
        }

        [AuthorizeUser(RoleModule.Meal, Function.View)]
        public JsonResult GetMeals(MealViewModel mViewModel)
        {

            PaginationInfo pager = new PaginationInfo();

            pager = mViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();
            try
            {

                pViewModel.dt = _mRepo.GetMeals(mViewModel.Meal.MealName,ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("Meal Controller GetMeals");
           
            }

            catch (Exception ex)
            {
                mViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Meal Controller - GetMeals" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        [AuthorizeUser(RoleModule.Meal, Function.Edit)]
        public JsonResult Update(MealViewModel mViewModel)
        {
            try
            {
                Set_Date_Session(mViewModel.Meal);

                _mRepo.Update(mViewModel.Meal);

                mViewModel.FriendlyMessage.Add(MessageStore.Get("M02"));

                Logger.Debug("Meal Controller Update");
            }
            catch (Exception ex)
            {
                mViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Meal Controller - Update  " + ex.Message);
            }

            return Json(mViewModel);
        }

        [AuthorizeUser(RoleModule.Meal, Function.View)]
        public JsonResult CheckMealNameExist(string mealName)
        {
            bool check = false;

            MealViewModel mViewModel = new MealViewModel();

            try
            {
                check = _mRepo.CheckMealNameExist(mealName);

                Logger.Debug("Meal Controller CheckMealNameExist");
            }
            catch (Exception ex)
            {
                Logger.Error("Meal Controller - CheckMealNameExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);

        }

    }
}
