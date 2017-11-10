using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaBusinessEntities.SupplierSearch
{
    public class SupplierSearchInfo
    {
        public int CityId { get; set; }

        public string CityName { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public int AdultCount { get; set; }

        public int ChildCount { get; set; }

        public string PackageName { get; set; }

        public string SupplierName { get; set; }

        public Decimal PackageCost { get; set; }      

        public int SupplierHotelId { get; set; }

        public int OccupancyValue { get; set; }

        public string OccupancyName { get; set; }

        public decimal ChildAge { get; set; }
     
        public string MonthName { get; set; }

        public int OccupancyCapacity { get; set; }

        public int NoOfNights { get; set; }

        public int NoOfDays { get; set; }

        public int OccupancyType { get; set; }

        public int CountryId { get; set; }

        public int StateId { get; set; }

        public int HotelId { get; set; }

        public string HotelName { get; set; }

        public int VehicleId { get; set; }

        public string VehicleName { get; set; }

        public int Meal { get; set; }

        public string MealName { get; set; }

        public int SightSeeingId { get; set; }

        public string SightSeeingName { get; set; }

        public int SupplierHotelDayId { get; set; }

        public string Title { get; set; }

        public string Duration { get; set; }

        public decimal Cost { get; set; }

        public int EnquiryitemId { get; set; }

        public int Quantity { get; set; }
    }

    public class SupplierSearchFilter
    {
        // Search Filter start
        public int CityId { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        //City Dropdown

        public int CountryId { get; set; }

        public string Country { get; set; }

        public int StateId { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string PackageName { get; set; }

        public string SupplierName { get; set; }

        public Decimal PackageCost { get; set; }

        //Search Filter End
    }
}
