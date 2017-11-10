using Lohana.Common;
using Lohana.Models;
using Lohana.Models.Master;
using Lohana.Models.Quotation;
using LohanaBusinessEntities;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Quotation;
using LohanaBusinessEntities.SightSeeing;
using LohanaHelper.Authorization;
using LohanaHelper.Logging;
using LohanaRepo.Accessories;
using LohanaRepo.Master;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Lohana.Controllers.PostLogin.Master
{
    public class SightSeeingController : BaseController
    {


        public SightSeeingRepo _sRepo;

        public SightSeeingController()
        {
            _sRepo = new SightSeeingRepo();
        }

        [AuthorizeUser(RoleModule.SightSeeing, Function.View)]
        public ActionResult Index(SightSeeingViewModel sViewModel)
        {
            if (TempData["sViewModel"] != null)
            {
                sViewModel = (SightSeeingViewModel)TempData["sViewModel"];
            }
            sViewModel.Cities = _sRepo.drpGetCountryStateCity();

            Set_Date_Session(sViewModel.SightSeeing);

            return View("Index", sViewModel);
        }

        [AuthorizeUser(RoleModule.SightSeeing, Function.View)]
        public ActionResult Search(SightSeeingViewModel sViewModel)
        {
            try
            {
                Set_Date_Session(sViewModel.SightSeeing);

                sViewModel.Cities = _sRepo.drpGetCountryStateCity();

                Logger.Debug("SightSeeing Controller Search");

            }
            catch (Exception ex)
            {
                sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("SightSeeing Controller - Search " + ex.Message);
            }
            return View("Search", sViewModel);
        }

        [AuthorizeUser(RoleModule.SightSeeing, Function.Create)]
        public JsonResult Insert(SightSeeingViewModel sViewModel)
        {
            try
            {
                Set_Date_Session(sViewModel.SightSeeing);

                sViewModel.SightSeeing.SightSeeingId = _sRepo.Insert(sViewModel.SightSeeing);

                sViewModel.FriendlyMessage.Add(MessageStore.Get("SS01"));

                Logger.Debug("SightSeeing Controller Insert");

            }
            catch (Exception ex)
            {
                sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("SightSeeing Controller - Insert " + ex.Message);
            }

            return Json(sViewModel);
        }

        [AuthorizeUser(RoleModule.SightSeeing, Function.View)]
        public JsonResult GetSightSeeing(SightSeeingViewModel sViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager = sViewModel.Pager;

            PaginationViewModel pViewModel = new PaginationViewModel();

            try
            {

                //Modification by swapali | Date:28/06/2017
                pViewModel.dt = _sRepo.GetSightSeeing(sViewModel.SightSeeing.SightSeeingName,sViewModel.SightSeeing.CityId, ref pager);

                pViewModel.Pager = pager;

                Logger.Debug("SightSeeing Controller GetSightSeeing");

            }

            catch (Exception ex)
            {
                sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("SightSeeing Controller - GetSightSeeing" + ex.ToString());
            }

            return Json(JsonConvert.SerializeObject(pViewModel), JsonRequestBehavior.AllowGet);

        }

        [AuthorizeUser(RoleModule.SightSeeing, Function.View)]
        public ActionResult GetSightSeeingById(SightSeeingViewModel sViewModel)
        {

            try
            {
                sViewModel.SightSeeing = _sRepo.GetSightSeeingById(sViewModel.Filter.SightSeeingId);

                Logger.Debug("SightSeeing Controller GetSightSeeingById");
            }
            catch (Exception ex)
            {
                sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("SightSeeing Controller - GetUserById" + ex.ToString());
            }

            TempData["sViewModel"] = sViewModel;

            return Index(sViewModel);
        }

        [AuthorizeUser(RoleModule.SightSeeing, Function.Edit)]
        public JsonResult Update(SightSeeingViewModel sViewModel)
        {
            try
            {
                Set_Date_Session(sViewModel.SightSeeing);

                _sRepo.UpdateSightSeeing(sViewModel.SightSeeing);

                sViewModel.FriendlyMessage.Add(MessageStore.Get("SS02"));

                Logger.Debug("SightSeeing Controller Update");
            }
            catch (Exception ex)
            {

                sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("SightSeeing Controller - UpdateSightSeeing  " + ex.Message);
            }

            return Json(sViewModel);

        }

        [AuthorizeUser(RoleModule.SightSeeing, Function.View)]
        public JsonResult CheckSightSeeingNameExist(string sightseeingid)
        {
            bool check = false;

            SightSeeingViewModel sViewModel = new SightSeeingViewModel();

            try
            {
                check = _sRepo.CheckSightSeeingNameExist(sightseeingid);

                Logger.Debug("SightSeeing Controller CheckSightSeeingNameExist");
            }
            catch (Exception ex)
            {
                Logger.Error("SightSeeing Controller - CheckSightSeeingNameExist" + ex.Message);
            }

            return Json(check, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GetSightSeeingView(SightSeeingViewModel sViewModel)
        {
            int SightSeeingId = sViewModel.Filter.SightSeeingId;

           

            AccessoriesRepo _aRepo = new AccessoriesRepo();

            sViewModel.Images = _aRepo.GetImagesByRefType(SightSeeingId, (int)Attachment.SightSeeing);

            sViewModel.SightSeeing = _sRepo.GetSightSeeingById(sViewModel.Filter.SightSeeingId);

            return View("SightSeeingView", sViewModel);
        }


        #region SearchSightSeeing
        public ActionResult SearchSightSeeing(SightSeeingViewModel sViewModel)
        {
            return View("SightSeeingSearch", sViewModel);
        }

        public PartialViewResult GetSearchSightSeeingDetails(SightSeeingViewModel sViewModel)
        {
            AccessoriesRepo _aRepo = new AccessoriesRepo();
            try
            {

                bool IsExtraChild = false;

                decimal cost = 0;

                decimal Extracost = 0;

                decimal Extra = 0;

                //int OccupancyValueCount = 0;

                decimal ExtraPeopleCost = 0;

                decimal ExtraChildCost = 0;

                decimal CheckBudget = sViewModel.SightSeeing.Budget;

                sViewModel.SightSeeings = _sRepo.GetSearchSightSeeingDetails(sViewModel.SightSeeing, IsExtraChild, (int)OccupancyType.Room);
                              

                int TotalAdultCount = sViewModel.SightSeeing.AdultCount;

                foreach (var item in sViewModel.SightSeeings.Select(a => new { a.SightSeeingId }).Distinct())
                {
                    
                    if (sViewModel.SightSeeing.ChildCount != 0)
                    {
                        IsExtraChild = true;

                        sViewModel.SightSeeingSearchExtraChildList = _sRepo.GetSearchSightSeeingDetails(sViewModel.SightSeeing, IsExtraChild, (int)OccupancyType.Extra);

                        if (sViewModel.SightSeeingSearchExtraChildList.Count > 0)
                        {

                            ExtraChildCost = sViewModel.SightSeeing.ChildCount * (sViewModel.SightSeeingSearchExtraChildList.Where(a => a.SightSeeingId == item.SightSeeingId).Select(a => a.NetRate).FirstOrDefault());
                        
                        }
                        else
                        {
                            decimal singlePeopleCost = sViewModel.SightSeeings.Where(b => b.SightSeeingId == item.SightSeeingId && b.OccupancyValue == 1).Select(a => a.NetRate).FirstOrDefault();

                            ExtraChildCost = sViewModel.SightSeeing.ChildCount * singlePeopleCost;
                        }

                    }

                    string SightSeeingName = " ";
                    string Location = "";
                    string Description = " ";
                    string VisitTime = "";
                    string Highlights = "";
                    string Duration = "";                  
                    int SightSeeingId = 0;
                   
                    foreach (var i in sViewModel.SightSeeings.Where(a => a.SightSeeingId == item.SightSeeingId).OrderByDescending(s => s.OccupancyValue))
                    {                       
                        if (i.OccupancyValue <= sViewModel.SightSeeing.AdultCount)
                        {
                            if (i.OccupancyValue == sViewModel.SightSeeing.AdultCount)
                            {
                                cost = i.NetRate;

                                sViewModel.SightSeeing.AdultCount = 0;
                            }
                            else
                            {
                                while (sViewModel.SightSeeing.AdultCount >= i.OccupancyValue)
                                {
                                    int remains = sViewModel.SightSeeing.AdultCount - i.OccupancyValue;

                                    Extra = i.NetRate;

                                    sViewModel.SightSeeing.AdultCount = remains;

                                    Extracost += Extra;
                                }

                            }

                            SightSeeingName = i.SightSeeingName;

                            Location = i.location;

                            Description = i.Description;

                            VisitTime = i.VisitTime;

                            Highlights = i.Highlights;

                            Duration = i.Duration;

                            SightSeeingId = i.SightSeeingId;

                            sViewModel.Images = i.Images;                           

                        }
                    }

                    if (sViewModel.SightSeeing.AdultCount != 0)
                    {
                        IsExtraChild = false;

                        sViewModel.SightSeeingSearchExtraAdultList = _sRepo.GetSearchSightSeeingDetails(sViewModel.SightSeeing, IsExtraChild, (int)OccupancyType.Extra);

                        if (sViewModel.SightSeeingSearchExtraAdultList.Count > 0)
                        {
                            ExtraPeopleCost = sViewModel.SightSeeing.AdultCount * (sViewModel.SightSeeingSearchExtraAdultList.Where(a => a.SightSeeingId == item.SightSeeingId).Select(a => a.NetRate).FirstOrDefault());
                        }
                        else
                        {
                            decimal singlePeopleCost = sViewModel.SightSeeings.Where(b => b.SightSeeingId == item.SightSeeingId && b.OccupancyValue == 1).Select(a => a.NetRate).FirstOrDefault();

                            ExtraPeopleCost = sViewModel.SightSeeing.AdultCount * singlePeopleCost;

                        }
                    }

                   
                    decimal NetRate = cost + Extracost + ExtraPeopleCost + ExtraChildCost;
                    
                    SightSeeingInfo info = new SightSeeingInfo();

                    info.SightSeeingName = SightSeeingName;

                    info.location = Location;

                    info.VisitTime = VisitTime;

                    info.Highlights = Highlights;

                    info.Duration = Duration;                   

                    info.SightSeeingId = SightSeeingId;

                    info.Images = sViewModel.Images;

                    if (CheckBudget != 0)
                    {
                        if (CheckBudget > NetRate)
                        {
                            info.NetRate = NetRate;
                            sViewModel.SightSeeingSearchList.Add(info);
                        }
                    }
                    else
                    {
                        info.NetRate = NetRate;
                        sViewModel.SightSeeingSearchList.Add(info);
                    }                   

                    sViewModel.SightSeeing.AdultCount = TotalAdultCount;

                    NetRate = 0; cost = 0; Extracost = 0; ExtraPeopleCost = 0; ExtraChildCost = 0;
                }
               
            }

            catch (Exception ex)
            {
                sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("Package Controller - GetPackage" + ex.ToString());
            }

            TempData["sViewModel"] = sViewModel;

            return PartialView("_SearchSightSeeingDetails", sViewModel);
        }

        #endregion

        //public JsonResult GetSightSeeingByCityId(SightSeeingViewModel sViewModel)
        //{

        //    try
        //    {
        //        sViewModel.SightSeeings = _sRepo.GetSightSeeingByCityId(sViewModel.SightSeeing.CityId);

        //        Logger.Debug("VehicleTariff Controller GetVehicleDetailsById");
        //    }
        //    catch (Exception ex)
        //    {

        //        sViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

        //        Logger.Error("VehicleTariff Controller - GetVehicleDetailsById  " + ex.Message);//Added by vinod mane on 06/10/2016
        //    }

        //    return Json(sViewModel.SightSeeings, JsonRequestBehavior.AllowGet);
        //}


        public JsonResult SightSeeingAddToCart(QuotationViewModel qViewModel)
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
                if (Request.Cookies["Bookings"].Value != null)
                {
                    if (Request.Cookies["Bookings"].Value != "")
                    {
                        qsViewModel.Quotation.QuatationItem = json_serializer.Deserialize<List<BookingCartDetailsInfo>>(Request.Cookies["Bookings"].Value);

                        string SightSeeingName = qViewModel.Quotation.QuatationItem.Select(x => x.HotelName).FirstOrDefault();

                        if (!qsViewModel.Quotation.QuatationItem.Where(x => x.SightseeingName == SightSeeingName).Any())
                        {
                            qsViewModel.Quotation.QuatationItem.AddRange(qViewModel.Quotation.QuatationItem);

                            string jsonData = json_serializer.Serialize(qsViewModel.Quotation.QuatationItem);

                            Response.Cookies["Bookings"].Value = jsonData;

                            HttpContext.Response.SetCookie(Response.Cookies["Bookings"]);
                        }
                    }
                    else
                    {
                        string jsonData = json_serializer.Serialize(qViewModel.Quotation.QuatationItem);

                        Response.Cookies["Bookings"].Value = jsonData;

                        HttpContext.Response.SetCookie(Response.Cookies["Bookings"]);
                    }
                }
            }
            catch (Exception ex)
            {
                qsViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("SightSeeingSearch Controller - SightSeeingAddToCart" + ex.ToString());

                Request.Cookies["Bookings"].Value = null;
            }

            return Json(qsViewModel, JsonRequestBehavior.AllowGet);
        }


    }
}
