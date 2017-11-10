using Lohana.Models.Master;
using LohanaRepo.Master;
using Lohana.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LohanaBusinessEntities;
using LohanaBusinessEntities.Quotation;
using LohanaBusinessEntities.Common;
using LohanaHelper.Logging;
using System.Web.Script.Serialization;
using Lohana.Models.Quotation;
using System.Collections.Specialized;
using LohanaBusinessEntities.HotelSearch; 

namespace Lohana.Controllers.PostLogin.Master
{
    public class HotelSearchController : BaseController
    {

        public HotelRepo _hRepo;

        public HotelSearchRepo _hsRepo;

        public HotelSearchController()
        {
            _hsRepo = new HotelSearchRepo();

            _hRepo = new HotelRepo();

        }

        public ActionResult Search(HotelSearchViewModel hsViewModel)
        {
            hsViewModel.Cities = _hRepo.drpGetCountryStateCity();

            hsViewModel.RoomTypes = _hRepo.drpGetRoomTypes();

            if (TempData["hsViewModel"] != null)
            {
                hsViewModel = (HotelSearchViewModel)TempData["hsViewModel"];
            }

            return View("Search", hsViewModel);
        }


        public PartialViewResult GetHotelSearch(HotelSearchViewModel hsViewModel)
        {
            try
            {
                hsViewModel.HotelSearch.IsExtraChild = false;

                hsViewModel.HotelSearchRoomList = _hsRepo.GetHotelBasicDetails(hsViewModel.HotelSearch, (int)OccupancyType.Room); 

                #region-----Price Calculation based on adult and child
                //decimal NetRate = 0;

                //decimal Extra = 0;

                //decimal ExtraPeopleCost = 0;

                //int PeopleCount = hsViewModel.HotelSearch.AdultCount + hsViewModel.HotelSearch.ChildCount;

                //foreach (var item in hsViewModel.HotelSearchRoomList)
                //{
                //    if (item.OccupancyCapacity >= PeopleCount)
                //    {
                //        if (hsViewModel.HotelSearch.ChildCount != 0)
                //        {
                //            hsViewModel.HotelSearch.IsExtraChild = true;

                //            hsViewModel.HotelSearchExtraList = _hsRepo.GetHotelBasicDetails(hsViewModel.HotelSearch, (int)OccupancyType.Extra);

                //            if (hsViewModel.HotelSearchExtraList.Count > 0)
                //            {
                //                decimal ExtraRate = 0;

                //                var minExtraCost = hsViewModel.HotelSearchExtraList.Min(a => a.HotelRoomPrice);

                //                ExtraRate = ((hsViewModel.HotelSearch.ChildCount) * minExtraCost);

                //                NetRate = item.HotelRoomPrice + ExtraRate;

                //                item.HotelRoomPrice = NetRate;

                //                //hsViewModel.HotelSearchList.Add(item);
                //            }
                //        }

                //        if (item.OccupancyValue <= hsViewModel.HotelSearch.AdultCount)
                //        {
                //            if (item.OccupancyValue == hsViewModel.HotelSearch.AdultCount)
                //            {
                //                item.HotelRoomPrice = ((item.HotelRoomPrice) * hsViewModel.HotelSearch.AdultCount);
                //            }
                //            else
                //            {
                //                int AdultCount = hsViewModel.HotelSearch.AdultCount;

                //                while (AdultCount >= item.OccupancyValue)
                //                {
                //                    int remains = AdultCount - item.OccupancyValue;

                //                    Extra = item.HotelRoomPrice;

                //                    AdultCount = remains;

                //                    ExtraPeopleCost += Extra;
                //                }

                //                item.HotelRoomPrice = ExtraPeopleCost;
                //            }
                //        }
                //        else
                //        {
                //            hsViewModel.HotelSearch.IsExtraChild = false;

                //            item.HotelRoomPrice = ((item.HotelRoomPrice) * hsViewModel.HotelSearch.AdultCount);

                //            hsViewModel.HotelSearchExtraList = _hsRepo.GetHotelBasicDetails(hsViewModel.HotelSearch, (int)OccupancyType.Extra);

                //            if (hsViewModel.HotelSearchExtraList.Count > 0)
                //            {

                //                var minExtraCost = hsViewModel.HotelSearchExtraList.Min(a => a.HotelRoomPrice);

                //                decimal ExtraRate = 0;

                //                ExtraRate = ((hsViewModel.HotelSearch.AdultCount) * minExtraCost);

                //                NetRate = NetRate + ExtraRate;

                //                item.HotelRoomPrice = NetRate;
                //            }
                //        }
                //        hsViewModel.HotelSearchList.Add(item);
                //    }
                //} 
                #endregion

                #region ---Comment------
                //foreach (var item in hsViewModel.HotelSearchRoomList)
                //{
                //    if (item.OccupancyCapacity >= PeopleCount)
                //    {

                //        if (item.OccupancyValue <= hsViewModel.HotelSearch.AdultCount)
                //        {
                //            item.HotelRoomPrice = ((item.HotelRoomPrice) * hsViewModel.HotelSearch.AdultCount);

                //            if (hsViewModel.HotelSearch.ChildCount != 0)
                //            {
                //                //find pkg for extra child

                //                //hsViewModel.HotelSearch.OccupancyName = "Extra Child";

                //                hsViewModel.HotelSearch.IsExtraChild = true;

                //                hsViewModel.HotelSearchExtraList = _hsRepo.GetHotelBasicDetails(hsViewModel.HotelSearch, (int)OccupancyType.Extra);

                //                if (hsViewModel.HotelSearchExtraList.Count > 0)
                //                {
                //                    decimal ExtraRate = 0;

                //                    var minExtraCost = hsViewModel.HotelSearchExtraList.Min(a => a.HotelRoomPrice);

                //                    ExtraRate = ((hsViewModel.HotelSearch.ChildCount) * minExtraCost);

                //                    NetRate = item.HotelRoomPrice + ExtraRate;

                //                    item.HotelRoomPrice = NetRate;
                //                }

                //            }
                //        }

                //        else
                //        {
                //            //find pkg for extra adult

                //            //hsViewModel.HotelSearch.OccupancyName = "Extra Adult";

                //            hsViewModel.HotelSearch.IsExtraChild = false;

                //            item.HotelRoomPrice = ((item.HotelRoomPrice) * hsViewModel.HotelSearch.AdultCount);

                //            hsViewModel.HotelSearchExtraList = _hsRepo.GetHotelBasicDetails(hsViewModel.HotelSearch, (int)OccupancyType.Extra);

                //            if (hsViewModel.HotelSearchExtraList.Count > 0)
                //            {

                //                var minExtraCost = hsViewModel.HotelSearchExtraList.Min(a => a.HotelRoomPrice);

                //                decimal ExtraRate = 0;

                //                ExtraRate = ((hsViewModel.HotelSearch.AdultCount) * minExtraCost);

                //                NetRate = NetRate + ExtraRate;

                //                item.HotelRoomPrice = NetRate;
                //            }
                //        }

                //        hsViewModel.HotelSearchList.Add(item);
                //    }

                //}
                #endregion

                Logger.Debug("HotelSearch Controller GetHotelSearch");
            }
            catch (Exception ex)
            {
                hsViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("HotelSearch Controller - GetHotelSearch" + ex.ToString());
            }

            TempData["hsViewModel"] = hsViewModel;

            return PartialView("_RoomMealOccupancy", hsViewModel);
        }


        public PartialViewResult GetHotelRoomDetails(HotelSearchViewModel hsViewModel)
        {
            try
            {
                hsViewModel.HotelSearchRoomMealOccupancyPriceList = _hsRepo.GetHotelRoomDetails(hsViewModel.HotelSearch);
                Logger.Debug("HotelSearch Controller GetHotelSearch");
            }
            catch (Exception ex)
            {
                hsViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("HotelSearch Controller - GetHotelSearch" + ex.ToString());
            }

            TempData["hsViewModel"] = hsViewModel;

            return PartialView("_HotelRoomDetails", hsViewModel);
        }


        public JsonResult HotelAddToCart(QuotationViewModel qViewModel)
        {
            QuotationViewModel qsViewModel = new QuotationViewModel();

            #region--comment--
            //HttpCookie cookieObj = new HttpCookie("Bookings");
            //HttpCookie cookieObj = Request.Cookies["Bookings"];
            //string data = Server.HtmlEncode(cookieObj.Value);

            //if (cookieObj != null)
            //{  
            //    JavaScriptSerializer json_serializer = new JavaScriptSerializer(); 

            //    string jsonData = json_serializer.Serialize(qViewModel.Quotation.QuatationItem);

            //    cookieObj.Value = jsonData;

            //    //HttpContext.Response.SetCookie(cookieObj);

            //    qsViewModel.Quotation.QuatationItem = json_serializer.Deserialize<List<BookingCartDetailsInfo>>(cookieObj.Value);

            //    Response.Cookies.Add(new HttpCookie("Bookings", jsonData));

            //}
            //else
            //{
            //HttpCookie cookieNewObj = new HttpCookie("Bookings");
            #endregion

            JavaScriptSerializer json_serializer = new JavaScriptSerializer(); 
            try
            {
                if ((HttpContext.Session["BookingCart"] != null))
                {
                    qsViewModel.Quotation.QuatationItem = (List<BookingCartDetailsInfo>)HttpContext.Session["BookingCart"];

                    qViewModel.Quotation.QuatationItem.AddRange(qsViewModel.Quotation.QuatationItem);

                    HttpContext.Session["BookingCart"] = qViewModel.Quotation.QuatationItem;   
                }
                else
                {
                    HttpContext.Session["BookingCart"] = qViewModel.Quotation.QuatationItem;

                }

                #region----Cart Cookies ------------------
                //if (Request.Cookies["Bookings"].Value != null)
                //{
                //    if (Request.Cookies["Bookings"].Value != "")
                //    {
                //        qsViewModel.Quotation.QuatationItem = json_serializer.Deserialize<List<BookingCartDetailsInfo>>(Request.Cookies["Bookings"].Value);

                //        string HotelName = qViewModel.Quotation.QuatationItem.Select(x => x.HotelName).FirstOrDefault();

                //        if (!qsViewModel.Quotation.QuatationItem.Where(x => x.HotelName == HotelName).Any())
                //        {
                //            qsViewModel.Quotation.QuatationItem.AddRange(qViewModel.Quotation.QuatationItem);

                //            string jsonData = json_serializer.Serialize(qsViewModel.Quotation.QuatationItem);

                //            Response.Cookies["Bookings"].Value = jsonData;

                //            HttpContext.Response.SetCookie(Response.Cookies["Bookings"]);
                //        }
                //    }
                //    else
                //    {
                //        string jsonData = json_serializer.Serialize(qViewModel.Quotation.QuatationItem);

                //        Response.Cookies["Bookings"].Value = jsonData;

                //        HttpContext.Response.SetCookie(Response.Cookies["Bookings"]);
                //    }
                //}
                #endregion
            }
            catch (Exception ex)
            {
                qsViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("HotelSearch Controller - HotelAddToCart" + ex.ToString());

                Request.Cookies["Bookings"].Value = null;
            }

            return Json(qsViewModel, JsonRequestBehavior.AllowGet);
        }


    }

}