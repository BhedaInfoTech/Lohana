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
using System.Web.Mvc;

namespace Lohana.Controllers.PostLogin.Master
{
	public class RoomTypeController:BaseController
	{
		public RoomTypeRepo _rtRepo;

		public RoomTypeController()
		{
			_rtRepo = new RoomTypeRepo();
		}

        [AuthorizeUser(RoleModule.RoomType, Function.View)]
		public ActionResult Index(RoomTypeViewModel rtViewModel)
		{
			return View("Index", rtViewModel);
		}

        [AuthorizeUser(RoleModule.RoomType, Function.View)]
		public ActionResult Search()
		{
			return View();
		}

        [AuthorizeUser(RoleModule.RoomType, Function.Create)]
		public JsonResult Insert(RoomTypeViewModel rtViewModel)
		{
			try
			{
				Set_Date_Session(rtViewModel.RoomType);

				rtViewModel.RoomType.RoomTypeId = _rtRepo.Insert(rtViewModel.RoomType);

				rtViewModel.FriendlyMessage.Add(MessageStore.Get("RT01"));

                Logger.Debug("RoomType Controller Insert");
			}
			catch(Exception ex)
			{
				rtViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

				Logger.Error("RoomType Controller - Insert " + ex.Message);
			}

			return Json(rtViewModel);
		}

        [AuthorizeUser(RoleModule.RoomType, Function.View)]
		public JsonResult GetRoomTypes(RoomTypeViewModel rtViewModel)
		{
			PaginationInfo pager = new PaginationInfo();

			pager = rtViewModel.Pager;

			PaginationViewModel pViewModel = new PaginationViewModel();
			try
			{
				pViewModel.dt = _rtRepo.GetRoomTypes(rtViewModel.RoomType.RoomTypeName, ref pager);

				pViewModel.Pager = pager;

                Logger.Debug("RoomType Controller GetRoomTypes");
			}

			catch(Exception ex)
			{
				rtViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

				Logger.Error("RoomType Controller - GetRoomTypes" + ex.ToString());
			}

			return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);
		}

        [AuthorizeUser(RoleModule.RoomType, Function.Edit)]
		public JsonResult Update(RoomTypeViewModel rtViewModel)
		{
			try
			{
				Set_Date_Session(rtViewModel.RoomType);

				_rtRepo.Update(rtViewModel.RoomType);

				rtViewModel.FriendlyMessage.Add(MessageStore.Get("RT02"));

                Logger.Debug("RoomType Controller Update");
			}
			catch(Exception ex)
			{
				rtViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

				Logger.Error("RoomType Controller - Update  " + ex.Message);
			}

			return Json(rtViewModel);
		}

        [AuthorizeUser(RoleModule.RoomType, Function.View)]
		public JsonResult CheckRoomTypeNameExist(string roomtypeName)
		{
			bool check = false;

			RoomTypeViewModel rtViewModel = new RoomTypeViewModel();

			try
			{
				check = _rtRepo.CheckRoomTypeNameExist(roomtypeName);

                Logger.Debug("RoomType Controller CheckRoomTypeNameExist");
			}
			catch(Exception ex)
			{
				Logger.Error("RoomType Controller - CheckRoomTypeNameExist" + ex.Message);
			}

			return Json(check, JsonRequestBehavior.AllowGet);
		}
	}
}