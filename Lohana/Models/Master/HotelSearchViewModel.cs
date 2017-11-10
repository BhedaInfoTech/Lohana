using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using LohanaBusinessEntities;
using LohanaBusinessEntities.Hotel;
using LohanaBusinessEntities.City;
using LohanaBusinessEntities.State;
using LohanaBusinessEntities.Country;
using LohanaBusinessEntities.RoomType;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.HotelTariff;
using LohanaBusinessEntities.Occupancy;
using LohanaBusinessEntities.HotelSearch;
using LohanaBusinessEntities.Enquiry;



namespace Lohana.Models.Master
{
    public class HotelSearchViewModel
    {
        public HotelSearchViewModel()
        {
            FriendlyMessage = new List<FriendlyMessage>();

            HotelSearch = new HotelSearchInfo();

            HotelSearchList = new List<HotelSearchInfo>();

            HotelSearchExtraList = new List<HotelSearchInfo>();

            HotelSearchRoomList = new List<HotelSearchInfo>();

            HotelSearchRoomMealOccupancyPrice = new HotelSearchRoomMealOccupancyPrice();

            HotelSearchRoomMealOccupancyPriceList = new List<HotelSearchRoomMealOccupancyPrice>();

            HotelSearchFilter = new HotelSearchFilter();

            HotelSearchFilterList = new List<HotelSearchFilter>();

            HotelTariff = new HotelTariffInfo();

            HotelTariffs = new List<HotelTariffInfo>();

            Hotels = new List<HotelInfo>();

            RoomTypes = new List<RoomTypeInfo>();

            Occupancies = new List<OccupancyInfo>();

            Cities = new List<CityInfo>();

            Pager = new PaginationInfo();

        }

         public List<FriendlyMessage> FriendlyMessage { get; set; }

         public HotelSearchInfo HotelSearch { get; set; }

         public List<HotelSearchInfo> HotelSearchList { get; set; }

         public List<HotelSearchInfo> HotelSearchExtraList { get; set; }

         public List<HotelSearchInfo> HotelSearchRoomList { get; set; }

         public HotelSearchRoomMealOccupancyPrice HotelSearchRoomMealOccupancyPrice { get; set; }

         public List<HotelSearchRoomMealOccupancyPrice> HotelSearchRoomMealOccupancyPriceList { get; set; }

         public HotelSearchFilter HotelSearchFilter { get; set; }

         public List<HotelSearchFilter> HotelSearchFilterList { get; set; } 

         public HotelTariffInfo HotelTariff { get; set; }

         public List<HotelTariffInfo> HotelTariffs { get; set; }

         public HotelInfo Hotel { get; set; }

         public List<HotelInfo> Hotels { get; set; }

         public RoomTypeInfo RoomType { get; set; }

         public List<RoomTypeInfo> RoomTypes { get; set; }

         public List<OccupancyInfo> Occupancies { get; set; }

         public List<CityInfo> Cities { get; set; }

         public CityInfo City { get; set; } 

         public PaginationInfo Pager { get; set; }

         public HotelTariffDateDetailsInfo HotelTariffDate { get; set; }

         public List<HotelTariffDateDetailsInfo> HotelTariffDates { get; set; }

         public HotelTariffDurationDetailsInfo HotelTariffDuration { get; set; }

         public List<HotelTariffDurationDetailsInfo> HotelTariffDurations { get; set; }

         public HotelTariffPriceDetailsInfo HotelTariffPrice { get; set; }

         public List<HotelTariffPriceDetailsInfo> HotelTariffPrices { get; set; }

         public HotelTariffRoomDetailsInfo HotelTariffRoom { get; set; }

         public List<HotelTariffRoomDetailsInfo> HotelTariffRooms { get; set; }

         public EnquiryInfo Enquiry { get; set; }

         public bool IsHotel { get; set; }



    }
}