using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LohanaBusinessEntities.HotelTariff
{
	public class HotelTariffInfo
	{
		public int HotelTariffId
		{
			get;
			set;
		}

		public int VendorId
		{
			get;
			set;
		}

		public int HotelId
		{
			get;
			set;
		}
        public string VendorName
        {
            get;
            set;
        }

        public string HotelName
        {
            get;
            set;
        }

		public int CityId
		{
			get;
			set;
		}

		public string CityName
		{
			get;
			set;
		}

		public DateTime CreatedDate
		{
			get;
			set;
		}

		public int CreatedBy
		{
			get;
			set;
		}

		public DateTime UpdatedDate
		{
			get;
			set;
		}

		public int UpdatedBy
		{
			get;
			set;
		}

	}

	public class HotelTariffDateDetailsInfo
	{
        public int HotelTariffDatesDetailsId
        {
            get;
            set;
        }

        public int HotelTariffCustomerCategoryId
        {
            get;
            set;
        }

		public int HotelTariffPriceDetailsId
		{
			get;
			set;
		}

        public int HotelTariffRoomOccupancyId
		{
			get;
			set;
		}

		public int NoOfNight
		{
			get;
			set;
		}

		public DateTime TariffDate
		{
			get;
			set;
		}

		public decimal NetRate
		{
			get;
			set;
		}

		public decimal NetRatePerNight
		{
			get;
			set;
		}


	}

	public class HotelTariffDurationDetailsInfo
	{
		public int HotelTariffDurationDetailsId
		{
			get;
			set;
		}

		public int HotelTariffPriceDetailsId
		{
			get;
			set;
		}

        public int HotelTariffRoomOccupancyId
		{
			get;
			set;
		}

		public int HotelTariffId
		{
			get;
			set;
		}

		public int NoOfNight
		{
			get;
			set;
		}

		public DateTime FromDate
		{
			get;
			set;
		}

		public DateTime ToDate
		{
			get;
			set;
		}

		public string OperationalDays
		{
			get;
			set;
		}

		public DateTime CreatedDate
		{
			get;
			set;
		}

		public int CreatedBy
		{
			get;
			set;
		}

		public DateTime UpdatedDate
		{
			get;
			set;
		}

		public int UpdatedBy
		{
			get;
			set;
		}

	}

	public class HotelTariffPriceDetailsInfo
	{
        public HotelTariffPriceDetailsInfo()
        {
            HotelTariffCharges = new List<HotelTariffChargesDetailsInfo>();

        }
        public List<HotelTariffChargesDetailsInfo> HotelTariffCharges 
        {
            get; set;
        }
       
		public int HotelTariffPriceDetailsId
		{
			get;
			set;
		}

        public int HotelTariffRoomOccupancyId
		{
			get;
			set;
		}

		public int HotelTariffDurationDetailsId
		{
			get;
			set;
		}

		public int HotelTariffId
		{
			get;
			set;
		}

		public decimal PublishPrice
		{
			get;
			set;
		}

		public decimal SpecialPrice
		{
			get;
			set;
		}

		public decimal CommissionPrice
		{
			get;
			set;
		}

		public int FormulaId
		{
			get;
			set;
		}

		public decimal TotalTaxPrice
		{
			get;
			set;
		}

		public decimal NetRate
		{
			get;
			set;
		}

		public decimal NetRatePerNight
		{
			get;
			set;
		}
        public int NoOfNight
        {
            get;
            set;
        }

		public string Color
		{
			get;
			set;
		}

		public DateTime CreatedDate
		{
			get;
			set;
		}

		public int CreatedBy
		{
			get;
			set;
		}

		public DateTime UpdatedDate
		{
			get;
			set;
		}

		public int UpdatedBy
		{
			get;
			set;
		}

	}

	public class HotelTariffRoomDetailsInfo
	{
		public int HotelTariffRoomDetailsId
		{
			get;
			set;
		}

		public int HotelTariffDurationDetailsId
		{
			get;
			set;
		}

		public int HotelTariffId
		{
			get;
			set;
		}

		public int RoomRateTypeId
		{
			get;
			set;
		}



		public int RoomTypeId
		{
			get;
			set;
		}

		public int OccupancyId
		{
			get;
			set;
		}

		public decimal AgeFrom
		{
			get;
			set;
		}

		public decimal AgeTo
		{
			get;
			set;
		}

		public int MealId
		{
			get;
			set;
		}

		public string MealInclusion
		{
			get;
			set;
		}

		public string RoomInclusion
		{
			get;
			set;
		}

		public string RoomExclusion
		{
			get;
			set;
		}

		public DateTime CreatedDate
		{
			get;
			set;
		}

		public int CreatedBy
		{
			get;
			set;
		}

		public DateTime UpdatedDate
		{
			get;
			set;
		}

		public int UpdatedBy
		{
			get;
			set;
		}

		public DateTime CheckInTime
		{
			get;
			set;
		}

		public DateTime CheckOutTime
		{
			get;
			set;
		}

		public int NoOfNight
		{
			get;
			set;
		}

	}

    public class HotelTariffRoomOccupancyInfo
    {
        public int HotelTariffRoomOccupancyId
        {
            get;
            set;
        }

        public int HotelTariffRoomDetailsId
        {
            get;
            set;
        }

        public int HotelTariffDurationDetailsId
        {
            get;
            set;
        }

        public int HotelTariffId
        {
            get;
            set;
        }         

        public int OccupancyId
        {
            get;
            set;
        }

        public decimal AgeFrom
        {
            get;
            set;
        }

        public decimal AgeTo
        {
            get;
            set;
        }

        public int MealId
        {
            get;
            set;
        }

        public string MealInclusion
        {
            get;
            set;
        }

        public string RoomInclusion
        {
            get;
            set;
        }

        public string RoomExclusion
        {
            get;
            set;
        }

        public DateTime CreatedDate
        {
            get;
            set;
        }

        public int CreatedBy
        {
            get;
            set;
        }

        public DateTime UpdatedDate
        {
            get;
            set;
        }

        public int UpdatedBy
        {
            get;
            set;
        } 

    }

    public class HotelTariffChargesDetailsInfo
    {
        public int HotelTariffChargesDetailsId
        {
            get;
            set;
        }
        public int HotelTariffPriceDetailsId
        {
            get;
            set;
        }
        public int ChargesId
        {
            get;
            set;
        }

        public decimal Percentage
        {
            get;
            set;
        }

        public decimal CalculatedPrice
        {
            get;
            set;
        }
        public decimal TotalTaxPrice
        {
            get;
            set;
        }

        public string HotelTariffCalOn { get; set;}
        
    }

    public class HotelTariffCustomerCategoryDetailsInfo
    {
        public int HotelTariffDateDetailsId
		{
			get;
			set;
		}

        public int HotelTariffRoomOccupancyId
        {
            get;
            set;
        }

        public int CustomerCategoryId { get; set; }

        public string CustomerCategoryName { get; set; }

        public decimal TariffMargin { get; set; }

		public decimal GlobalMargin
		{
			get;
			set;
		}

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }

    }
   
}
