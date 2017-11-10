using LohanaBusinessEntities.City;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Hotel;
using LohanaBusinessEntities.LohanaPackageTariff;
using LohanaBusinessEntities.Meal;
using LohanaBusinessEntities.RoomType;
using LohanaBusinessEntities.Vehicle;
using LohanaBusinessEntities.Vendor;
using LohanaBusinessEntities.PackageType;
using LohanaBusinessEntities.SightSeeingTariff;
using LohanaBusinessEntities.Tariff.VehicleTariff;
using LohanaBusinessEntities.SightSeeing;
using LohanaBusinessEntities.HotelTariff;
using LohanaBusinessEntities.LohanaPackageTariffSearch;
using LohanaBusinessEntities.Enquiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lohana.Models.Tariff
{
    public class LohanaPackageTariffSearchViewModel
    {

        public LohanaPackageTariffSearchViewModel()
        {

            FriendlyMessage = new List<FriendlyMessage>();

            LohanaPackageTariffSearch = new LohanaPackageTariffSearchInfo();

            LohanaPackageTariffSearchList = new List<LohanaPackageTariffSearchInfo>();

            LohanaPackageTariffRoot = new LohanaPackageTariffRootInfo();

            LohanaPackageTariffRootList = new List<LohanaPackageTariffRootInfo>();

            LohanaPackageTariff = new LohanaPackageTariffInfo();

            LohanaPackageTariffList = new List<LohanaPackageTariffInfo>();

            HotelTariff = new HotelTariffInfo();

            HotelTariffs = new List<HotelTariffInfo>();

            PackageType = new PackageTypeInfo();

            PackageTypes = new List<PackageTypeInfo>();

            Hotel = new HotelInfo();

            Hotels = new List<HotelInfo>();

            RoomType = new RoomTypeInfo();

            Cities = new List<CityInfo>();

            City = new CityInfo();

            Pager = new PaginationInfo();

            HotelTariffDate = new HotelTariffDateDetailsInfo();

            HotelTariffDates = new List<HotelTariffDateDetailsInfo>();

            HotelTariffDuration = new HotelTariffDurationDetailsInfo();

            HotelTariffDurations = new List<HotelTariffDurationDetailsInfo>();

            HotelTariffPrice = new HotelTariffPriceDetailsInfo();

            HotelTariffPrices = new List<HotelTariffPriceDetailsInfo>();

            HotelTariffRoom = new HotelTariffRoomDetailsInfo();

            HotelTariffRooms = new List<HotelTariffRoomDetailsInfo>();


            LohanaPackageTariffSearchRoomList = new List<LohanaPackageTariffSearchInfo>();

            LohanaPackageTariffSearchExtraChildList = new List<LohanaPackageTariffSearchInfo>();

            LohanaPackageTariffSearchExtraList = new List<LohanaPackageTariffSearchInfo>();

            LohanaPackageTariffSearchFilter = new LohanaPackageTariffSearchInfo();

            LohanaPackageTariffSearchFilterList = new List<LohanaPackageTariffSearchInfo>();


            LohanaPackageItienaryList = new List<LohanaPackageTariffSearchInfo>();


            Enquiry = new EnquiryInfo();

        }

        public List<FriendlyMessage> FriendlyMessage { get; set; }

        public LohanaPackageTariffSearchInfo LohanaPackageTariffSearch { get; set; }

        public List<LohanaPackageTariffSearchInfo> LohanaPackageTariffSearchList { get; set; }

        public LohanaPackageTariffRootInfo LohanaPackageTariffRoot { get; set; }

        public List<LohanaPackageTariffRootInfo> LohanaPackageTariffRootList { get; set; }

        public LohanaPackageTariffInfo LohanaPackageTariff { get; set; }

        public List<LohanaPackageTariffInfo> LohanaPackageTariffList { get; set; }



        public LohanaPackageTariffSearchInfo LohanaPackageTariffSearchFilter { get; set; }

        public List<LohanaPackageTariffSearchInfo> LohanaPackageTariffSearchFilterList { get; set; }

        public List<LohanaPackageTariffSearchInfo> LohanaPackageTariffSearchRoomList { get; set; }

        public List<LohanaPackageTariffSearchInfo> LohanaPackageTariffSearchExtraChildList { get; set; }

        public List<LohanaPackageTariffSearchInfo> LohanaPackageTariffSearchExtraList { get; set; }


        public List<LohanaPackageTariffSearchInfo> LohanaPackageItienaryList { get; set; }


        public HotelTariffInfo HotelTariff { get; set; }

        public List<HotelTariffInfo> HotelTariffs { get; set; }

        public HotelInfo Hotel { get; set; }

        public List<HotelInfo> Hotels { get; set; }

        public RoomTypeInfo RoomType { get; set; }

        public List<RoomTypeInfo> RoomTypes { get; set; }

        public PackageTypeInfo PackageType { get; set; }

        public List<PackageTypeInfo> PackageTypes { get; set; }
   
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

        public bool IsPackage { get; set; }

        public EnquiryInfo Enquiry { get; set; }

    }
}