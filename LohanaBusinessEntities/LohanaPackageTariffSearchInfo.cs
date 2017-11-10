using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaBusinessEntities.LohanaPackageTariffSearch
{
    public class LohanaPackageTariffSearchInfo
    {

        public string PackageName { get; set; }

        public int PackageTypeId { get; set; }

        public string PackageTypeName { get; set; }

        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public int StateId { get; set; }

        public string StateName { get; set; }

        public int CityId { get; set; }

        public string CityName { get; set; }

        public int DayDuration { get; set; }

        public int NightDuration { get; set; }

        public string LPTDuration { get; set; }

       // public int Cost { get; set; }

        public int AdultCount { get; set; }

        public int ChildCount { get; set; }

        public int RoomTypeId { get; set; }

        public string RoomTypeName { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public int LohanaPackageTariffHotelId { get; set; }

        public decimal Cost { get; set; }

        public int LohanaPackageTariffId { get; set; }

        public int OccupancyId { get; set; }

        public string OccupancyName { get; set; }

        public int OccupancyValue { get; set; }

        public int EnquiryitemId { get; set; }


        // Itienary Data

        public int HotelId { get; set; }

        public string HotelName { get; set; }

        public int VehicleId { get; set; }

        public string VehicleName { get; set; }

        public int Meal { get; set; }

        public string MealName { get; set; }

        public int SightSeeingId { get; set; }

        public string SightSeeingName { get; set; }

        public int LohanaPackageTariffRootId { get; set; }

        public string Title { get; set; }

        public string Duration { get; set; }

        //public decimal Cost { get; set; }


    }

    public class LohanaPackageTariffSearchSearchFilter
    {
     
        public int CountryId { get; set; }

        public string Country { get; set; }

        public int StateId { get; set; }

        public string State { get; set; }

        public int CityId { get; set; }

        public string City { get; set; }

        public int PackageTypeId { get; set; }

        public int AdultCount { get; set; }

        public int ChildCount { get; set; }

        public DateTime CheckInDate { get; set; }

        public int NoOfDays { get; set; }

        public int NoOfNights { get; set; }

        public int RoomTypeId { get; set; }

        public DateTime CheckOutDate { get; set; }

    }
}
