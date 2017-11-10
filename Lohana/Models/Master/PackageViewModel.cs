using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using LohanaBusinessEntities;
using LohanaBusinessEntities.Package;
using LohanaBusinessEntities.City;
using LohanaBusinessEntities.State;
using LohanaBusinessEntities.Country;
using LohanaBusinessEntities.Common;
using LohanaBusinessEntities.PackageType;
using LohanaBusinessEntities.Hotel;
using LohanaBusinessEntities.Meal;
using LohanaBusinessEntities.Accessories;
using LohanaBusinessEntities.Enquiry;

namespace Lohana.Models.Master
{
    public class PackageViewModel
    {

        public PackageViewModel()
        {

            FriendlyMessage = new List<FriendlyMessage>();

            Pager = new PaginationInfo();

            Package = new PackageInfo();

            PackageFilter = new PackageFilter();

            Packages = new List<PackageInfo>();

            PackageItinerary = new PackageItineraryInfo();

            PackageItineraries = new List<PackageItineraryInfo>();

            PackageDate = new PackageDatesInfo();

            PackageDates = new List<PackageDatesInfo>();

            PackageTypes = new List<PackageTypeInfo>();

            City = new CityInfo();

            Cities = new List<CityInfo>();

            Location = new CityInfo();

            Locations = new List<CityInfo>();

            Hotel = new HotelInfo();

            Hotels = new List<HotelInfo>();

            Meal = new MealInfo();

            Meals = new List<MealInfo>();

            Images = new List<AccessoriesInfo>();

            PackageSearchList = new List<PackageInfo>();

            Enquiry = new EnquiryInfo();

            EnquiryGitDetails = new List<EnquiryInfo>();

            DayItemTriff = new List<PackageDaysTriffInfo>();

            packagedaytriff = new PackageDaysTriffInfo();

         packageDayItems = new PackageDayitemTriffinfo();

         Packageduration = new PackageDuration();

         PackageDurationNetrate = new List<PackageDuration>();

         PackageCustomerCategory = new List<PackageCustomerCategoryInfo>();

         PriceList = new List<PackageDuration>();
           
        }


        public List<FriendlyMessage> FriendlyMessage { get; set; }

        public PaginationInfo Pager { get; set; }

        public PackageInfo Package { get; set; }

        public PackageFilter PackageFilter { get; set; }

        public List<PackageInfo> Packages { get; set; }

        public PackageItineraryInfo PackageItinerary { get; set; }

        public List<PackageItineraryInfo> PackageItineraries { get; set; }

        public PackageDatesInfo PackageDate { get; set; }

        public List<PackageDatesInfo> PackageDates { get; set; }

        public EnquiryInfo Enquiry { get; set; }

        //Dropdowm

        public List<PackageTypeInfo> PackageTypes { get; set; }

        public CityInfo City { get; set; }

        public List<CityInfo> Cities { get; set; }

        public CityInfo Location { get; set; }

        public List<CityInfo> Locations { get; set; }

        public HotelInfo Hotel { get; set; }

        public List<HotelInfo> Hotels { get; set; }

        public MealInfo Meal { get; set; }

        public List<MealInfo> Meals { get; set; }

        public List<AccessoriesInfo> Images { get; set; }

        public List<PackageInfo> PackageSearchList { get; set; }

        public List<EnquiryInfo> EnquiryGitDetails { get; set; }

        public PackageDaysTriffInfo packagedaytriff { get; set; }

        public List<PackageDaysTriffInfo> DayItemTriff { get; set; }

        public bool Flags { get; set; }

        public bool AddtoCart { get; set; }

        public PackageDayitemTriffinfo packageDayItems { get; set; }

        public PackageDuration Packageduration { get; set; }

        public List<PackageDuration> PackageDurationNetrate { get; set; }

        public List<PackageCustomerCategoryInfo> PackageCustomerCategory { get; set; }

        public List<PackageDuration> PriceList { get; set; }
        

        
    }

    public class PackageFilter
    {
        public int PackageId { get; set; }
    }

}