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
using LohanaRepo.Accessories;
using LohanaBusinessLogic.Utilities;
using System.Configuration;
using System.IO;
using LohanaBusinessEntities.Hotel;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.tool.xml;
using iTextSharp.text.html.simpleparser;


namespace Lohana.Controllers.PostLogin.Master
{
	[SessionExpired]
	public class HotelController:BaseController
	{
		public HotelRepo _hRepo;

		public FacilityRepo _fRepo;

		public FacilityTypeRepo _ftRepo;

		public VendorRepo _vRepo;

		public HotelController()
		{
			_hRepo = new HotelRepo();

			_vRepo = new VendorRepo();
		}

		#region Hotel

        [AuthorizeUser(RoleModule.Hotel, Function.View)]
		public ActionResult Index(HotelViewModel hViewModel)
		{
			if(TempData["hViewModel"] != null)
			{
				hViewModel = (HotelViewModel)TempData["hViewModel"];
			}

			hViewModel.Cities = _hRepo.drpGetCountryStateCity();

			hViewModel.RoomTypes = _hRepo.drpGetRoomTypes();

			hViewModel.Designations = _hRepo.drpGetDesignations();

            hViewModel.HotelTypes = _hRepo.drpGetHotelTypes();

			hViewModel.HotelFacilityDetails = _hRepo.GetHotelFacilities(hViewModel.Hotel.HotelId);

			return View("Index", hViewModel);
		}

        [AuthorizeUser(RoleModule.Hotel, Function.Create)]
		public JsonResult Insert(HotelViewModel hViewModel)
		{
			try
			{
				Set_Date_Session(hViewModel.Hotel);

				hViewModel.Hotel.HotelId = _hRepo.Insert(hViewModel.Hotel);

				hViewModel.FriendlyMessage.Add(MessageStore.Get("HM01"));

                Logger.Debug("Hotel Controller InsertHotelBasicDetails");
			}
			catch(Exception ex)
			{
				hViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Hotel Controller - InsertHotelBasicDetails " + ex.Message);
			}

			return Json(hViewModel);
		}

        [AuthorizeUser(RoleModule.Hotel, Function.Edit)]
		public JsonResult UpdateHotel(HotelViewModel hViewModel)
		{
			try
			{
				Set_Date_Session(hViewModel.Hotel);

				_hRepo.UpdateHotel(hViewModel.Hotel);

				_hRepo.DeleteHotelFacilities(hViewModel.Hotel.HotelId);

				hViewModel.HotelFacilityDetails = _hRepo.GetHotelFacilities(hViewModel.Hotel.HotelId);

				hViewModel.FriendlyMessage.Add(MessageStore.Get("HM02"));

                Logger.Debug("Hotel Controller Update HotelBasicDetails");
			}
			catch(Exception ex)
			{
				hViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Hotel Controller - Update HotelBasicDetails " + ex.Message);
			}

			return Json(hViewModel);
		}

        [AuthorizeUser(RoleModule.Hotel, Function.View)]
		public JsonResult GetHotel(HotelViewModel hViewModel)
		{
			PaginationInfo pager = new PaginationInfo();

			pager = hViewModel.Pager;

			PaginationViewModel pViewModel = new PaginationViewModel();

			try
			{
				pViewModel.dt = _hRepo.GetHotel(hViewModel.Hotel.HotelName, hViewModel.Hotel.StarCategory, hViewModel.Hotel.CityId, ref pager);

				pViewModel.Pager = pager;

                Logger.Debug("Hotel Controller GetHotel BasicDetail");
			}

			catch(Exception ex)
			{
				hViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Hotel Controller - GetHotel BasicDetail" + ex.ToString());
			}

			return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);
		}

        [AuthorizeUser(RoleModule.Hotel, Function.View)]
		public ActionResult GetHotelById(HotelViewModel hViewModel)
		{
			try
			{
				hViewModel.Hotel = _hRepo.GetHotelById(hViewModel.HotelFilter.HotelId);

                Logger.Debug("Hotel Controller GetHotelById");
			}
			catch(Exception ex)
			{
				hViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

				Logger.Error("Hotel Controller - GetHotelById" + ex.ToString());
			}

			TempData["hViewModel"] = hViewModel;

			return Index(hViewModel);
		}

        [AuthorizeUser(RoleModule.Hotel, Function.View)]
		public JsonResult CheckHotelNameExist(int cityId, string hotelName)
		{
			bool check = false;

			HotelViewModel hViewModel = new HotelViewModel();

			try
			{
				check = _hRepo.CheckHotelNameExist(cityId, hotelName);

                Logger.Debug("Hotel Controller CheckHotelNameExist");
			}
			catch(Exception ex)
			{
				Logger.Error("Hotel Controller - CheckHotelNameExist" + ex.Message);
			}

			return Json(check, JsonRequestBehavior.AllowGet);
		}

        [AuthorizeUser(RoleModule.Hotel, Function.View)]
		public JsonResult CheckWebsiteExist(string website)
		{
			bool check = false;

			HotelViewModel hViewModel = new HotelViewModel();

			try
			{
				check = _hRepo.CheckWebsiteExist(website);

                Logger.Debug("Hotel Controller CheckWebsiteAddressExist");
			}
			catch(Exception ex)
			{
				Logger.Error("Hotel controller-CheckWebsiteAddressExist" + ex.Message);
			}

			return Json(check, JsonRequestBehavior.AllowGet);
		}

		#endregion

		#region Hotel Room Type

        [AuthorizeUser(RoleModule.Hotel, Function.Create)]
		public JsonResult InsertHotelRoomType(HotelViewModel hViewModel)
		{
			try
			{
				Set_Date_Session(hViewModel.HotelRoomType);

				hViewModel.HotelRoomType.RoomTypeDetailsId = _hRepo.InsertHotelRoomType(hViewModel.HotelRoomType);

				hViewModel.FriendlyMessage.Add(MessageStore.Get("HM04"));

                Logger.Debug("Hotel Controller Insert HotelRoomType");
			}
			catch(Exception ex)
			{
				hViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

				Logger.Error("Hotel Controller - Insert " + ex.Message);
			}

			return Json(JsonConvert.SerializeObject(hViewModel));
		}

        [AuthorizeUser(RoleModule.Hotel, Function.View)]
		public JsonResult GetHotelRoomType(HotelViewModel hViewModel)
		{
			PaginationInfo pager = new PaginationInfo();

			pager = hViewModel.Pager;

			PaginationViewModel pViewModel = new PaginationViewModel();

			try
			{
				pViewModel.dt = _hRepo.GetHotelRoomType(hViewModel.HotelRoomType.HotelId, ref pager);

				pViewModel.Pager = pager;

                Logger.Debug("Hotel Controller GetHotelRoomType");
			}

			catch(Exception ex)
			{
				hViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

				Logger.Error("Hotel Controller - GetCharges" + ex.ToString());
			}

			return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);
		}

        [AuthorizeUser(RoleModule.Hotel, Function.View)]
		public JsonResult GetHotelRoomTypeById(HotelViewModel hViewModel)
		{
			try
			{
				hViewModel.HotelRoomType = _hRepo.GetHotelRoomTypeById(hViewModel.HotelRoomType.RoomTypeDetailsId);

                Logger.Debug("Hotel Controller GetHotelRoomTypeById");
			}
			catch(Exception ex)
			{
				hViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

				Logger.Error("Hotel Controller - GetHotelRoomTypeById" + ex.ToString());
			}

			TempData["hViewModel"] = hViewModel;

			//return Index(vViewModel);

			return Json(hViewModel, JsonRequestBehavior.AllowGet);
		}

        [AuthorizeUser(RoleModule.Hotel, Function.Edit)]
		public JsonResult UpdateHotelRoomType(HotelViewModel hViewModel)
		{
			try
			{
				Set_Date_Session(hViewModel.HotelRoomType);

				_hRepo.UpdateHotelRoomType(hViewModel.HotelRoomType);

				hViewModel.FriendlyMessage.Add(MessageStore.Get("HM05"));

                Logger.Debug("Hotel Controller UpdateHotelRoomType");
			}
			catch(Exception ex)
			{
				hViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

				Logger.Error("Hotel Controller - UpdateHotelRoomType  " + ex.Message);
			}

			return Json(JsonConvert.SerializeObject(hViewModel));
		}

        [AuthorizeUser(RoleModule.Hotel, Function.View)]
		public JsonResult DeleteHotelRoomType(HotelViewModel hViewModel)
		{
			try
			{
				_hRepo.DeleteHotelRoomType(hViewModel.HotelRoomType.RoomTypeDetailsId, hViewModel.HotelRoomType.HotelId);

				hViewModel.FriendlyMessage.Add(MessageStore.Get("HM06"));

                Logger.Debug("Hotel Controller DeleteHotelRoomType");
			}
			catch(Exception ex)
			{
				hViewModel.FriendlyMessage.Add(MessageStore.Get("RT04"));

				Logger.Error("Hotel Controller - DeleteHotelRoomType" + ex.ToString());
			}

			return Json(hViewModel, JsonRequestBehavior.AllowGet);
		}

		#endregion

		#region Hotel Contact Person

        [AuthorizeUser(RoleModule.Hotel, Function.Create)]
		public JsonResult InsertContactPerson(HotelViewModel hViewModel)
		{
			try
			{
				Set_Date_Session(hViewModel.ContactPerson);

				hViewModel.ContactPerson.ContactPersonId = _hRepo.InsertContactPerson(hViewModel.ContactPerson);

				hViewModel.ContactPerson.RefType = (int)ContactType.Hotel;

				hViewModel.FriendlyMessage.Add(MessageStore.Get("HM07"));

                Logger.Debug("Hotel Controller InsertContactPerson");
			}
			catch(Exception ex)
			{
				hViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

				Logger.Error("Hotel Controller - InsertContactPerson " + ex.Message);
			}

			return Json(JsonConvert.SerializeObject(hViewModel));
		}

        [AuthorizeUser(RoleModule.Hotel, Function.View)]
		public JsonResult GetContactPerson(HotelViewModel hViewModel)
		{
			PaginationInfo pager = new PaginationInfo();

			pager = hViewModel.Pager;

			PaginationViewModel pViewModel = new PaginationViewModel();

			try
			{
				hViewModel.ContactPerson.RefType = (int)ContactType.Hotel;

				pViewModel.dt = _hRepo.GetContactPerson(hViewModel.ContactPerson.RefId, hViewModel.ContactPerson.RefType, ref pager);

				pViewModel.Pager = pager;

                Logger.Debug("Hotel Controller GetContactPerson");
			}

			catch(Exception ex)
			{
				hViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

				Logger.Error("Hotel Controller - GetContactPerson" + ex.ToString());
			}

			return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);
		}

        [AuthorizeUser(RoleModule.Hotel, Function.View)]
		public JsonResult GetContactPersonById(HotelViewModel hViewModel)
		{
			try
			{
				hViewModel.ContactPerson = _hRepo.GetContactPersonById(hViewModel.ContactPerson.ContactPersonId);

                Logger.Debug("Hotel Controller GetContactPersonById");
			}
			catch(Exception ex)
			{
				hViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

				Logger.Error("Hotel Controller - GetContactPersonById" + ex.ToString());
			}

			TempData["hViewModel"] = hViewModel;

			//return Index(vViewModel);

			return Json(hViewModel, JsonRequestBehavior.AllowGet);
		}

        [AuthorizeUser(RoleModule.Hotel, Function.Edit)]
		public JsonResult UpdateContactPerson(HotelViewModel hViewModel)
		{
			try
			{
				Set_Date_Session(hViewModel.ContactPerson);

				_hRepo.UpdateContactPerson(hViewModel.ContactPerson);

				hViewModel.FriendlyMessage.Add(MessageStore.Get("HM08"));

                Logger.Debug("Hotel Controller UpdateContactPerson");
			}
			catch(Exception ex)
			{
				hViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

				Logger.Error("Hotel Controller - UpdateContactPerson  " + ex.Message);
			}

			return Json(JsonConvert.SerializeObject(hViewModel));
		}

        [AuthorizeUser(RoleModule.Hotel, Function.View)]
		public JsonResult DeleteContactPerson(HotelViewModel hViewModel)
		{
			try
			{
				_hRepo.DeleteContactPerson(hViewModel.ContactPerson.ContactPersonId, hViewModel.ContactPerson.RefId);

				hViewModel.FriendlyMessage.Add(MessageStore.Get("HM09"));

                Logger.Debug("Hotel Controller DeleteContactPerson");
			}
			catch(Exception ex)
			{
				hViewModel.FriendlyMessage.Add(MessageStore.Get("CP03"));

				Logger.Error("Hotel Controller - DeleteContactPerson" + ex.ToString());
			}

			return Json(hViewModel, JsonRequestBehavior.AllowGet);
		}

		#endregion

		#region Hotel Bank

        [AuthorizeUser(RoleModule.Hotel, Function.Create)]
		public JsonResult InsertHotelBank(HotelViewModel hViewModel)
		{
			try
			{
				Set_Date_Session(hViewModel.HotelBank);

				hViewModel.HotelBank.BankId = _hRepo.InsertHotelBank(hViewModel.HotelBank);

				hViewModel.FriendlyMessage.Add(MessageStore.Get("HM10"));

                Logger.Debug("Hotel Controller InsertHotelBank");
			}
			catch(Exception ex)
			{
				hViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

				Logger.Error("Hotel Controller - InsertHotelBank " + ex.Message);
			}

			return Json(JsonConvert.SerializeObject(hViewModel));
		}

        [AuthorizeUser(RoleModule.Hotel, Function.View)]
		public JsonResult GetHotelBank(HotelViewModel hViewModel)
		{
			PaginationInfo pager = new PaginationInfo();

			pager = hViewModel.Pager;

			PaginationViewModel pViewModel = new PaginationViewModel();

			try
			{
				pViewModel.dt = _hRepo.GetHotelBank(hViewModel.HotelBank.HotelId, ref pager);

				pViewModel.Pager = pager;

                Logger.Debug("Hotel Controller GetHotelBank");
			}

			catch(Exception ex)
			{
				hViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

				Logger.Error("Hotel Controller - GetHotelBank" + ex.ToString());
			}

			return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);
		}

        [AuthorizeUser(RoleModule.Hotel, Function.View)]
		public JsonResult GetHotelBankById(HotelViewModel hViewModel)
		{
			try
			{
				hViewModel.HotelBank = _hRepo.GetHotelBankById(hViewModel.HotelBank.BankId);

                Logger.Debug("Hotel Controller GetHotelBankById");
			}
			catch(Exception ex)
			{
				hViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

				Logger.Error("Hotel Controller - GetHotelBankById" + ex.ToString());
			}

			TempData["hViewModel"] = hViewModel;

			return Json(hViewModel, JsonRequestBehavior.AllowGet);
		}

        [AuthorizeUser(RoleModule.Hotel, Function.Edit)]
		public JsonResult UpdateHotelBank(HotelViewModel hViewModel)
		{
			try
			{
				Set_Date_Session(hViewModel.HotelBank);

				_hRepo.UpdateHotelBank(hViewModel.HotelBank);

				hViewModel.FriendlyMessage.Add(MessageStore.Get("HM11"));

                Logger.Debug("Hotel Controller UpdateHotelBank");
			}
			catch(Exception ex)
			{
				hViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

				Logger.Error("Hotel Controller - UpdateHotelBank  " + ex.Message);
			}

			return Json(JsonConvert.SerializeObject(hViewModel));
		}

        [AuthorizeUser(RoleModule.Hotel, Function.View)]
		public JsonResult DeleteHotelBank(HotelViewModel hViewModel)
		{
			try
			{
				_hRepo.DeleteHotelBank(hViewModel.HotelBank.BankId, hViewModel.HotelBank.HotelId);

				hViewModel.FriendlyMessage.Add(MessageStore.Get("HM12"));

                Logger.Debug("Hotel Controller DeleteHotelBank");
			}
			catch(Exception ex)
			{
				hViewModel.FriendlyMessage.Add(MessageStore.Get("HB03"));

				Logger.Error("Hotel Controller - DeleteHotelBank" + ex.ToString());
			}

			return Json(hViewModel, JsonRequestBehavior.AllowGet);
		}

		#endregion

		#region Hotel Facilites

        [AuthorizeUser(RoleModule.Hotel, Function.Create)]
		public JsonResult InsertHotelFacilityDetails(HotelViewModel hViewModel)
		{
			try
			{
				foreach(var item in hViewModel.HotelFacilityDetails)
				{
					Set_Date_Session(item);

					_hRepo.InsertHotelFacilityDetails(item);
				}

                hViewModel.FriendlyMessage.Add(MessageStore.Get("HM03"));

                Logger.Debug("Hotel Controller InsertHotelFacility");
			}
			catch(Exception ex)
			{
				hViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

				Logger.Error("Hotel Controller - InsertHotelFacility" + ex.ToString());
			}

			return Json(hViewModel);
		}

        [AuthorizeUser(RoleModule.Hotel, Function.View)]
		public ActionResult Search(HotelViewModel hViewModel)
		{
			hViewModel.Cities = _hRepo.drpGetCountryStateCity();

			return View("Search", hViewModel);
		}

		public PartialViewResult GetDesignationDropDown()
		{
			HotelViewModel hViewModel = new HotelViewModel();

			hViewModel.Designations = _hRepo.drpGetDesignations();

			return PartialView("_designationDropDown", hViewModel);
		}

		public PartialViewResult GetContactPersonListing(HotelViewModel hViewModel)
		{
			return PartialView("_contactPersonListing", hViewModel);
		}

		#endregion

        public ActionResult GetHotelView(HotelViewModel hViewModel)
        {
            AccessoriesRepo _aRepo = new AccessoriesRepo();

            int HotelId = hViewModel.HotelFilter.HotelId;

            hViewModel.Hotel = _hRepo.GetHotelById(HotelId);

            hViewModel.HotelFacilityDetails = _hRepo.GetHotelFacilities(HotelId);

            hViewModel.HotelRoomTypes = _hRepo.GetHotelRoomTypeByHotelId(HotelId);

            hViewModel.Images = _aRepo.GetImagesByRefType(HotelId, (int)Attachment.Hotel);

            hViewModel.Hotel.HotelFacilityDetails = hViewModel.HotelFacilityDetails;
            hViewModel.Hotel.RoomTypeDetails = hViewModel.HotelRoomTypes;
            hViewModel.Hotel.Images = hViewModel.Images;          
          //  GenerateHotel_PDF(hViewModel.Hotel);

            return View("HotelView",hViewModel);
        }

        public void GenerateHotel_PDF(HotelInfo hotelInfo)
        {           
            string Path = (ConfigurationManager.AppSettings["CustomerFileUpload"].ToString());

            bool directoryExists = System.IO.Directory.Exists(Path);

            if (!directoryExists)
            {
                System.IO.Directory.CreateDirectory(Path);
            }
            string HotelName = hotelInfo.HotelName;

            StringBuilder body = new StringBuilder();

            body.Append("<table><tbody><tr><td>");


            body.Append("<table style='width:100%'><tbody>");
            body.Append("<tr style='letter-spacing:2px'><td>");
            body.Append("<table style='width:100%'><tbody>");
            body.Append("<tr><td><div><ul><li><a><h3><span></span>&nbsp; Basic Details</h3></a></li></ul></div></td></tr>");
            body.Append("<tr style='font-size:12px;letter-spacing:1px;line-height:25px'>");
            body.Append("<td colspan='3' width='45%;' style='background-color:dimgray;padding:4px;font-size:15px;text-align:left;text-transform:uppercase;color:white'>Primary Details:</td>");
            body.Append("<td><div style='border-top:1px solid #ccc;margin:7px'></div></td>");
            body.Append("</tr>");
            body.Append("</tbody></table>");
            body.Append("</td></tr>");
            body.Append("<tr style='letter-spacing:2px'><td>");
            body.Append("<table style='width:100%'><tbody>");
            body.Append("<tr style='font-size:12px;letter-spacing:1px;line-height:25px'>");
            body.Append("<td style='text-align:left;width:25%'>Hotel Type</td><td style='text-align:left;width:1%'>:</td><td>" + hotelInfo.HotelType + "</td>");
            body.Append("</tr>");
            body.Append("<tr style='font-size:12px;letter-spacing:1px;line-height:25px'>");
            body.Append("<td>Hotel Name</td><td>:</td><td>" + hotelInfo.HotelName + "</td>");
            body.Append("</tr>");
            body.Append("<tr style='font-size:12px;letter-spacing:1px;line-height:25px'>");
            body.Append("<td>Hotel Group</td><td>:</td><td style='font-size:12px;letter-spacing:1px;line-height:25px'>" + hotelInfo.HotelGroup + "</td>");
            body.Append("</tr>");
            body.Append("<tr style='font-size:12px;letter-spacing:1px;line-height:25px'>");
            body.Append("<td>Star Category</td><td>:</td><td style='text-decoration-line:underline'><b>" + hotelInfo.StarCategory + "</b></td>");
            body.Append("</tr>");
            body.Append("<tr style='font-size:12px;letter-spacing:1px;line-height:25px'>");
            body.Append("<td>Nearest Airport (Km)</td><td>:</td><td style='font-size:12px;letter-spacing:1px;line-height:25px'>" + hotelInfo.NearestAirport + "</td>");
            body.Append("</tr>");
            body.Append("<tr style='font-size:12px;letter-spacing:1px;line-height:25px'>");
            body.Append("<td>Nearest Railway Station (Km)</td><td>:</td><td style='font-size:12px;letter-spacing:1px;line-height:25px'>" + hotelInfo.NearestRailwayStation + "</td>");
            body.Append("</tr>");
            body.Append("<tr style='font-size:12px;letter-spacing:1px;line-height:25px'><td>Nearest LandMark</td><td>:</td><td style='font-size:12px;letter-spacing:1px;line-height:25px'>" + hotelInfo.NearestLandMark + "</td>");
            body.Append("</tr>");
            body.Append("</tbody></table><br/><br/><br/>");
            body.Append("</td></tr></tbody></table></td></tr><br/><br/><br/>");

            body.Append("<tr><td><table style='width:100%'>");
            body.Append("<tbody>");
            body.Append("<tr style='letter-spacing:2px'><td><table style='width:100%'><tbody>");
            body.Append("<tr style='font-size:12px;letter-spacing:1px;line-height:25px'>");
            body.Append("<td colspan='3' width='45%;' style='background-color:dimgray;padding:4px;font-size:15px;text-align:left;text-transform:uppercase;color:white'>Additional Details:</td>");
            body.Append("<td><div style='border-top:1px solid #ccc;margin:7px'></div></td>");
            body.Append("</tr>");
            body.Append("</tbody></table></td></tr>");
            body.Append("<tr style='letter-spacing:2px'><td>");
            body.Append("<table style='width:100%'><tbody>");
            body.Append("<tr style='font-size:12px;letter-spacing:1px;line-height:25px'>");
            body.Append("<td style='text-align:left;width:25%'>Lohana Ratings</td><td style='text-align:left;width:1%'>:</td><td>" + hotelInfo.LohanaRatings + "</td>");
            body.Append("</tr>");
            body.Append("<tr style='font-size:12px;letter-spacing:1px;line-height:25px'>");
            body.Append("<td>Hotel Description</td><td>:</td><td>" + hotelInfo.HotelDescription + "</td>");
            body.Append("</tr>");
            body.Append("<tr style='font-size:12px;letter-spacing:1px;line-height:25px'>");
            body.Append("<td>Top Attractions Near By</td><td>:</td><td style='font-size:12px;letter-spacing:1px;line-height:25px'>" + hotelInfo.TopAttractionsNearBy + "</td>");
            body.Append("</tr>");
            body.Append("<tr style='font-size:12px;letter-spacing:1px;line-height:25px'>");
            body.Append("<td>Useful Hotel Stats</td><td>:</td><td style='text-decoration-line:underline'><b>" + hotelInfo.UsefulHotelStats + "</b></td>");
            body.Append("</tr>");
            body.Append("<tr style='font-size:12px;letter-spacing:1px;line-height:25px'>");
            body.Append("<td>Notes</td><td>:</td><td style='font-size:12px;letter-spacing:1px;line-height:25px'>" + hotelInfo.Notes + "</td>");
            body.Append("</tr>");
            body.Append("</tbody></table>");
            body.Append("</td></tr></tbody></table></td></tr><br/><br/><br/>");


            body.Append("<tr><td><table style='width:70%'><tbody><br/><br/><br/>");
            body.Append("<tr>");
            body.Append("<td><div><ul><li><a><h3><span></span>&nbsp; Room Types</h3></a></li></ul></div></td>");
            body.Append("</tr>");
            body.Append("<tr>");
            body.Append("<td>");
            body.Append("<table border='1' cellpadding='5' cellspacing='5' style='border-color:black; width:70%'><tr><th style='background-color:black;color:white'>RoomType Name</th><th style='background-color:black;color:white'>No Of Rooms</th><th style='background-color:black; color:white'>Occupancy Capacity</th></tr>");
            foreach (var item in hotelInfo.RoomTypeDetails)
            {
                body.Append("<tr><td style='color:black'>" + item.RoomTypeName + "</td><td style='color:black'>" + item.NoOfRooms + "</td>");
                body.Append("<td style='color:black'>" + item.OccupancyCapacity + "</td></tr>");
            }
            body.Append("</table></td></tr></tbody></table></td></tr><br/><br/><br/>");


            body.Append("<tr><td><table style='width:100%'><tbody><tr><td><div><ul><li><a><h3><span></span>&nbsp; Images</h3></a></li></ul></div></td></tr><br/><br/><br/>");
           
            if (hotelInfo.Images.Count > 0)
            {
                int i = 0;
                for (int j =i; j < hotelInfo.Images.Count; j++)
                {
                    if ((j + 3) % 3 == 0)
                    {
                        body.Append("<tr>");
                    }
                    body.Append("<td>");
                    body.Append("<img src='" + Server.MapPath("~/Upload/" + hotelInfo.Images[j].UniqueAttachmentId) + "' style='width:250px;height:200px' alt='" + hotelInfo.Images[j].AttachmentName + "' />");
                    body.Append("</td>");
                    if (j != 0)
                    {
                        if ((j + 1) % 3 == 0)
                        {
                            body.Append("</tr>");
                        }
                    }
                    i = j;
                }
                if ((i - 2) % 3 != 0)
                {
                    body.Append("</tr>");
                }
            }
            body.Append("</tbody></table></td></tr></tbody></table><br/><br/><br/>");

            CommonMethods.GeneratePDF(hotelInfo.HotelId, Server.MapPath(@"/Upload"), body.ToString(), "Hotel");
           
        }       
	}
}
 