using LohanaBusinessEntities.City;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Hotel;
using LohanaBusinessEntities.LohanaPackageTariff;
using LohanaBusinessEntities.Meal;
using LohanaBusinessEntities.RoomType;
using LohanaBusinessEntities.Vehicle;
using LohanaBusinessEntities.Vendor;
using LohanaBusinessEntities.PackageType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lohana.Models.Tariff.LohanaPackageTariff
{
    public class LohanaPackageTariffViewModel
    {
        public LohanaPackageTariffViewModel()
        {
            LohanaPackageTariff = new LohanaPackageTariffInfo();

            LohanaPackageTariffs = new List<LohanaPackageTariffInfo>();

            LohanaPackageTariffHotel = new LohanaPackageTariffHotelInfo();

            LohanaPackageTariffHotels = new List<LohanaPackageTariffHotelInfo>();

            LohanaPackageTariffVehicle = new LohanaPackageTariffVehicleInfo();

            LohanaPackageTariffVehicles=new List<LohanaPackageTariffVehicleInfo>();

            LohanaPackageTariffRoot = new LohanaPackageTariffRootInfo();

            LohanaPackageTariffRoots = new List<LohanaPackageTariffRootInfo>();

            LohanaPackageTariffSightSeeing = new LohanaPackageTariffSightSeeingInfo();

            Cities = new List<CityInfo>();

            RoomTypes = new List<RoomTypeInfo>();

            Meals = new List<MealInfo>();

            Hotels = new List<HotelInfo>();

            Vendors = new List<VendorInfo>();

            Vehicles=new List<VehicleInfo>();

            PackageTypes = new List<PackageTypeInfo>();

            Pager = new PaginationInfo();

            FriendlyMessage = new List<FriendlyMessage>();
        }

        public LohanaPackageTariffInfo LohanaPackageTariff { get; set; }

        public List<LohanaPackageTariffInfo> LohanaPackageTariffs { get; set; }

        public LohanaPackageTariffHotelInfo LohanaPackageTariffHotel { get; set; }

        public List<LohanaPackageTariffHotelInfo> LohanaPackageTariffHotels { get; set; }

        public LohanaPackageTariffVehicleInfo LohanaPackageTariffVehicle { get; set; }

        public List<LohanaPackageTariffVehicleInfo> LohanaPackageTariffVehicles { get; set; }

        public LohanaPackageTariffRootInfo LohanaPackageTariffRoot { get; set; }

        public List<LohanaPackageTariffRootInfo> LohanaPackageTariffRoots { get; set; }

        public LohanaPackageTariffSightSeeingInfo LohanaPackageTariffSightSeeing { get; set; }

        public List<CityInfo> Cities { get; set; }

        public List<HotelInfo> Hotels { get; set; }

        public List<MealInfo> Meals { get; set; }

        public List<RoomTypeInfo> RoomTypes { get; set; }

        public List<VendorInfo> Vendors { get; set; }

        public List<VehicleInfo> Vehicles { get; set; }

        public List<PackageTypeInfo> PackageTypes { get; set; }

        public PaginationInfo Pager { get; set; }

        public List<FriendlyMessage> FriendlyMessage { get; set; }
    }
}