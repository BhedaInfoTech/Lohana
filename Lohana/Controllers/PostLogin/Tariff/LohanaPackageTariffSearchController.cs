using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Lohana.Models.Master;
using Lohana.Models.Tariff;
using LohanaRepo.Master;
using LohanaRepo.Tariff;
using LohanaRepo.LohanaPackageTariffSearch;
using Lohana.Common;
using LohanaBusinessEntities;
using LohanaBusinessEntities.Quotation;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.LohanaPackageTariffSearch;
using LohanaHelper.Logging;
using System.Web.Script.Serialization;
using Lohana.Models.Quotation;
using System.Collections.Specialized;
using System.Web.Mvc;


namespace Lohana.Controllers.PostLogin.Tariff
{
    public class LohanaPackageTariffSearchController : BaseController
    {

        public PackageRepo _pRepo;

        public LohanaPackageTariffSearchRepo _lptsRepo;

        public LohanaPackageTariffSearchController()
        {
            _pRepo = new PackageRepo();

            _lptsRepo = new LohanaPackageTariffSearchRepo();

        }


        public ActionResult LohanaPackageTariffSearch(LohanaPackageTariffSearchViewModel lptsViewModel)
        {

            lptsViewModel.PackageTypes = _pRepo.drpGetPackageTypes();

            if (TempData["lptsViewModel"] != null)
            {
                lptsViewModel = (LohanaPackageTariffSearchViewModel)TempData["lptsViewModel"];
            }

            return View("LohanaPackageTariffSearch", lptsViewModel);
        }

        public PartialViewResult GetLohanaPackageTariffSearch(LohanaPackageTariffSearchViewModel lptsViewModel)
        {
            try
            {

                bool IsExtraChild = false;

                decimal cost = 0;

                decimal Extracost = 0;

                //int OccupancyValueCount = 0;

                decimal ExtraPeopleCost = 0;

                decimal ExtraChildCost = 0;

                decimal Extra = 0;

                //lptsViewModel.LohanaPackageTariffSearch.CheckOutDate = lptsViewModel.LohanaPackageTariffSearch.CheckInDate.AddDays(lptsViewModel.LohanaPackageTariffSearch.DayDuration);

                lptsViewModel.LohanaPackageTariffSearchList = _lptsRepo.GetLohanaPackageTariffBasicDetails(lptsViewModel.LohanaPackageTariffSearch, IsExtraChild, (int)OccupancyType.Room);
                //lptsViewModel.LohanaPackageTariffSearchList

                int TotalAdultCount = lptsViewModel.LohanaPackageTariffSearch.AdultCount;

                foreach (var item in lptsViewModel.LohanaPackageTariffSearchList.Select(a => new { a.LohanaPackageTariffId, a.RoomTypeId }).Distinct())
                {

                    if (lptsViewModel.LohanaPackageTariffSearch.ChildCount != 0)
                    {

                        IsExtraChild = true;

                        lptsViewModel.LohanaPackageTariffSearchExtraChildList = _lptsRepo.GetLohanaPackageTariffBasicDetails(lptsViewModel.LohanaPackageTariffSearch, IsExtraChild, (int)OccupancyType.Extra);


                        if (lptsViewModel.LohanaPackageTariffSearchExtraChildList.Count > 0)
                        {
                            ExtraChildCost = lptsViewModel.LohanaPackageTariffSearch.ChildCount * (lptsViewModel.LohanaPackageTariffSearchExtraChildList.Where(a => a.LohanaPackageTariffId == item.LohanaPackageTariffId).Select(a => a.Cost).FirstOrDefault());
                        }
                        else
                        {

                            decimal singlePeopleCost = lptsViewModel.LohanaPackageTariffSearchList.Where(b => b.LohanaPackageTariffId == item.LohanaPackageTariffId && b.OccupancyValue == 1).Select(a => a.Cost).FirstOrDefault();

                            ExtraChildCost = lptsViewModel.LohanaPackageTariffSearch.ChildCount * singlePeopleCost;

                        }

                   
                    }

                    string PackageName = " ";

                    string PackageTypeName = " ";
                   
                    int LohanaPackageTariffId = 0;

                    int DayDuration = 0;

                    int NightDuration = 0;

                    string LPTDuration = "";

                    int PackageTypeId = 0;

                    int CountryId = 0;

                    int StateId = 0;

                    int CityId = 0;

                    int RoomTypeId = 0;

                    int OccupancyId = 0;

                    string OccupanyName = "";

                    string CountryName = "";

                    string StateName = "";

                    string CityName = "";

                    decimal Cost = 0;

                   // OccupancyValueCount = lptsViewModel.LohanaPackageTariffSearchRoomList.Where(a => a.LohanaPackageTariffId == item.LohanaPackageTariffId).Select(b => b.OccupancyValue).Sum();

                    //for (int k = 0; k <= 1; k++)
                    //{
                        //if (OccupancyValueCount >= lptsViewModel.LohanaPackageTariffSearch.AdultCount)
                        //{


                    foreach (var i in lptsViewModel.LohanaPackageTariffSearchList.Where(a => a.LohanaPackageTariffId == item.LohanaPackageTariffId && a.RoomTypeId == item.RoomTypeId).OrderByDescending(s => s.OccupancyValue))
                    //foreach (var i in lptsViewModel.LohanaPackageTariffSearchList)
                    
                    {
                                if (i.OccupancyValue <= lptsViewModel.LohanaPackageTariffSearch.AdultCount)
                                {
                                    if (i.OccupancyValue == lptsViewModel.LohanaPackageTariffSearch.AdultCount)
                                    {
                                        //cost = i.Cost * lptsViewModel.LohanaPackageTariffSearch.AdultCount;
                                        cost = i.Cost;

                                        lptsViewModel.LohanaPackageTariffSearch.AdultCount = 0;
                                    }
                                    else
                                    {
                                        while (lptsViewModel.LohanaPackageTariffSearch.AdultCount >= i.OccupancyValue)
                                        {

                                            int remains = lptsViewModel.LohanaPackageTariffSearch.AdultCount - i.OccupancyValue;

                                            //Extra = i.Cost * i.OccupancyValue;
                                            Extra = i.Cost;

                                            lptsViewModel.LohanaPackageTariffSearch.AdultCount = remains;

                                            Extracost += Extra;

                                        }

                                    }

                                }

                                    LohanaPackageTariffId = i.LohanaPackageTariffId;

                                    PackageName = i.PackageName;

                                    PackageTypeName = i.PackageTypeName;

                                    CountryId = i.CountryId;

                                    StateId = i.StateId;

                                    CityId = i.CityId;

                                    PackageTypeId = i.PackageTypeId;

                                    RoomTypeId = i.RoomTypeId;

                                    OccupancyId = i.OccupancyId;

                                    OccupanyName = i.OccupancyName;

                                    CountryName = i.CountryName;

                                    StateName = i.StateName;

                                    CityName = i.CityName;

                                    DayDuration = i.DayDuration;

                                    NightDuration = i.NightDuration;

                                    LPTDuration = i.LPTDuration;

                                    Cost = i.Cost;


                                }
                            //}

                        
                         if (lptsViewModel.LohanaPackageTariffSearch.AdultCount != 0)
                            {

                        

                            //extra adult cost

                            IsExtraChild = false;

                           // int RemainingPeople = lptsViewModel.LohanaPackageTariffSearch.AdultCount - OccupancyValueCount;

                            lptsViewModel.LohanaPackageTariffSearchExtraList = _lptsRepo.GetLohanaPackageTariffBasicDetails(lptsViewModel.LohanaPackageTariffSearch, IsExtraChild, (int)OccupancyType.Extra);

                            if (lptsViewModel.LohanaPackageTariffSearchExtraList.Count > 0)
                            {
                                ExtraPeopleCost = lptsViewModel.LohanaPackageTariffSearch.AdultCount * (lptsViewModel.LohanaPackageTariffSearchExtraList.Where(a => a.LohanaPackageTariffId == item.LohanaPackageTariffId).Select(a => a.Cost).FirstOrDefault());
                            }

                            else
                            {
                                decimal singlePeopleCost = lptsViewModel.LohanaPackageTariffSearchList.Where(b => b.LohanaPackageTariffId == item.LohanaPackageTariffId && b.OccupancyValue == 1).Select(a => a.Cost).FirstOrDefault();

                                ExtraPeopleCost = lptsViewModel.LohanaPackageTariffSearch.AdultCount * singlePeopleCost;

                            }


                            //lptsViewModel.LohanaPackageTariffSearch.AdultCount = OccupancyValueCount;

                        }

                 //   }

                    decimal PackageCost = cost + Extracost + ExtraPeopleCost + ExtraChildCost;

                    if (PackageCost != 0)
                    {


                        LohanaPackageTariffSearchInfo info = new LohanaPackageTariffSearchInfo();

                        // info.SupplierName = Suppliername;

                        info.PackageTypeName = PackageTypeName;

                        info.PackageName = PackageName;

                        info.Cost = PackageCost;

                        info.LohanaPackageTariffId = LohanaPackageTariffId;

                        info.CountryId = CountryId;

                        info.StateId = StateId;

                        info.CityId = CityId;

                        info.PackageTypeId = PackageTypeId;

                        info.OccupancyId = OccupancyId;

                        info.OccupancyName = OccupanyName;

                        info.RoomTypeId = RoomTypeId;

                        info.CountryName = CountryName;

                        info.StateName = StateName;

                        info.CityName = CityName;

                        info.DayDuration = DayDuration;

                        info.NightDuration = NightDuration;

                        info.LPTDuration = LPTDuration;

                        lptsViewModel.LohanaPackageTariffSearchRoomList.Add(info);

                    }

                    lptsViewModel.LohanaPackageTariffSearch.AdultCount = TotalAdultCount;

                    PackageCost = 0; cost = 0; Extracost = 0; ExtraPeopleCost = 0; ExtraChildCost = 0;


                }

                Logger.Debug("LohanaPackageTariffSearch Controller GetLohanaPackageTariffSearch");
            }
            catch (Exception ex)
            {
                lptsViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("LohanaPackageTariffSearch Controller - GetLohanaPackageTariffSearch" + ex.ToString());
            }

            TempData["lptsViewModel"] = lptsViewModel;

            return PartialView("_LohanaPackageTariffSearchDetails", lptsViewModel);
        }

        public PartialViewResult ViewLohanaPackageTariffItienarySearchDetails(int LohanaPackageTariffId)
        {
            LohanaPackageTariffSearchViewModel lptsViewModel = new LohanaPackageTariffSearchViewModel();

            lptsViewModel.LohanaPackageItienaryList = _lptsRepo.GetLohanaPackageTariffItienarySearchDetails(LohanaPackageTariffId);


            return PartialView("_LohanaPackageItienary", lptsViewModel);
        }


        public JsonResult LPTAddToCart(QuotationViewModel qViewModel)
        {
            QuotationViewModel qsViewModel = new QuotationViewModel();

            JavaScriptSerializer json_serializer = new JavaScriptSerializer();

            try
            {
                if (Request.Cookies["Bookings"].Value != null)
                {
                    if (Request.Cookies["Bookings"].Value != "")
                    {
                        qsViewModel.Quotation.QuatationItem = json_serializer.Deserialize<List<BookingCartDetailsInfo>>(Request.Cookies["Bookings"].Value);

                        string PackageName = qViewModel.Quotation.QuatationItem.Select(x => x.PackageName).FirstOrDefault();

                        if (!qsViewModel.Quotation.QuatationItem.Where(x => x.PackageName == PackageName).Any())
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

                Logger.Error("LohanaPackageTariffSearch Controller - LPTAddToCart" + ex.ToString());

                Request.Cookies["Bookings"].Value = null;
            }

            return Json(qsViewModel, JsonRequestBehavior.AllowGet);
        }

    }
}