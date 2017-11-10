using LohanaBusinessEntities.Charges;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.CustomerCategory;
using LohanaBusinessEntities.Hotel;
using LohanaBusinessEntities.HotelTariff;
using LohanaBusinessEntities.Meal;
using LohanaBusinessEntities.Occupancy;
using LohanaBusinessEntities.RoomType;
using LohanaBusinessEntities.TaxFormula;
using LohanaBusinessEntities.Vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


namespace Lohana.Models.Tariff.HotelTariff
{
    public class HotelTariffViewModel
    {
     public HotelTariffViewModel()
        {
            HotelTariff = new HotelTariffInfo();

            HotelTariffs = new List<HotelTariffInfo>();

            Vendors = new List<VendorInfo>();

            Hotels = new List<HotelInfo>();

            RoomTypes = new List<RoomTypeInfo>();

            Meals = new List<MealInfo>();

            Occupancies = new List<OccupancyInfo>();

            Filter = new HotelTariffFilter();

            Pager = new PaginationInfo();

            FriendlyMessage = new List<FriendlyMessage>();

         //for date details

            HotelTariffDate =new HotelTariffDateDetailsInfo();

            HotelTariffDates=new List<HotelTariffDateDetailsInfo>();  
     
         //for duration
            HotelTariffDuration=new HotelTariffDurationDetailsInfo();

            HotelTariffDurations=new List<HotelTariffDurationDetailsInfo>();

            HotelTariffDurationFilter=new HotelTariffDurationFilter();

         //for price
           HotelTariffPrice=new HotelTariffPriceDetailsInfo();

           HotelTariffPrices=new List<HotelTariffPriceDetailsInfo>();

           HotelTariffPriceFilter=new HotelTariffPriceFilter();


         //for room
           HotelTariffRoom = new HotelTariffRoomDetailsInfo();

           HotelTariffRooms = new List<HotelTariffRoomDetailsInfo>();

           HotelTariffRoomFilter = new HotelTariffRoomFilter();

           //for room Occupancy
           HotelTariffRoomOccupancy = new HotelTariffRoomOccupancyInfo();

           HotelTariffRoomOccupancies = new List<HotelTariffRoomOccupancyInfo>();

           HotelTariffRoomOccupancyFilter = new HotelTariffRoomOccupancyFilter();

         //For tax formula

           LstStandardCharges = new List<ChargesInfo>();

           LstTaxFormula = new List<TaxFormulaInfo>();

           LstTaxFormulaCharges = new List<TaxFormulaChargesInfo>();
         //for Customer Category

           HotelTariffCustomerCategory = new HotelTariffCustomerCategoryDetailsInfo();

           HotelTariffCustomerCategories = new List<HotelTariffCustomerCategoryDetailsInfo>();

           CustomerCategory = new CustomerCategoryInfo();

           CustomerCategories = new List<CustomerCategoryInfo>();

           HotelTariffCustomerCategoryFilter = new HotelTariffCustomerCategoryFilter();

            
        }


        public HotelTariffInfo HotelTariff { get; set; }

        public List<HotelTariffInfo> HotelTariffs { get; set; }

        public HotelTariffFilter Filter { get; set; }

        public List<VendorInfo> Vendors { get; set; }

        public List<HotelInfo> Hotels { get; set; }

        public List<RoomTypeInfo> RoomTypes { get; set; }

        public List<MealInfo> Meals { get; set; }

        public List<OccupancyInfo> Occupancies { get; set; }

        public PaginationInfo Pager { get; set; }

        public List<FriendlyMessage> FriendlyMessage { get; set; }


        public HotelTariffDateDetailsInfo HotelTariffDate { get; set; }

        public List<HotelTariffDateDetailsInfo> HotelTariffDates { get; set; }


        public HotelTariffDurationDetailsInfo HotelTariffDuration { get; set; }

        public List<HotelTariffDurationDetailsInfo> HotelTariffDurations { get; set; }

        public HotelTariffDurationFilter HotelTariffDurationFilter { get; set; }


        public HotelTariffPriceDetailsInfo HotelTariffPrice { get; set; }

        public List<HotelTariffPriceDetailsInfo> HotelTariffPrices { get; set; }

        public HotelTariffPriceFilter HotelTariffPriceFilter { get; set; }



        public HotelTariffRoomDetailsInfo HotelTariffRoom { get; set; }

        public List<HotelTariffRoomDetailsInfo> HotelTariffRooms { get; set; }

        public HotelTariffRoomFilter HotelTariffRoomFilter { get; set; }

        public HotelTariffRoomOccupancyInfo HotelTariffRoomOccupancy { get; set; }

        public List<HotelTariffRoomOccupancyInfo> HotelTariffRoomOccupancies { get; set; }

        public HotelTariffRoomOccupancyFilter HotelTariffRoomOccupancyFilter { get; set; }

        //For tax formula

        public List<ChargesInfo> LstStandardCharges { get; set; }

        public List<TaxFormulaInfo> LstTaxFormula { get; set; }

        public List<TaxFormulaChargesInfo> LstTaxFormulaCharges { get; set; } 
     
        //for customer category

        public CustomerCategoryInfo CustomerCategory { get; set; }

        public List<CustomerCategoryInfo> CustomerCategories { get; set; }

        public HotelTariffCustomerCategoryDetailsInfo HotelTariffCustomerCategory { get; set; }

        public List<HotelTariffCustomerCategoryDetailsInfo> HotelTariffCustomerCategories { get; set; }

        public HotelTariffCustomerCategoryFilter HotelTariffCustomerCategoryFilter { get; set; }


    }

    public class HotelTariffFilter
    {
        public int SightSeeingTariffId { get; set; }
    }

    public class HotelTariffDurationFilter
    {
        public int HotelTariffDurationDetailsId { get; set; }
    }

    public class HotelTariffPriceFilter
    {
        public int HotelTariffPriceDetailsId { get; set; }
    }

    public class HotelTariffRoomFilter
    {
        public int HotelTariffRoomDetailsId { get; set; }
    }

    public class HotelTariffRoomOccupancyFilter
    {
        public int HotelTariffRoomOccupancyId { get; set; }
    }

    public class HotelTariffCustomerCategoryFilter
    {
        public int HotelTariffCustomerCategoryId { get; set; }
    }
    }
