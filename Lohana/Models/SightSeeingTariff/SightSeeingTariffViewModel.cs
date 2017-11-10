using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.Package;
using LohanaBusinessEntities.SightSeeing;
using LohanaBusinessEntities.SightSeeingTariff;
using LohanaBusinessEntities.Vendor;
using LohanaBusinessEntities.Meal;
using LohanaBusinessEntities.Occupancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LohanaBusinessEntities.TaxFormula;
using LohanaBusinessEntities.Charges;
using System.Data;
using LohanaBusinessEntities.CustomerCategory;


namespace Lohana.Models.SightSeeingTariff
{
    public class SightSeeingTariffViewModel
    {

        public SightSeeingTariffViewModel()
        {
            //For Sight Seeing Tariff

            SightSeeingTariff = new SightSeeingTariffInfo();

            SightSeeingTariffs = new List<SightSeeingTariffInfo>();

            Filter = new SightSeeingTariffFilter();


            Vendors = new List<VendorInfo>();

            SightSeeings = new List<SightSeeingInfo>();

            Meals = new List<MealInfo>();

            Occupancies = new List<OccupancyInfo>();

            Pager = new PaginationInfo();

            FriendlyMessage = new List<FriendlyMessage>();

            //for date details

            SightSeeingTariffDate = new SightSeeingTariffDateInfo();

            SightSeeingTariffDates = new List<SightSeeingTariffDateInfo>();

            //For Duration

            Durations = new List<DurationInfo>();

            Duration = new DurationInfo();         

            DurationFilter = new DurationFilter();

            //for sight seeing duration

            SightSeeingTariffDuration = new SightSeeingTariffDurationInfo();

            SightSeeingTariffDurations = new List<SightSeeingTariffDurationInfo>();

            SightSeeingTariffDurationFilter = new SightSeeingTariffDurationFilter();

            //For Sight Seeing Tariff Occupancy

            SightSeeingTariffOccupancy = new SightSeeingTariffOccupancyInfo();

            SightSeeingTariffOccupancies = new List<SightSeeingTariffOccupancyInfo>();

            SightSeeingTariffOccupancyFilter = new SightSeeingTariffOccupancyFilter();

            //For tax formula

            LstStandardCharges = new List<ChargesInfo>();

            LstTaxFormula = new List<TaxFormulaInfo>();

            LstTaxFormulaCharges = new List<TaxFormulaChargesInfo>();

            //For Sight Seeing Details

            SightSeeingDetails = new List<SightSeeingDetailInfo>();

            SightSeeingDetail = new SightSeeingDetailInfo();

            SightSeeingDetailFilter = new SightSeeingDetailFilter();

            //For Sight Seeing Tariff Price

            SightSeeingTariffPrice = new SightSeeingTariffPriceInfo();

            SightSeeingTariffPrices = new List<SightSeeingTariffPriceInfo>();

            SightSeeingTariffPriceFilter = new SightSeeingTariffPriceFilter();

            //For Sight Seeing Tariff Duration

            SightSeeingTariffDuration = new SightSeeingTariffDurationInfo();

            SightSeeingTariffDurations = new List<SightSeeingTariffDurationInfo>();

            SightSeeingTariffDurationFilter = new SightSeeingTariffDurationFilter();

            //for Customer Category

            SightSeeingTariffCustomerCategory = new SightSeeingTariffCustomerCategoryInfo();

            SightSeeingTariffCustomerCategories = new List<SightSeeingTariffCustomerCategoryInfo>();

            CustomerCategory = new CustomerCategoryInfo();

            CustomerCategories = new List<CustomerCategoryInfo>();

            SightSeeingTariffCustomerCategoryFilter = new SightSeeingTariffCustomerCategoryFilter();
     
        }

        //For Sight Seeing Tariff

        public SightSeeingTariffInfo SightSeeingTariff { get; set; }

        public List<SightSeeingTariffInfo> SightSeeingTariffs { get; set; }

        public SightSeeingTariffFilter Filter { get; set; }


        public List<VendorInfo> Vendors { get; set; }

        public List<MealInfo> Meals { get; set; }

        public List<OccupancyInfo> Occupancies { get; set; }

        public List<SightSeeingInfo> SightSeeings { get; set; }

        public SightSeeingInfo SightSeeing { get; set; }

        public PaginationInfo Pager { get; set; }

        public List<FriendlyMessage> FriendlyMessage { get; set; }

        //for date details

        public SightSeeingTariffDateInfo SightSeeingTariffDate { get; set; }

        public List<SightSeeingTariffDateInfo> SightSeeingTariffDates { get; set; }

        //For Duration

        public List<DurationInfo> Durations { get; set; }

        public DurationInfo Duration { get; set; }

        public DurationFilter DurationFilter { get; set; }

        //For Sight Seeing Details

        public List<SightSeeingDetailInfo> SightSeeingDetails { get; set; }

        public SightSeeingDetailInfo SightSeeingDetail { get; set; }

        public SightSeeingDetailFilter SightSeeingDetailFilter { get; set; }

        //For Sight Seeing Tariff Occupancy

        public SightSeeingTariffOccupancyInfo SightSeeingTariffOccupancy { get; set; }

        public List<SightSeeingTariffOccupancyInfo> SightSeeingTariffOccupancies { get; set; }

        public SightSeeingTariffOccupancyFilter SightSeeingTariffOccupancyFilter { get; set; }

        //For tax formula

        public List<ChargesInfo> LstStandardCharges { get; set; }

        public List<TaxFormulaInfo> LstTaxFormula { get; set; }

        public List<TaxFormulaChargesInfo> LstTaxFormulaCharges { get; set; }

        //For Sight Seeing Tariff Price

        public SightSeeingTariffPriceInfo SightSeeingTariffPrice { get; set; }

        public List<SightSeeingTariffPriceInfo> SightSeeingTariffPrices { get; set; }

        public SightSeeingTariffPriceFilter SightSeeingTariffPriceFilter { get; set; }

        //For Sight Seeing Tariff Duration

        public SightSeeingTariffDurationInfo SightSeeingTariffDuration { get; set; }

        public List<SightSeeingTariffDurationInfo> SightSeeingTariffDurations { get; set; }

        public SightSeeingTariffDurationFilter SightSeeingTariffDurationFilter { get; set; }

        //for customer category

        public CustomerCategoryInfo CustomerCategory { get; set; }

        public List<CustomerCategoryInfo> CustomerCategories { get; set; }

        public SightSeeingTariffCustomerCategoryInfo SightSeeingTariffCustomerCategory { get; set; }

        public List<SightSeeingTariffCustomerCategoryInfo> SightSeeingTariffCustomerCategories { get; set; }

        public SightSeeingTariffCustomerCategoryFilter SightSeeingTariffCustomerCategoryFilter { get; set; }
    }

    public class SightSeeingTariffFilter
    {
        public int SightSeeingTariffId { get; set; }
    }

    public class DurationFilter
    {
        public int DurationId { get; set; }
    }
    public class SightSeeingDetailFilter
    {
        public int SightSeeingDetailsId { get; set; }
    }

    public class SightSeeingTariffOccupancyFilter
    {
        public int SightSeeingTariffOccupancyId { get; set; }
    }

    public class SightSeeingTariffPriceFilter
    {
        public int SightSeeingTariffPriceId { get; set; }
    }

    public class SightSeeingTariffDurationFilter
    {
        public int SightSeeingTariffDurationId { get; set; }
    }

    public class SightSeeingTariffCustomerCategoryFilter
    {
        public int SightSeeingTariffCustomerCategoryId { get; set; }
    }
}