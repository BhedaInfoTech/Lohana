using System;
using System.Collections.Generic;

namespace LohanaBusinessEntities.SupplierHotelTariff
{
    public class SupplierHotelTariffInfo
    {
        public SupplierHotelTariffInfo()
        {
            LstHotelName = new List<HotelNames>();

            supplierHotelTariffDays = new List<SupplierHotelTariffDayInfo>();

            supplierHotelTariffDay = new SupplierHotelTariffDayInfo();
        }

        public int SupplierHotelId { get; set; }

        public int SupplierId { get; set; }

        public string SupplierName { get; set; }

        public string PackageName { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public List<HotelNames> LstHotelName { get; set; }

        public int DayDuration { get; set; }

        public int NightDuration { get; set; }

        public List<SupplierHotelTariffDayInfo> supplierHotelTariffDays { get; set; }

        public SupplierHotelTariffDayInfo supplierHotelTariffDay { get; set; }
    }

    public class SupplierHotelTariffDurationInfo
    {
        public int SupplierHotelDurationId  
        {
            get;
            set;
        }

        public int SupplierHotelPriceId
        {
            get;
            set;
        }

        public int OccupancyDetailId
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

        //public DateTime TariffDate
        //{
        //    get;
        //    set;
        //}

        //public decimal NetRate
        //{
        //    get;
        //    set;
        //}

        
 }

    public class SupplierHotelDetailInfo
    {
        public SupplierHotelDetailInfo()
        {

        }

        public int SupplierHoteDetaillId { get; set; }

        public int SupplierHotelId { get; set; }

        public int CityId { get; set; }

        public int HotelId { get; set; }

        public int RoomTypeId { get; set; }

        public int MealId { get; set; }

        public int TotalNights { get; set; }

        public string MealInclusions { get; set; }      

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }
    }

    public class SupplierHotelDurationInfo
    {
        public SupplierHotelDurationInfo()
        {

        }

        public int SupplierHotelDurationId { get; set; }

        public int OccupancyDetailId { get; set; }

        public int SupplierHotelPriceId
        {
            get;
            set;
        }

        public int SupplierHotelTariffId
        {
            get;
            set;
        }

        public string Days { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string OperationalDays
        {
            get;
            set;
        }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }
    }

    public class SupplierHotelDurationDayInfo
    {
        public SupplierHotelDurationDayInfo()
        {

        }

        public int SupplierHotelDurationId { get; set; }

        public int Day { get; set; }

        public decimal AdultPrice { get; set; }

        public decimal ChildPrice { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }
    }

    public class SupplierHotelPriceInfo
    {
        public SupplierHotelPriceInfo()
        {
            SupplierHotelPriceDetails = new List<SupplierHotelPriceDetailInfo>();
        }

        public int SupplierHotelPriceId { get; set; }

        public int OccupancyDetailId
		{
			get;
			set;
		}

        public decimal PublishPrice { get; set; }

        public decimal SpecialPrice { get; set; }

        public decimal CommissionPrice { get; set; }

        public int FormulaId { get; set; }

        public decimal TotalTaxPrice { get; set; }

        public decimal NetRate { get; set; }

		public bool IsChildPrice
		{
			get;
			set;
		}

		public string Color
		{
			get;
			set;
		}

        public int AgeFrom { get; set; }

        public int AgeTo { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }

		public List<SupplierHotelPriceDetailInfo> SupplierHotelPriceDetails
		{
			get;
			set;
		}
    }

    public class SupplierHotelPriceDetailInfo
    {
        public SupplierHotelPriceDetailInfo()
        {

        }

        public int SupplierHotelPriceId { get; set; }

        public int TaxFormualId { get; set; }

        public int ChargesId { get; set; }

        public decimal Percentage { get; set; }

        public decimal CalculatedPrice { get; set; }
    }


    public class SupplierOccupancyDetailInfo
    {
        public SupplierOccupancyDetailInfo()
        {
       
        }
        public int OccupancyDetailId { get; set; }

        public int SupplierHotelId { get; set; }

        public int OccupancyId { get; set; }

        public decimal AgeFrom  { get; set; }
        
        public decimal AgeTo { get; set; }
        
        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }

    }

    public class HotelNames
    {
        public string HotelName { get; set; }  
    }

    public class SupplierHotelCustomerCategoryInfo
    {
        public int SupplierHotelCustomerCategoryId { get; set; }

        public int OccupancyDetailId { get; set; }

        public int SupplierHotelPriceId { get; set; }

        public int SupplierHotelDurationId { get; set; }

        public int CustomerCategoryId { get; set; }

        public string CustomerCategoryName { get; set; }

        public decimal Margin { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }

    }

    public class SupplierHotelTariffDayInfo
    {
        public SupplierHotelTariffDayInfo()
        {
            supplierHotelDayItems = new List<SupplierHotelDayItemInfo>();

            supplierHotelDayItem = new SupplierHotelDayItemInfo();
        }

        public int SupplierHotelDayId { get; set; }

        public int SupplierHotelId { get; set; }

        public int CityId { get; set; }

        public string Title { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }

        public List<SupplierHotelDayItemInfo> supplierHotelDayItems = new List<SupplierHotelDayItemInfo>();

        public SupplierHotelDayItemInfo supplierHotelDayItem = new SupplierHotelDayItemInfo();

    }

    public class SupplierHotelDayItemInfo
    {
        public int SupplierHotelDayItemId { get; set; }

        public int SupplierHotelDayId { get; set; }

        public int RefType { get; set; }

        public int HotelId { get; set; }

        public int RoomTypeId { get; set; }

        public int SightSeeingId { get; set; }

        public int VehicleId { get; set; }

        public int MealId { get; set; }

        public string HotelName { get; set; }

        public string SightSeeingName { get; set; }

        public string VehicleName { get; set; }

        public string MealName { get; set; }

        public string RoomTypeName { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int UpdatedBy { get; set; }

    }

}
