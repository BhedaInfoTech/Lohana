using LohanaBusinessEntities.Charges;
using LohanaBusinessEntities.City;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.CustomerCategory;
using LohanaBusinessEntities.Hotel;
using LohanaBusinessEntities.Meal;
using LohanaBusinessEntities.RoomType;
using LohanaBusinessEntities.SupplierHotelTariff;
using LohanaBusinessEntities.TaxFormula;
using LohanaBusinessEntities.Vendor;
using System.Collections.Generic;

namespace Lohana.Models.Tariff.SupplierHotelTariff
{
    public class SupplierHotelTariffViewModel
    {
        public SupplierHotelTariffViewModel()
        {
            SupplierHotelTariff = new SupplierHotelTariffInfo();

            SupplierHotelDetail = new SupplierHotelDetailInfo();

            SupplierOccupancyDetail = new SupplierOccupancyDetailInfo();

            SupplierHotelCustomerCategory = new SupplierHotelCustomerCategoryInfo();

            SupplierHotelCustomerCategories = new List<SupplierHotelCustomerCategoryInfo>();

            LstVendor = new List<VendorInfo>();

            LstCities = new List<CityInfo>();

            LstRoomTypes = new List<RoomTypeInfo>();

            LstMeals = new List<MealInfo>();

            LstHotel = new List<HotelInfo>();

            FriendlyMessage = new List<FriendlyMessage>();

            SupplierHotelTariffDuration = new SupplierHotelTariffDurationInfo();

            SupplierHotelTariffDurations = new List<SupplierHotelTariffDurationInfo>();

            LstStandardCharges = new List<ChargesInfo>();

            LstSupplierHotelPriceDetail = new List<SupplierHotelPriceDetailInfo>();

            LstSupplierHotelPrice = new List<SupplierHotelPriceInfo>();

            CustomerCategories = new List<CustomerCategoryInfo>();

			LstStandardCharges = new List<ChargesInfo>();

			LstTaxFormula = new List<TaxFormulaInfo>();

			LstTaxFormulaCharges = new List<TaxFormulaChargesInfo>();

			SupplierHotelPrice = new SupplierHotelPriceInfo();

            Pager = new PaginationInfo();

            Cities = new List<CityInfo>();

            SupplierHotelTariffDayInfo = new SupplierHotelTariffDayInfo();

            SupplierHotelTariffDays = new List<SupplierHotelTariffDayInfo>();

            SupplierHotelDayItem = new SupplierHotelDayItemInfo();

            SupplierHotelDayItems = new List<SupplierHotelDayItemInfo>();

            
        }

        public SupplierHotelTariffInfo SupplierHotelTariff { get; set; }

        public SupplierHotelDetailInfo SupplierHotelDetail { get; set; }

        public SupplierOccupancyDetailInfo SupplierOccupancyDetail { get; set; }

        public SupplierHotelDurationInfo SupplierHotelDuration { get; set; }

        public SupplierHotelPriceInfo SupplierHotelPrice { get; set; }

        public SupplierHotelPriceDetailInfo SupplierHotelPriceDetail { get; set; }

        public SupplierHotelCustomerCategoryInfo SupplierHotelCustomerCategory { get; set; }

        public List<SupplierHotelCustomerCategoryInfo> SupplierHotelCustomerCategories { get; set; }

        public List<SupplierHotelPriceInfo> LstSupplierHotelPrice { get; set; }       

        public List<SupplierHotelPriceDetailInfo> LstSupplierHotelPriceDetail { get; set; }

        public List<VendorInfo> LstVendor { get; set; }

        public List<CityInfo> LstCities { get; set; }

        public List<HotelInfo> LstHotel { get; set; }

        public List<RoomTypeInfo> LstRoomTypes { get; set; }

        public List<MealInfo> LstMeals { get; set; }

        public List<FriendlyMessage> FriendlyMessage { get; set; }

        public SupplierHotelTariffDurationInfo SupplierHotelTariffDuration { get; set; }

        public List<SupplierHotelTariffDurationInfo> SupplierHotelTariffDurations { get; set; }

        public List<CustomerCategoryInfo> CustomerCategories { get; set; }

		public List<ChargesInfo> LstStandardCharges
		{
			get;
			set;
		}

		public List<TaxFormulaInfo> LstTaxFormula
		{
			get;
			set;
		}

		public List<TaxFormulaChargesInfo> LstTaxFormulaCharges
		{
			get;
			set;
		} 



        public PaginationInfo Pager { get; set; }

        public List<CityInfo> Cities { get; set; }

        public SupplierHotelTariffDayInfo SupplierHotelTariffDayInfo { get; set; }

        public List<SupplierHotelTariffDayInfo> SupplierHotelTariffDays { get; set; }


        public List<SupplierHotelDayItemInfo> SupplierHotelDayItems { get; set; }

        public SupplierHotelDayItemInfo SupplierHotelDayItem { get; set; }

    }
}