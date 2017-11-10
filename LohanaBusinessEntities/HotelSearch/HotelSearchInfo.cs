using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaBusinessEntities.HotelSearch
{
    public class HotelSearchInfo
    {

        public List<HotelSearchRoomMealOccupancyPrice> HotelSearchRoomMealOccupancyPriceList { get; set; }

        public HotelSearchInfo()
        {
            HotelSearchRoomMealOccupancyPriceList = new List<HotelSearchRoomMealOccupancyPrice>();
        }

        public int HotelId { get; set; }

        public string HotelName { get; set; }

        public int CountryId { get; set; }

        public int StateId { get; set; }

        public int CityId { get; set; }

        public string HotelDescription { get; set; }

        public int StarCategory { get; set; }

        public string StarCategoryStr { get; set; }

        public int HotelType { get; set; }

        public string HotelTypeName { get; set; }

        public string CityName { get; set; }

        public int RoomTypeId { get; set; }

        public int OccupancyId { get; set; }

        public DateTime CheckinDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        public int AdultCount { get; set; }

        public int ChildCount { get; set; }

        public decimal HotelRoomPrice { get; set; }

		public string RoomTypeName
		{
			get;
			set;
		}

		public string MealName
		{
			get;
			set;
		}

        public int OccupancyCapacity
        {
            get;
            set;
        }

        public int NoOfRooms
        {
            get;
            set;
        }

        public int OccupancyValue
        {
            get;
            set;
        }

        public string OccupancyName
        {
            get;
            set;
        }

        public bool IsExtraChild
        {
            get;
            set;
        }

        public bool IsQuotationHotel
        {
            get;
            set;
        }


        public int EnquiryItemId { get; set; }

        public int NoOfNight { get; set; }

        public int VendorId { get; set; }

        public decimal NetRatePerNight { get; set; }

        public decimal NetRate { get; set; }

        public DateTime CheckInTime { get; set; }

        public DateTime CheckOutTime { get; set; } 

    }

    public class HotelSearchRoomMealOccupancyPrice
    {
        public int RoomTypeId { get; set; }

        public string RoomTypeName { get; set; }

        public int MealId { get; set; }

        public string MealName { get; set; }

        public int OccupancyId { get; set; }

        public string OccupancyName { get; set; }

        public string MealType { get; set; }

        public int HotelId { get; set; }

        public string HotelName { get; set; }

        public int VendorId { get; set; }

        public string VendorName { get; set; }

        public int NetRatePerNight { get; set; }

        public int HotelTariffRoomDetailsId { get; set; }

        public int HotelTariffPriceDetailsId { get; set; }

        public int NoOfNight { get; set; }

        public int HotelTariffId { get; set; }

        public int TotalRate { get; set; }

        public decimal NetRate { get; set; }

    }

    public class HotelSearchFilter
    {
        // Search Filter start
        public int HotelId { get; set; }

        public string HotelName { get; set; }

        public int CityId { get; set; }

        public int StarCategoryId { get; set; }

        public int RoomTypeId { get; set; }

        public int OccupancyId { get; set; }

        public DateTime CheckInDate { get; set; }

        public DateTime CheckOutDate { get; set; }

        //City Dropdown

        public int CountryId { get; set; }

        public string Country { get; set; }

        public int StateId { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string RoomTypeName { get; set; }

        //Search Filter End
    }
}
