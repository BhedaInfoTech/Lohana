using Lohana.Models.Master;
using LohanaRepo.Master;
using System;
using Lohana.Common;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LohanaBusinessEntities.Common;
using System.Web.Mvc;
using LohanaHelper.Logging;
using LohanaBusinessEntities;
using LohanaBusinessEntities.SupplierSearch;
using Lohana.Models.Quotation;
using System.Web.Script.Serialization;
using LohanaBusinessEntities.Quotation;

namespace Lohana.Controllers.PostLogin.Master
{
    public class SupplierSearchController : Controller
    {
        //
        // GET: /SupplierSearch/
        public SupplierSearchRepo _ssRepo;

        public CityRepo _cRepo;



        public SupplierSearchController()
        {
            _ssRepo = new SupplierSearchRepo();

            _cRepo = new CityRepo();
        }

        public ActionResult Index(SupplierSearchViewModel SupplierSearchViewModel)
        {

            return View("Search", SupplierSearchViewModel);
        }

        public PartialViewResult GetSupplierSearch(SupplierSearchViewModel ssViewModel)
        {
            try
            {

                bool IsExtraChild = false;

                decimal cost = 0;

                decimal Extracost = 0;

                //int OccupancyValueCount=0;

                decimal ExtraPeopleCost = 0;

                decimal ExtraChildCost = 0;

                decimal Extra=0;
               
                ssViewModel.SupplierSearch.CheckOutDate = ssViewModel.SupplierSearch.CheckInDate.AddDays(ssViewModel.SupplierSearch.NoOfDays);

                ssViewModel.SupplierSearchRoomList = _ssRepo.GetHotelBasicDetails(ssViewModel.SupplierSearch, IsExtraChild, (int)OccupancyType.Room);

              
                int TotalAdultCount = ssViewModel.SupplierSearch.AdultCount;

                int ChildQuantity = ssViewModel.SupplierSearch.ChildCount;

                foreach (var item in ssViewModel.SupplierSearchRoomList.Select(a => new { a.SupplierHotelId}).Distinct())
                {

                    if (ssViewModel.SupplierSearch.ChildCount != 0)
                    {

                        IsExtraChild = true;

                        ssViewModel.SupplierSearchExtraChildList = _ssRepo.GetHotelBasicDetails(ssViewModel.SupplierSearch, IsExtraChild, (int)OccupancyType.Extra);


                        if (ssViewModel.SupplierSearchExtraChildList.Count > 0)
                        {
                            ExtraChildCost = ssViewModel.SupplierSearch.ChildCount * (ssViewModel.SupplierSearchExtraChildList.Where(a => a.SupplierHotelId == item.SupplierHotelId).Select(a => a.PackageCost).FirstOrDefault());
                            if(ExtraChildCost==0)
                            {
                                decimal singlePeopleCost = ssViewModel.SupplierSearchRoomList.Where(b => b.SupplierHotelId == item.SupplierHotelId && b.OccupancyValue == 1).Select(a => a.PackageCost).FirstOrDefault();

                                ExtraChildCost = ssViewModel.SupplierSearch.ChildCount * singlePeopleCost;
                                
                            }
                        }
                        else
                        {

                            decimal singlePeopleCost = ssViewModel.SupplierSearchRoomList.Where(b => b.SupplierHotelId == item.SupplierHotelId && b.OccupancyValue == 1).Select(a => a.PackageCost).FirstOrDefault();

                            ExtraChildCost = ssViewModel.SupplierSearch.ChildCount * singlePeopleCost;
                                
                        }
                    }



                string Packagename=" ";
                string Suppliername = "";
                int SupplierHotelId = 0;
                int Days = 0;
                int Nights = 0;

                 // OccupancyValueCount = ssViewModel.SupplierSearchRoomList.Where(a => a.SupplierHotelId == item.SupplierHotelId).Select(b => b.OccupancyValue).Sum();

                   //for(int k=0;k<= 1;k++)
                   //  {       
                        //if (OccupancyValueCount >= ssViewModel.SupplierSearch.AdultCount)
                        //{
                            int AdultQuantity = 0;
                            foreach (var i in ssViewModel.SupplierSearchRoomList.Where(a => a.SupplierHotelId == item.SupplierHotelId).OrderByDescending(s => s.OccupancyValue))
                             {                               

                                 if (i.OccupancyValue <= ssViewModel.SupplierSearch.AdultCount)
                                 {
                                if (i.OccupancyValue == ssViewModel.SupplierSearch.AdultCount)
                                {
                                    cost = i.PackageCost * ssViewModel.SupplierSearch.AdultCount;

                                    ssViewModel.SupplierSearch.AdultCount = 0;

                                    if(cost !=0)
                                    {
                                        AdultQuantity++;
                                    }
                                }
                                else
                                {                                                                     
                                    while (ssViewModel.SupplierSearch.AdultCount >= i.OccupancyValue)
                                    {

                                        int remains = ssViewModel.SupplierSearch.AdultCount - i.OccupancyValue;

                                        Extra = i.PackageCost * i.OccupancyValue;

                                        ssViewModel.SupplierSearch.AdultCount = remains;

                                        Extracost += Extra;

                                        if(Extra !=0)
                                        {
                                            AdultQuantity++;
                                        }
                                    }                               
                                }

                              
                            }
                                 Packagename = i.PackageName;

                                 Suppliername = i.SupplierName;

                                 SupplierHotelId = i.SupplierHotelId;

                                 Days = i.NoOfDays;

                                 Nights = i.NoOfNights;
                                
                            }

                            if (ssViewModel.SupplierSearch.AdultCount != 0)
                            {
                                IsExtraChild = false;

                                ssViewModel.SupplierSearchExtraList = _ssRepo.GetHotelBasicDetails(ssViewModel.SupplierSearch, IsExtraChild, (int)OccupancyType.Extra);

                                if (ssViewModel.SupplierSearchExtraList.Count > 0)
                                {
                                    ExtraPeopleCost = ssViewModel.SupplierSearch.AdultCount * (ssViewModel.SupplierSearchExtraList.Where(a => a.SupplierHotelId == item.SupplierHotelId).Select(a => a.PackageCost).FirstOrDefault());
                                }
                                else
                                {
                                decimal singlePeopleCost=ssViewModel.SupplierSearchRoomList.Where(b => b.SupplierHotelId == item.SupplierHotelId && b.OccupancyValue==1).Select(a => a.PackageCost).FirstOrDefault();

                                ExtraPeopleCost=ssViewModel.SupplierSearch.AdultCount* singlePeopleCost;
                                
                                }

                        
                            }
                            
                  

                      decimal PackageCost = cost + Extracost + ExtraPeopleCost + ExtraChildCost;

                      int Quantity = AdultQuantity + ChildQuantity;

                      if (PackageCost != 0)
                      {

                          SupplierSearchInfo info = new SupplierSearchInfo();

                          info.SupplierName = Suppliername;

                          info.PackageName = Packagename;

                          info.PackageCost = PackageCost;

                          info.SupplierHotelId = SupplierHotelId;

                          info.Duration = Days + "D/" + Nights + "N";

                          info.Quantity = Quantity;

                          ssViewModel.SupplierSearchList.Add(info);
                      }

                     ssViewModel.SupplierSearch.AdultCount = TotalAdultCount;

                     ssViewModel.SupplierSearch.ChildCount = ChildQuantity;

                     PackageCost = 0; cost = 0; Extracost = 0; ExtraPeopleCost = 0; ExtraChildCost = 0; AdultQuantity = 0; 
                  
  
                    }

        
                                
                Logger.Debug("HotelSearch Controller GetHotelSearch");
            }
            catch (Exception ex)
            {
                ssViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));

                Logger.Error("HotelSearch Controller - GetHotelSearch" + ex.ToString());
            }

            TempData["ssViewModel"] = ssViewModel;

            return PartialView("_RoomMealOccupancy", ssViewModel);
        }


        public PartialViewResult ViewSupplierHotelDetails(int SupplierHotelId)
        {
            SupplierSearchViewModel ssViewModel = new SupplierSearchViewModel();

            ssViewModel.SupplierHotelList = _ssRepo.GetSupplierHotelDetails(SupplierHotelId);

         
            return PartialView("_GetHotel", ssViewModel);
        }


        public JsonResult SupplierAddToCart(QuotationViewModel qViewModel)
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

                Logger.Error("SupplierSearch Controller - HotelAddToCart" + ex.ToString());

                Request.Cookies["Bookings"].Value = null;
            }

            return Json(qsViewModel, JsonRequestBehavior.AllowGet);
        }


    }
}
